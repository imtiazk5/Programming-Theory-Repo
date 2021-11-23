using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject restartScene;// gets a gameobject from the scene. of this it is a gameOver UI
                                             // contains GameOver test/ restart button / and return to manue button

    [SerializeField] public bool isGameActive { get; private set; } // sets this bool variable readonly for other classes and and writable for this class 

    private void Awake() // when the scene loads the gamective bool will be true
    {
        isGameActive = true;
    }

    public void SetGameOver(bool condition)// this method will updates the gamecondition for true or false on the given
                                           // value i used this method to triger gameOver scene.
    {
        if (condition)// if the condition is true then set isgameActive false and set the UI scene true
        {
            restartScene.SetActive(true);
            isGameActive = false;
        }
        
    }

    public void restartGame() // this method is used by the restart button in the canves to reload this secene
    {
        isGameActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // this will load the active secne again ( here Main scene)
        
    }

    public void ReturnManue()// this method will load the Manue scene  
    {
        SceneManager.LoadScene(0); // 0 indedx shows that it is the main manue scene and one is this current.
    }

}
