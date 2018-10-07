using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    //Singleton class
    public static GameController instance = null;

    public int numberOfLevel = 3;

    int currentLevel=-1;

    public bool isBriefShowed = false;

    bool quitIsOpened = false;

    // Start is called before the first frame update
    void Awake()
    {
        //If there is an instance of game controller destroy this
        if (GameController.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;

        currentLevel = SceneManager.GetActiveScene().buildIndex;

        DontDestroyOnLoad(this);

    }

    public int getCurrentLevel(){
        return currentLevel;
    }

    public void loadNextLevel(){
        if(isLastLevel()){
            print("All levels are finished");
        }else{
            currentLevel += 1;
            loadLevel(currentLevel);
        }
    }

    public bool isLastLevel(){
        return currentLevel == numberOfLevel;
    }

    public void resetLevel(){
        loadLevel(currentLevel);
    }

 
    void loadLevel(int level){

        SceneManager.LoadScene(level);
    }

    private void Update()
    {
        var prompt = PromptPanelController.instance;
        if (prompt != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                if (quitIsOpened)
                {
                    prompt.disablePanel();
                    quitIsOpened = false;
                }
                else
                {
                    prompt.quitPanel();
                    quitIsOpened = true;
                }
        }
    }

    public void exitGame(){
        Application.Quit();
    }

}
