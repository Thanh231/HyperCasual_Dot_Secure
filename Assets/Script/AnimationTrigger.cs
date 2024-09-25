using System.Collections;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public MenuMain menu;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void PlayAnimation()
    {
        StartCoroutine(ClickOn());
    }

    private IEnumerator ClickOn()
    {
        anim.SetBool("Play", true);
        yield return new WaitForSeconds(0.5f);
        menu.PlayGame();
    }
}
