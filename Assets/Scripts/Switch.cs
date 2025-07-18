using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject switchObject;
    [SerializeField] Sprite turnOnSwitch;
    [SerializeField] SpriteRenderer sr;

    private bool isSwitchOn;
    // Start is called before the first frame update
    void Start()
    {
        switchObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isSwitchOn)
        {
            AudioManager.instance.audioSystem(18);
            switchObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            sr.sprite= turnOnSwitch;
            isSwitchOn = true;
        }
    }
}
