using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGuide : MonoBehaviour
{
    public GameObject ball;
    public GameObject meshHandler;

    private BallController _ballController;

    private void Start()
    {
        _ballController = ball.GetComponent<BallController>();
    }


    private void Update()
    {
        // turns off the guide when the ball is not moving.. 
        // bug where the guide will show while the ball reverses direction when its shot uphill..

        if (_ballController.isBallMoving() == true)
        {
            meshHandler.SetActive(false);
        }
        else
        {
            meshHandler.SetActive(true);
        }
    }


    void LateUpdate()
    {
        // match location to ball
        this.transform.position = ball.transform.position;        
        
        // Rotates aim guide around ball to match camera rotation
        Vector3 newRot = this.transform.eulerAngles;
        newRot.y = (Camera.main.transform.eulerAngles.y);
        this.transform.eulerAngles = newRot;
    }

   

}
