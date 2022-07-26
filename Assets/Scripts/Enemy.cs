using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.instance.environmentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward*speed*Time.deltaTime,Space.World);
        if(transform.position.z < -70f) Destroy(gameObject);
    }
}
