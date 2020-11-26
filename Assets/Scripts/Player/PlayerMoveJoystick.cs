using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public float speed = 10, maxVelocity = 4;
    private Rigidbody2D mybody;
    private Animator anim;
    private bool moveLeft, moveRight;

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveLeft)
        {
            MoveLeft();
        }

        if (moveRight)
            MoveRight();
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft; //this e aceeasi chestie cu PlayerMoveJoystick.moveLeft, ne referim la variabila de aici
        this.moveRight = !moveLeft;
        
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("walkParameter", false);
    }
  

    void MoveLeft()
    {
        float forceX = 0;
        float vel = Mathf.Abs(mybody.velocity.x);

        if (vel < maxVelocity)
            forceX = -speed;

        Vector3 temp = transform.localScale; //aici avem playeru cu fata spre stg
        temp.x = -0.25f;
        transform.localScale = temp;

        anim.SetBool("walkParameter", true);

        mybody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0;
        float vel = Mathf.Abs(mybody.velocity.x);

        if (vel < maxVelocity)
            forceX = speed;

        Vector3 temp = transform.localScale; 
        temp.x = 0.25f;
        transform.localScale = temp;

        anim.SetBool("walkParameter", true);

        mybody.AddForce(new Vector2(forceX, 0));
    }
}
