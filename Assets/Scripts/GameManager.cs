using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [HideInInspector] public int fireSpawned = 0;
    [HideInInspector] public int fireSolved = 0;
    [HideInInspector] public int humanSpawned = 0;
    [HideInInspector] public int humanSolved = 0;
    public float environmentSpeed = 10f;
    public int waterNum = 20;
    public int ladderNum = 10;
    public float xMin, xMax;
 
    public TextMeshProUGUI ladderTxt;
    public TextMeshProUGUI waterTxt;
    public TextMeshProUGUI humanTxt;
    public TextMeshProUGUI fireTxt;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
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
