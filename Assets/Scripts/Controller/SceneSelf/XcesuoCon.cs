using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XcesuoCon : MonoBehaviour
{  // Start is called before the first frame update
    float timerCount = 10;
    bool isShow = false;
    public GameObject showTips;
    public GameObject[] qtips;
    void Start()
    {
        timerCount = 10;
    }
    private void OnEnable()
    {
       GameController.Instance?.OnGameContinue();
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        if (Input.anyKey || mouseX > 0)
        {
            timerCount = 10;
        }
        if (!isShow) { timerCount -= Time.deltaTime; }

        if (timerCount < 0 && !isShow)
        {
            showTips.gameObject.SetActive(true);
            isShow = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameController.Instance?.OnGamePause();
            qtips[0].gameObject.SetActive(true);
        }
    }
    public void OnbtnContinueGame()
    {
        GameController.Instance?.OnGameContinue();
    }
    public void OnShowisfalse()
    {
        isShow = false;
        timerCount = 10;
    }
}
