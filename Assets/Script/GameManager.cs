using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager ins; 

    private string highScore;
    public int currentScore;

    private void Awake()
    {
        if(ins == null) 
        {
            ins = this;
            Init();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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

    public bool IsInitialized { get; set; }
    private void Init()
    {
        IsInitialized = false;
        currentScore = 0;
    }

    private string memuMain = "MenuMain";
    private string gamePlay = "GamePlay";

    public void LoadMenu()
    {
        SceneManager.LoadScene(memuMain);
    }    
    public void LoadGamePlay()
    {
        SceneManager.LoadScene(gamePlay);
    }    
}
