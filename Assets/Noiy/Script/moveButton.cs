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
    public  bool groundedPlayer;

    public Animator anim;
    private void Start()
    {
      
      PlayerInput = GetComponent<PlayerInput>();
        Rigidbody player = GetComponent<Rigidbody>();
        groundedPlayer = true;
        

    }
   
    private void Update()
    {
        if (PlayerInput.actions["Jump"].triggered && groundedPlayer == true)
        {
            player.AddForce(transform.up * jumpHight);
            Debug.Log("JUMP");
            

        }
        
        
        if (PlayerInput.actions["Left"].triggered && player.position.x >= -2 )
        {
            if(player.position.x >= 3 && player.position.x != 0)
            {
                transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
            }   
            else { transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);}
            
        }

        if (PlayerInput.actions["Right"].triggered && player.position.x <=2)
        {
            if (player.position.x <= -3 && player.position.x != 0)
            {
                transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
            }
            else
            { transform.position = new Vector3(3.5f, transform.position.y, transform.position.z); }
            
           
        }
       


    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            groundedPlayer = true;
           
                anim.SetBool("isJumping", false);

        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            groundedPlayer = false;
            anim.SetBool("isJumping", true);
        }

    }
    
}
