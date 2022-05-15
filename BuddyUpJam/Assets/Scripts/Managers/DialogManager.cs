using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI nameText;

    [SerializeField] private GameObject nameBox;
    [SerializeField] private int currentLine;

    [SerializeField] Image leftPortrait;
    [SerializeField] Image rightPortrait;

    private bool justStarted = false;

    public GameObject dialogBox;
    public string[] dialogLines;

    private int dialogNumber = 1;


    //private void OnEnable()
    //{
    //    EventHandler.DialogFinished += DialogFinished;
    //}

    //private void OnDisable()
    //{
    //    EventHandler.DialogFinished -= DialogFinished;
    //}

    private void Start()
    {
        //FirstDialogSet();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);
                        EventHandler.CallDialogFinishedEvent(dialogNumber);
                        //GameManager.instance.dialogueActive = false;

                        return;
                    }
                    CheckIfName();
                    dialogText.text = dialogLines[currentLine];
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

    public void ShowDialogue(string[] newLines, bool isPerson, int personToShow, Dictionary<int, int[]> linesToHidePerson)
    {
        dialogLines = newLines;
        currentLine = 0;
        CheckIfName();
        dialogBox.SetActive(true);
        dialogText.text = dialogLines[currentLine];
        
        if (isPerson)
        {
            nameBox.SetActive(true);
            switch (personToShow)
            {
                case 1:
                    leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                    nameText.text = "Miyako";
                    break;
                case 2:
                    rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                    nameText.text = "Teo";
                    break;
                default:
                    leftPortrait.color = new Color(1f, 1f, 1f, 0f);
                    rightPortrait.color = new Color(1f, 1f, 1f, 0f);
                    break;
            }
        }
        justStarted = true;
       // GameManager.instance.dialogueActive = true;
    }

    public void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }

    public void FirstDialogSet()
    {
        dialogNumber = 1;
        string[] dialogLines = new string[4];
        dialogLines[0] = "...";
        dialogLines[1] = "I just have to get through this";
        dialogLines[2] = "It's already halfway through the day, then...";
        dialogLines[3] = "...";

        ShowDialogue(dialogLines, true, 1, new Dictionary<int, int[]>());
    }

    
}
