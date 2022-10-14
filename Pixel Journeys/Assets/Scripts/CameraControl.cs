using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform farBackground;
    [SerializeField] Transform middleBackground;
    [SerializeField] Vector2 cameraOffset;
    [SerializeField] float followSpeed;

    private float xlastPos;
    public float minHeight, maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        xlastPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        CamProperties();
    }
    private void Awake()
    {
        cameraOffset = playerTransform.position - transform.position;
    }

    private void CamProperties()
    {
        float offsetplayerpos = playerTransform.position.y - cameraOffset.y;
        float clampY = Mathf.Clamp(offsetplayerpos, minHeight, maxHeight);
        Vector3 targetpos = new Vector3(playerTransform.position.x - cameraOffset.x, clampY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetpos, followSpeed);

        float x_move_amount = transform.position.x - xlastPos;
        farBackground.position = farBackground.position + new Vector3(x_move_amount, 0f, 0f);
        middleBackground.position = middleBackground.position + new Vector3(x_move_amount * 0.5f, 0f, 0f);
        xlastPos = transform.position.x;
 
    }
}
//transform.position = new Vector3(camTransform.position.x, transform.position.y, transform.position.z);
// a+(b-a)*t;