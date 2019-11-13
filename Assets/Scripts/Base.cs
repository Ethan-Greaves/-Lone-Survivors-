using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] int health = 100;

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
        //This is onyl a temp value, later on hopefully I can add specific enemy damage depending on enemy type
        RemoveHealth(10);
    }

    private void RemoveHealth(int damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        //Pause game 

        //Display game over screen

        //have exit or restart level buttons
    }
}
