using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Overhauled this controller to use composite pattern and the new input system.
//Better encapsulation and more extendable.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IModifiable
{
    //Sub Components.
    [SerializeField] private PlayerArms arms = new PlayerArms();
    [SerializeField] private PlayerHands hands = new PlayerHands();
    [SerializeField] private PlayerMotor motor = new PlayerMotor();

    private void Awake()
    {
        //Initialize sub-components. Done instead of using constructor as these are serialized in the editor.
        arms.Initialize(this);
        hands.Initialize(this);
        motor.Initialize(this);
    }

    void Update()
    {
        //Update input.
        arms.Update();
        hands.Update();
    }

    void FixedUpdate()
    {
        motor.Update();
    }

    public void Mod_Fire()
    {

    }

    public void Mod_FastForward()
    {
        
    }

    public void OnDrawGizmos()
    {
        //Debugging stuff here.
    }
}
