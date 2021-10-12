using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    private Animator _anim;
    [SerializeField]
    private float health = 20;

    [SerializeField]
    private float touchDamage = 5;
    
    void Start()
    {
        //Randomly offset the idle animation of they arent synced if multiple enemies exist.
        _anim = GetComponent<Animator>();
        float randomOffset = Random.Range(0, _anim.GetCurrentAnimatorStateInfo(0).length);
        _anim.Play("Blob-Squeeze", 0, randomOffset);
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
        if(damageComp != null)
        {
            damageComp.TakeDamage(touchDamage);
        }
    }
}
