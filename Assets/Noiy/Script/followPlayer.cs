using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private GameObject gos;
    private Vector3 num;
    // Start is called before the first frame update
    void Start()
    {
        gos = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(0, 0, gos.transform.position.z); ;
    }
    
}
