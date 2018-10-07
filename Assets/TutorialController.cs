using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct tutorialString
{
    public string key;
    public string value;
}

public class TutorialController : MonoBehaviour
{

    //Singleton class
    public static TutorialController instance=null;

    RectTransform rt;
    public Text content;


    public float transitionSpeed = 1f;
    public float width = 170;
    public tutorialString[] Tutorials;
    
    float currentWidth = 0;

    enum transition{
        none,
        opening,
        closeing,
    }

    transition transitionState = transition.none;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        TutorialController.instance = this;

        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transitionState==transition.opening){

            if (currentWidth < width)
            {
                currentWidth += transitionSpeed * Time.deltaTime;
                rt.sizeDelta = new Vector2(currentWidth,rt.rect.height);
            }
            else
            {
                transitionState = transition.none;
            }
        }else if(transitionState==transition.closeing){
            if (currentWidth >0)
            {
                currentWidth -= transitionSpeed * Time.deltaTime;
                rt.sizeDelta = new Vector2(currentWidth, rt.rect.height);
            }
            else
            {
                transitionState = transition.none;
            }
        }
        
    }

    public void openTutorial(string key){
        string tutorial = null;
        for (int i = 0; i<Tutorials.Length;i++){
            if (Tutorials[i].key == key)
            {
                
                tutorial = Tutorials[i].value;
            }
        }

        if(tutorial==null){
            print("Key doesnt exist");
            return;
        }

        content.text = tutorial;

        transitionState = transition.opening;


    }

    public void closeTutorial(){

        transitionState = transition.closeing;

    }


}
