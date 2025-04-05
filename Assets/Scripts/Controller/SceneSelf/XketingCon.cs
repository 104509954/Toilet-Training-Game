using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XketingCon : MonoBehaviour
{
    public GameObject[] qtips;
    public GameObject talkNpcPage;
    public GameObject OverPage;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.isOver)
        {
            OverPage.gameObject.SetActive(true);
            GameController.Instance.OnGamePause();
        }
    }
    private void OnEnable()
    {
        GameController.Instance.OnGameContinue();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameController.Instance.OnGamePause();
            qtips[0].gameObject.SetActive(true);
        }
    }

    public void OnbtnContinueGame()
    {
        GameController.Instance.OnGameContinue();
    }

    public void OnBtnRegame()
    {
        GameController.isOver = false;
        GameController.Instance.OnGameContinue();
    }
}
