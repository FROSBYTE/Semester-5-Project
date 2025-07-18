using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Checkpoint instance;

    [SerializeField] SpriteRenderer checpointSprite;
    [SerializeField] Sprite checkOn;
    [SerializeField] Sprite checkOff;
    private bool Ischeckpoint;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !Ischeckpoint)
        {
            checpointSprite.sprite = checkOn;
            Ischeckpoint= true;
            CheckpointManager.instance.spawnPoint = transform.position;
            AudioManager.instance.audioSystem(12);
        }
    }
    public void resetCheckpoint()
    {
        checpointSprite.sprite = checkOff;
    }
}
