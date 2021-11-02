using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerArms 
{
    [SerializeField] private Transform arms;
    [SerializeField] private float handRadius;
    private LineRenderer _armLine;
    private PlayerController _pc;

    public void Initialize(PlayerController pc)
    {
        _pc = pc;
        _armLine = _pc.GetComponent<LineRenderer>();
    }

    public void Update()
    {
        //Get mouse position as a point in world space.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //Get this pos as a vector2.
        Vector2 pos = _pc.transform.position;
        
        //Get the direction to the mouse clamped to the defined hand radius.
        Vector2 dirToMouse = Vector2.ClampMagnitude(mousePos - pos, handRadius);
        
        //Update the position of the hand to be in the direction of the mouse (from the player.)
        arms.transform.position = pos + dirToMouse;

        //Flip sprite based on direction to mouse.
        if (dirToMouse.x > 0)
        {
            _pc.transform.localScale = Vector3.one;
            arms.transform.right = dirToMouse;
        } 
        else if (dirToMouse.x < 0)
        {
            _pc.transform.localScale = new Vector3(-1, 1, 1);
            arms.transform.right = -dirToMouse;
        }
        //~~~~~~~~~~~~~~~~~~~
        
        //Update arm line renderer.
        _armLine.SetPosition(0, pos);
        _armLine.SetPosition(1, dirToMouse + pos);
    }
    
}
