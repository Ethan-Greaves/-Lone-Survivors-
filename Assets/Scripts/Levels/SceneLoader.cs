using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public void LoadNextScene()
    {
        //Get our active scene, return its index.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToMenu()
    {
        int startMenu = 0;
        SceneManager.LoadScene(startMenu);
        score.DestroyScoreObject();
    }

    //This function will only work on standalone builds of the game.
    public void ExitGame()
    {
        Application.Quit();
    }
}
