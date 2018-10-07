using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveWind : Wind
{
    public float minSpeed = 0;

    //Speed multipliers multplies enter speed with the value
    public float speedMultiplier = 10;
    public float rotateSpeedMultiplier = 50;

    Vector3 rotateAxis;
    float rotateSpeed = 0;


    Vector3 prevBallPosition;

    protected override void activateWind(){
        rotateSpeed = enteredVelocity.magnitude;

        var ballDirection = enteredVelocity.normalized;
        var centerToBall = transform.position - ball.transform.position;
        var normalVector = Vector3.Project(ballDirection, centerToBall).normalized;
        var tangentVector = (ballDirection - normalVector).normalized;
        rotateAxis = Vector3.Cross(normalVector,tangentVector);

        TutorialController.instance.openTutorial("revolveWind");


    }

    private void Update()
    {
        if(windIsActive){

            //Rotate wind around center with wind radius
            var center = transform.position;
            ball.transform.RotateAround(center, rotateAxis, rotateSpeed * Time.deltaTime * rotateSpeedMultiplier);


            if (Input.GetMouseButton(1))
            {
                kickFromWindZone();
                windIsActive = false;
                return;
            }

            prevBallPosition = ball.transform.position;
        }
    }

    void kickFromWindZone(){


        var ballDirection = ball.transform.position - prevBallPosition;
        ballDirection.Normalize();

        //multiply that vector with rotateSpeed
        var kickVector = ballDirection * rotateSpeed*speedMultiplier;

        //release ball
        var ballRG = ball.GetComponent<Rigidbody>();
        ballRG.isKinematic = false;
        ballRG.AddForce(kickVector);

        TutorialController.instance.closeTutorial();

    }


}
