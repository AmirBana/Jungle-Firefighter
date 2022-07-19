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
    [SerializeField] TextMeshProUGUI humanTxt;
    [SerializeField] TextMeshProUGUI fireTxt;

    public LayerMask mask;
    void Start()
    {
        cameraSize = Camera.main.orthographicSize / 2 - 3;
        layer = 1<<4;
    }
    void Update()
    {
        Movement();
        // ProblemDetection();
        FireFinder();
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
            GameManager.waterNum += 1;
        }
        if(other.transform.CompareTag("Ladder"))
        {
            Debug.Log(other.transform.name);
            Destroy(other.gameObject);
            GameManager.ladderNum += 1;
        }
        if(other.transform.CompareTag("Enemy"))
        {
            print("game over");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
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
            switch (objHit.tag)
            {
                case "Human":
                    if(GameManager.ladderNum > 0)
                    {
                        AbilitySpawn(ladder);
                        objHit.gameObject.tag = "HumanSolved";
                        GameManager.humanSolved += 1;
                        // Destroy(objHit.gameObject);
                        GameManager.ladderNum -= 1;
                    }
                    break;
                case "Fire":
                    if(GameManager.waterNum > 0)
                    {
                        print('s');
                        AbilitySpawn(water);
                        objHit.gameObject.tag = "FireSolved";
                        GameManager.fireSolved += 1;
                        //fireTxt.text = fireNum.ToString();
                        //Destroy(objHit.gameObject);
                        GameManager.waterNum -= 1;
                        //waterTxt.text = waterNum.ToString();
                    }
                    break;
                default:
                    break;
            }
        }
    }
    void FireFinder()
    {
        float rayHeight = 50.0f;

        var ray = new Ray(transform.position, Vector3.down*rayHeight);
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down * rayHeight, Color.red);
        if (Physics.Raycast(ray, out hit,10000,mask))
        {
            var objHit = hit.transform.gameObject;
            print(objHit.tag);
            if (objHit.transform.CompareTag("Fire"))
            {
                print('s');
                AbilitySpawn(water);
                objHit.gameObject.tag = "FireSolved";
                if(objHit.gameObject.GetComponent<MeshRenderer>().material.color == Color.green)
                {
                    GameManager.fireSolved += 1;
                }
                //fireNum += 1;
                //Destroy(objHit.gameObject);
                GameManager.waterNum -= 1;
            }
        }
    }
    private void AbilitySpawn(GameObject ability)
    {
        Vector3 spawnPos = new Vector3(transform.position.x,transform.position.y-3,transform.position.z);
        GameObject obj=Instantiate(ability, spawnPos, Quaternion.identity);
        obj.GetComponent<Ability>().planeAbility = true;
        obj.GetComponent<SphereCollider>().isTrigger = false;
    }
}
