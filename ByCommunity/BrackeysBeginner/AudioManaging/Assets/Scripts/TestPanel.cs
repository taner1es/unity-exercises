using UnityEngine.SceneManagement;
using UnityEngine;

public class TestPanel : MonoBehaviour
{
    public void JumpSFXButtonClicked()
    {
        FindObjectOfType<SoundManager>().Play("Jump");
    }

    public void TouchSFXButtonClicked()
    {
        FindObjectOfType<SoundManager>().Play("Touch");
    }

    public void MenuSceneChangerButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
