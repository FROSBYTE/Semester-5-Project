using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    [SerializeField] float bounceForce;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim  = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement.instance.rb.velocity = new Vector2(PlayerMovement.instance.rb.velocity.x, bounceForce);
        AudioManager.instance.audioSystem(13);
        anim.SetTrigger("isBounce");
    }
}
