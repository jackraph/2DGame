using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private AudioSource audio;
    [SerializeField] private float healAmount;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    //Messy but quick.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null && collision.gameObject.CompareTag("Player"))
        {
            audio.Play();
            damagable.TakeDamage(-healAmount);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject, 5);
        }
    }
}
