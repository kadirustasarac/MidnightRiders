using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;
    [SerializeField] TMP_Text optionsFirstText;
    [SerializeField] TMP_Text optionSecondText;
    [SerializeField] GameObject optionFirst;
    [SerializeField] GameObject optionSecond;
    [SerializeField] private float writeTime = 0.5f;
    private GameManager gm;
    SoundHandler soundHandler;
    Animator animator;
    public string dialogT = "Bir gun kafayi siyirip birimizi vuracagini hep dusunmusumdur. Ama bunun bugun olacagini hic tahmin etmemistim...";
    public string optionsFirstT = "YOO";
    public string optionsSecondT = "Ben degildim";
    public string answerFirst = "Biz kotuyuz ayneen";
    public string answerSecond = "yokyaw";
    bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        gm = FindFirstObjectByType<GameManager>();
        soundHandler = FindObjectOfType<SoundHandler>();
        soundHandler.PhoneRing();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isOpen)
        {
           CallingCutscene();
           isOpen = true;
           soundHandler.StopAudio();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(WriteText(dialogText, "Bir gun kafayi siyirip birimizi vuracagini hep dusunmusumdur. Ama bunun bugun olacagini hic tahmin etmemistim..."));
        }
    }


    public void CallingCutscene()
    {
        animator.SetTrigger("SPEAKING");
    }


    public void WriteTexts()
    {
        StartCoroutine(StartConvo());

    }

    IEnumerator StartConvo()
    {
        yield return StartCoroutine(WriteText(dialogText, dialogT));
        optionFirst.SetActive(true);
        optionSecond.SetActive(true);
        optionsFirstText.text = optionsFirstT;
        optionSecondText.text = optionsSecondT;
    }


    IEnumerator WriteText(TMP_Text text,string write)
    {
        soundHandler.TalkSound();
        text.text = "";
        bool textFinished = false;
        string finalText = "";
        foreach (char word in write)
        {
            finalText += word;
            text.text = finalText;
            yield return new WaitForSeconds(writeTime);
        }
        soundHandler.StopAudio();
       
        
    }

    public void OptionsFirst()
    {
        optionFirst.SetActive(false);
        optionSecond.SetActive(false);
        StartCoroutine(OptionsFirstCoroutine());
    }

    IEnumerator OptionsFirstCoroutine()
    {
        yield return StartCoroutine(WriteText(dialogText, answerFirst));
        yield return new WaitForSeconds(2f);
        gm.isSpawningEnemy = true;
        gm.HideCursor();
        gm.dialogEnded = true;
        Destroy(gameObject);
    }
    IEnumerator OptionsSecondCoroutine()
    {
        yield return StartCoroutine(WriteText(dialogText, answerSecond));
        yield return new WaitForSeconds(2f);
        gm.isSpawningEnemy = true;
        gm.HideCursor();
        gm.dialogEnded = true;
        Destroy(gameObject);
    }

    public void OptionsSecond()
    {
        optionFirst.SetActive(false);
        optionSecond.SetActive(false);
        StartCoroutine(OptionsSecondCoroutine());
    }
}
