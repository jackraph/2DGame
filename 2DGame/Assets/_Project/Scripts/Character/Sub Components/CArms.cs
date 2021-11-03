using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CArms 
{
    [SerializeField] private Transform arms;
    private LineRenderer _armLine;
    private CController _cc;
    
    [SerializeField] private float armLength;

    /// <summary>
    /// This coefficient is accessed by the mandatory IModifiable methods in the controller class.
    /// </summary>
    public float ArmLengthCoEfficient { get; set; }

    /// <summary>
    /// Serves the role of a constructor as this class is serializable in the editor.
    /// </summary>
    public void Initialize(CController cc)
    {
        _cc = cc;
        _armLine = _cc.GetComponent<LineRenderer>();
        ArmLengthCoEfficient = 1;
    }

    /// <summary>
    /// Update method for this class. Called by the controller where appropriate.
    /// </summary>
    public void Update()
    {
        //Get mouse position as a point in world space.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //Get this pos as a vector2.
        Vector2 pos = _cc.transform.position;
        
        //Get the direction to the mouse clamped to the defined hand radius.
        Vector2 dirToMouse = Vector2.ClampMagnitude(mousePos - pos, armLength);
        
        //Update the position of the hand to be in the direction of the mouse (from the player.)
        arms.transform.position = pos + dirToMouse;

        //Flip sprite based on direction to mouse.
        if (dirToMouse.x > 0)
        {
            _cc.transform.localScale = Vector3.one;
            arms.transform.right = dirToMouse;
        } 
        else if (dirToMouse.x < 0)
        {
            _cc.transform.localScale = new Vector3(-1, 1, 1);
            arms.transform.right = -dirToMouse;
        }
        //~~~~~~~~~~~~~~~~~~~
        
        //Update arm line renderer.
        _armLine.SetPosition(0, pos);
        _armLine.SetPosition(1, dirToMouse + pos);
    }
    
}
