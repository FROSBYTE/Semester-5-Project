using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    public Vector3 spawnPoint;

    [SerializeField] Checkpoint[] checkpoints;
    
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerMovement.instance.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void deactivateCheckpoint()
    {
        for(int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].resetCheckpoint();
        }
    }
}
