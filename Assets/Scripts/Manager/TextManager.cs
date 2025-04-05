using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private Text _txt;
    public string fullText;
    public AudioClip audioClip;
    private AudioSource _source;
    public string richText;
    public float timeToDisplay = 5f;
    public UnityEvent onEventTriggered;
    void Awake()
    {
        _txt = GetComponent<Text>();
        _source = GameObject.Find("manager").GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SetText(fullText);
    }



    public void SetText(string text)
    {
   
        if (!String.IsNullOrEmpty(fullText))
        {
            StartCoroutine(TypeText(fullText, timeToDisplay));
        }

        if (audioClip != null)
        {
          

            _source.clip = audioClip;
            _source.Play();
        }
    }

   
    IEnumerator TypeText(string text, float totalTime)
    {
        float timePerCharacter = totalTime / text.Length;  

        _txt.text = ""; 

       
        for (int i = 0; i < text.Length; i++)
        {
            _txt.text += text[i]; 
            yield return new WaitForSeconds(timePerCharacter);  
        }
        yield return null;
        if (!String.IsNullOrEmpty(richText))
        {
            _txt.text = richText;
        }
        onEventTriggered?.Invoke();
    }
}