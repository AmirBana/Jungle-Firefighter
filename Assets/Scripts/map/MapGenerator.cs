using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private float speed;
    public int cameraSize;
    public int xGrid, zGrid;
    bool isOdd;
    public int size;
    public GameObject[] baseCubes;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.instance.environmentSpeed;
        xGrid = xGrid*size;
        zGrid = zGrid * size;
        isOdd = xGrid%2==0 ? false : true;
        Generator();
    }
    private void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
    void Generator()
    {
       
        int startCube = 0;
        Vector3 sPos;
        for(int z = 0;z < zGrid;z += size)
        {
            for(int x = 0;x < xGrid;x += size)
            {
                sPos = new Vector3(transform.position.x+x,transform.position.y,transform.position.z+z);
                GameObject cell=Instantiate(baseCubes[startCube], sPos, transform.rotation, transform);
                startCube = startCube == 1 ? 0 : 1;
            }
            if(!isOdd)
                startCube = startCube == 1 ? 0 : 1;
        }
    }
}
