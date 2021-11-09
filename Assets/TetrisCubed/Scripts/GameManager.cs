using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void To4x4()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void ToOptions()
    {
        SceneManager.LoadScene(3);
    }

    public void ToCredits()
    {
        SceneManager.LoadScene(4);
    }
}
