using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuScreenController : UnityEngine.MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
