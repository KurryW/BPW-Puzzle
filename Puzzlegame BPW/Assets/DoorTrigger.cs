using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent triggerPressed;

    public GameObject Blokje;

    public bool doWeHaveTheRightBlock = false;

    void Start()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Blokje)
        {
            Debug.Log("ik heb mijn blokje");
            triggerPressed?.Invoke();
            doWeHaveTheRightBlock = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Blokje)
        {
            Debug.Log("ik heb mijn blokje niet meer");
            doWeHaveTheRightBlock = false;
        }

    }
 
}
