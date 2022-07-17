using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    public static Action planeAbility;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward* speed *Time.deltaTime);
        if(planeAbility != null)
        {
            planeAbility();
        }
    }
}
