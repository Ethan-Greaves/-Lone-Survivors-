using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] int attackDamage = 20;
    [SerializeField] int moveSpeed = 500;
    [SerializeField] int health = 100;

    [Header("References")]
    [SerializeField] Projectile projectile;

    Vector2 moveDown;
    Rigidbody2D rb;
    bool changeColour = false;

    //Getters
    public int GetAttackDamage() { return attackDamage; }

    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * (moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the enemy collides with the base
        if (collision.gameObject.tag == "Base")
        {
            Destroy(gameObject, 1f);
        }
        else if(collision.gameObject.tag == "Projectile")
        {
            health -= projectile.GetDamage();
            StartCoroutine(FlashRedWhenDamaged());

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator FlashRedWhenDamaged()
    {
        changeColour = true;
        float timeLeft = 0.08f;
        if (changeColour)
        {
            transform.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(timeLeft);
            changeColour = false;
        }

        if (changeColour == false)
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
    }

}
