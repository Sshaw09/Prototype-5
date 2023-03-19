﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    float minSpeed = 12;
    float maxSpeed = 16;
    float maxTorque = 10;
    float xRange = 4;
    float ySpawnPos = -2;
    // Start is called before the first frame update
    void Start()
    {
        //Get the objects Rigidbody component
        targetRb = GetComponent<Rigidbody>();
        //Applies the force using the RandomForce method
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //Torque() makes the object rotates randomly on it's X,Y,Z 
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //Sets the positon of the object
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This makes the object go up between a random strength of 12-16
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    //Method to applies a random rotation to the object 
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    //Sets the position of the object below the player between -4,4, X value
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    //When the mouse is inside a colldier and gets clicked it will destroy the object
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    //When it colldies with the sensor (The only object with the trigger on), the object gets destroyed
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
