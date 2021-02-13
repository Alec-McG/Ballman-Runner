using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    private Collider2D myCollider;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();  // search for <> in current thing

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); // Check if collider is touching collider on ground

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) // Jump if space OR || left click (or screen?)
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }

        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);



    }
}
