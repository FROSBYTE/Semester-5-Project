using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivator : MonoBehaviour
{
    [SerializeField] GameObject horizontalPlatform;
    // Start is called before the first frame update
    void Start()
    {
        horizontalPlatform.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            horizontalPlatform.SetActive(true);
        }
    }
}
