﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == "Ground")
        {            
            Destroy(gameObject);
        }
    }
}
