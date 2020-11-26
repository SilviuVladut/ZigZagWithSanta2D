using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 10, maxVelocity = 4;
    private Rigidbody2D mybody;
    private Animator anim;
    

    void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update este apelata la fiecare frame pe secunda, FixedUpdated e apelata la o serie de frameuri 
    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0;
        float vel = Mathf.Abs(mybody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        if(h>0)
        {
            if (vel < maxVelocity)
                forceX = speed;

            Vector3 temp = transform.localScale; //aici avem playeru cu fata spre dreapta
            temp.x = 0.25f;
            transform.localScale = temp;

            anim.SetBool("walkParameter",true);
        } 
        else if(h<0)
        {
            if (vel < maxVelocity)
                forceX = -speed;

        Vector3 temp = transform.localScale; //aici avem playeru cu fata spre stg
            temp.x = -0.25f;
            transform.localScale = temp;

        anim.SetBool("walkParameter",true);

        } else 
        { 
            anim.SetBool("walkParameter",false);
        }
        
        mybody.AddForce(new Vector2(forceX, 0));
    }
}
