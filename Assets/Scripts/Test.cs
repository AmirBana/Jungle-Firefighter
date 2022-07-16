using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    private float sizeMove;
    private float cameraSize;
    //private Rigidbody rb;
    void Start()
    {
        cameraSize = Camera.main.orthographicSize;
        sizeMove = cameraSize/3;
       // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(transform.position.x > (sizeMove*-1))
            {
                Vector3 newPos = new Vector3(transform.position.x-sizeMove, transform.position.y, transform.position.z);
                transform.position = newPos;
                // rb.velocity = Vector3.left;
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x < sizeMove)
            {
                Vector3 newPos = new Vector3(transform.position.x + sizeMove, transform.position.y, transform.position.z);
                transform.position = newPos;
               // rb.velocity = Vector3.right;
            }
        }
    }
}
