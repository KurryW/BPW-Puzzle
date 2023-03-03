using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadsceneAll : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSceneButton()
    {
        SceneManager.LoadScene("Levels 1");
        SceneManager.LoadScene("Menu");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("GOGOGOGO SCENE");
        SceneManager.LoadScene("Levels 2");
    }
}
