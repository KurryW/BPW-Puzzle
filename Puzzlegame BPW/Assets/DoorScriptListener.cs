using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorScriptListener : MonoBehaviour
{
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
            Destroy(door);
            Debug.Log("deur gaat open");
        }
    }

}
