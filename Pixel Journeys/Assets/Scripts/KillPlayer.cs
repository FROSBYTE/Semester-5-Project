using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            LevelManager.instance.RespawnPlayer();
            UIManager.Instance.fadeScreen();
            //UIManager.Instance.unfadeScrren();
        }
    }
}
