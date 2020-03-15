using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnCooldown = 2.0f;
    private bool isInCooldown;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !isInCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            isInCooldown = true;
            Invoke("ResetCoolDown", spawnCooldown);
        }
    }

    void ResetCoolDown()
    {
        isInCooldown = false;
    }
}
