using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneGenerator : MonoBehaviour
{
    [SerializeField] GameObject zone;
    private float cameraSize;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        size = 4;
        cameraSize = Camera.main.orthographicSize / 2 - (3 + size);
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
            yield return new WaitForSeconds(Random.Range(3,7));
            Vector3 spawnPos = new Vector3(Random.Range(-cameraSize, cameraSize), transform.position.y, transform.position.z);
            Instantiate(zone, spawnPos, Quaternion.identity, transform);
        }
    }
}
