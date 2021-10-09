using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform arms;
    [SerializeField] private float handRadius;

    void Update()
    {
        //Get mouse position as a point in world space.
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        //Get this pos as a vector2.
        Vector2 pos = transform.position;
        
        //Get the direction to the mouse clamped to the defined hand radius.
        Vector2 dirToMouse = Vector2.ClampMagnitude(mousePos - pos, handRadius);
        
        //Update the position of the hand to be in the direction of the mouse (from the player.)
        arms.transform.position = pos + dirToMouse;

        //Flip sprite based on direction to mouse.
        if (dirToMouse.x > 0)
        {
            transform.localScale = Vector3.one;
            arms.transform.right = dirToMouse;
        } 
        else if (dirToMouse.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            arms.transform.right = -dirToMouse;
        }
        //~~~~~~~~~~~~~~~~~~~
        
        //~~~~~~~~~~~~~~~~~~~
        if (Input.GetMouseButton(0))
        {
            //Swing action.
        }
        //~~~~~~~~~~~~~~~~~~~
    }
}
