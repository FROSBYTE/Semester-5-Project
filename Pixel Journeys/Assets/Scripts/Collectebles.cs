using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectebles : MonoBehaviour
{
    [SerializeField] bool isGem;
    [SerializeField] bool isHealth;

    [SerializeField] GameObject pickupEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isGem)
            {
                LevelManager.instance.gemsCollected++;
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIManager.Instance.gemUpdate();
                
            }
        }

        if (other.CompareTag("Player"))
        {
            if (isHealth)
            {
                HealthSystem.instance.addHealth();
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
        }
    }
}
