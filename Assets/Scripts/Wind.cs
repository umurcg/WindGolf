using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Wind is an abstract for wind object
//When ball enters in the field of wind 
abstract public class Wind : MonoBehaviour
{
    //Speed of ball when entered to wind zone
    protected Vector3 enteredVelocity;

    protected bool windIsActive = false;
    protected GameObject ball;

    protected abstract void activateWind();


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball"){
     
            ball = other.gameObject;

            var ballRb = other.GetComponent<Rigidbody>();
            enteredVelocity = ballRb.velocity;
            EventSystem.enteredWind();


            windIsActive = true;
            activateWind();

        }

    }
    


}
