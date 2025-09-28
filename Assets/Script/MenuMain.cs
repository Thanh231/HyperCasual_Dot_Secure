using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class MenuMain : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject menu;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    private bool isIncreasePoint = false;
    private int increaseDuration = 0;

    private int currentScore = 0;
    private int highScore = 0;

    void OnEnable()
    {
        EventManager.StartGame += StartGame;
        EventManager.ShowMenu += ShowMenu;
    }
    void OnDisable()
    {
        EventManager.StartGame -= StartGame;
        EventManager.ShowMenu -= ShowMenu;
    }


    private void StartGame()
    {
        tutorial.SetActive(false);
    }

    public void SkipMenu()
    {
        tutorial.SetActive(true);
    }

    private void Start()
    {

        menu.SetActive(true);
        highScore = GameManager.ins.HighScore;
        highScoreText.text = "HIGH SCORE \n" + highScore.ToString("0000");
        currentScoreText.text = "SCORE \n" + increaseDuration.ToString("0000");
    }

    private void ShowMenu(int score)
    {
        menu.SetActive(true);
        currentScore = score;
        highScore = GameManager.ins.HighScore;
        highScoreText.text = "HIGH SCORE \n" + highScore.ToString("0000");
        isIncreasePoint = true;
    }

    void Update()
    {
        if (isIncreasePoint)
        {

            if (increaseDuration > currentScore)
            {
                isIncreasePoint = false;
            }
            if (currentScore > highScore)
            {
                // StartCoroutine(ShowNewBest(currentScore));
                currentScoreText.text = "NEW BEST \n" + increaseDuration.ToString("0000");
                GameManager.ins.HighScore = currentScore;
            }
            else
            {
                currentScoreText.text = "SCORE \n" + increaseDuration.ToString("0000");
            }
        }
    }

}
