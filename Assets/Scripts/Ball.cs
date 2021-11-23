using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb; // rigidbody variable for using forces on the Ball gameobject.
	private GameManager manager;// making a gamemanager variable
	[SerializeField] int health;// variable for containing the ball health.

	[SerializeField] protected TMP_Text textHealth; // health text which is joint with the ball gameobejct for visual scene. 
	[SerializeField] protected float jumpForce;// this variable will be used for adding amount of force to bounce back the ball from ground.
	
    void Start()
    {
		manager = GameObject.Find("GameManager").GetComponent<GameManager>();// getting gamemnager script reference from gamemanager gameobject
		rb = GetComponent<Rigidbody2D>(); // getting rigitbody component from the ball gameobject
		rb.velocity = Vector2.right * 2;// adding the push force to the right to start ball to move in the scene 
		UpdateHealthUI(); // this method will update the health of ball when the ball will spawn.
    }

    private void Update()
    {
		checkBounds();   // this method will check if the balls are in the boundary It prevents ball from going out of the scene.
    }

	private void checkBounds() // I used this apprech for bound Because i was facing problem using colliders on the walls so for saving the time i used this method.
	{
		float leftBound = -13f; // left wall distanvce
		float rightBound = 18f; // right wall distance

		//Checks and restricts if the player is in defined zone.
		if (transform.position.x < leftBound)
		{
			//hit left wall
			rb.AddForce(Vector2.right * 180f);
		}
		if (transform.position.x > rightBound)
		{
			//hit right wall
			rb.AddForce(Vector2.left * 180f);
		}
		rb.AddTorque(transform.position.x * 4f); // adds torque to the ball after it hit the wall.
	}
	void OnTriggerEnter2D(Collider2D other) // checks ball collitions with diffrent gameObjects.
	{
		if (other.tag.Equals("Player")) // if ball hits the player the game will trigered Over.
		{//--------------------------------
		 //gameover
			//Debug.Log("gameover");
			manager.SetGameOver(true); // calls method for showing the gameover scene from the GameManager script.

		}

		if (other.tag.Equals("bullet")) // if the ball get hit by the bullet it will get damage and destroy the bullet gameobject.
		{//--------------------------------
		 //takedamage
			TakeDamage(1); // the value 1 is passed every time the ball gets hit by bullet.
			//destroy Bullet
			Destroy(other.gameObject); // after it hit the ball and gave damage the bullet will be destroyed.

		}

		if (other.tag.Equals("ground"))// if the ball gets hit to the ground
		{//----------------------------------

			rb.velocity = new Vector2(rb.velocity.x, jumpForce); // this line will add velovity to x coordinate with the force we mention on top of the script
			                                                // this will make ball bounce back in the air
			rb.AddTorque(-rb.angularVelocity * 4f);// this line will add torque to the ball By the angularvelocity 
										// making it to rotate in reverce direction by giving value negitive
										// and multiply with the 4f value( it is ammount of force to rotate). 
										// 
		}
	}
	public void TakeDamage(int damage) // this method updates the health cound every time the bullet hits the ball
	{
		if (health > 1) // checks if the health is not 0 then minus the health by damage value.
		{
			health -= damage;
		}
		else // if the health is 0 or less, then call Die method. 
		{
			Die();
		}
		UpdateHealthUI(); // after updating the health variable calls the updateHealthUI to update the visual counter on the ball
	}

	virtual protected void Die()
	{
		Destroy(gameObject);// destroys the ball
	}

	protected void UpdateHealthUI()
	{
		textHealth.text = health.ToString();// reWrites the the value of health test
											// Here health.toString will convert the integet health points to string because the 
											// heralth text variable only eccepts the string value.
	}
}
