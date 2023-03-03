using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 moveDirection;

    public float turnSpeed = 100.0f;

    private Animator anim;


    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

        if (moveDirection == Vector3.zero)
        {
            anim.SetInteger("AnimationPar", 0);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("AnimationPar", 1);
        }


    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * Time.deltaTime);
    }
}
