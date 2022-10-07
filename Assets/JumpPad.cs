using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject Ball;
    Vector3 direction;
    Vector3 straight;
    public float jumpforce = 20f;
    
   
    void Start()
    {
        
    }
    private void Update()
    {
        direction = transform.TransformDirection(Vector3.up * jumpforce);
        
    }
    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.collider.tag == "Ball")
        {
            Ball = Collision.gameObject;

            Ball.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
            Ball.GetComponent<Rigidbody>().AddForce(0, 0, 65);
        }
    }

  

}

