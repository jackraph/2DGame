using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        _anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x != 0 && y != 0)
        {
            _anim.SetBool("Diagonal", true);  
        }
        else
        {
            _anim.SetBool("Diagonal", false);
        }
    }
}
