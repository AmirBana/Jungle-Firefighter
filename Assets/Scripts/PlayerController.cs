using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float xMin,xMax,zMin,zMax;
    [SerializeField] float forwardSpeed=10f;
    [SerializeField] float turnSpeed=10f;
    [SerializeField] float backwardSpeed = 10f;
    [SerializeField] int waterAdd = 10;
    [SerializeField] int waterTake = 10;
    [SerializeField] int ladderAdd = 1;
    [SerializeField] int ladderTake = 1;
    [SerializeField] GameObject water;
    [SerializeField] GameObject ladder;
    [SerializeField] TextMeshProUGUI ladderTxt;
    [SerializeField] TextMeshProUGUI waterTxt;
    [SerializeField] TextMeshProUGUI humanTxt;
    [SerializeField] TextMeshProUGUI fireTxt;

    public LayerMask mask;
    void Start()
    {
        xMin = GameManager.instance.xMin;
        xMax = GameManager.instance.xMax;
    }
    void Update()
    {
        Movement();
        ProblemDetection();
        //FireFinder();
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.A))//todo add mobile swipe
        {
            if (transform.position.x >= xMin)
            {
                transform.Translate(Vector3.left*turnSpeed*Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.D))//todo add mobile swipe
        {
            if (transform.position.x <= xMax)
            {
                transform.Translate(Vector3.right*turnSpeed* Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.W))//todo add mobile swipe
        {
            if (transform.position.z < zMax)
            {
                transform.Translate(Vector3.forward*forwardSpeed* Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey(KeyCode.S))//todo add mobile swipe
        {
            if (transform.position.z > zMin)
            {
                transform.Translate(-Vector3.forward*backwardSpeed* Time.deltaTime, Space.World);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Water"))
        {
            Debug.Log(other.transform.name);
            Destroy(other.gameObject);
            GameManager.instance.waterNum += waterAdd;
        }
        if(other.transform.CompareTag("Ladder"))
        {
            Debug.Log(other.transform.name);
            Destroy(other.gameObject);
            GameManager.instance.ladderNum += ladderAdd;
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
        float rayHeight = 50.0f;
        var ray = new Ray(transform.position, Vector3.down*rayHeight);
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down*rayHeight, Color.red);
        if (Physics.Raycast(ray, out hit,1000f, mask))
        {
            print("ray detect1:" + hit.collider.gameObject.name);
            var objHit = hit.transform.gameObject;
            switch (objHit.tag)
            {
                case "Human":
                    if(GameManager.instance.ladderNum > 0)
                    {
                        AbilitySpawn(ladder);
                        objHit.gameObject.tag = "HumanSolved";
                        GameManager.instance.humanSolved += 1;
                        // Destroy(objHit.gameObject);
                        GameManager.instance.ladderNum -= ladderTake;
                    }
                    break;
                case "Fire":
                    if(GameManager.instance.waterNum > 0)
                    {
                        AbilitySpawn(water);
                        objHit.gameObject.tag = "FireSolved";
                        if (objHit.gameObject.GetComponent<MeshRenderer>().material.color == Color.green)
                        {
                            GameManager.instance.fireSolved += 1;
                        }
                        //fireTxt.text = fireNum.ToString();
                        //Destroy(objHit.gameObject);
                        GameManager.instance.waterNum -= waterTake;
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
        obj.GetComponent<Ability>().planeAbility = true;
        obj.GetComponent<SphereCollider>().isTrigger = false;
    }
}
