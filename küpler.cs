using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class küpler : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    public GameObject player;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("karakter");
    }
   
    private void OnMouseDown()
    {
        if(!player.GetComponent<Player>().elinde)
        {
            
           transform.position = target.position;
           gameObject.transform.SetParent(target.transform, true);
           rb.isKinematic = true;
        }
       
    }
}
