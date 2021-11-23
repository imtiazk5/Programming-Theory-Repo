using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour // this script fires the bullets from the parent position to upside
{
    [SerializeField] GameObject bulletPrefab; // getting the bullet prefab from assets folder
    private GameManager manager; // making a gamemanager variable
    void Start() // used to get the gamemanager script reference when the gameobject start
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        bool isActive = manager.isGameActive;// getting the gameOver condition from GameManager script and saving it in a bool variable
        if (Input.GetKeyDown(KeyCode.Space) && isActive) // checks if the player pressed the space bar button
        {// if condition gets true then instantiate method will spawns the bullets on the player position facing upside.
            Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
        }
    }
}
