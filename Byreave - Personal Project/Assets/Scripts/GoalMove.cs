using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMove : MonoBehaviour
{
    private Rigidbody goalRb;
    private GameObject player;

    [SerializeField] float xBound = 14;
    [SerializeField] float zBound = 10;
    // Start is called before the first frame update
    void Start()
    {
        goalRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        goalRb.AddForce(new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f)), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xBound || transform.position.x > xBound ||
            transform.position.z < -zBound || transform.position.z > zBound)
        {
            transform.position = player.transform.position + new Vector3(Random.Range(-2.0f, 2.0f), transform.position.y, Random.Range(-3.0f, 3.0f));
        }
    }
}
