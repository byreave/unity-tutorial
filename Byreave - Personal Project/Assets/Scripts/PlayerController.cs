using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField] float zBound = 9.0f;
    [SerializeField] float xBound = 14.0f;

    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerAnim.SetFloat("Speed_f", Mathf.Abs(horizontalInput + verticalInput) / 2.0f);
        if (horizontalInput == 0.0f && verticalInput == 0.0f)
            return;

        if (transform.position.x > xBound && horizontalInput > 0.0f)
            horizontalInput = 0.0f;
        if (transform.position.x < -xBound && horizontalInput < 0.0f)
            horizontalInput = 0.0f;

        if (transform.position.z > zBound && verticalInput > 0.0f)
            verticalInput = 0.0f;
        if (transform.position.z < -zBound && verticalInput < 0.0f)
            verticalInput = 0.0f;

        Vector3 velocity = (Vector3.forward * verticalInput + Vector3.right * horizontalInput) * speed * Time.deltaTime;
        if (velocity.sqrMagnitude != 0.0f)
            transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        //space is default by self
        transform.Translate(velocity, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Good") || collision.gameObject.CompareTag("Bad"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.impulse.normalized * 50, ForceMode.Impulse);
        }
    }
}
