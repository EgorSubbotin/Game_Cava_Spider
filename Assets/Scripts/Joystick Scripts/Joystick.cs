using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    PlayerScript player;
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
    public void OnPointerDown (PointerEventData date)
    {
        if (gameObject.name == "Left") 
        {
            player.SetMoveLeft(true);
        }
        else
        {
            player.SetMoveLeft(false);
        }
    }
   public void OnPointerUp(PointerEventData date)
    {
        player.StopMoving();
    }
}
