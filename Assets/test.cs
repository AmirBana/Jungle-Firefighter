using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 2000f);
        transform.eulerAngles = Vector3.zero;
    }
}
