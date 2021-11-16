using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour, IDamagable
{
    private Animator _anim;
    [SerializeField] private float touchDamage = 5;

    //Sub components.
    [SerializeField] private EnemyAI _ai = new EnemyAI();

    private Rigidbody2D _rb;
    private Health health;

    private void Awake()
    {
        //Initialize sub components.
        health = GetComponent<Health>();
        _rb = GetComponent<Rigidbody2D>();
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
        health.ChangeHealth(-amount);

        //Remove the enemy from scene when dead
        if(health.GetCurrHealth() <= 0)
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

    public void OnDrawGizmos()
    {
        foreach (Vector2 waypoint in _ai.waypoints)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(waypoint, 0.1f);
        }
    }
}
