using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Fruitz;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Identity Identity { get; set; }

    public float speed = 7;
    public GameObject squashed;

    protected Rigidbody2D rb2d;
    private Animator animator;

    private float curSpeed;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = Vector2.zero;
        // get input
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        
        // move it
        Vector2 force = move * speed;

        curSpeed = speed;
        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                                Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
        // rotate to look direction 
        Vector2 moveNorm = move.normalized;
        Vector3 look = new Vector3(moveNorm.x, moveNorm.y, 0.0f);

        if (force.magnitude > 0.01f) // only change direction if has input
        {
            //transform.right = look;
            float rot_z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }

        animator.SetFloat("velocity", Mathf.Abs(force.magnitude) / speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("FruitProjectile -> OnCollisionEnter2D ; " + col.gameObject.name + ", Tag " + col.gameObject.tag + ", Layer " + col.gameObject.layer);
        if (col.gameObject.tag == "Projectile") // Projectile layer
        {
            OnHit();
        }
    }

    public void OnHit()
    {
        //Debug.Log("PlayerFruitPerson -> ONHIT! OUCH!");
        Instantiate<GameObject>(squashed, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
