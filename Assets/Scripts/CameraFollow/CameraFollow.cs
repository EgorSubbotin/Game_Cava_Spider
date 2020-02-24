using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    public float maxX, minX;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            if (temp.x < minX)
                temp.x = minX;
            if (temp.x > maxX)
                temp.x = maxX;

           // temp.y = player.position.y+3.8f;
            transform.position=temp;
        }
    }

}
