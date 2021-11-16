using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Would add code for changing outfits etc here.
/// </summary>
[Serializable]
public class CBody
{
    private CController _cc;
    private CharacterInputHandler _input;
    
    [SerializeField] private CArm arm = new CArm();
    [SerializeField] private CHand hand = new CHand();
    
    public void Initialize(CController cc, CharacterInputHandler input)
    {
        _cc = cc;
        _input = input;
        
        arm.Initialize(_cc, _input);
        hand.Initialize(_cc, _input);
    }

    public void Update()
    {
        arm.Update();
        hand.Update();

        Vector2 dirToHand = _input.Hand - (Vector2)_cc.transform.position;
         //Flip sprite based on direction to mouse.
         if (dirToHand.x > 0)
         {
             _cc.transform.localScale = Vector3.one;
             arm.ChangeScale(Vector3.one);
         } 
         else if (dirToHand.x < 0)
         {
            
             _cc.transform.localScale = new Vector3(-1, 1, 1);
             arm.ChangeScale(new Vector3(-1, -1, 1));
         }
    }
}
