using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject player;
    float offset;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = Camera.main.transform.position.y - player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset, player.transform.position.z);
    }
}
