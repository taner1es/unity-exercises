using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Scrollbar LoadingBar;
    public Text LoadingPercentage;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            LoadingBar.size = operation.progress; 
            LoadingPercentage.text = operation.progress * 100f + 10f + "%";
            Debug.Log(progress);

            yield return null;
        }
    }
}
