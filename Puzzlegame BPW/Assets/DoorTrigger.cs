using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent triggerPressed;

    [SerializeField] private bool putBlockOnTrigger = false;

    [SerializeField] GameObject vinkje2;
    [SerializeField] GameObject letterInDot;
    [SerializeField] GameObject Dot;

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
            letterInDot.gameObject.SetActive(true);
            Destroy(Dot);
            vinkje2.gameObject.SetActive(true);

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
