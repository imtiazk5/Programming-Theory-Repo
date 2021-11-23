using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR // i used this for making the game quite if it is running in the Unity editor of build
using UnityEditor;
#endif

public class ManueUIScript : MonoBehaviour
{


    public void StartNew()// this method will called by the start button in the Manue scene Ui
    {
        SceneManager.LoadScene(1); // loads the MAIN scene
    }

    public void Exit()// this method will quit the game
    {
#if UNITY_EDITOR // checks if the game is running on editor or a builld

        EditorApplication.ExitPlaymode();// if playing on the editor then ecit playmode

#else
            // this is disabled because for now we are using the editor if we make build then this line will get exicuted.       
        Application.Quit(); // original code to quit Unity player 
     
#endif

    }
}
