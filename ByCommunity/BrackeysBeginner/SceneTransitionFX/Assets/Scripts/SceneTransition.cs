using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] GameObject sceneTransition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                StartCoroutine(LoadLevel(nextSceneIndex));
            }
            else
            {
                Debug.Log("There is no next scene!!");
            }
            
        }
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        sceneTransition.GetComponent<Animator>().SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneIndex);
    }
}
