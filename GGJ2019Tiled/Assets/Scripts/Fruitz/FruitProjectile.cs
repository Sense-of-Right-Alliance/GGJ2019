using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitProjectile : MonoBehaviour
{
    public float speed = 15;
    public GameObject explosionPrefab;

    protected Rigidbody2D rb2d;

    protected Vector2 direction = Vector2.left; // default...

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Mathf.Lerp(0, direction.x * speed, 0.8f),
                                                Mathf.Lerp(0, direction.y * speed, 0.8f));

        // rotate to look direction 
        Vector3 look = new Vector3(direction.x, direction.y, 0.0f);
        
        float rot_z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("FruitProjectile -> OnCollisionEnter2D ; " + col.gameObject.name + ", Tag " + col.gameObject.tag + ", Layer " + col.gameObject.layer);
        OnHit();
    }

    void OnHit()
    {
        Instantiate<GameObject>(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
