using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    // Start is called before the first frame update
    public float z_min=5.9f,z_max=42.6f;
    float speed = 10f;
    void Start()
    {
        speed = GameManager.environmentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <= z_min)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,z_max);
        }
        else
        {
            transform.Translate((-Vector3.forward) *speed* Time.deltaTime);
        }
    }
}
