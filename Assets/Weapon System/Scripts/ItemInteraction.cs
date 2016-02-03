using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemInteraction : MonoBehaviour
{
    [Tooltip("Assign the disabled gun in your hands")]
    public GameObject ActualWeapon;

    [Tooltip("Assign the text object you want to display the equip info to")]
    public Text TextObject;

    #region Properties

    //Public
    [Tooltip("Classify your Item")]
    public ItemTypes Type_Of_Item; // variable to store the type of item

    [Tooltip("Give your item a name")]
    public string Name; //variable to store the name

    [Tooltip("Give your item an ID")]
    public int ID; // variable to store the item id

    //Private
    private string txtToDisplay;
    #endregion

    void Start()
    {
        //Disable the textobject if it is already enabled
        if (TextObject.enabled == true)
        {
            TextObject.enabled = false;
            print("Disabled because it was enabled at start");
        }
    }
    void Equip()
    {
        //Have the text display what weapon you're looking at it
        ShowText();

        //Pick up the weapon if you click the "Pick-Up" button
        if (Input.GetButton("Fire1"))
        {
            //Set your actual weapon to be active
            ActualWeapon.SetActive(true);

            //diable the Text Object
            DisableText();

            //Hide the object on the floor then respawn the weapon once the time has gone
            Despawn();
            
        }
        //end if 
    }


    void Despawn()
    {
        this.gameObject.SetActive(false); //hide the object
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.5f);

        print("spawned");
        this.gameObject.SetActive(true);
        StopCoroutine(Respawn());
    }
    void ShowText()
    {
        txtToDisplay = "Pick up " + this.Name;
        TextObject.text = txtToDisplay;
        TextObject.enabled = true;
    }

    void DisableText()
    {
        txtToDisplay = null;
        TextObject.text = "";
        TextObject.enabled = false;
    }
}



//Modify the item type list to your desire.
public enum ItemTypes
{
    Melee1Hand,
    Melee2Hand,
    Item1Hand,
    Item2Hand,
    Pistol,
    Rifle,
}
