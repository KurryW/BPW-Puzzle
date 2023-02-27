using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup = false; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem = false; // a bool to see if you have an item in your hand

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hasItem && canpickup)
            {
                
                Rigidbody objectRigidBody = ObjectIwantToPickUp.GetComponent<Rigidbody>();
                objectRigidBody.isKinematic = true;   //makes the rigidbody not be acted upon by forces
                objectRigidBody.constraints = RigidbodyConstraints.FreezeAll;
                ObjectIwantToPickUp.GetComponent<gravity>().enabled = false;
                ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
                ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
                hasItem = true;
            }
            else if (hasItem)
            {
                Rigidbody objectRigidBody = ObjectIwantToPickUp.GetComponent<Rigidbody>();
                objectRigidBody.isKinematic = true;   //makes the rigidbody be acted upon by forces
                objectRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
                ObjectIwantToPickUp.GetComponent<gravity>().enabled = true;
                ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
                hasItem = false;
                Debug.Log("ik laat los");
            }
        }
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if (other.gameObject.CompareTag("PickUp")) //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            ObjectIwantToPickUp = other.gameObject; //set the gameobject you collided with to one you can reference
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            canpickup = false;  
        }
    }
}



