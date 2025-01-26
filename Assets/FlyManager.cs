using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class FlyManager : MonoBehaviour
{
    public int flyCount;
    [SerializeField] private GameObject flyPrefab;
    [SerializeField] private GameObject burpEffect;
    [SerializeField] private BoxCollider2D bugSpawnBounds;

    [SerializeField] private Vector2 ribbitTime;
    [SerializeField] private float remainingRibbitTime;
    [SerializeField] private Animator transitionAnimator;

    private void Start()
    {
        int rng = Random.Range(5, 7);
        for (int i = 0; i < rng; i++)
        {
            float x = Random.Range(bugSpawnBounds.bounds.min.x, bugSpawnBounds.bounds.max.x);
            float y = Random.Range(bugSpawnBounds.bounds.min.y, bugSpawnBounds.bounds.max.y);
            Vector3 pos = new Vector3(x, y, 0);
            
            Instantiate(flyPrefab, pos, Quaternion.identity);
        }
        
        flyCount = GameObject.FindGameObjectsWithTag("Fly").Length;
        StartCoroutine(FlyCheck());
        
        remainingRibbitTime = Random.Range(ribbitTime.x, ribbitTime.y);
    }

    private void Update()
    {
        if (flyCount > 0)
        {
            if (remainingRibbitTime <= 0)
            {
                soundManager.instance.PlaySound("Ribbit");
                remainingRibbitTime = Random.Range(ribbitTime.x, ribbitTime.y);
            }
            else
            {
                remainingRibbitTime -= Time.deltaTime;
            }
        }
    }

    // Periodically check how many flies exist
    IEnumerator FlyCheck()
    {
        while (flyCount > 0)
        {
            yield return new WaitForSeconds(3);
            flyCount = GameObject.FindGameObjectsWithTag("Fly").Length;
        }
        soundManager.instance.PlaySound("Burp");
        Mouthanim.instance.ChangeState("Burp");
        burpEffect.SetActive(true);
        
        yield return new WaitForSeconds(3);
        transitionAnimator.Play("TransitionIn");
        SceneManager.LoadScene("VictoryScreen");
    }
}
