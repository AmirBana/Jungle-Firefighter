using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float cameraSize;
    [SerializeField] float forwardSpeed = 1f;
    void Start()
    {
        cameraSize = Camera.main.orthographicSize/2 - 3;
        print(cameraSize);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))//todo add mobile swipe
        {
            if(transform.position.x > cameraSize*-1)
            {
                transform.Translate(Vector3.left);
            }
        }
        if (Input.GetKey(KeyCode.D))//todo add mobile swipe
        {
            if(transform.position.x < cameraSize)
            {
                transform.Translate(Vector3.right);
            }
        }
    }
}
