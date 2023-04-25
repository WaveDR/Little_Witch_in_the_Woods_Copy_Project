using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Manager : MonoBehaviour
{
    static string nextScene;
    public Image loadingBar;
    public Text loadingText;
    public static void LoadScene(string Scene_Name)
    {
       nextScene = Scene_Name;
       SceneManager.LoadScene("Loading_Scene");
    }
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }
    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.7f)
            {
                loadingBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.deltaTime;
                loadingBar.fillAmount = Mathf.Lerp(0.7f, 1f, timer);
                loadingText.text = $"{Mathf.FloorToInt( loadingBar.fillAmount * 100f)}%";
                if (loadingBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
