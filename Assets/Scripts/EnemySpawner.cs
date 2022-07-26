using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float minTime = 1f;
    [SerializeField] float maxTime = 3f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -70f) Destroy(gameObject);
    }
    IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Vector3 spawnPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            Instantiate(enemy, spawnPos, enemy.transform.rotation,transform);

        }
    }
}
