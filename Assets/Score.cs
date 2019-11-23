using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreUI;
    [SerializeField] int pointsPerEnemyKilled = 100;
    private int score;

    private void Awake()
    {
        int scoreObjectCount = FindObjectsOfType<Score>().Length;

        //if a score object object already exists
        if (scoreObjectCount > 1)
        {
            //Destroy the new one
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            //otherwise keep it
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreUI.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UpdateScore()
    {
        score += pointsPerEnemyKilled;
        scoreUI.text = score.ToString();
        Debug.Log(score);
    }

    public void DestroyScoreObject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public int GetScore()
    {
        return score;
    }
}
