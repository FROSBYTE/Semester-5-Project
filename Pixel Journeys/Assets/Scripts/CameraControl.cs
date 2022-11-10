using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl instance;

    [SerializeField] Transform playerTransform;
    [SerializeField] Transform farBackground;
    [SerializeField] Transform middleBackground;
    [SerializeField] Vector2 cameraOffset;
    [SerializeField] float followSpeed;

    public float minHeight, maxHeight;

    private Vector2 lastPos;

   
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CamProperties();
    }
    private void Awake()
    {
        instance = this;
        cameraOffset = playerTransform.position - transform.position;
    }

    private void CamProperties()
    {
        CamMovement();
        Parallax();
    }

    private void Parallax()
    {
        Vector2 move_amount = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        farBackground.position = farBackground.position + new Vector3(move_amount.x, move_amount.y, 0f);
        middleBackground.position = middleBackground.position + new Vector3(move_amount.x, move_amount.y, 0f) * 0.8f;
        lastPos = transform.position;
    }

    private void CamMovement()
    {
        float offsetplayerpos = playerTransform.position.y - cameraOffset.y;
        float clampY = Mathf.Clamp(offsetplayerpos, minHeight, maxHeight);
        Vector3 targetpos = new Vector3(playerTransform.position.x - cameraOffset.x, clampY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetpos, followSpeed * Time.deltaTime);
    }
}
