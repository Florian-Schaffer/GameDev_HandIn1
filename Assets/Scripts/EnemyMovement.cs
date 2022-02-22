using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform spawnPos;
    public Transform playerPos;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPos.position;
        transform.LookAt(playerPos.position);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        Vector3 move = transform.forward * 2f;

        var player = GameObject.FindWithTag("Player");

        var distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance > 15){
            controller.Move(move * speed * Time.deltaTime);
        }

        if(distance > 2){
            controller.Move(move * speed*2 * Time.deltaTime);
        }


    }
}
