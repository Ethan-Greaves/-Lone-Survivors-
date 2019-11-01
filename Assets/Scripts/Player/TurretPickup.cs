using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPickup : MonoBehaviour
{
    [SerializeField] Turret turret;
    [SerializeField] Canvas turretUICanvas;
    private bool isPickedUp = false;

    // Update is called once per frame
    void Update()
    {
        DropTurret();
        ShowUI();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PickupTurret(collision);
    }

    private void PickupTurret(Collider2D collision)
    {
        if(isPickedUp == false)
        {
            //Compare the tag of turret with collision
            if (collision.gameObject.tag == "Turret")
            {
                //if RMB is pressed
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    //This is kind of cheating, but it works and destroying and re-instantiating in different functions turned out to be a nightmare.
                    turret.transform.position = new Vector2(-1000, -1000);
               
                    isPickedUp = true;
                }
            }
        }
    }

    private void DropTurret()
    {
        if (isPickedUp == true)
        {
            //if the MMB is pressed
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                //Drop the turret at players position
                turret.transform.position = transform.position;

                isPickedUp = false;
            }
        }
    }

    private void ShowUI()
    {
        //Display or hide UI depending on if turret is picked up or not
        if (isPickedUp)
        {
            turretUICanvas.gameObject.SetActive(true);
        }
        else
        {
            turretUICanvas.gameObject.SetActive(false);
        }
    }
}