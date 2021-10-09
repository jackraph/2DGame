using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [Tooltip("")]
    [SerializeField] private GameObject[] holdableStuff;

    private IUsable _equipped;
    private Animator _anim;

    private void Start()
    {
        _equipped = holdableStuff[0].GetComponent<IUsable>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _equipped.OnUse();
            _anim.SetBool("Active", true);
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            _equipped.OffUse();
            _anim.SetBool("Active", false);
        }
    }
}
