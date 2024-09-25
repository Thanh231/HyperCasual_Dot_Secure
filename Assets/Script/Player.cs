using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float face;
    public GamePlayManager gamePlayManager;
    public List<float> speedPlayer;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            face *= -1;
            SoundManager.instance.Play(SoundManager.instance.moveSound);
        }
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero,transform.forward * face, speedPlayer[gamePlayManager.currentLevel] * Time.deltaTime);
    }
}
