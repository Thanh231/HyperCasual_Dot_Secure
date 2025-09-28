using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelUp;

    public int currentScore;

    private float score;
    public bool hasFinish;
    private float timer = 1;
    void Start()
    {
        // currentLevel = 0;
        // GameManager.ins.IsInitialized = true;
        // hasFinish = false;
    }

    void Update()
    {
        if (hasFinish) return;

        score += GameManager.ins.speedIncreaseScore[Mathf.Clamp(GameManager.ins.currentLevel, 0, GameManager.ins.speedIncreaseScore.Count - 1)] * Time.deltaTime;

        scoreText.text = score.ToString("00000");

        if (score > GameManager.ins.pivotScore[Mathf.Clamp(GameManager.ins.currentLevel, 0, GameManager.ins.pivotScore.Count - 1)])
        {
            GameManager.ins.currentLevel++;
            SoundManager.instance.Play(SoundManager.instance.updateSound);

            levelUp.gameObject.SetActive(true);
            
            StartCoroutine(HideLevelUp());
        }
    }
    // public void SetEndGame()
    // {
    //     GameManager.ins.currentScore = (int)score;
    // }
    private IEnumerator HideLevelUp()
    {
        yield return new WaitForSeconds(timer);
        levelUp.gameObject.SetActive(false);
    }
}
