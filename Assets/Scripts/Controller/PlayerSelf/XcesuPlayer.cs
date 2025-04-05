using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class XcesuPlayer : MonoBehaviour
{
    public GameObject[] TipsUI;
    public AudioClip chongshuisheng;
    public AudioSource audioSource;

    public GameObject[] tipsYuyin;

    public GameObject[] Qtips;
    public GameObject[] ruceliucheng;
    public Animator animator;

    public Animator chouzhiAnmiator;

    public Animator shuilongtouAnimator;
    public GameObject xishouObj;

    public Animator xishouAnmiator;

    public GameObject zuoxiaTIps;

    private GameObject childrenCamera;

    private Animator playerAnimator;
    private FirstPersonController playerFirstpersonCon;

    private bool isRuce = false;
    private bool ruceIng = false;
    private bool isMatongOpen = false;
    public int quzhiCount = 0;
    private bool useweishengzhi = false;

    private bool iszuoxia = false;

    private bool isOverQili = false;

    private float timerCountChongshui = 0;

    private bool isChongshuiIng = false;

    private bool isKongchouzhi = false;

    private Vector3[] xishoutrans = { new Vector3(-5.16f, 3.65f, -2.757f), new Vector3(0, 271, 0) };
    private void OnInit()
    {
       // isRuce = false;
        ruceIng = false;
        isMatongOpen = false;
        useweishengzhi = false;
        iszuoxia = false;
        isOverQili = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        childrenCamera = transform.Find("Main Camera").gameObject;
        playerAnimator = gameObject.GetComponent<Animator>();
        playerFirstpersonCon =GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isRuce:" + isRuce);
        Debug.Log("iszuoxia:" + iszuoxia);
        Debug.Log("isChongshuiIng:"+ isChongshuiIng);
        Debug.Log("isMatongOpen:" + isMatongOpen);
        if (isChongshuiIng)
        {
            timerCountChongshui += Time.deltaTime;
         
            if (timerCountChongshui>4)
            {
                isChongshuiIng = false;
                timerCountChongshui = 0;

            }
        }
    }


    public void OnAnimEventisMatongOpen(bool b) =>isMatongOpen = b;

    public void OnAnimEventisZuoxia(bool b) => iszuoxia = b;

    public void OnAnimEventConruceIng(bool b) => ruceIng = b;

    public void OnAnimEventRuceOver(bool b) => isRuce = b;

    public void OnEventOverQili(bool b) => isOverQili = b;

    public void OnAnimatorXishouHouHUaiyuanAnimtor() => xishouAnmiator.SetBool("isxi", false);

    private void OnAnimEventOpenShui() => shuilongtouAnimator.SetBool("isopen", true);
    private void OnAnimEventCloseShui() => shuilongtouAnimator.SetBool("isopen", false);
    public void XiShouPlayerMove()
    {
        OnAnimEventOpenShui();
       // xishouObj.SetActive(true);
        transform.position = xishoutrans[0];
        //transform.rotation = new Quaternion(0,89, 0, 0);
        childrenCamera.transform.eulerAngles = new Vector3(50,-89,0);
        transform.eulerAngles = xishoutrans[1];
        playerFirstpersonCon.enabled = false;
    }

    public void OnAnimOverXishou()
    {
        OnAnimEventCloseShui();
        xishouObj.SetActive(false);
        playerFirstpersonCon.enabled = true; 
        GameController.isOver = true;
    }

    public void OnAnimChouzhi() 
    {
        if (isKongchouzhi)
        {
            chouzhiAnmiator.SetBool("ischou", false);
            ruceIng = false;
            isRuce = true;
            useweishengzhi = true;
            Qtips[2].SetActive(false);
            Qtips[3].SetActive(true);
            quzhiCount += 1;
        }
        else
        {
            Debug.Log("kongchou");
            quzhiCount += 1;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "matong" && isMatongOpen)
        {
            zuoxiaTIps.SetActive(true);
        }
        if (other.name == "matong"&& !isMatongOpen)
        {
            if (isRuce)
            {
                TipsUI[4].gameObject.SetActive(true);
            }
            else
            {
                TipsUI[0].gameObject.SetActive(true);
            }
        }
        else if (other.name == "matong" && useweishengzhi)
        {
            TipsUI[3].gameObject.SetActive(true);
        }
        if (other.name == "weishenzhi")
        {
            TipsUI[1].gameObject.SetActive(true);
        }
        if (other.name == "xishoutai")
        {
            TipsUI[2].gameObject.SetActive(true);
        }

        if (other.name == "goKeting")
        {
            TipsUI[5].gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name== "matong")
        {
            if (isMatongOpen)
            {
                TipsUI[0].gameObject.SetActive(!true);
            }
            if (useweishengzhi && !isOverQili)
            {
                TipsUI[3].gameObject.SetActive(true);
            }
            else if(useweishengzhi&& isOverQili)
            {
                TipsUI[3].gameObject.SetActive(!true);
            }
            if (Input.GetKey(KeyCode.E)&& !isMatongOpen&&!isRuce)
            {
                animator.SetBool("isOpen",true);
                Qtips[0].SetActive(false);
                Qtips[1].SetActive(true);
            }
            if (Input.GetKey(KeyCode.E) && isMatongOpen&& !isRuce)
            {
                playerAnimator.enabled = true;
                ruceIng = true;
                //playerAnimator.SetBool("isST",true);
            }

            if (Input.GetKey(KeyCode.E) && isRuce && isChongshuiIng)
            {
                tipsYuyin[4].SetActive(true);
            }
            if (Input.GetKey(KeyCode.E) && iszuoxia&& useweishengzhi)
            {
                playerAnimator.SetBool("isSP", true);
                animator.SetBool("isOpen",false);
            }
            //if (Input.GetKey(KeyCode.E) && isMatongOpen)
            //{
            //    animator.SetBool("isOpen", false);
            //}

            if (Input.GetKey(KeyCode.E)&&!isRuce&& iszuoxia)
            {
                tipsYuyin[3].SetActive(true);
            }

            if (isChongshuiIng&&isRuce&& isMatongOpen)
            {
                tipsYuyin[4].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                audioSource.clip = chongshuisheng;
                audioSource.Play();
                isChongshuiIng = true;
                if (isChongshuiIng)
                {
                    //Debug.Log();
                    //tipsYuyin[4].SetActive(true);
                }
                if (!isRuce)//&&!isChongshuiIng
                {
                    tipsYuyin[1].SetActive(true);
                }
                else
                {
                    //Debug.Log("冲水");
                    TipsUI[4].SetActive(false);
                    TipsUI[0].SetActive(true);
                    Qtips[4].SetActive(true);

                    OnInit();
                }
            }
        }
        if (other.name == "weishenzhi")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
               
                if (ruceIng)
                {
                    isKongchouzhi = true;
                }
                else
                {
                    if (quzhiCount>2)
                    {
                        tipsYuyin[2].SetActive(true);
                        quzhiCount = 0;
                    }
                    else
                    {
                        Debug.Log("使用卫生纸");
                    }
                }
                chouzhiAnmiator.SetBool("ischou", true);

            }
        }
        if (other.name == "xishoutai")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isRuce)
                {
                    Debug.Log("使用洗手台");
                    //  xishouObj.SetActive(true);
                    xishouAnmiator.SetBool("isxi",true);
                      isRuce = false;
                }
                else
                {
                    tipsYuyin[0].SetActive(true);
                }
            }
        }
        if (other.name == "goKeting")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("keting");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "matong")
        {
            TipsUI[4].gameObject.SetActive(false);
            TipsUI[0].gameObject.SetActive(false);
        }
        if (other.name == "weishenzhi")
        {
            TipsUI[1].gameObject.SetActive(!true);
        }
        if (other.name == "xishoutai")
        {
            TipsUI[2].gameObject.SetActive(!true);
        }
        if (other.name == "goKeting")
        {
            TipsUI[5].gameObject.SetActive(!true);
        }
        if (other.name == "matong" && isMatongOpen)
        {
            zuoxiaTIps.SetActive(!true);
        }
    }
}
