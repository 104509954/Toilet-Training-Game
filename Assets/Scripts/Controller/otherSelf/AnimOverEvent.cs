using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimOverEvent : MonoBehaviour
{
    public UnityEvent AnimEvent;

    public UnityEvent PlayEvent;

    public UnityEvent Event3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimOver()
    {
        AnimEvent?.Invoke();
    }
    

    public void OnAnimPlayerEvent()
    {
        PlayEvent?.Invoke();
    }

    public void OnAnimaEvent3()
    {
        Event3?.Invoke();
    }
}
