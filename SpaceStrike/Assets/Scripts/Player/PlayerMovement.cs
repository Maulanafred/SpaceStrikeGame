using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;

    public Transform playercam;
    public float gravity = -9.81f;

    public float jumpHeight;

    private Vector3 player;

    public float speed;

    private bool ground;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

        playercam = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        ground = cc.isGrounded;

        if(ground && player.y < 0){
            player.y = 0;
        }

        if(Input.GetKeyDown(KeyCode.Space) && ground){
            player.y += Mathf.Sqrt(jumpHeight * -3f * gravity);
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        movement = movement.x * playercam.right + movement.z * playercam.forward;
        cc.Move(movement * Time.deltaTime * speed);

        //jump

        player.y += gravity * Time.deltaTime;
        cc.Move(player * Time.deltaTime);




        
    }

}
