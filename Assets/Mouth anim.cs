using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Mouthanim : MonoBehaviour
{
    public static Mouthanim instance;
    private Animator animator;

    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void ChangeState(string state, float delay = 0)
    {
        StartCoroutine(changeAnim(state, delay));
    }
    
    IEnumerator changeAnim(string state, float delay)
    {
        yield return new WaitForSeconds(delay);
        switch (state)
        {
            case "Open": animator.Play("Open");
                break;
            case "Closed": animator.Play("Closed");
                break;
            case "Burp": animator.Play("Burp");
                break;
        }
    }
}