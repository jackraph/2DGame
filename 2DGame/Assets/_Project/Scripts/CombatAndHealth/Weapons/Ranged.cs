using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour, IUsable
{
    [Tooltip("Attach the arrow prefab here.")]
    [SerializeField] private GameObject arrowPrefab;

    public  void OnUse()
    {
        //Shoot an arrow at mouse position.
    }

    public void OffUse()
    {
        
    }
}
