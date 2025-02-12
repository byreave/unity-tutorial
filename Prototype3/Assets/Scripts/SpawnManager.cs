﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25.0f, 0.0f, 0.0f);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(!playerControllerScript.gameOver)
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
