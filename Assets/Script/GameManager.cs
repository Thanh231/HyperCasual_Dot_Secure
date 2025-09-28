using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;

    private string highScore;
    public int currentLevel;

    // public GamePlayManager gamePlayManager;
    public List<float> speedPlayer;

    public List<float> speedObstacle;
    public List<float> pivotScore, speedIncreaseScore;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;
            // Init();
            // DontDestroyOnLoad(gameObject);
        }
        // else
        // {
        //     Destroy(gameObject);
        // }
    }
    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScore, 0);
        }
        set
        {
            PlayerPrefs.SetInt(highScore, value);
        }
    }

    // public bool IsInitialized { get; set; }
    // private void Init()
    // {
    //     IsInitialized = false;
    //     currentScore = 0;
    // }

    // private string memuMain = "MenuMain";
    // private string gamePlay = "GamePlay";

    // public void LoadMenu()
    // {
    //     SceneManager.LoadScene(memuMain);
    // }    
    // public void LoadGamePlay()
    // {
    //     SceneManager.LoadScene(gamePlay);
    // }    

    public void PlayGame()
    {
        // GameManager.ins.LoadGamePlay();
        SoundManager.instance.Play(SoundManager.instance.playSound);
        EventManager.StartGame?.Invoke();
    }

    public void EndGame()
    {
        // GameManager.ins.LoadGamePlay();
        EventManager.ResetGame?.Invoke();
    }
}
