using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private AudioSource source;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * 20f;
        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        IDamagable damagable = target.GetComponent<IDamagable>();
        damagable?.TakeDamage(damage);
        
        //Play collision sound.
        //source.Play();
        
        //Show collision effect.
        
        //Destroy(this.gameObject);
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
    }
}
