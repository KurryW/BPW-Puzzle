using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent triggerPressed;

    public GameObject Blokje;
    public Material colorGreen;
    public Material colorRed;

    public bool doWeHaveTheRightBlock = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Blokje)
        {
            Debug.Log("ik heb mijn blokje");
            triggerPressed?.Invoke();
            doWeHaveTheRightBlock = true;
            Blokje.GetComponent<Renderer>().material.color = Color.green;

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Blokje)
        {
            Debug.Log("ik heb mijn blokje niet meer");
            doWeHaveTheRightBlock = false;
            Blokje.GetComponent<Renderer>().material.color = Color.red;
        }

    }
 
}
