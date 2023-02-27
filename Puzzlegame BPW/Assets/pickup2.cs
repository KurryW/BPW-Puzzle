using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup2 : MonoBehaviour
{
    public float pickUpRange = 50;
    public float moveForce = 250;
    public Transform holdParent;

    private GameObject heldObj;

    private bool canpickup = false;
    private GameObject ObjectIwantToPickUp;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                if (canpickup)
                {
                    PickupObject(ObjectIwantToPickUp);
                }
            }
            else
            {
                DropObject();
            }
        }

        if (heldObj != null)
        {
            MoveObject();
        }

        void MoveObject()
        {
            if (Vector3.Distance(heldObj.transform.position, holdParent.position) > .35f)
            {
                Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
                heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);

            }
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (heldObj == null)
    //        {
    //            RaycastHit hit;
    //            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
    //            {
    //                PickupObject(hit.transform.gameObject);
    //            }
    //        }
    //        else
    //        {
    //            DropObject();
    //        }
    //    }

    //    if (heldObj != null)
    //    {
    //        MoveObject();
    //    }

    //    void MoveObject()
    //    {
    //        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > .35f)
    //        {
    //            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
    //            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);

    //        }
    //    }
    //}


    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;

        }

    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
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
