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



    public Image leftPortrait;
    /// <summary>
    /// 0 = Myiako, 1 = Myiako angry, 2 = Miyako happy, 3 = Miyako startled
    /// </summary>
    [SerializeField] private Sprite[] leftSprites;
    public Image rightPortrait;
    /// <summary>
    /// 0 = Teo, 1 = Teo sad, 2 = Teo happy
    /// </summary>
    [SerializeField] private Sprite[] rightSprites;

    private bool justStarted = false;

    public GameObject dialogBox;
    public string[] dialogLines;

    private int dialogNumber = 1;
    private bool specialCase = false;

    

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
                    if(specialCase)
                    {
                        SpecialCase();
                    }
                }
                else
                {
                    justStarted = false;
                }
            }
        }
    }

    private void SpecialCase()
    {
        switch (currentLine)
        {
            case 0:
                leftPortrait.sprite = leftSprites[1];
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                
                break;
            case 1:
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                break;
            case 2:
                nameText.text = "?";
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 3:
                nameText.text = "Miyako";
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                break;
            case 4:
                nameText.text = "?";
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 5:
                nameText.text = "Miyako";
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 6:
                leftPortrait.sprite = leftSprites[0];
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                break;
            case 7:
                nameText.text = "?";
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 8:
                nameText.text = "Miyako";
                leftPortrait.sprite = leftSprites[3];
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                break;
            case 9:
                nameText.text = "?";
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 10:
                nameText.text = "Miyako";
                leftPortrait.sprite = leftSprites[0];
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 11:
                nameText.text = "Teo";
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 12:
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 13:
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 14:
                nameText.text = "Miyako";
                leftPortrait.sprite = leftSprites[0];
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                break;
            case 15:
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                break;
            case 16:
                nameText.text = "Teo";
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;
            case 17:
                nameText.text = "Miyako";
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                break;
            case 18:
                leftPortrait.color = new Color(1f, 1f, 1f, 1f);
                rightPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                break;
            case 19:
                nameText.text = "Teo";
                if (SoundManager.Instance != null)
                {
                    SoundManager.Instance.PlaySfx(6);
                }
                rightPortrait.sprite = rightSprites[2];
                leftPortrait.color = new Color(1f, 1f, 1f, 0.6f);
                rightPortrait.color = new Color(1f, 1f, 1f, 1f);
                break;

            default:
                break;
        }
    }

    public void ShowDialogue(string[] newLines, bool isPerson, int personToShow, bool specialCase)
    {
        this.specialCase = specialCase;
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

        ShowDialogue(dialogLines, true, 1, false);
    }

    public void SecondDialogSet()
    {
        dialogNumber = 2;
        string[] dialogLines = new string[8];
        dialogLines[0] = "...";
        dialogLines[1] = "I wish things could stop being so hard";
        dialogLines[2] = "I just need a break";
        dialogLines[3] = "Everyone keeps talking, but no one ever does anything.";
        dialogLines[4] = "I hate them";
        dialogLines[5] = "I hate my job";
        dialogLines[6] = "I hate my life";
        dialogLines[7] = "...";

        ShowDialogue(dialogLines, true, 1,false);
    }

    public void ThirdDialogSet()
    {
        dialogNumber = 3;
        string[] dialogLines = new string[1];
        dialogLines[0] = "Oh! That irresponsible person! Throwing things at me? I’ll show him!";
        
        ShowDialogue(dialogLines, true, 1, false);
    }

    public void FourthDialogSet()
    {
        dialogNumber = 4;
        string[] dialogLines = new string[20];
        dialogLines[0] = "Sorry - Hey!";
        dialogLines[1] = "You’re the one who threw this paper crane at me! What’s wrong with you?";
        dialogLines[2] = "Hey, that wasn’t me! Why would I go around throwing paper cranes at people";
        dialogLines[3] = "If it wasn’t you, who was it?";
        dialogLines[4] = "Well, I didn’t see them, obviously.";
        dialogLines[5] = "But I know where you can find them.";
        dialogLines[6] = "Then tell me.";
        dialogLines[7] = "Tell you what, I’ll give you that information if you help me with my performance today.";
        dialogLines[8] = "What? Isn’t that blackmailing?";
        dialogLines[9] = "No, listen!";
        dialogLines[10] = "Today’s performance is really important to me, alright?";
        dialogLines[11] = "I’m Teo, and this is the last time I’ll perform. I'm moving in with my ailing partner tomorrow, and… everything needs to be perfect.";
        dialogLines[12] = "See, my partner is a composer, and they’re the sweetest person ever. They wrote this new song just for me. Can you believe it?";
        dialogLines[13] = "But I need to download this app that will help me translate the notes properly, otherwise I won’t be able to play it. So if you could just…";
        dialogLines[14] = "...";
        dialogLines[15] = "I can read the music for you, if you’d like.";
        dialogLines[16] = "Huh? You can read it?";
        dialogLines[17] = "Yeah, I took music lessons when I was a child. I used to like it so much that my tutor became one of my favorite adults back then.";
        dialogLines[18] = "It’s a bit silly, but at least I can help you now.";
        dialogLines[19] = "It’s not silly at all! Thank you for the help, by the way.";

        ShowDialogue(dialogLines, true, 1, true);
    }

    
}
