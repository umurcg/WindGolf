using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public ArrowController arrowController;
    Rigidbody rb;

    public float stopVelocity = 0.01f;
    public float resetTime = 4;

    float timer = 0;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        //Assing event that disables rb when ball is entered to wind
        EventSystem.EnteredWindZone += stopBall;


    }

    private void Start()
    {
        TutorialController.instance.openTutorial("kick");
    }

    private void OnDestroy()
    {
        EventSystem.EnteredWindZone -= stopBall;
    }

    void stopBall(){
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

    private void Update()
    {
        if(timer>resetTime){
            PromptPanelController.instance.restartLevelPanel("Your ball has lost all the velocity.");
            this.enabled = false;
        }

        //When ball is kicked isKinematic must be false
        //in that condition script will check weather or not ball is below stop velocity and 
        //start timer for reseting level
        if(rb.isKinematic==false && rb.velocity.magnitude < stopVelocity)
        {
           timer += Time.deltaTime;
        }else{
            timer = 0;
        }
    }


    public void kick(){

        print("ball is kicked");

        //Get speed and direction of kick from arrow controller
        var speed = arrowController.getSpeed();
        var direction = arrowController.getDirection();

        rb.isKinematic = false;
        rb.AddForce(direction * speed );

        EventSystem.kick();

        TutorialController.instance.closeTutorial();
    }
}
