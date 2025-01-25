using UnityEngine;

public class Mouthanim : MonoBehaviour
{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left"))
        {
            animator.Play("Open");

        }
        else if(Input.GetKey("right"))
        {
            animator.Play("Mouth animation");

        }
        else if(Input.GetKey("up"))
        {
            animator.Play("Burp");

        }
    }
}
