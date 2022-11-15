using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompPoint : MonoBehaviour
{
    [SerializeField] GameObject deathEfeect;
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
        if (other.tag == "Enemy")
        {
            Destroy(other.transform.parent.gameObject);
            Instantiate(deathEfeect, other.transform.position, other.transform.rotation);
            PlayerMovement.instance.bounce();
        }        
    }
}
