using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float cameraSize;
    [SerializeField] float forwardSpeed = 1f;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.up*forwardSpeed);
        if (Input.GetKey(KeyCode.A) )//todo add mobile swipe
        {
            transform.
            transform.Rotate(0, -1f, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.D))//todo add mobile swipe
        {
            transform.Rotate(0, 1f, 0, Space.World);
            //transform.Translate(Vector3.right);
        }
    }
}
