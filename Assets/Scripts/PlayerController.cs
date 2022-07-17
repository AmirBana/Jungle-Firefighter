using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float cameraSize;
    [SerializeField] float speed=10f;
    void Start()
    {
        cameraSize = Camera.main.orthographicSize / 2 - 3;
        print(cameraSize);
    }
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.A))//todo add mobile swipe
        {
            if (transform.position.x > cameraSize * -1)
            {
                transform.Translate(Vector3.left*speed*Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.D))//todo add mobile swipe
        {
            if (transform.position.x < cameraSize)
            {
                transform.Translate(Vector3.right*speed* Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.W))//todo add mobile swipe
        {
            if (transform.position.z < 50f)
            {
                transform.Translate(Vector3.forward*speed* Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.S))//todo add mobile swipe
        {
            if (transform.position.z > 1f)
            {
                transform.Translate(-Vector3.forward*speed* Time.deltaTime, Space.World);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Water") || other.transform.CompareTag("Ladder"))
        {
            Debug.Log(other.transform.name);
            Destroy(other.gameObject);
        }
    }
}
