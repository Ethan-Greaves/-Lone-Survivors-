using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] float speed = 5f;
    [SerializeField] float padding = 1f;
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] Text playerHealthUI;
    [SerializeField] int damagePerSec = 3;
    [SerializeField] SceneLoader sceneLoader;

    [SerializeField] float playerHealth;
    private Vector2 mousePos;
    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100.0f;
        Debug.Log(playerHealth);
        playerHealthUI.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu.GetIsPaused() == false)
        {
             MouseClickMovement();
        }

        //Radiation Sickness
        LoseHealthOverTime();
    }

    public void AddHealth(int healAmount)
    { 
        playerHealth += healAmount;

        //Make sure player does not exceed full health
        if (playerHealth > 100) { playerHealth = 100; }
    }

    private void KeyboardMovement()
    {
        float moveHor = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveVer = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float newXPos = Mathf.Clamp(transform.position.x + moveHor, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + moveVer, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void MouseClickMovement()
    {
        //Check if left mouse button has been clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Find the position of the mouse 
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //Make sprite move towards mouse position
        if ((Vector2)transform.position != mousePos)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        }
    }

    private void MovementBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void LoseHealthOverTime()
    { 
        if(playerHealth > 0)
        {
            //Make the player lose x health every second
            playerHealth -= Time.deltaTime * damagePerSec;

            //Create a local INT variable version of player health so that the UI does not dipsplay decimals
            int playerHealthToInt = Mathf.RoundToInt(playerHealth);

            //Update the playerHealth UI as int 
            playerHealthUI.text = playerHealthToInt.ToString();
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        //Wait 2 seconds 
        yield return new WaitForSeconds(4);

        //Player loses, load game over
        sceneLoader.LoadSceneByName("Game Over Screen");
    }

    public float GetPlayerHealth()
    {
        return playerHealth;
    }
}
