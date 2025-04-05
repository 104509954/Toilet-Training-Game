using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIController : MonoBehaviour
{
    public Slider slider;
    private void Start()
    {
        AudioListener.volume = slider.value;
    }
    private void Update()
    {
        //Debug.Log("AudioListener.volume:" + AudioListener.volume);
    }

    public void ValueCon()
    {
        AudioListener.volume = slider.value;
    }
    public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
