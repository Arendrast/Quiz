using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    private int _scenePCIndex = 1;

    private void Awake()
    {
        LoadScene();
    }

    private void LoadScene()
    {
        if (!Application.isMobilePlatform)
        {
            SceneManager.LoadScene(_scenePCIndex);
        }
    }
}
