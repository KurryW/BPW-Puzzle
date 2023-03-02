using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorScriptListener : MonoBehaviour
{
    [SerializeField] GameObject deur;

    bool isOpened = false;
    
    public List<DoorTrigger> Doortriggers;
    public UnityEvent OnDoorOpen;
    public GameObject door;

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
            deur.transform.position += new Vector3(0, (float)0.05, (float)0.04);
            //Destroy(door);
            Debug.Log("deur gaat open");
        }
    }

}
