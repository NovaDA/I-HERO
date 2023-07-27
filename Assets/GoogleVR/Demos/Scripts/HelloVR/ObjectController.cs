// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace GoogleVR.HelloVR {
    using System;
    using UnityEngine;
    using UnityEngine.EventSystems;

    [RequireComponent(typeof(Collider))]
  public class ObjectController : MonoBehaviour {

    private Vector3 startingPosition;
    private Renderer myRenderer;

        public float timeSpentGazingAt = 0.0f;
        public bool isGazing = false;
        public GameObject Bar;
        public bool isMoventTowards = false;
        public float speed = 10.0f;

        public GameObject player;
        bool playerAtLocation = false;
        Vector3 originalPos;
        Vector3 newPos;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;
       

    void Start() {

             Bar = GameObject.Find("ABANDONED BAR");
            startingPosition = transform.localPosition;
            player = GameObject.Find("Player");
      myRenderer = GetComponent<Renderer>();
     // SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt) {
      if (inactiveMaterial != null && gazedAtMaterial != null) {
        myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        return;
      }
    }

    public void Reset() {
      int sibIdx = transform.GetSiblingIndex();
      int numSibs = transform.parent.childCount;
      for (int i=0; i<numSibs; i++) {
        GameObject sib = transform.parent.GetChild(i).gameObject;
        sib.transform.localPosition = startingPosition;
        sib.SetActive(i == sibIdx);
      }
    }

    public void RotateObject()
    {
            GetComponent<Rigidbody>().AddTorque(Vector3.left);
            ///transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.1f);

    }

        public void IsGazing(bool gazing)
        {
            isGazing = gazing;
            if(!isGazing)
            {
                timeSpentGazingAt = 0.0f;
            }
        }

        private void Update()
        {
            if(isGazing)
            {
                timeSpentGazingAt += Time.deltaTime;
                Debug.Log(timeSpentGazingAt);
            }


            if(timeSpentGazingAt >= 2)
            {
                
                isGazing = false;
                isMoventTowards = true;
                Debug.Log("Moving");
                timeSpentGazingAt = 0.0f;
                originalPos = transform.position;
                //Debug.Log("Player Position Is:" + player.transform.position.x);
                // MoveTowardsObject();
            }

            if(isMoventTowards == true)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, originalPos, speed);
                playerAtLocation = false;
                
            }

            if(player.transform.position == transform.position || Vector3.Distance(player.transform.position, transform.position) < 1)
            {
                isMoventTowards = false;

            }
            
        }

       

        private void MoveTowardsObject()
        {
            isGazing = false;
            Debug.Log("Moving Towards Object");
        }

        public void Recenter() {
#if !UNITY_EDITOR
      GvrCardboardHelpers.Recenter();
#else
      if (GvrEditorEmulator.Instance != null) {
        GvrEditorEmulator.Instance.Recenter();
      }
#endif  // !UNITY_EDITOR
    }

    public void TeleportRandomly(BaseEventData eventData) {
      // Pick a random sibling, move them somewhere random, activate them,
      // deactivate ourself.
      int sibIdx = transform.GetSiblingIndex();
      int numSibs = transform.parent.childCount;
      sibIdx = (sibIdx + UnityEngine.Random.Range(1, numSibs)) % numSibs;
      GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

      // Move to random new location ±100º horzontal.
      Vector3 direction = Quaternion.Euler(
          0,
          UnityEngine.Random.Range(-90, 90),
          0) * Vector3.forward;
      // New location between 1.5m and 3.5m.
      float distance = 2 * UnityEngine.Random.value + 1.5f;
      Vector3 newPos = direction * distance;
      // Limit vertical position to be fully in the room.
      newPos.y = Mathf.Clamp(newPos.y, -1.2f, 4f);
      randomSib.transform.localPosition = newPos;

      randomSib.SetActive(true);
      gameObject.SetActive(false);
      SetGazedAt(false);
    }
  }
}
