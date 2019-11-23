using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] Text baseHealthUI;

    [SerializeField] SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        baseHealthUI.text = health.ToString();
        //sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(LoseGame());
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
            baseHealthUI.text = health.ToString();
            Debug.Log(health);
        }
    }

    private IEnumerator LoseGame()
    {
        if(health <= 0)
        {
            //TODO play lose game sound effect

            //Wait 2 seconds 
            yield return new WaitForSeconds(2);
            //Player loses, load game over
            sceneLoader.LoadSceneByName("Game Over Screen");
        }
    }
}
