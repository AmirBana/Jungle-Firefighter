using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProblemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] problem;
    [SerializeField] float minTime, maxTime;
    private float cameraSize;
    // Start is called before the first frame update
    void Start()
    {
        cameraSize = Camera.main.orthographicSize / 2 - 3;
        StartCoroutine("SpawnProblem");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnProblem()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Vector3 spawnPos = new Vector3(Random.Range(-cameraSize, cameraSize), transform.position.y, transform.position.z);
            Instantiate(problem[Random.Range(0, problem.Length)], spawnPos, Quaternion.identity, transform);
        }
    }
}
