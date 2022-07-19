using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZoneManager : MonoBehaviour
{
    [SerializeField] GameObject cube;
    float size = 2f;
    float xBase ;
    float zBase ;
    float xMinBound, xMaxBound;
    int hHeight, vHeight;
    // Start is called before the first frame update
    void Start()
    {
        size = cube.transform.localScale.x;
        xBase = transform.position.x;
        zBase = transform.position.z;
        xMinBound = -19+size;
        xMaxBound = 11-size;
        print(xBase+' '+ zBase);
        print(size);
        int zLines=Random.Range(5, 15);
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
        int fire = -1;
        List<GameObject> line = new List<GameObject>();
        for (float z=zBase;z<zBase+(zLines* size); z+= size)
        {
            for (float x = xBase; x < xBase + (xLines * size); x += size)
            {
                Vector3 spawnPos = new Vector3(x, transform.position.y, z);
                GameObject sCube=Instantiate(cube, spawnPos, cube.transform.rotation, transform);
                line.Add(sCube);
            }
            if (fire == -1)
            {
                fire = Random.Range(0, line.Count);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (fire == 0)
            {
                fire = Random.Range(0, fire + 1);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if (fire == line.Count)
            {
                fire=Random.Range(fire - 1, fire);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                fire = Random.Range(fire - 1, fire + 2);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
            }
            line.Clear();
        }
    }
}
