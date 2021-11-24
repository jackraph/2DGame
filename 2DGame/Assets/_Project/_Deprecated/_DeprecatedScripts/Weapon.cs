using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base weapon class. 
public abstract class Weapon : MonoBehaviour, IUsable, IModifiable
{
    public enum WeaponType
    {
        Axe,
        Sword,
        Bow,
        Projectile,
        Shield
    }

    public virtual void OnUse()
    {
        
    }

    public virtual void OffUse()
    {
       
    }

    public virtual UsableType GetUsableType()
    {
        return UsableType.RANGED;
    }

    #region Modifier System


    public virtual void Mod_Fire()
    {
        
    }

    public virtual void Mod_FastForward()
    {
        
    }
    
    #endregion

}
