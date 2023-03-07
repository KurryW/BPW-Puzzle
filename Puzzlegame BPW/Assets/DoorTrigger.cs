using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent triggerPressed;

    [SerializeField] private bool putBlockOnTrigger = false;

    public GameObject Blokje;
    public Material colorGreen;
    public Material colorRed;

    public bool doWeHaveTheRightBlock = false;



    private void OnValidate()
    {
        if (putBlockOnTrigger)
        {
            Blokje.transform.position = transform.position + transform.up*2;
        }
    }

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
