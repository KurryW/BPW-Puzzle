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

    public AudioSource nextlevelSound;

    [SerializeField] private Vector3 doorOpenOffset;
    [SerializeField] private Vector3 raketOpenOffset;

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
            nextlevelSound.enabled = true;
            //deur.transform.position += new Vector3((float)-0.6, (float)0.5, (float)0.4);
            deur.gameObject.SetActive(true);
            raket.gameObject.SetActive(true);
            //raket.transform.position += new Vector3((float)0, (float)4, (float)-6);
            //raket.transform.position += raketOpenOffset;
            //Destroy(door);
            Debug.Log("deur gaat open");
        }

        //else if(shouldDoorOpen == false)
        //{
        //    door.transform.position = standardLocationDoor;
        //}
    }

}
