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

    private Health health;
    private Animator anim;
    private AudioSource audio;



    private void Awake()
    {
        //Initialize sub-components. Done instead of using constructor as these are serialized in the editor.
        body.Initialize(this, input);
        motor.Initialize(this, input);

        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Update sub components.
        input.Update();
        body.Update();

        if(Mathf.Abs(input.Movement.x) > 0)
        {
            anim.SetFloat("MovementAbsolute", Mathf.Abs(input.Movement.x));
            audio.volume = 0.4f;
        } else if (Mathf.Abs(input.Movement.y) > 0)
        {
            anim.SetFloat("MovementAbsolute", Mathf.Abs(input.Movement.y));
            audio.volume = 0.4f;
        } else
        {
            anim.SetFloat("MovementAbsolute", 0);
            audio.volume = 0;
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
        health.ChangeHealth(-amount);
    }
}
