using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(300, 1000)]
    [SerializeField] float speed;

    Rigidbody2D rb;

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
}
    

