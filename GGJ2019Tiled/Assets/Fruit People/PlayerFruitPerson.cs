using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFruitPerson : FruitPhysicsObject
{

    public float maxSpeed = 7;

    //private SpriteRenderer spriteRenderer;
    //private Animator animator;

    // Use this for initialization
    void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        /*
        if (move.magnitude > 0.1f)
        {
            rb2d.AddForce(move * maxSpeed * Time.deltaTime);

            rb2d.position = rb2d.position + move.normalized * distance;
        }
        */

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;

    }

    public void OnHit()
    {
        Debug.Log("PlayerFruitPerson -> ONHIT! OUCH!");

        Destroy(gameObject);
    }
}