using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneGenerator : MonoBehaviour
{
    [SerializeField] GameObject zone;
    [SerializeField] GameObject zoneHolder;
    MapGenerator mapGenerator;
    int xGrid, zGrid;
    int cubeSize;
    int totalFreeSpace;
    int averangeFreeSpace;
    public int amount=5;
    public int starter = 10;
    public int maxDistance = 5;
    public int minZoneSizeX=3, maxZoneSizeX=5;
    //public int minZoneSizeZ=5, maxZoneSizeZ=15;
    public int zSize = 10;
    bool isEnded;
    private void Start()
    {
        isEnded = false;
        mapGenerator = gameObject.GetComponentInParent<MapGenerator>();
        xGrid = mapGenerator.xGrid;
        zGrid = mapGenerator.zGrid;
        cubeSize = mapGenerator.size;
        FreeSpaceCalc();
        for(int i= 0; i < amount; i++)
        {
            if(isEnded)
            {
                break;
            }
            GenerateZone(i);
        }
    }
    void FreeSpaceCalc()
    {
        int mapSize = zGrid - starter;
        int totalSpaceNeeded = zSize*amount;
        totalFreeSpace = mapSize - totalSpaceNeeded;
        averangeFreeSpace = totalFreeSpace / amount;
    }
    void GenerateZone(int left)
    {
        //print('a');
        int xSize = Random.Range(minZoneSizeX, maxZoneSizeX);
        //int zSize = Random.Range(minZoneSizeZ, maxZoneSizeZ);
        int xStart = Random.Range(0, xGrid - xSize);
         averangeFreeSpace = totalFreeSpace / (amount-left);
        print("averange Zone:"+averangeFreeSpace);
        int zStart = Random.Range(starter, starter+averangeFreeSpace+1);
        totalFreeSpace = totalFreeSpace - (zStart-starter);
        Vector3 holderPos = new Vector3(transform.position.x + xStart, transform.position.y, transform.position.z + zStart);
        GameObject holder = Instantiate(zoneHolder, holderPos, transform.rotation, transform);
        Vector3 sPos;
        for(int z = zStart; z < zStart+zSize; z++)
        {
            if (z >= zGrid)
            {
                isEnded = true;
                break;
            }
            //print('z');
            for (int x = xStart; x < xStart+xSize; x++)
            {
               // print('x');
                sPos = new Vector3(mapGenerator.transform.position.x + x
                    , mapGenerator.transform.position.y, mapGenerator.transform.position.z + z);
                Instantiate(zone, sPos, mapGenerator.transform.rotation, holder.transform);
            }
        }
        starter = zStart + zSize;
    }
}

/*private float cameraSize;
    [SerializeField] float minTime=3, maxTime=7;
    float size;
    void Start()
    {
        //todo rework vars
        size = zone.GetComponent<FireZoneManager>().cube.transform.localScale.x;
        print("size of zone:"+size);
        cameraSize = Camera.main.orthographicSize / 2 - (3 + size*2);
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
            yield return new WaitForSeconds(Random.Range(minTime,maxTime));
            Vector3 spawnPos = new Vector3(Random.Range(-cameraSize, cameraSize), transform.position.y, transform.position.z);
            Instantiate(zone, spawnPos, Quaternion.identity, transform);
        }
    }*/
