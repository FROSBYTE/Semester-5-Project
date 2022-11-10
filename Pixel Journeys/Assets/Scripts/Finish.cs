using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject gamewinPanel;
    [SerializeField] Transform player;
    [SerializeField] float autoSpeed;

    private bool AutoBool;

    void Start()
    {
        gamewinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(AutoBool && player!=null)
        {
            autoMove();
        }
    }

    public void endPoint()
    {
        StartCoroutine(endPointCo());
    }

    private IEnumerator endPointCo()
    {
        yield return new WaitForSeconds(2f);
        gamewinPanel.SetActive(true);
        PlayerMovement.instance.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AutoBool = true;
            CameraControl.instance.enabled = false;
            PlayerMovement.instance.enabled = false;
            endPoint();
        }
    }

    public void autoMove()
    {
        player.Translate(Vector3.right * Time.deltaTime * autoSpeed);
    }
}
