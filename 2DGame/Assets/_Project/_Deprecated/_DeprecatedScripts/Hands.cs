using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [Tooltip("")]
    [SerializeField] private GameObject[] holdableStuff;

    [Tooltip("Object to be activated on block input (Shield object)")]
    [SerializeField] private GameObject blockTool;

    private IUsable _equipped;
    private Animator _anim;
    private IUsable _equippedBlockTool;
    private int _currentEquipIndex;

    private void Start()
    {
        _equipped = holdableStuff[0].GetComponent<IUsable>();
        _anim = GetComponent<Animator>();
        _equippedBlockTool = blockTool.GetComponent<IUsable>();
        _currentEquipIndex = 0;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _equipped.OnUse();
            //anim.SetBool("Active", true);
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            _equipped.OffUse();
            //_anim.SetBool("Active", false);
        }

        //MouseWheel up/down check for weapon cycling
        if(Input.mouseScrollDelta.y > 0)
        {
            EquipNext();
        }

        if(Input.mouseScrollDelta.y < 0)
        {
            EquipPrevious();
        }

        //Right Click check for block action
        if(Input.GetMouseButtonDown(1))
        {
            StartBlock();
        }

        if(Input.GetMouseButtonUp(1))
        {
            EndBlock();
        }
    }

    //Method to call when cycling holdable index up
    private void EquipNext()
    {
        int newIndex = _currentEquipIndex + 1;
        if(newIndex > holdableStuff.Length - 1)
        {
            newIndex = 0;
        }

        holdableStuff[_currentEquipIndex].SetActive(false);
        holdableStuff[newIndex].SetActive(true);

        _currentEquipIndex = newIndex;
        _equipped = holdableStuff[_currentEquipIndex].GetComponent<IUsable>();
    }

    //Method to call when cycling holdable index down
    private void EquipPrevious()
    {
        int newIndex = _currentEquipIndex - 1;
        if(newIndex < 0)
        {
            newIndex = holdableStuff.Length - 1;
        }

        holdableStuff[_currentEquipIndex].SetActive(false);
        holdableStuff[newIndex].SetActive(true);

        _currentEquipIndex = newIndex;
        _equipped = holdableStuff[_currentEquipIndex].GetComponent<IUsable>();
    }

    private void StartBlock()
    {
        blockTool.SetActive(true);
        holdableStuff[_currentEquipIndex].SetActive(false);

        _equippedBlockTool.OnUse();

    }

    private void EndBlock()
    {
        blockTool.SetActive(false);
        holdableStuff[_currentEquipIndex].SetActive(true);

        _equippedBlockTool.OffUse();
    }
}