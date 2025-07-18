using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem instance;    

    [SerializeField] int damgeAmount; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D colllider)
    {
        if(colllider.tag == "Player")
        {
            HealthSystem.instance.dealDamage();
        }
        
    }
}
