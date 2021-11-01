using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class manages the application of modifiers.
//There should be two objects in the scene with this component, an enemy manager and a player manager
//Applicable objects should be parented to that manager


public class ModifierManager : MonoBehaviour
{
    [SerializeField]
    [TooltipAttribute("Name of the modifier to be called on debug button")]
    private string debugModifier = "Mod_NameHere";

    [SerializeField]
    [TooltipAttribute("Button to call debug modifier")]
    private KeyCode debugButton = KeyCode.None;
    //This is the list of modifiers that the manager can pull from
    //These should be named exactly as they are in the Modifiable interface
    //As the manager calls those methods by name via Broadcast calls
    

    [SerializeField]
    private string[] validModifiers = {
        "Mod_Fire", 
        "Mod_FastForward"
        };


    //The list of modifiers to be applied to either enemies or the player
    private string[] activeModifiers = {};

    //This will broadcast all active modifiers to every object that has this manager as its parent
    public void BroadCastAll()
    {
        foreach(string modifier in activeModifiers)
        {
            BroadcastMessage(modifier);
        }

        
    }

    public void Update()
    {
        if(Input.GetKeyDown(debugButton))
        {
            DebugModTest();
        }
    }

    private void DebugModTest()
    {
        BroadcastMessage(debugModifier);
    }
}
