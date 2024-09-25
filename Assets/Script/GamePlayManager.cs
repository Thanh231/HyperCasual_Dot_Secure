using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelUp;

    [SerializeField] private List<float> pivotScore, speed;

    public int currentLevel;
    private float score;
    public bool hasFinish;
    public float timer;
    void Start()
    {
        currentLevel = 0;
        GameManager.ins.IsInitialized = true;
        hasFinish = false;
    }

    void Update()
    {
        if (hasFinish) return;

        score += speed[Mathf.Clamp(currentLevel, 0, pivotScore.Count - 1)] * Time.deltaTime;

        scoreText.text = score.ToString("00000");

        if (score > pivotScore[Mathf.Clamp(currentLevel, 0, pivotScore.Count - 1)])
        {
            currentLevel++;
            SoundManager.instance.Play(SoundManager.instance.updateSound);

            levelUp.gameObject.SetActive(true);
            
            StartCoroutine(HideLevelUp());
        }
    }
    public void SetEndGame()
    {
        GameManager.ins.currentScore = (int)score;
    }
    private IEnumerator HideLevelUp()
    {
        yield return new WaitForSeconds(timer);
        levelUp.gameObject.SetActive(false);
    }
}
