using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    //private Animator anim;

    public float moveSpeed;
    private Vector3 moveDirection;
    //private Vector2 turn;
    //public float sensitivity = .5f;
    //public Vector3 deltaMove;
    //public float speed = 1;


    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        //turn.x += Input.GetAxis("Mouse X") * sensitivity;
        //turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        //transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * Time.deltaTime);
    }
}
