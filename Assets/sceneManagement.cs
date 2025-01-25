using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagement : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene("Game");
    }
}
