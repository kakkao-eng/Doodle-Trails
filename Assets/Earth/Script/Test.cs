using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    
    bool alive = true;
    
    public float speed;
    public Rigidbody rb;
    
    float horizontalInput;
    public float horizontalMultiplier;

    public void FixedUpdate()
    {
        if (!alive) return;
        
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
        
    }

    public void Die()
    {
        alive = false;
        //Restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
