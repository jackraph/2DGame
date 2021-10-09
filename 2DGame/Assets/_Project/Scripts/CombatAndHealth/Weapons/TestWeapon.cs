using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a simple weapon that will enable and disable it's collider/hitbox on use.
public class TestWeapon : MonoBehaviour, IUsable
{
    [Tooltip("Collider that will check for enemies on attack.")]

    [SerializeField] private float damageValue = 10;
    [SerializeField] private float activeTime = 5;
    
    private BoxCollider2D _collider;
    private bool _active = false;
    private float _remainingTime = 0f;
    
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _collider.enabled = false;
    }

    private void Update()
    {
        //VERY clumsy way of timing active frames, probably better ways of timing.
        if(_active)
        {
            _remainingTime -= Time.deltaTime;
            if(_remainingTime <= 0)
            {
                _collider.enabled = false;
                _active = false;
            }
        }
    }
    public void OnUse()
    {
        //Debug message if a hitbox hasnt been assigned to the weapon
        if(!_collider)
        {
            Debug.Log("Please assign a BoxCollider2D to the hitbox field of TestWeapon");
            return;
        }
        if(!_active)
        {
            //Activate the weapons collider.
            _collider.enabled = true;
            
            //Set timer for collider active period
            _remainingTime = activeTime;
            _active = true;
        }
    }

    public void OffUse()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// If collision occurs with an object that implements IDamagable interface call that interface to apply damage.
    /// This is so we don't have to do string checks for the tags of all damagable things in the game.
    /// Anything that implements IDamagable will now interact with this weapon on collision.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D target)
    {
        IDamagable damagable = target.GetComponent<IDamagable>();
        damagable?.TakeDamage(damageValue);

    }
}
