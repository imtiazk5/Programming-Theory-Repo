using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] ballPrefabs; // gets number of prfabs in an array
    private GameManager manager;// making a gamemanager variable

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();// getting gamemnager script reference from gamemanager gameobject
        Instantiate(ballPrefabs[0], SpawnPosition(), Quaternion.identity); // this will spawn the ball on the first game startup
        StartCoroutine(BallSpawn()); // I started the coroutine to wait for 10 seconds and spawn other ball from array.
    }                             // Here SpawnPosition method returns  vector 2 variable for the position the spawn the ball

    IEnumerator BallSpawn()
    {

        while (manager.isGameActive) // checks if the game is not over then
        {
            yield return new WaitForSeconds(10); // wait for 10 seconds then
            int index = Random.Range(0, ballPrefabs.Length); // returns the rendom number inbetween of 0 and the lenght of the array.

            Instantiate(ballPrefabs[index], SpawnPosition(), Quaternion.identity);// spawns rendom ball using index value on the
                                                                                  // rendom position selected buy the SpawnPositions
                                                                                  //method.
        }
        
    }


    private Vector2 SpawnPosition()// returns a vector2 variable for rendom position for spawn
    {
        float xRange = Random.Range(-10, 15);// teturns a rendom value for x position in the scene.

        Vector2 pos = new Vector2(xRange, 0); // initializes a new vector2 with the new values of X/ and 0 for y because 
                                                // we can to spawn the ball on the 0 axis of the Y.
        return pos; // returns new vector2/
    }
}
