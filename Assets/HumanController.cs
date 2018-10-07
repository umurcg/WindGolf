using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HumanController : MonoBehaviour
{
    public BallController ballController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
            GetComponent<Animator>().SetTrigger("kick");
    }

    //Kick ball event will be called by animation clip when the right time comes
    //To synchrinize with movement of gold rod and kick action
    public void kickBall(){
        ballController.kick();
    }

}
