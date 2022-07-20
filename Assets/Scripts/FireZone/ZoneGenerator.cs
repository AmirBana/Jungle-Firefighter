using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneGenerator : MonoBehaviour
{
    [SerializeField] GameObject zone;
    private float cameraSize;
    [SerializeField] float minTime=3, maxTime=7;
    float size;
    void Start()
    {
        //todo rework vars
        size = 4;
        cameraSize = Camera.main.orthographicSize / 2 - (3 + size*2);
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minTime,maxTime));
            Vector3 spawnPos = new Vector3(Random.Range(-cameraSize, cameraSize), transform.position.y, transform.position.z);
            Instantiate(zone, spawnPos, Quaternion.identity, transform);
        }
    }
}
