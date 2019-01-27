using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Fruitz;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Identity Identity { get; set; }

    public float shootTime = 2.0f;
    public GameObject projectilePrefab;

    private Animator animator;
    private float timer = 0.0f;

    protected Vector2 direction = Vector2.left;

    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        timer = shootTime;

        SetDirection(Vector2.left);
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir;

        // rotate to look direction 
        Vector3 look = new Vector3(direction.x, direction.y, 0.0f);

        //transform.right = look;
        float rot_z = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            ShootProjectile();

            timer = shootTime;
        }
    }

    protected void ShootProjectile()
    {
        GameObject projectile = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        projectile.GetComponent<Projectile>().SetDirection(direction);

        animator.SetTrigger("shoot");
    }
}
