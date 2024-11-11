using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class moveButton : MonoBehaviour
{
    [SerializeField] Rigidbody player;
    [SerializeField] int jumpHight;
    [SerializeField] int moveHorizon;

    private PlayerInput PlayerInput;
    private bool groundedPlayer;
    

    private void Start()
    {
      
      PlayerInput = GetComponent<PlayerInput>();
        Rigidbody player = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (PlayerInput.actions["Jump"].triggered)
        { 
           player.AddForce(transform.up * jumpHight) ;
        Debug.Log("JUMP");

        }
        if (PlayerInput.actions["Left"].triggered && player.position.x >= -2 )
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - moveHorizon, transform.position.y, transform.position.z), Time.deltaTime*5);
        }

        if (PlayerInput.actions["Right"].triggered && player.position.x <=2)
        { 
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + moveHorizon, transform.position.y, transform.position.z), Time.deltaTime*5);
        }
       


    }
}
