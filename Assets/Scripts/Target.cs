using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    //Reference to the game manager *********
    private GameManager gameManager;
    float minSpeed = 12;
    float maxSpeed = 16;
    float maxTorque = 10;
    float xRange = 4;
    float ySpawnPos = -2;
    public ParticleSystem explosionParticle;

    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        //Finds the game manager object then locates the script attached to it
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //Get the objects Rigidbody component
        targetRb = GetComponent<Rigidbody>();
        //Applies the force using the RandomForce method
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //Torque() makes the object rotates randomly on it's X,Y,Z 
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //Sets the positon of the object
        transform.position = RandomSpawnPos();
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
    //Makes the score go up based on the pointValue of the object
    //Makes a particle spawn when mouse is clicked
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    //When it colldies with the sensor (The only object with the trigger on), the object gets destroyed
    //Makes the game over UI pop up after target hits sensor but doesn't active when the bad object is hits it 
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        
    }
}
