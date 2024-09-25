using System.Collections;
using TMPro;
using UnityEngine;

public class MenuMain : MonoBehaviour
{
    public GameObject scoreTitle;
    public GameObject score;
    public TextMeshProUGUI highScore;

    private void Start()
    {
        highScore.text = GameManager.ins.HighScore.ToString("0000");
        if (!GameManager.ins.IsInitialized)
        {
            scoreTitle.SetActive(false);
            score.SetActive(false);
        }
        else
            ShowScore();
    }

    private void ShowScore()
    {
        scoreTitle.SetActive(true);
        score.SetActive(true);

        int currentScore = GameManager.ins.currentScore;
        int highScore = GameManager.ins.HighScore;
        score.GetComponent<TextMeshProUGUI>().text = currentScore.ToString("0000");

        if(currentScore > highScore)
        {
            StartCoroutine(ShowNewBest(currentScore));
        }


    }

    private IEnumerator ShowNewBest(int currentScore)
    {
        scoreTitle.GetComponent<TextMeshProUGUI>().text = "NEW BEST";
        GameManager.ins.HighScore = currentScore;
        highScore.text = GameManager.ins.HighScore.ToString();

        yield return new WaitForSeconds(3f);
        scoreTitle.GetComponent<TextMeshProUGUI>().text = "SCORE";
    }

    public void PlayGame()
    {
        GameManager.ins.LoadGamePlay();
        SoundManager.instance.Play(SoundManager.instance.playSound);
    }
}
