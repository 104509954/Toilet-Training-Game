using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int count = 0;

    public void OnLoadTargetScene()
    {
        SceneManager.LoadScene(count);
    }

    public void OnLoadStartScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnLoadKetingScene()
    {
        SceneManager.LoadScene("keting");
    }
}
