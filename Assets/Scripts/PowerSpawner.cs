using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] ability;
    [SerializeField] float minTime,maxTime;
    private float cameraSize;
    // Start is called before the first frame update
    void Start()
    {
        cameraSize = Camera.main.orthographicSize / 2 - 3;
        StartCoroutine("SpawnAbility");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnAbility()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minTime,maxTime));
            Vector3 spawnPos = new Vector3(Random.Range(-cameraSize, cameraSize), transform.position.y, transform.position.z);
            int index = Random.Range(0, ability.Length);
            Instantiate(ability[index], spawnPos, ability[index].transform.rotation,transform);
        }
    }
}
