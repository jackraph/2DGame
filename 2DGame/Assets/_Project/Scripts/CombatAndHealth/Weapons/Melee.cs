using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour, IUsable, IModifiable
{
    [SerializeField] private float damage;
    private BoxCollider2D _collider;

    [SerializeField] private SpriteRenderer fireModSprite;
    private AudioSource _audio;

    [SerializeField] private float animLength = 0;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _audio = GetComponent<AudioSource>();
    }

    public void OnUse()
    {
        _collider.enabled = true;
        StartCoroutine(AnimCoroutine());
    }

    public void OffUse()
    {
        _collider.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D target)
    {
        IDamagable damagable = target.GetComponent<IDamagable>();
        damagable?.TakeDamage(damage);
        _audio.Play();
        
    }

    private IEnumerator AnimCoroutine()
    {
        yield return new WaitForSeconds(animLength);
        OffUse();
    }

    public UsableType GetUsableType()
    {
        return UsableType.MELEE;
    }

    public void Mod_Fire()
    {
        if(fireModSprite)
        {
            fireModSprite.enabled = true;
        }

        damage *= 2f;

        Debug.Log("Fire called");
    }

    public void Mod_FastForward()
    {

    }
}
