using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    private Score score;
    [SerializeField] Text scoreUI = null;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
        scoreUI.text = score.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
