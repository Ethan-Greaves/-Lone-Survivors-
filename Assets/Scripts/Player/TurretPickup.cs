using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//*************
//PSUEDO CODE
//*************

//*********************
//FOR PICKING UP TURRET
//*********************

//Create bool variable "pickedUp" equal to false

//Create reference object for the turret

//Use OnTriggerEnter to see if the player and the turret are colliding

//Compare the tag of turret in OnTriggerEnter, so "other.tag == 'turret'"

//check to see if the mouse position is a short enough distance away from the turret transform

//If pickedUp is equal to false, if the RMB is pressed, delete the turret

//Set pickedUp equal to true

//Instantiate a UI prefab with the turret image in the corner of screen

//*********************
//FOR DROPPING TURRET
//*********************

//Find the mouse position

//If pickedUp is equal to true

//If RMB is pressed

//Check the distance between mouse position and player transform is not too far away

//Instantiate the turret at mouse position

//Destroy UI turret element
