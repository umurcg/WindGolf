using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptPanelController : MonoBehaviour
{
    //Singleton class
    public static PromptPanelController instance = null;

    public Text textContent;
    public Button button;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        PromptPanelController.instance = this;

        disablePanel();

    }

    private void Update()
    {
  
    }

    public void quitPanel(){
        gameObject.SetActive(true);
        textContent.text = "Are you sure you want to quit?";
        button.GetComponentInChildren<Text>().text = "Quit Game";

        button.onClick.AddListener(delegate {
            GameController.instance.exitGame();
            button.onClick.RemoveAllListeners();
            disablePanel();

        });
    }

    public void disablePanel(){
        textContent.text = "";
        button.GetComponentInChildren<Text>().text = "";
        gameObject.SetActive(false);
    }

    public void restartLevelPanel(string Reason){


        print("Restart Level");
        gameObject.SetActive(true);

        textContent.text = Reason;
        button.GetComponentInChildren<Text>().text = "Restart Level";


        button.onClick.AddListener( delegate {
            GameController.instance.resetLevel();
            button.onClick.RemoveAllListeners();
            disablePanel();

        } );

    }

    public void nextLevel(){

        gameObject.SetActive(true);
        textContent.text = "Yeaay! You have completed the level.";
        button.GetComponentInChildren<Text>().text = "Next Level";
    
        button.onClick.AddListener(delegate {
            GameController.instance.loadNextLevel();
            button.onClick.RemoveAllListeners();
            disablePanel();

        });

    }

    public void winPanel(){

        gameObject.SetActive(true);
        textContent.text = "Yeaay! You have completed all levels.";
        button.GetComponentInChildren<Text>().text = "Quit Game";

        button.onClick.AddListener(delegate {
            GameController.instance.exitGame();
            button.onClick.RemoveAllListeners();
            disablePanel();

        });

    }




}
