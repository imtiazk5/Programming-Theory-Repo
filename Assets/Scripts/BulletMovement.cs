using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D rb; // declearing the rigidbody2d variable
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// getting component reference of rb.
    }

    void FixedUpdate() // used fixed update because i am using the rigidbody for the bullet and it is done in fixed for smoothnesss.
    {
        rb.velocity = Vector2.up * 8;// applys the force to the bullet to mov eit in upside direction

        if(transform.position.y > 0)// checks if the bullet crossed the given position boundary the ndestroy the object.
        {
            Destroy(gameObject);
        }
    }
}
