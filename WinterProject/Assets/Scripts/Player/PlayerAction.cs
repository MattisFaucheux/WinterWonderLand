using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : Player
{
    public CharacterController controller;
    public float playerSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public LayerMask ammoMask;
    public float interactRange = 5f;
    public Camera playerCam;

    public LayerMask gunMask;
    public WeaponSwitch weaponSwitch;


    public KeyCode sprint;
    public KeyCode interract;

    private Vector3 velocity;



    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(sprint) && isGrounded)
        {
            controller.Move(move * playerSpeed * Time.deltaTime * sprintSpeed);
        }
        else
        {
            controller.Move(move * playerSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(interract))
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, interactRange, ammoMask))
            {
                lightCharger = maxLightCharger;
                mediumCharger = maxMediumCharger;
                heavyCharger = maxHeavyCharger;
                grenade = maxGrenade;
            }

            RaycastHit hit;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, interactRange, gunMask))
            {
                GameObject gm = hit.transform.gameObject;
                weaponSwitch.PickupWeapon(gm);
            }
        }
    }
}
