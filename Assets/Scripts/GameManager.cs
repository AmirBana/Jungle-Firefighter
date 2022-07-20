using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static int fireSpawned = 0;
    [HideInInspector] public static int fireSolved = 0;
    [HideInInspector] public static int humanSpawned = 0;
    [HideInInspector] public static int humanSolved = 0;
    public static float environmentSpeed = 10f;
    public static int waterNum = 20;
    public static int ladderNum = 10;
    public TextMeshProUGUI ladderTxt;
    public TextMeshProUGUI waterTxt;
    public TextMeshProUGUI humanTxt;
    public TextMeshProUGUI fireTxt;
    // Start is called before the first frame update
    void Start()
    {
        humanTxt.text = "0%";
        fireTxt.text = "0%";
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate();
    }
    void TextUpdate()
    {
        if(fireSpawned > 0)
        fireTxt.text = ((fireSolved * 100) / fireSpawned).ToString() + '%';
        if(humanSpawned >0)
        humanTxt.text = ((humanSolved * 100) / humanSpawned).ToString() + '%';
        waterTxt.text = waterNum.ToString();
        ladderTxt.text = ladderNum.ToString();
    }
}
