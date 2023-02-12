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
    [HideInInspector]
    public float lastHorizontalDeCoupledVector;
    [HideInInspector]
    public float lastVerticalDeCoupledVector;

    [HideInInspector]
    public float lastHorizontalCoupledVector;
    [HideInInspector]
    public float lastVerticalCoupledVector;

    // Start is called before the first frame update
    private void Start()
    {
        lastHorizontalDeCoupledVector = 1f;
        lastVerticalDeCoupledVector = 1f;

        lastHorizontalCoupledVector = -1f;
        lastVerticalCoupledVector = -1f;
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
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
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

        if (movementVector.x != 0 || movementVector.y != 0)
        {
            lastHorizontalCoupledVector = movementVector.x;
            lastVerticalCoupledVector = movementVector.y;
        }

        if (movementVector.x != 0)
        {
            lastHorizontalDeCoupledVector = movementVector.x;
        }
        if (movementVector.y != 0)
        {
            lastVerticalDeCoupledVector = movementVector.y;
        }
    }

}
