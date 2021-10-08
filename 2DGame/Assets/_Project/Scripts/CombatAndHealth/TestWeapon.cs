using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a simple weapon that will enable and disable a hitbox on use.
public class TestWeapon : MonoBehaviour, IUsable
{
    [Tooltip("Collider that will check for enemies on attack.")]
    //In a proper weapon implementation that is attached to the character this will need to either move with character facing direction or have multiple hit boxes for each viable attack angle
    public BoxCollider2D hitbox;

    public float damageValue = 10;
    public float activeTime = 5;
    public SpriteRenderer hitboxVisual;
    private bool active = false;
    private float remainingTime = 0f;
    private void Awake()
    {
        hitbox.enabled = false;
    }

    private void Update()
    {
        //VERY clumsy way of timing active frames, probably better ways of timing.
        if(active)
        {
            remainingTime -= Time.deltaTime;
            //Disable when timer expires
            if(remainingTime <= 0)
            {
                hitbox.enabled = false;
                active = false;

                hitboxVisual.enabled = false;
            }
        }
    }
    public void OnUse()
    {
        //Debug message if a hitbox hasnt been assigned to the weapon
        if(!hitbox)
        {
            Debug.Log("Please assign a BoxCollider2D to the hitbox field of TestWeapon");
            return;
        }
        if(!active)
        {
            
            //Activate the hitbox, this will apply damage to overlapping Enemy tagged objects
            hitbox.enabled = true;
            //Set timer for hitbox active period
            remainingTime = activeTime;
            active = true;

            hitboxVisual.enabled = true;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        //Apply damage to all objects tagged as Enemy in the editor
        if(target.tag == "Enemy")
        {
            target.GetComponent<Enemy>().TakeDamage(damageValue);
            Debug.Log("Enemy Detected");
        }
    }
}
