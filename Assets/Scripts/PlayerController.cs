using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float sizeMove;
    private float cameraSize;
    [SerializeField] float forwardSpeed = 1f;
    void Start()
    {
        cameraSize = Camera.main.orthographicSize;
        sizeMove = cameraSize / 3;
    }
    void Update()
    {
        transform.Translate(Vector3.up*forwardSpeed);
        if (Input.GetKey(KeyCode.A) )//todo add mobile swipe
        {
            transform.Rotate(0, 0,1f);
        }
        if (Input.GetKey(KeyCode.D))//todo add mobile swipe
        {
            transform.Rotate(0,0, -1f);
            //transform.Translate(Vector3.right);
        }
    }
}
