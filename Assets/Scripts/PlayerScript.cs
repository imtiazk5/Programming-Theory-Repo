using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameManager manager; // making a gamemanager variable 
    [SerializeField] ParticleSystem deathParticle;// getting a deathPricle for kill effect of player
    void Start() // used to get the gamemanager script reference when the gameobject starts 
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>(); // getting gamemnager script reference from gamemanager gameobject
    }

    void Update() // used update to check player input and movement in every frame.
    {
        float speed = 20; // initializing a float variable for player movement speed

        if (manager.isGameActive) //Checking if the game is still active or not
        {
            float horizontalInput = Input.GetAxis("Horizontal"); // getting input from input manager for movement in x direction

            transform.Translate(Vector2.left * horizontalInput * speed * Time.deltaTime); // I used trsansform.translate for movement
            checkBounds();// this method checks player movement boundary                   // because it is simple and suitable for this.
        }
        else // if game is over 
        {
            deathParticle.Play(); // play the particle
            Destroy(gameObject,0.5f); // destroy player gameobject after half of second
        }                
    }

    private void checkBounds() 
    {
        float leftBound = -11f;
        float rightBound = 16f;

        //Checks and restricts if the player is in defined zone.
        // if player try to go out it will prevent it from going out of boundary.
        if (transform.position.x < leftBound) 
        {   //if player is going left side it will make player stay in the boundary by apllying the fixed position value to the Transform position
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        if (transform.position.x > rightBound)
        {//if player is going right side it will make player stay in the boundary by apllying the fixed position value to the Transform position
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
}
