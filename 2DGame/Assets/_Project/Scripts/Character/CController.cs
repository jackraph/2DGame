using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Overhauled this controller to use a composite pattern and the new input system.
//Better encapsulation and more flexible/extendable.
[RequireComponent(typeof(Rigidbody2D))]
public class CController : MonoBehaviour, IModifiable, IDamagable
{
    //Sub Components.
    [SerializeField] private CharacterInputHandler input = new CharacterInputHandler();
    [SerializeField] private CBody body = new CBody();
    [SerializeField] private CMotor motor = new CMotor();

    private HealthSystem health;
    private Animator anim;



    private void Awake()
    {
        //Initialize sub-components. Done instead of using constructor as these are serialized in the editor.
        body.Initialize(this, input);
        motor.Initialize(this, input);

        health = GetComponent<HealthSystem>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Update sub components.
        input.Update();
        body.Update();

        if(Mathf.Abs(input.Movement.x) > 0)
        {
            anim.SetFloat("MovementAbsolute", Mathf.Abs(input.Movement.x));
        } else if (Mathf.Abs(input.Movement.y) > 0)
        {
            anim.SetFloat("MovementAbsolute", Mathf.Abs(input.Movement.y));
        } else
        {
            anim.SetFloat("MovementAbsolute", Mathf.Abs(0));
        }
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

    public void TakeDamage(float amount)
    {
        health.HealthChange(-amount);
    }
}
