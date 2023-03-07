using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorScriptListener : MonoBehaviour
{
    [SerializeField] GameObject deur;
    [SerializeField] GameObject raket;

    bool isOpened = false;
    
    public List<DoorTrigger> Doortriggers;
    public UnityEvent OnDoorOpen;
    public GameObject door;
    private Vector3 standardLocationDoor;

    public void Start()
    {
        standardLocationDoor = door.transform.position;
    }
    public void SetTriggerState()
    {
        bool shouldDoorOpen = true;
        foreach (DoorTrigger trigger in Doortriggers)
        {
            shouldDoorOpen &= trigger.doWeHaveTheRightBlock;

        }

        if(shouldDoorOpen)
        {
            OnDoorOpen?.Invoke();
            deur.transform.position += new Vector3((float)-0.6, (float)0.5, (float)0.4);
            raket.transform.position += new Vector3((float)0, (float)4, (float)-6);
            //Destroy(door);
            Debug.Log("deur gaat open");
        }

        else if(shouldDoorOpen == false)
        {
            door.transform.position = standardLocationDoor;
        }
    }

}
