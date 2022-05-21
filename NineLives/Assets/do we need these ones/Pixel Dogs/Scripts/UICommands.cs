using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICommands : MonoBehaviour {

    SceneManager sceneManager;

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }


}