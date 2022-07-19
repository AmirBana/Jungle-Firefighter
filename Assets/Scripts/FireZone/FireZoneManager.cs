using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZoneManager : MonoBehaviour
{
    [SerializeField] GameObject cube;
    int size = 2;
    int xBase = 0;
    int zBase = 0;
    int hHeight, vHeight;
    // Start is called before the first frame update
    void Start()
    {
        size = (int)cube.transform.localScale.x;
        print(size);
        int zLines=Random.Range(3, 7);
        int xLines = Random.Range(2, 5);
        print(xLines);
        print(zLines);
        Spawner(zLines,xLines);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawner(int zLines,int xLines)
    {
        for(int z=zBase;z<zLines* size; z+= size)
        {
            for(int x=xBase;x<xLines* size; x+= size)
            {
                Vector3 spawnPos = new Vector3(x,transform.position.y,z);
                Instantiate(cube,spawnPos,cube.transform.rotation,transform);
            }
        }
    }
}
