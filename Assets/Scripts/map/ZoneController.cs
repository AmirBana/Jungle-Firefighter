using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    List<GameObject> line = new List<GameObject>();
    int zoneHeight = 10;
    int zoneWidth;
    public int human;
    public Material mainColor;
    // Start is called before the first frame update
    void Start()
    {
        // human = transform.parent.GetComponent<ZoneGenerator>().humanInEevryZone;
        ZoneWidthCalc();
        FireLineGenerator();
        HumanGenerator();
    }
    void ZoneWidthCalc()
    {
        int cubes = transform.childCount;
        zoneWidth = cubes / zoneHeight;
        if(Input.GetKey(KeyCode.A))
        {

        }
    }
    void FireLineGenerator()
    {
        int fire = -1;
        for (int i = 0; i < zoneHeight; i++)
        {
            for (int j = 0; j < zoneWidth; j++)
            {
                //print(((i * zoneWidth) + j));
                line.Add(transform.GetChild((i * zoneWidth) + j).gameObject);
                //line[j].GetComponent<MeshRenderer>().material.color = Color.red;
            }
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
            else if (fire == line.Count - 1)
            {
                fire = Random.Range(fire - 1, fire + 1);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
                //line[fire].GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                //print("before fire" + fire);
                fire = Random.Range(fire - 1, fire + 2);
                //print("lines:" + line.Count);
                //print("fire:" + fire);
                line[fire].GetComponent<MeshRenderer>().material.color = Color.green;
                //line[fire].GetComponent<MeshRenderer>().enabled = true;
            }
            GameManager.instance.fireSpawned += 1;
            line.Clear();
        }
    }
    void HumanGenerator()
    {
        List<GameObject> freeCubes = new List<GameObject>();
        for (int i = 0; i < zoneHeight; i++)
        {
            for (int j = 0; j < zoneWidth; j++)
            {
                if (transform.GetChild((i * zoneWidth) + j).gameObject.GetComponent<MeshRenderer>().material.color == mainColor.color)
                {
                    freeCubes.Add(transform.GetChild((i * zoneWidth) + j).gameObject);
                }
            }
        }
        for (int i = 0; i < human; i++)
        {
            int index = Random.Range(0, freeCubes.Count);
            freeCubes[index].GetComponent<MeshRenderer>().material.color = Color.blue;
            freeCubes[index].tag = "Human";
            GameManager.instance.humanSpawned += 1;
            freeCubes.RemoveAt(index);
        }
        freeCubes.Clear();
    }
}