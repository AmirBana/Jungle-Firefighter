using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapGenerator : MonoBehaviour
{
    private float speed;
    public int cameraSize;
    public int xGrid, zGrid;
    bool isOdd;
    public int size;
    public GameObject[] baseCubes;
    float zPos;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameManager.instance.environmentSpeed;
        zPos = transform.position.z;
        xGrid = xGrid*size;
        zGrid = zGrid * size;
        isOdd = xGrid%2==0 ? false : true;
        CubeScale();
        Generator();
    }
    private void CubeScale()
    {
        baseCubes[0].transform.localScale = new Vector3(xGrid+30, 1, 10);
        baseCubes[1].transform.localScale = new Vector3(xGrid+30, 1, 10);
    }
    private void Update()
    {
        if (GameManager.instance.gameStart == true && GameManager.instance.gameOver == false)
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
    }
    /*void Generator()
    {
       
        int startCube = 0;
        Vector3 sPos;
        for(int z = -10;z < zGrid+30;z += size)
        {
            for(int x = -10;x < xGrid+10;x += size)
            {
                sPos = new Vector3(transform.position.x+x,transform.position.y,transform.position.z+z);
                Instantiate(baseCubes[startCube], sPos, transform.rotation, transform);
                startCube = startCube == 1 ? 0 : 1;
            }
            if(!isOdd)
                startCube = startCube == 1 ? 0 : 1;
        }
    }*/
    void Generator()
    {
        int startCube = 0;
        Vector3 sPos;
        int x =-10;
        for (int z = -50; z < zGrid + 30; z += 10)
        {
                sPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + z);
                Instantiate(baseCubes[startCube], sPos, transform.rotation, transform);
                startCube = startCube == 1 ? 0 : 1;
        }
    }
    public void OnReset()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
    }
}
