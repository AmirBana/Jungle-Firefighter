using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZoneManager : MonoBehaviour
{
    public GameObject cube;
    List<GameObject> line = new List<GameObject>();
    private float size = 2f;
    float xBase ;
    float zBase ;
    [SerializeField] int minZHeight=7,maxZHeight=15;
    [SerializeField] int minXHeight=2,maxXHeight=5;
    //float xMinBound, xMaxBound;
    // todo rework vars
    void Start()
    {
        size = cube.transform.localScale.x;
        xBase = transform.position.x;
        zBase = transform.position.z;
        //xMinBound = -19+size;
        //xMaxBound = 11-size;
        print(xBase+' '+ zBase);
        print(size);
        int zLines=Random.Range(minZHeight, maxZHeight);
        int xLines = Random.Range(minXHeight, maxXHeight);
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
        int fire = -1;
        for (float z=zBase;z<zBase+(zLines* size); z+= size)
        {
            for (float x = xBase; x < xBase + (xLines * size); x += size)
            {
                Vector3 spawnPos = new Vector3(x, transform.position.y, z);
                GameObject sCube=Instantiate(cube, spawnPos, cube.transform.rotation, transform);
                line.Add(sCube);
            }
            //todo change way of fire of cubes
            if (fire == -1)
            {
                fire = Random.Range(0, line.Count);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
                //line[fire].GetComponent<MeshRenderer>().enabled = true;
            }
            else if (fire == 0)
            {
                fire = Random.Range(0, fire + 2);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
                //line[fire].GetComponent<MeshRenderer>().enabled = true;
            }
            else if (fire == line.Count-1)
            {
                fire=Random.Range(fire - 1, fire+1);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
                //line[fire].GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                print("before fire" + fire);
                fire = Random.Range(fire - 1, fire + 2);
                print("lines:" + line.Count);
                print("fire:" + fire);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
                //line[fire].GetComponent<MeshRenderer>().enabled = true;
            }
            line.Clear();
            GameManager.instance.fireSpawned += 1;
        }
    }
}
