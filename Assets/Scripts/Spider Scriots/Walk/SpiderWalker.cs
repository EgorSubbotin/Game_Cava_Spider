using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour
{
    Rigidbody2D myBody;
    float speed=3f;
    [SerializeField ]
    Transform startPos, endPos;
    bool collision;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }
   
    void ChangeDirection()
    {       
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(startPos.position, endPos.position, Color.green);
        if (!collision)
        {          
            Vector3 temp = transform.localScale;
            if (temp.x == 0.4f)
            {               
                temp.x=-0.4f;
            }
            else
            {
                temp.x =0.4f;
            }
            transform.localScale  = temp;
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
            Destroy(target.gameObject);
        }
    }
    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0f) * speed;
    }
}
