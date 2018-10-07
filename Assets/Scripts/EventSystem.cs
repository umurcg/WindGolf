using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Basic event system for whole game
public class EventSystem : MonoBehaviour
{
    public delegate void GameAction();

    //Kick event that will be triggered when ball is kicked by user
    public static event GameAction OnKicked;
    public static event GameAction EnteredWindZone;

    public static void kick()
    {
        if(OnKicked!=null)
            OnKicked();
    }

    public static void enteredWind(){
        if (EnteredWindZone != null)
            EnteredWindZone();
    }
}
