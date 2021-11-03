using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Overhauled this controller to use a composite pattern and the new input system.
//Better encapsulation and more flexible/extendable.
[RequireComponent(typeof(Rigidbody2D))]
public class CController : MonoBehaviour, IModifiable
{
    //Sub Components.
    [SerializeField] private CharacterInputHandler input = new CharacterInputHandler();
    [SerializeField] private CArms arms = new CArms();
    [SerializeField] private CHands hands = new CHands();
    [SerializeField] private CMotor motor = new CMotor();
    

    private void Awake()
    {
        //Initialize sub-components. Done instead of using constructor as these are serialized in the editor.
        arms.Initialize(this);
        hands.Initialize(this, input);
        motor.Initialize(this, input);
    }

    void Update()
    {
        //Update sub components.
        input.Update();
        arms.Update();
        hands.Update();
    }

    void FixedUpdate()
    {
        //Update physics based sub components.
        motor.Update();
    }

    public void Mod_Fire()
    {
        //Access appropriate sub components and apply modifiers to their coefficients.
    }

    public void Mod_FastForward()
    {
        //Access appropriate sub components and apply modifiers to their coefficients.
    }
}
