using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}