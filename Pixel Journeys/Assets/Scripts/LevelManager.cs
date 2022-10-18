using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] float reloadDelay;
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
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }
    private IEnumerator RespawnPlayerCo()
    {
        PlayerMovement.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(reloadDelay);
        PlayerMovement.instance.gameObject.SetActive(true);
        PlayerMovement.instance.transform.position = CheckpointManager.instance.spawnPoint;
        HealthSystem.instance.currentHealth = HealthSystem.instance.maxHealth;
        UIManager.Instance.heartcountDisplay();
    }
}
