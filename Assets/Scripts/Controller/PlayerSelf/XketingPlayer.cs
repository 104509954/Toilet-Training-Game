using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class XketingPlayer : MonoBehaviour
{
    public XketingCon xketing;
    public bool isTalk = false;

    public GameObject doorTipUI;
    public GameObject eTipUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEventistalk(bool b)=> isTalk = b;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "talkNpc")
        {
            eTipUI.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E) && !isTalk)
            {
                isTalk = true;
                xketing.talkNpcPage.SetActive(true);
                transform.gameObject.GetComponent<FirstPersonController>().enabled = false;
            }
        }
        if (other.gameObject.name == "doorTips")
        {
            doorTipUI.gameObject.SetActive(true);
        }

        if (other.gameObject.name == "gobedroom")
        {
            eTipUI.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E) && !isTalk)
            {
                SceneManager.LoadScene("woshi");
            }
        }
        if (other.gameObject.name == "gocesuo")
        {
            eTipUI.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E) && !isTalk)
            {
                SceneManager.LoadScene("cesuo");
            }
        }
        if (other.gameObject.name == "gochufang")
        {
            eTipUI.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E) && !isTalk)
            {
                SceneManager.LoadScene("chufang");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "doorTips")
        {
            doorTipUI.gameObject.SetActive(!true);
        } 
        if (other.gameObject.name == "talkNpc")
        {
            eTipUI.gameObject.SetActive(!true);
        }
        if (other.gameObject.name == "gocesuo")
        {
            eTipUI.gameObject.SetActive(!true);
           
        }
    }
}

