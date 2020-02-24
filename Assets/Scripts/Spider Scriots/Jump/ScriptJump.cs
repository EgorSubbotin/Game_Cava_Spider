using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptJump : MonoBehaviour
{
    float forceY = 300f;
    Rigidbody2D myBody;
    Animator anim;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    private void Start()
    {
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(3f, 7f));
        forceY = Random.Range(250, 500);
        myBody.AddForce(new Vector2( 0f, forceY));
        anim.SetBool("Jump", true);
        yield return new WaitForSeconds(.7f);
        
        StartCoroutine(Attack());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Ground")
        {
            anim.SetBool("Jump", false);
        }
        if (collision.tag == "Player")
        {
            GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
            Destroy (collision.gameObject );
        }
    }
    

}
