using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//First level additionaly has a brief tutorial bfeore starting to game
//So disable required scripts and wait for user to click mouse to pass brief tutorial
public class BriefTutorial : MonoBehaviour
{
    public string tutortialKey = "brief";
    public BallController ballController;
    

    private void Awake()
    {
        if(GameController.instance!=null && GameController.instance.isBriefShowed){
            startGame();
            Destroy(gameObject);
            return;
        }

        ballController.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        TutorialController.instance.openTutorial(tutortialKey);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            TutorialController.instance.closeTutorial();

            GameController.instance.isBriefShowed = true;

            //Start game after a second
            Invoke("startGame", 1.0f);
            enabled = false;

        }
    }

    void startGame(){
        ballController.enabled = true;
    }

}
