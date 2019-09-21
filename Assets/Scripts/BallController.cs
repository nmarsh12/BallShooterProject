using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb_ball;
    public GameObject aimGuide;
    public float ballSpeed;

    public bool ballMoving;

    // Start is called before the first frame update
    void Start()
    {
        rb_ball = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ballSpeed = rb_ball.velocity.magnitude;     

        stopBallDrift();
    }

    public void stopBallDrift() // slows the ball to a stop when the ball is going very slow
    {
        if (ballSpeed < 0.05f)
        {
            rb_ball.velocity *= 0.8f;
        }
        
    }

    public void StopBall() //immediately halts the ball movement
    {        
        rb_ball.isKinematic = true;
        rb_ball.isKinematic = false;       
    }


    public void ballShoot() // adds force to ball in a direction away from camera
    {
        rb_ball = this.GetComponent<Rigidbody>();
        aimGuide = GameObject.Find("AimGuide");
        rb_ball.AddForce(aimGuide.transform.forward * 25, ForceMode.VelocityChange);        
    }

    public bool isBallMoving() // Checks to see if the ball is still moving
    {
        if (ballSpeed > 0.05f)
        { return (true); }

        else
        { return (false); }
    }
    


}
