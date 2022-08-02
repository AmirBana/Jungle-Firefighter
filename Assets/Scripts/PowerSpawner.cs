using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] ability;
    [SerializeField] float minTime,maxTime;
    public float xMin, xMax;
    // Start is called before the first frame update
    void Start()
    {
        xMin = GameManager.instance.xMin;
        xMax = GameManager.instance.xMax;
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
            if(GameManager.instance.gameStart && !GameManager.instance.gameOver)
            {
                Vector3 spawnPos = new Vector3(Random.Range(xMin, xMax), transform.position.y, transform.position.z);
                int index = Random.Range(0, ability.Length);
                Instantiate(ability[index], spawnPos, ability[index].transform.rotation, transform);
            }
        }
    }
}
