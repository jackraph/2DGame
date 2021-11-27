using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class manages the application of modifiers.
//There should be two objects in the scene with this component, an enemy manager and a player manager
//Applicable objects should be parented to that manager


public class ModifierManager : MonoBehaviour
{
    [SerializeField]
    private bool isPlayerModManager = false;

    [SerializeField]
    [TooltipAttribute("Name of the modifier to be called on debug button")]
    private string debugModifier = "Mod_NameHere";

    [SerializeField]
    [TooltipAttribute("Button to call debug modifier")]
    private KeyCode debugModActivateInput = KeyCode.None;
    [SerializeField]
    [TooltipAttribute("Button to test the roll a modifier")]
    private KeyCode debugRollInput = KeyCode.None;
    //This is the list of modifiers that the manager can pull from
    //These should be named exactly as they are in the Modifiable interface
    //As the manager calls those methods by name via Broadcast calls
    

    [SerializeField]
    private string[] validModifiers = {
        "Mod_Fire", 
        "Mod_FastForward"
        };

    //Random modifiers will be pulled from this list and 
    private List<string> unusedModifiers = new List<string>();

    //The list of modifiers to be applied to either enemies or the player
    private List<string> activeModifiers = new List<string>();

    //This will broadcast all active modifiers to every object that has this manager as its parent
    public void BroadCastAll()
    {
        foreach(string modifier in activeModifiers)
        {
            BroadcastMessage(modifier);
        }

        
    }

    public void BroadcastSingle(string modifier)
    {
        BroadcastMessage(modifier);
    }

    public void Start()
    {
        unusedModifiers = new List<string>(validModifiers);
    }
    public void Update()
    {
        if(Input.GetKeyDown(debugModActivateInput))
        {
            DebugModTest();
        }

        if(Input.GetKeyDown(debugRollInput))
        {

            RollModifier();
        }
    }

    private void DebugModTest()
    {
        BroadcastMessage(debugModifier);
    }

    public void RollModifier()
    {
        if(unusedModifiers.Count <= 0)
        {
            Debug.Log("Out of Mods");
            return;
        }

        int modIndex = Random.Range(0, validModifiers.Length);
        string newMod = unusedModifiers[ modIndex ];

        activeModifiers.Add(newMod);
        unusedModifiers.Remove(newMod);                                                      

        if(isPlayerModManager)
        {
            BroadcastMessage(newMod);
        }

    }
}
