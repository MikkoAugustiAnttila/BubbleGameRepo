using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public void EnterGame()
    {
        StartCoroutine(startGame());
    }
    
    IEnumerator startGame()
    {
        anim.Play("TransitionIn");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Game");
    }
}
