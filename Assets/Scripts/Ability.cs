using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float fallSpeed = 10f;
    public bool planeAbility=false;
    private string problemTag;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.CompareTag("Water"))
            problemTag = "Fire";
        else if (transform.CompareTag("Ladder"))
            problemTag = "Human";
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward* moveSpeed *Time.deltaTime);
        if(planeAbility)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(problemTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
