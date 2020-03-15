using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PropellerToSpin;
    public float RotateSpeed = 500;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PropellerToSpin?.transform.Rotate(Vector3.forward, RotateSpeed * Time.deltaTime);
    }
}
