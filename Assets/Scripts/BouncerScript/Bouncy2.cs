using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy2 : MonoBehaviour
{
    public float force = 0f;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    IEnumerator WaitBouncer()
    {
        yield return new WaitForSeconds(.7f);
        anim.Play("Idle 2");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.Play("Bouncer 2");
            collision.gameObject.GetComponent<PlayerScript>().BouncePlayerBoyncy(force);
            StartCoroutine(WaitBouncer());
        }
    }
}
