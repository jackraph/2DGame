using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IUsable, IDamagable
{
    private BoxCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audio;
    
    [SerializeField]
    private Color defaultColour;

    [SerializeField]
    private Color onHitColour;

    [SerializeField]
    private float colourChangeTime = 0.1f;

    private bool isTiming;
    private float remainingTime;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
        isTiming = false;

    }

    void Awake()
    {
        isTiming = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Colour change timer
        if(isTiming)
        {
            remainingTime -= Time.deltaTime;
            if(remainingTime <= 0)
            {
                Debug.Log("Reset Colour");
                isTiming = false;

                _spriteRenderer.color = defaultColour;

                
            }
        }
    }

    public void OnUse()
    {
        //Not specifically utilized at enabling the gameObject effectively handles activation logic at this point
    }

    public void OffUse()
    {

    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Shield Hit");

        remainingTime = colourChangeTime;
        isTiming = true;

        _spriteRenderer.color = onHitColour;
        _audio.Play();
    }
}
