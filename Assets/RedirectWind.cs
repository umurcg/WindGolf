using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectWind : Wind
{
    public float lerpSpeed = 2.0f;
    ArrowController ac;

    BallController ballCont;

    bool waitForKick = false;

    protected override void activateWind()
    {
        StartCoroutine(lerpBallToCenter());
        ballCont = ball.GetComponent<BallController>();
        ac = ballCont.arrowController;


        TutorialController.instance.openTutorial("kickWind");

    }


    // Update is called once per frame
    void Update()
    {
        if(waitForKick && Input.GetMouseButton(1)){
            ballCont.kick();
            waitForKick = false;
            TutorialController.instance.closeTutorial();
        }
        
    }

    IEnumerator lerpBallToCenter(){

        var ratio = 0.0f;

        var initialPos = ball.transform.position;
        var aim = transform.position;

        while(ratio<1){
            ratio += Time.deltaTime;
            ball.transform.position = Vector3.Lerp(initialPos, aim, ratio);
            yield return null;
        }

        ball.transform.position = aim;

        //At the end of lerping enable arrow controller for next kick
        ac.Activate();
        waitForKick = true;

        yield break;
    }
}
