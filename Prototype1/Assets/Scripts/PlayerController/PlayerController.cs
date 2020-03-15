using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float TurnSpeed = 25.0f;

    float horizontalInput;
    float fowardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        fowardInput = Input.GetAxis("Vertical");
        //Move the vehicle forward
        transform.Translate(Vector3.forward *  Time.deltaTime * speed * fowardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * horizontalInput);

    }
}
