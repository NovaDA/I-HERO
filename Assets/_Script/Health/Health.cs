using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int startinghealth;
    public int healthperheart;
    public Image heartGui;
    public Transform parent;
    private ArrayList hearts = new ArrayList();
    public Image[] images; 
    public int maxHeartsPerRow;
    private float spaceX;
    private float spaceY;
    private int currentHealth;
    private int maxHealth;

    private void Awake()
    {
        currentHealth = startinghealth;
        spaceX = 1;
        spaceY = 1;
        AddHearts(startinghealth / healthperheart);
    }
   
	public void AddHearts(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Transform newHeart = Instantiate(heartGui, parent.position, Quaternion.identity, parent).transform;
            int y = Mathf.FloorToInt(hearts.Count / maxHeartsPerRow);
            int x = hearts.Count - y * maxHeartsPerRow;
            newHeart.transform.position = new Vector3(parent.position.x + 
                (spaceX * 1 * -x), parent.position.y + (spaceY * 1 * y), parent.position.z);
            hearts.Add(newHeart); 
        }
        maxHealth += n * healthperheart;
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void Modifyhealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    void UpdateHearts()
    {
        bool restAreEmpty = false;
        int i = 0;
        foreach (Transform heart in hearts)
        {
            if(restAreEmpty)
            {
                heart.GetComponent<Image>().sprite = images[0].sprite;
            }
            else
            {
               i += 1;
               if (currentHealth >= i * healthperheart)
               {
                    heart.GetComponent<Image>().sprite = images[4].sprite;
               }
               else
               {
                    int currentHealthHeart = (int)(healthperheart - (healthperheart * i - currentHealth));
                    int healthPerImage = healthperheart / images.Length;
                    int imageIndex = currentHealthHeart / healthPerImage;

                    if(imageIndex == 0 && currentHealthHeart > 0)
                    {
                        imageIndex = 1;
                        
                    }
                    heart.GetComponent<Image>().sprite = images[imageIndex].sprite;
                    restAreEmpty = true;
                }
            }
        }
    } 
}
