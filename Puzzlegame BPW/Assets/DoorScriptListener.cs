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
            deur.transform.position += new Vector3((float)-0.6, (float)0.6, (float)0.4);
            //Destroy(door);
            Debug.Log("deur gaat open");
        }
    }

}
