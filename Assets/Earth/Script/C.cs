using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    public Transform player;
     Vector3 offset;
    
    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = player.position + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
