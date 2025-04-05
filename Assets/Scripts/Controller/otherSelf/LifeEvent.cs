using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeEvent : MonoBehaviour
{

    public UnityEvent OnenableEvent;
    public UnityEvent OndissableEvent;
    // Start is called before the first frame update

    private void OnEnable()
    {
        OnenableEvent?.Invoke();
    }

    private void OnDisable()
    {
        OndissableEvent?.Invoke();
    }
}
