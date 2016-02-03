﻿using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Collections;

public class DetectItem : MonoBehaviour
{
    [Tooltip ("You can change the distance of detection from object to player")]
    public float Distance = 1.5f;

    [Tooltip("Select the layers that the ray can see. Unselect layers that you want to ignore.")]
    public LayerMask LayersToDetect;

    [Tooltip("Put in the text object that will display item info inside here")]
    public Text TextObject;




    void FixedUpdate()
    {
        DetectWithRay(); //calls the ray detector
    } //end fixed update

    void DetectWithRay()
    {
        #region Head Location Properties
        Vector3 fwd = transform.TransformDirection(Vector3.forward); // direction
        Vector3 myPos = transform.position; //position of camera
        #endregion

        #region Ray info
        RaycastHit hit; //make a reference to the object that is intersected
        Ray ray = new Ray(transform.position, fwd); //make a ray type 
        Debug.DrawRay(myPos, fwd, Color.green); // draw the ray that we are desiring
        #endregion


        if (Physics.Raycast(myPos, fwd, out hit, Distance, LayersToDetect))
        {
            if (hit.transform.tag == "Item") // you can change the tag(s) of your objects here that need to be detected
            {
                hit.transform.SendMessage("Equip");
            }
            
            // end if for detection
        } 
        else
        {
            TextObject.enabled = false;
        }   // end Raycast if

    } // end DetectWithRay
} // end class