﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody enemyRB;
    public GameObject player;
    private float xDestroy = 30f;
    private float zDestroy = 20f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);
        transform.LookAt(player.transform.position);
        
        if(transform.position.z < -zDestroy)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > zDestroy)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -xDestroy)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > xDestroy)
        {
            Destroy(gameObject);
        }

    }
}