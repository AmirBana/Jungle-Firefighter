using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float cameraSize;
    [SerializeField] float speed=10f;
    int layer;
    [SerializeField] GameObject water;
    [SerializeField] GameObject ladder;
    [SerializeField] TextMeshProUGUI ladderTxt;
    [SerializeField] TextMeshProUGUI waterTxt;
    private int waterNum;
    private int ladderNum;
    void Start()
    {
        cameraSize = Camera.main.orthographicSize / 2 - 3;
        layer = 1<<4;
        print(cameraSize);
        waterNum = 0;
        ladderNum = 0;
    }
    void Update()
    {
        Movement();
        ProblemDetection();
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.A))//todo add mobile swipe
        {
            if (transform.position.x > cameraSize * -1)
            {
                transform.Translate(Vector3.left*speed*Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.D))//todo add mobile swipe
        {
            if (transform.position.x < cameraSize)
            {
                transform.Translate(Vector3.right*speed* Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.W))//todo add mobile swipe
        {
            if (transform.position.z < 50f)
            {
                transform.Translate(Vector3.forward*speed* Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.S))//todo add mobile swipe
        {
            if (transform.position.z > 1f)
            {
                transform.Translate(-Vector3.forward*speed* Time.deltaTime, Space.World);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Water"))
        {
            Debug.Log(other.transform.name);
            Destroy(other.gameObject);
            waterNum += 1;
            waterTxt.text = waterNum.ToString();
        }
        if(other.transform.CompareTag("Ladder"))
        {
            Debug.Log(other.transform.name);
            Destroy(other.gameObject);
            ladderNum += 1;
            ladderTxt.text = ladderNum.ToString();
        }
    }
    private void ProblemDetection()
    {
        var ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down*20f, Color.red);
        if (Physics.Raycast(ray, out hit, layer))
        {
            var objHit = hit.transform.gameObject;
            print(objHit.tag);
            switch (objHit.tag)
            {
                case "Human":
                    //AbilitySpawn(ladder);
                    if(ladderNum > 0)
                    {
                        Destroy(objHit.gameObject);
                        ladderNum -= 1;
                        ladderTxt.text = ladderNum.ToString();
                    }
                    break;
                case "Fire":
                    // AbilitySpawn(water);
                    if(waterNum > 0)
                    {
                        Destroy(objHit.gameObject);
                        waterNum -= 1;
                        waterTxt.text = waterNum.ToString();
                    }
                    break;
                default:
                    break;
            }
        }
    }
    private void AbilitySpawn(GameObject ability)
    {
        Vector3 spawnPos = new Vector3(transform.position.x,transform.position.y-3,transform.position.z);
        GameObject obj=Instantiate(ability, spawnPos, Quaternion.identity);
       // obj.planeAbility += PlaneAbility;
    }
    private void PlaneAbility()
    {

    }
}
