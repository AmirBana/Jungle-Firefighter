using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float sizeMove;
    private float cameraSize;
    void Start()
    {
        cameraSize = Camera.main.orthographicSize;
        sizeMove = cameraSize / 3;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x > (sizeMove * -1))
            {
                Vector3 newPos = new Vector3(transform.position.x - sizeMove, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x < sizeMove)
            {
                Vector3 newPos = new Vector3(transform.position.x + sizeMove, transform.position.y, transform.position.z);
                transform.position = newPos;
            }
        }
    }
}
