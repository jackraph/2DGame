using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// TODO finish implementing new input system with with class.
/// </summary>
[Serializable]
public class CHand
{
    private CController _cc;
    private CharacterInputHandler _input;
    private Animator _anim;
    private IUsable _equipped;
    private IUsable _equippedBlockTool;
    private int _currentEquipIndex;
    
    [SerializeField] private GameObject handObject;
    [SerializeField] private GameObject[] holdableStuff;
    [SerializeField] private GameObject blockTool;
    [SerializeField] private AudioClip soundSword;
    private AudioSource _audio;

    
    //----------------ANIMATION
    private string _currState;

    private void ChangeAnimationState(string newState)
    {
        if (_currState == newState) return;
        _anim.Play(newState);
        _currState = newState;
    }
    //----------------END ANIMATION
    public void Initialize(CController cc, CharacterInputHandler input)
    {
        _cc = cc;
        _input = input;
        _anim = handObject.GetComponent<Animator>();
        _equipped = holdableStuff[0].GetComponent<IUsable>();
        _equippedBlockTool = blockTool.GetComponent<IUsable>();
        _currentEquipIndex = 0;

    }
    
    public void Update()
    {
        if (_input.Attack)
        {
            _equipped.OnUse();
            Debug.Log("Pressed!");
            // TODO
            //Determine which animation to play based on the category of weapon being held.
            _anim.SetTrigger("Swing");
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
