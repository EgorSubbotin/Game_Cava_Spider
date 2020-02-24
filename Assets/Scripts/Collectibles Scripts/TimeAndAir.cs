using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if ( collision.tag == "Player")
        {
            if (gameObject.name == "Time")
            {
                GameObject.Find("Gameplay Controller").GetComponent<LevelTimer>().time += 50f;
            }
            if (gameObject.name == "Air")
            {
                GameObject.Find("Gameplay Controller").GetComponent<AirTimer>().air += 40f;
            }
            Destroy(gameObject);
        }
    }
}
