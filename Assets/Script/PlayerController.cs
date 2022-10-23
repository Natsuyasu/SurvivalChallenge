using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D RB;
    public float speed;

    public Animator anim;

    [HideInInspector]
    public Vector3 movementVector;
    //[HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        
    }

    void Movement()
    {
        float horizontalMove;
        float verticalMove;
        float face;

        face = Input.GetAxisRaw("Horizontal");
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        movementVector.x = horizontalMove;
        movementVector.y = verticalMove;

        if (horizontalMove != 0)
        {
            //RB.velocity = new Vector2(horizontalMove * speed * Time.deltaTime, RB.velocity.y);
            anim.SetFloat("running",Mathf.Abs(face));
        }
        if (verticalMove != 0)
        {
            //RB.velocity = new Vector2(RB.velocity.x, verticalMove * speed * Time.deltaTime);
            anim.SetFloat("running", Mathf.Abs(verticalMove));
        }

        if (face != 0)
        {
            transform.localScale = new Vector3(face, 1, 1);
        }
        RB.velocity = movementVector * speed * Time.deltaTime;

        if (movementVector.x != 0)
        {
            lastHorizontalVector = movementVector.x;
        }
        if (movementVector.y != 0)
        {
            lastVerticalVector = movementVector.y;
        }
    }

}
