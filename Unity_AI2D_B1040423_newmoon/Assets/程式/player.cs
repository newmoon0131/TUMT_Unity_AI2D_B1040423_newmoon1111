using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    public float jump = 2.5f;
    private Rigidbody2D r2d;
    private Transform tra;
    public bool isG = false;
    public float hp = 10.0f;
    public Image hpbar;
    public GameObject final;
    private float hpMax;

    public UnityEvent onEat;
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
        hpMax = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) turn(0);
        if (Input.GetKeyDown(KeyCode.A)) turn(180);
    }
    private void FixedUpdate()
    {
        walk();
        Jump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isG = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="能量球")
        {
            Destroy(collision.gameObject);
            onEat.Invoke();
        }
    }
    private void walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isG == true)            
        {
            isG = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }

    private void turn(int RorL)
    {

        tra.eulerAngles = new Vector3(0, RorL, 0);
    }
    public void Damage(float damage)
    {
        hp -= damage;
        hpbar.fillAmount = hp / hpMax;
        if (hp <= 0) final.SetActive(true);
    }

}
