using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple debug camera. Attach to main camera.
public class DebugCamera : MonoBehaviour
{
    [SerializeField] private bool enable;
    [SerializeField] float _shiftSpeed = 5;
    private float _panSpeed = 1;
    
    void Update()
    {
        //Apply shift multiplier.
        if (Input.GetKey(KeyCode.LeftShift))
            _panSpeed = _shiftSpeed;
        else
            _panSpeed = 1;
        
        //Apply movement based on axis input.
        Vector3 inputAxis = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 pos = transform.position;
        transform.position =
            Vector3.Lerp(pos, pos + inputAxis, Time.deltaTime * _panSpeed);
    }
}
