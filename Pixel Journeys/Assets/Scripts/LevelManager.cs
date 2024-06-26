using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] float reloadDelay;
    public int gemsCollected;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
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
        UIManager.Instance.unfadeScrren();
        PlayerMovement.instance.transform.position = CheckpointManager.instance.spawnPoint;
        HealthSystem.instance.currentHealth = HealthSystem.instance.respawnHealth;
        UIManager.Instance.heartcountDisplay();
    }
}
