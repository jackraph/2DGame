using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CArm
{
    private CController _cc;
    private CharacterInputHandler _input;
    private LineRenderer _armLine;
    
    [SerializeField] private GameObject arm;
    [SerializeField] private float armLength;

    /// <summary>
    /// This coefficient is accessed by the mandatory IModifiable methods in the controller class.
    /// </summary>
    public float ArmLengthCoEfficient { get; set; }
    
    public void Initialize(CController cc, CharacterInputHandler input)
    {
        _cc = cc;
        _input = input;
        
        _armLine = _cc.GetComponent<LineRenderer>();
        ArmLengthCoEfficient = 1;
    }
    
    public void Update()
    {
        Vector2 bodyPos = _cc.transform.position;
        
        //Determine direction of the body to the hand position provided by the input provider.
        Vector2 dirToHand = Vector2.ClampMagnitude(_input.Hand - bodyPos, armLength);
        Vector2 armPos = bodyPos + dirToHand;
        arm.transform.position = armPos;
        
        //Update arm line renderer.
        _armLine.SetPosition(0, bodyPos);
        _armLine.SetPosition(1, armPos);
        
        arm.transform.right = dirToHand;
    }
    
    public void ChangeScale(Vector3 newScale)
    {
        arm.transform.localScale = newScale;
       
    }
}
