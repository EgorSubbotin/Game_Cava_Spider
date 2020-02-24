using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveForce = 20f, jumpForce = 750f, maxVelocity = 4f;
    Rigidbody2D myBody;
    Animator anim;
    bool grounded;
    bool moveRight, moveLeft;
    Button q;
    private void Awake()
    {
        InitializeVariables();
        GameObject.Find("Jump").GetComponent<Button>().onClick.AddListener(() => Jump());
    }  
    void FixedUpdate()
    {
        PlaerWalkJoystick();
        //PlayerWalkKeyboard();       
    }
    void InitializeVariables()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }
    public void StopMoving()
    {
        this.moveLeft = false;
        this.moveRight = false;
    }
    void PlaerWalkJoystick()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        if (moveRight)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                    forceX = moveForce;
                else
                    forceX = moveForce * 1.1f;
                anim.SetBool("Walk", true);
                Vector3 scale = transform.localScale;
                scale.x = .3f;
                transform.localScale = scale;
            }
        }
        else if (moveLeft)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                    forceX = -moveForce;
                else
                    forceX =-moveForce * 1.1f;
                anim.SetBool("Walk", true);
                Vector3 scale = transform.localScale;
                scale.x = -.3f;
                transform.localScale = scale;
            }
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        myBody.AddForce(new Vector2(forceX, 0f));
    }
    void PlayerWalkKeyboard()
    {
        float forceX=0f, forceY=0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if (h > 0)
        {            
            if (vel < maxVelocity)
            {
                if (grounded)
                    forceX = moveForce;
                else
                    forceX = moveForce * 1.1f;
                anim.SetBool("Walk", true);
                Vector3 scale = transform.localScale;
                scale.x = .3f;
                transform.localScale = scale; 
            }                     
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                anim.SetBool("Walk", true);
                if (grounded)
                    forceX = -moveForce;
                else
                    forceX = -moveForce * 1.1f;
                Vector3 scale = transform.localScale;
                scale.x = -.3f;
                transform.localScale = scale;
            }
        }
        else if (h == 0)
        {
            anim.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {

            if ( grounded)
            {
                grounded = false;
                forceY = jumpForce;
            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }
    public void BouncePlayerBoyncy(float force)
    {
        //if (grounded)
        //{
            //grounded = false;
            myBody.AddForce (new Vector2 (0f,force));
        //}
    }
    //public void OnCollisionEnter2D(Collision2D target)
    //{
    //    if (target.gameObject.tag == "Ground")
    //    {
    //        grounded = true;
    //    }
    //}
    
        public void Jump()
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce));
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
