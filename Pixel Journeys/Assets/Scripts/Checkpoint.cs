using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint instance;

    [SerializeField] SpriteRenderer checpointSprite;
    [SerializeField] Sprite checkOn;
    [SerializeField] Sprite checkOff;

    private void Awake()
    {
        instance = this;
    }
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
        if(other.CompareTag("Player"))
        {
            CheckpointManager.instance.deactivateCheckpoint();
            checpointSprite.sprite = checkOn;
            CheckpointManager.instance.spawnPoint = transform.position;
        }
    }
    public void resetCheckpoint()
    {
        checpointSprite.sprite = checkOff;
    }
}
