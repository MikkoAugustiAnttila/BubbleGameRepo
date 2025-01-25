using System;
using System.Collections;
using UnityEngine;

public class FlyManager : MonoBehaviour
{
    public int flyCount;
    [SerializeField] private GameObject burpEffect;

    private void Start()
    {
        flyCount = GameObject.FindGameObjectsWithTag("Fly").Length;
        StartCoroutine(FlyCheck());
    }
    
    // Periodically check how many flies exist
    IEnumerator FlyCheck()
    {
        while (flyCount > 0)
        {
            yield return new WaitForSeconds(3);
            flyCount = GameObject.FindGameObjectsWithTag("Fly").Length;
        }
        Debug.Log("All flies have been eaten");
        burpEffect.SetActive(true);
    }
}
