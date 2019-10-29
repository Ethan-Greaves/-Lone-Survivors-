using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] float speed = 5f;
    [SerializeField] float padding = 1f;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        MovementBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    private void Movement()
    {
        float moveHor = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveVer = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float newXPos = Mathf.Clamp(transform.position.x + moveHor, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + moveVer, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
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
