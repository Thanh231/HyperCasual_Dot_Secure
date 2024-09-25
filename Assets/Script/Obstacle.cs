using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private List<float> speed;
    [SerializeField] private GamePlayManager gamePlayManager;
    public GameObject explosion;

    private float timer;
    public float dir;
    void Start()
    {
        timer = 0f;
        float faceDir = Random.Range(0, 2);
        faceDir = (faceDir == 0) ? 1f : -1f;
        dir = speed[Mathf.Clamp(gamePlayManager.currentLevel, 0, speed.Count - 1)] * faceDir;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer  > 2.5f)
        {
            timer = 0f;
            float faceDir = Random.Range(0, 2);
            faceDir = (faceDir == 0) ? 1f : -1f;
            dir = speed[Mathf.Clamp(gamePlayManager.currentLevel, 0, speed.Count - 1)] * faceDir;
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, dir * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        SoundManager.instance.Play(SoundManager.instance.loseSound);

        if (explosion != null)
        {
            Instantiate(explosion,collision.transform.position,Quaternion.identity);
        }

        StartCoroutine(EndGame());
    }
    private IEnumerator EndGame()
    {
        gamePlayManager.hasFinish = true;

       gamePlayManager.SetEndGame();

        yield return new WaitForSeconds(2f);

        GameManager.ins.LoadMenu();
    }
}
