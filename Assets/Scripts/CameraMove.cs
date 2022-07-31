using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    [SerializeField] TMP_InputField yPos;
    [SerializeField] TMP_InputField zPos;
    [SerializeField] TMP_InputField xRot;
    private float x, y, z;
    float offset;
    void Start()
    {
        y = Camera.main.transform.position.y;
        z = Camera.main.transform.position.z;
        x = Camera.main.transform.eulerAngles.x;
        player = GameObject.FindWithTag("Player");
        yPos.text = y.ToString();
        zPos.text = z.ToString();
        xRot.text = x.ToString();
        /* yPos.value = Camera.main.transform.position.y;
         zPos.value = Camera.main.transform.position.z;
         xRot.value = Camera.main.transform.eulerAngles.x;
         yTxt.text = string.Format("{0:F3}",yPos.value);
         zTxt.text = string.Format("{0:F3}", zPos.value);
         xTxt.text = string.Format("{0:F3}",xRot.value);*/
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnYPos()
    {
        if(yPos.text.Length > 0)
        {
            float y = Mathf.Clamp(Convert.ToSingle(yPos.text), 18f, 40f);
            yPos.text = y.ToString();
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        //yTxt.text = string.Format("{0:F3}",yPos.value);
    }
    public void OnZPos()
    {
        if(zPos.text.Length > 0)
        {
            float z = Mathf.Clamp(float.Parse(zPos.text), -9.5f, 3.6f);
            zPos.text = z.ToString();
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }
        //zTxt.text = string.Format("{0:F3}", zPos.value);
    }
    public void OnXRot()
    {
        if(xRot.text.Length > 0)
        {
            float x = Mathf.Clamp(float.Parse(xRot.text), 20f, 90f);
            xRot.text = x.ToString();
            transform.eulerAngles = new Vector3(x, transform.rotation.y, transform.rotation.z);
        }
       // xTxt.text = string.Format("{0:F3}", xRot.value);
    }
    public void YReset()
    {
        Camera.main.transform.position = new Vector3(transform.position.x,y,transform.position.z);
        yPos.text = y.ToString();
    }
    public void ZReset()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, z);
        zPos.text = z.ToString();
    }
    public void XReset()
    {
        Camera.main.transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
        xRot.text = x.ToString();
    }
}
