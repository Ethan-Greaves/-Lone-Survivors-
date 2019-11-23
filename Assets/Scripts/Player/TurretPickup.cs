using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPickup : MonoBehaviour
{
    [SerializeField] Turret turret;
    [SerializeField] GameObject turretUIImage;
    private bool isPickedUp = false;
    private float waitTime = .1f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DropTurret());
        ShowUI();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(PickupTurret(collision));
    }

    private IEnumerator PickupTurret(Collider2D collision)
    {
        if(!isPickedUp)
        {
            //Compare the tag of turret with collision
            if (collision.gameObject.tag == "Turret")
            {
                //if RMB is pressed
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    //This is kind of cheating, but it works and destroying and re-instantiating in different functions turned out to be a nightmare.
                    turret.transform.position = new Vector2(-1000, -1000);

                    yield return new WaitForSeconds(waitTime);
                    isPickedUp = true;
                }
            }
        }
    }

    private IEnumerator DropTurret()
    {
        if (isPickedUp)
        {
            //if the RMB is pressed
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //Drop the turret at players position
                turret.transform.position = transform.position;

                yield return new WaitForSeconds(waitTime);
                isPickedUp = false;
            }
        }
    }

    private void ShowUI()
    {
        //Display or hide UI depending on if turret is picked up or not
        if (isPickedUp)
            turretUIImage.gameObject.SetActive(true);
        else
            turretUIImage.gameObject.SetActive(false);
    }
}