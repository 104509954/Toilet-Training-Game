using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XchufangPlayer : MonoBehaviour
{
    public GameObject ketingTipUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.name=="ketingDoor")
        {
            ketingTipUI.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("keting");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ketingDoor")
        {
            ketingTipUI.gameObject.SetActive(!true);
        }
    }
}
