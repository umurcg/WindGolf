using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //When balls enter to en point trigger pass to next level
        if (other.tag == "ball")
        {
            var gc = GameController.instance;

            print(gc.isLastLevel());
            if (gc.isLastLevel())
                PromptPanelController.instance.winPanel();
            else
                PromptPanelController.instance.nextLevel();

            //Disable ball rwhile update function of ball controller
            //detecs ball is stoped and tries to prompt lost condition
            other.gameObject.SetActive(false);
            //var ballController = other.GetComponent<BallController>();
            //if(ballController){
            //    Debug.LogError("Ball controller doesnt exist in ball");
            //    ballController.enabled = false;
            //}


        }
        
    }
}
