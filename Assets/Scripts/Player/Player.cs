using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] float speed = 5f;
    [SerializeField] float padding = 1f;
    private float moveSpeed;
    private Vector2 mousePos;
    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        MouseClickMovement();
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
            transform.position = Vector2.MoveTowards(transform.position, mousePos, moveSpeed);
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
}
