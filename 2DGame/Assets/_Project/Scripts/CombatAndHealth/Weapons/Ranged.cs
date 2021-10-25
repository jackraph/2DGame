using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour, IUsable
{
    [Tooltip("Attach the arrow prefab here.")]
    [SerializeField] private GameObject projectilePrefab;

    public  void OnUse()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    public void OffUse()
    {
        
    }
}
