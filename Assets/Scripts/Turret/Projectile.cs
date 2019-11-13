using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(300, 1000)]
    [SerializeField] float speed;
    [SerializeField] int damage = 25;

    Rigidbody2D rb;

    //Getters
    public int GetDamage() { return damage; }

    // Start is called before the first frame update
    void Start()
    {
        FireProjectile();
    }

    private void FireProjectile()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * (speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Turret" && collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}
    

