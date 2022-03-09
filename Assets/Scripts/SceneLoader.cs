using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // public enum Scene{
    //     CatchingGame, Home
    // }
    // public void Load(Scene scene){
    //     SceneManager.LoadScene(scene.ToString());
    // }

    //will temporarily take in string scene (move onto enum later)
    public void Load(string scene){
        SceneManager.LoadScene(scene);
    }
}
