using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.5f;
    public float damage = 1;
    public Transform check;
    private Rigidbody2D r2d;
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name=="玩家")
        {
            track(collision.transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "玩家" && collision.transform.position.y < transform.position.y + 1.9f)
        {
            collision.gameObject.GetComponent<player>().Damage(damage);
        }
    
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(check.position, -check.up *2.0f);
    }
    private void Move()
    {
        r2d.AddForce(-transform.right*speed);
        

        RaycastHit2D hit=Physics2D.Raycast(check.position, -check.up, 2.0f, 1 << 8);

        //print(hit.collider.gameObject);
        if (hit==false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }
    private void track(Vector3 tatget)
    {
        if (tatget.x<transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    
}
