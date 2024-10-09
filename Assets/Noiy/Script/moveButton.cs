using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveButton : MonoBehaviour
{
    [SerializeField] Rigidbody player;
    [SerializeField] int jumpHight;

    public void Start()
    {
      
    }
    public void jump()
    {Rigidbody  rb=player.GetComponent<Rigidbody>();
      rb.AddForce(transform.up * jumpHight) ;
        Debug.Log("JUMP");
       

    }
}
