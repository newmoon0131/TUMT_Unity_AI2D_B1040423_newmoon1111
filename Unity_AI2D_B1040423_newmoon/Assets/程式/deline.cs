using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deline : MonoBehaviour
    
{

    public float damage = 999999;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<player>().Damage(damage);
    }
}
