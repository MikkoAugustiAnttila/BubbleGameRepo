using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private bool Audio = false;

    private void Start()
    {
        if (Audio)
        {
            StartCoroutine(endAudio());
        }
    }

    public void EnterGame()
    {
        StartCoroutine(startGame());
    }

    public void ReturnToMenu()
    {
        StartCoroutine(backToMenu());
    }
        
    
    IEnumerator startGame()
    {
        anim.Play("TransitionIn");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }
    
    IEnumerator backToMenu()
    { 
        anim.Play("TransitionIn");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("TitleScreen");
    }
    
    IEnumerator endAudio()
    { 
        yield return new WaitForSeconds(1);
        soundManager.instance.PlaySound("Victory");
        yield return new WaitForSeconds(3);
        soundManager.instance.PlaySound("GameOver");
    }
}
