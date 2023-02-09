using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    void Start()
    {
        print("Scene Count: " + SceneManager.sceneCountInBuildSettings);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadScenePicker()
    {
        SceneManager.LoadScene(1);
    }

}
