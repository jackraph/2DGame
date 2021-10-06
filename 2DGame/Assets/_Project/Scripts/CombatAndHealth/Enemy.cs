using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [Tooltip("Attach a scriptable object.")]
    [SerializeField]
    private EnemySO _enemySO;
    
    
    private Animator _anim;
        
    
    void Start()
    {
        //Randomly offset the idle animation of they arent synced if multiple enemies exist.
        _anim = GetComponent<Animator>();
        float randomOffset = Random.Range(0, _anim.GetCurrentAnimatorStateInfo(0).length);
        _anim.Play("Blob-Squeeze", 0, randomOffset);
    }

    public void TakeDamage(float amount)
    {
        
    }
}
