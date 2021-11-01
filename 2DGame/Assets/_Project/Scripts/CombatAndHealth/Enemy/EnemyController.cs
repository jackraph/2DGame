using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour, IDamagable
{
    private Animator _anim;
    [SerializeField] private float health = 20;
    [SerializeField] private float touchDamage = 5;

    //Sub components.
    [SerializeField] private EnemyAI _ai = new EnemyAI();

    private void Awake()
    {
        //Initialize sub components.
        _ai.Initialize(this);
    }

    private void Start()
    {
        //Randomly offset the idle animation of they arent synced if multiple enemies exist.
        _anim = GetComponent<Animator>();
        float randomOffset = Random.Range(0, _anim.GetCurrentAnimatorStateInfo(0).length);
        _anim.Play("Blob-Squeeze", 0, randomOffset);
    }

    private void FixedUpdate()
    {
       //Update sub components.
       _ai.Update();
    }

    public void TakeDamage(float amount)
    {
        //Basic take damage function for testing.
        health -= amount;

        Debug.Log("I took damage!");
        
        //Remove the enemy from scene when dead
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D hit)
    {
        //Debug.Log(hit.collider.gameObject.name);
        IDamagable damageComp = hit.collider.gameObject.GetComponent<IDamagable>();
        damageComp?.TakeDamage(touchDamage);
    }
    
}
