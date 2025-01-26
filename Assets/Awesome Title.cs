using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class AwesomeTitle : MonoBehaviour
{
   public TextMeshProUGUI text;
   public float fadeDuration;
   private Color oldColor;
   private Color newColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // text.color = Color.red;
       StartCoroutine(LerpColor());
    }

    IEnumerator LerpColor()
    {
    oldColor = newColor;
    float red = Random.Range(0f, 1f);
    float green = red+0.33f;
    if (green>1f)
    {
        green -= 1f;
    } 
    float blue = green+0.33f;
    if (blue>1f)
    {
        blue -= 1f;
    }
    newColor = new Color(red,green,blue);
    

    float t = 0;
    while (t < 1)
    {
        
        text.color = Color.Lerp(oldColor, newColor, t);
        t += Time.deltaTime / fadeDuration;
        yield return new WaitForEndOfFrame(); 
    }
    StartCoroutine(LerpColor());
    }
   
}
