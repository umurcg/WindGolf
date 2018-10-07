using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        //When ball exists field reset level
        if (other.tag == "ball")
            PromptPanelController.instance.restartLevelPanel("Your ball is out of field."); 
    }
}
