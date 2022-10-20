using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static HealthSystem instance;
    public int currentHealth, maxHealth;

    [SerializeField] int invincibleDelay;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameObject deathEffect;

    private float invincibilityCounter;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCounter > 0)
        {
           invincibilityCounter -= Time.deltaTime;
           
        }
    }
    public void dealDamage()
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Instantiate(deathEffect,transform.position,transform.rotation);
                gameObject.SetActive(false);
                LevelManager.instance.RespawnPlayer();
            }

            else
            {
                invincibilityCounter = invincibleDelay;
                PlayerMovement.instance.knockback();
            }
            
            UIManager.Instance.heartcountDisplay();
        }
    }
    public void addHealth()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

       
    }
}
//if(invincibilityCounter <= 0)
//{
//   sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
//} 
//sr.color = new Color(sr.color.r, sr.color.g, sr.color.b,0.5f);
