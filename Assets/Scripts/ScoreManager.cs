using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public LevelManager levelManager;

    public static int score;

    Text text;

    void Start()
    {

        levelManager = FindObjectOfType<LevelManager>();

        text = GetComponent<Text>();

        score = 0;
    }
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        text.text = "" + score;
    }
    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            levelManager.RespawnPlayer();
                score = 0;
        }
    }
}
