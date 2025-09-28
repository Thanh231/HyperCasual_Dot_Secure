using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float dir = 1;
    public GameObject babySprite;
    public CircleCollider2D circleCollider;
    private bool isStartGame = false;
    void OnEnable()
    {
        EventManager.StartGame += StartGame;
        EventManager.ResetGame += ResetGame;
    }
    void OnDisable()
    {
        EventManager.StartGame -= StartGame;
        EventManager.ResetGame -= ResetGame;
    }

    private void ResetGame()
    {
        throw new NotImplementedException();
    }

    private void StartGame()
    {
        isStartGame = true;
    }

    public void DisablePlayerObject()
    {
        babySprite.SetActive(false);
        circleCollider.enabled = false;
    }

    private void Update()
    {
        if (isStartGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dir *= -1;
                SoundManager.instance.Play(SoundManager.instance.moveSound);
            }
            transform.RotateAround(Vector3.zero, transform.forward * dir,
            Mathf.Clamp(GameManager.ins.speedPlayer[GameManager.ins.currentLevel],
            0, GameManager.ins.speedPlayer.Count - 1) * Time.deltaTime);
        }

    }
}
