using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jump = 3f;
    public GameObject player;
    public Camera Vue;

    public float groundD = 0.4f;
    public Transform GroundCheck;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {


        isGrounded = Physics.CheckSphere(GroundCheck.position, groundD, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            player.transform.localScale -= new Vector3(0, 0.5f, 0);
            Vue.transform.localPosition-= new Vector3(0, 0.5f, 0);
            controller.height -= 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            player.transform.localScale += new Vector3(0, 0.5f, 0);
            Vue.transform.localPosition += new Vector3(0, 0.5f, 0);
            controller.height += 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}
