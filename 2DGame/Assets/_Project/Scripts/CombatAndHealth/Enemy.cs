using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _anim;
        
        
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        float randomOffset = Random.Range(0, _anim.GetCurrentAnimatorStateInfo(0).length);
        _anim.Play("Blob-Squeeze", 0, randomOffset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
