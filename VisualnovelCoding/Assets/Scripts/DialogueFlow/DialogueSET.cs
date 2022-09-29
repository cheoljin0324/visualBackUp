using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DialogueSET : MonoBehaviour
{
    //ó������ �ƴ��� �ľ��ϴ� bool ��
    private bool isFirst = true;
    //���� �������� ����ǰ� �ִ��� �ľ��ϴ� bool ��
    private bool nowselection = false;
    //���� Ÿ���� ���ΰ��� �˷��ִ� bool ��
    private bool isTyping = false;

    //ù ��° �ε���
    int bfNum = 0;
    //�� ��° �ε���
    int bsNum = 2;
    //�� ���� �ε���
    int btNum = 4;

    //Ÿ���� ���ǵ�
    public float typingSpd = 0.03f;
    //�÷��̾� ������ ������
    int playerselectionNum = 0;
    //Ʈ������ �����ΰ�?
    bool isTransition = false;

    //���� ���� Ű��
    string normal = "n";
    string selection = "s";
    string eventCG = "e";
    string transScreen = "t";
    string oneTalk = "o";
    string iftalk = "sd";

    //���̾�α� ������
    DialogueUsingData usingData;
    //��� ������(��������Ʈ ������)
    BackGroundDataBase backGorundData;
    //ĳ���� ������(��������Ʈ ������)
    CharacterData charData;
    //UI��������Ʈ Ŭ����
    UIDataClass uiClass;
    //���Ǵ� Empty Object ���� Ŭ���� 
    ObjectSetting obSetting;
    //���Ǵ� �̺�ƮCG ��������Ʈ Ŭ����
    EventCGUse eventUse;
    //���� �Ŵ���
    SoundManager soundManager;


    //�ϴ� ĳ��
    void Awake()
    {
        usingData = GetComponent<DialogueUsingData>();
        backGorundData = FindObjectOfType<BackGroundDataBase>();
        charData = FindObjectOfType<CharacterData>();
        obSetting = FindObjectOfType<ObjectSetting>();
        uiClass = FindObjectOfType<UIDataClass>();
        eventUse = FindObjectOfType<EventCGUse>();
        soundManager = FindObjectOfType<SoundManager>();
    }







    /// <summary>
    /// ������Ʈ �ʱ� �غ�
    /// </summary>
    void inGameInit()
    {
        //������Ʈ Ű��(������ Fade 0 )
        obSetting.dialogueBox.gameObject.SetActive(true);
        obSetting.nameText.gameObject.SetActive(true);
        obSetting.talkText.gameObject.SetActive(true);
        obSetting.eventCG.gameObject.SetActive(true);
        obSetting.backGround.gameObject.SetActive(true);

        //Name Talk �ʱ�ȭ
        obSetting.nameText.text = "";
        obSetting.talkText.text = "";

        //���̾�α� �ڽ� ��������Ʈ ����
        obSetting.dialogueBox.sprite = uiClass.dialogueBox;

        //�÷��� Ȥ�� ���� ��������...
        obSetting.dialogueBox.color = new Color(1, 1, 1, 0);
        obSetting.eventCG.color = new Color(1, 1, 1, 0);
    }





    /// <summary>
    /// DialIndex ���
    /// </summary>
    /// <param name="dialIndex"></param>
    void BackGroundSetting()
    {
        //���� ��� ���� �� �����´�.
        int nowbackNum = int.Parse(usingData.backGround[usingData.nowNumber]);
        //���� ������ ������
        if (obSetting.backGround.sprite != backGorundData.setSprite[nowbackNum])
        {
            //��� ��ȯ
            obSetting.cutton.DOFade(1, 0.5f);
            obSetting.backGround.sprite = backGorundData.setSprite[nowbackNum];
            obSetting.cutton.DOFade(0, 0.5f);
        }
    }





    /// <summary>
    /// ĳ���� ����
    /// </summary>
    /// <param name="posNumber"></param>
    /// <param name="charID"></param>
    /// <param name="emotionNumber"></param>
    IEnumerator CharacterSetting(int posNumber, string charID, string emotionNumber)
    {
        //�̸���� int�� ��ȯ�ؼ� ���� �´�.
        int emotion = int.Parse(emotionNumber);
        //charData.characters�� ī��Ʈ ��ŭ �ݺ��� ������.
        for (int i = 0; i < charData.characters.Count; i++)
        {
            //UseID ���
            if (charData.characters[i].UseID == charID)
            {
                if (posNumber % 2 == 0)
                {
                    obSetting.charRenderer[posNumber + 1].DOFade(0, 0.5f);
                    if (isFirst == false)
                    {
                        if (usingData.zoom[usingData.nowNumber] == "t")
                        {
                            yield return new WaitForSeconds(0.5f);
                            obSetting.charRenderer[posNumber].transform.localScale = obSetting.charRenderer[posNumber].transform.localScale * 2;
                            obSetting.charRenderer[posNumber].transform.position = new Vector3(obSetting.charRenderer[posNumber].transform.position.x, -9f, 0f);
                            obSetting.charRenderer[posNumber+1].transform.localScale = obSetting.charRenderer[posNumber+1].transform.localScale * 2;
                            obSetting.charRenderer[posNumber+1].transform.position = new Vector3(obSetting.charRenderer[posNumber+1].transform.position.x, -9f, 0f);
                        }
                        else if (usingData.zoom[usingData.nowNumber - 1] == "t" && usingData.zoom[usingData.nowNumber] != "t")
                        {
                            yield return new WaitForSeconds(1f);
                            obSetting.charRenderer[posNumber].transform.localScale = obSetting.charRenderer[posNumber].transform.localScale / 2;
                            obSetting.charRenderer[posNumber].transform.position = new Vector3(obSetting.charRenderer[posNumber].transform.position.x, -2f, 0f);
                            obSetting.charRenderer[posNumber+1].transform.localScale = obSetting.charRenderer[posNumber+1].transform.localScale / 2;
                            obSetting.charRenderer[posNumber+1].transform.position = new Vector3(obSetting.charRenderer[posNumber+1].transform.position.x, -2f, 0f);
                        }
                    }
                  
                    obSetting.charRenderer[posNumber].sprite = charData.characters[i].Emotion[emotion];
                    obSetting.charRenderer[posNumber].DOFade(1, 0.5f);

                }
                else
                {
                    obSetting.charRenderer[posNumber - 1].DOFade(0, 0.5f);
                    if (isFirst == false)
                    {
                        if (usingData.zoom[usingData.nowNumber] == "t")
                        {
                            yield return new WaitForSeconds(0.5f);
                            obSetting.charRenderer[posNumber].transform.localScale = obSetting.charRenderer[posNumber].transform.localScale * 2;
                            obSetting.charRenderer[posNumber].transform.position = new Vector3(obSetting.charRenderer[posNumber].transform.position.x, -9f, 0f);
                            obSetting.charRenderer[posNumber - 1].transform.localScale = obSetting.charRenderer[posNumber-1].transform.localScale * 2;
                            obSetting.charRenderer[posNumber - 1].transform.position = new Vector3(obSetting.charRenderer[posNumber-1].transform.position.x, -9f, 0f);
                        }
                        else if (usingData.zoom[usingData.nowNumber - 1] == "t" && usingData.zoom[usingData.nowNumber] != "t")
                        {
                            yield return new WaitForSeconds(0.5f);
                            obSetting.charRenderer[posNumber].transform.localScale = obSetting.charRenderer[posNumber].transform.localScale / 2;
                            obSetting.charRenderer[posNumber].transform.position = new Vector3(obSetting.charRenderer[posNumber].transform.position.x, -2f, 0f);
                            obSetting.charRenderer[posNumber-1].transform.localScale = obSetting.charRenderer[posNumber-1].transform.localScale / 2;
                            obSetting.charRenderer[posNumber-1].transform.position = new Vector3(obSetting.charRenderer[posNumber-1].transform.position.x, -2f, 0f);
                        }
                    }
                    obSetting.charRenderer[posNumber].sprite = charData.characters[i].Emotion[emotion];
                    obSetting.charRenderer[posNumber].DOFade(1, 0.5f);

                }
            }
        }

    }







    public bool DialogueUpdate()
    {
        if (isFirst == true)
        {
            Debug.Log(backGorundData.setSprite.Count);
            inGameInit();
            BackGroundSetting();
            NexDialogue();
            isFirst = false;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && isTransition == false)
            {
                if (isTyping == true)
                {
                    isTyping = false;
                }
                else
                {
                    usingData.nowNumber++;
                    soundManager.BGMStop();
                    soundManager.VoiceStop();
                    if (usingData.talkType[usingData.nowNumber] == eventCG)
                    {
                        obSetting.UseCGTransition.DOFade(1, 1f);
                    }
                    Debug.Log("������");
                    obSetting.endIcon.gameObject.SetActive(false);
                    BackGroundSetting();
                    NexDialogue();
                    return false;
                }

            }
            if (usingData.nowNumber > usingData.dialogueNumber.Count)
            {
                return true;
            }
        }
        return false;
    }






    void NexDialogue()
    {
        soundManager.BGMPlay(usingData.bgmSound[usingData.nowNumber]);
        soundManager.VoicePlay(usingData.voiceSound[usingData.nowNumber]);
        obSetting.dialogueBox.DOFade(1, 1f);
        if(usingData.nowNumber != 0)
        {
            if (usingData.talkType[usingData.nowNumber - 1] == eventCG && usingData.talkType[usingData.nowNumber] != eventCG)
            {
                obSetting.eventCG.DOFade(0f, 1f);
            }
        }
        if (usingData.talkType[usingData.nowNumber] == normal)
        {  
            normalDialogueSetting();
            DialogueTyping();
        }
        else if (usingData.talkType[usingData.nowNumber] == selection)
        {
            if (usingData.selection2[usingData.nowNumber] != "") selectionFuncSetting(2);
            else if (usingData.selection3[usingData.nowNumber] != "") selectionFuncSetting(3);
            else selectionFuncSetting(1);
        }
        else if (usingData.talkType[usingData.nowNumber] == eventCG)
        {

            EvnetCGSetting(usingData.eventTrans[usingData.nowNumber], usingData.useCG[usingData.nowNumber]);
            DialogueTyping();

        }
        else if (usingData.talkType[usingData.nowNumber] == transScreen)
        {
            ScreenTransition();
        }
        else if (usingData.talkType[usingData.nowNumber] == oneTalk)
        {
            onetalkfunc();
            StartCoroutine(Typing2(usingData.dialogues[usingData.nowNumber]));
        }
        else if (usingData.talkType[usingData.nowNumber] == iftalk)
        {
            if (GameManager.instance.playerNowSelection == 1)
            {
                SelectionTalk(0);
            }
            else if (GameManager.instance.playerNowSelection == 2)
            {
                SelectionTalk(1);
            }
            else if (GameManager.instance.playerNowSelection == 3)
            {
                SelectionTalk(2);
            }
        }


    }

    void SelectionTalk(int index)
    {
        StartCoroutine(Typing(usingData.selectionMent1[index]));
    }



    void onetalkfunc()
    {
        obSetting.oneDialogue.gameObject.SetActive(true);
        obSetting.oneDialogue.DOFade(1, 1f);
    }



    void normalDialogueSetting()
    {
        if (usingData.talkType[usingData.nowNumber] == transScreen)
        {
            obSetting.ScreenTransition.DOFade(0, 1f);
        }
        if (usingData.talkType[usingData.nowNumber] == eventCG)
        {
            obSetting.UseCGTransition.DOFade(0, 1f);
        }

        if (usingData.useCharacter1[usingData.nowNumber] != "n")
        {
            if (usingData.nowNumber == 0 ? true : usingData.emotion2[usingData.nowNumber] != usingData.emotion2[usingData.nowNumber] || usingData.zoom[usingData.nowNumber] != usingData.zoom[usingData.nowNumber-1])
            {
                StartCoroutine(CharacterSetting(bfNum, usingData.useCharacter1[usingData.nowNumber], usingData.emotion1[usingData.nowNumber]));
                if (bfNum == 1) bfNum = 0;
                else bfNum = 1;
            }
        }
        if (usingData.useCharacter2[usingData.nowNumber] != "n")
        {
            if (usingData.nowNumber == 0 ? true : usingData.emotion2[usingData.nowNumber] != usingData.emotion2[usingData.nowNumber] || usingData.zoom[usingData.nowNumber] != usingData.zoom[usingData.nowNumber - 1])
            {
                StartCoroutine(CharacterSetting(bsNum, usingData.useCharacter2[usingData.nowNumber], usingData.emotion2[usingData.nowNumber]));
                if (bsNum == 3) bsNum = 2;
                else bsNum = 3;
            }
        }
        if (usingData.useCharacter3[usingData.nowNumber] != "n")
        {
            if (usingData.nowNumber == 0 ? true : usingData.emotion2[usingData.nowNumber] != usingData.emotion2[usingData.nowNumber] || usingData.zoom[usingData.nowNumber] != usingData.zoom[usingData.nowNumber - 1])
            {
                StartCoroutine(CharacterSetting(btNum, usingData.useCharacter3[usingData.nowNumber], usingData.emotion3[usingData.nowNumber]));
                if (btNum == 5) btNum = 4;
                else btNum = 5;
            }
        }
    }






    void NameSet()
    {
        if (usingData.talkChar[usingData.nowNumber] != "n" && usingData.talkChar[usingData.nowNumber] != "")
        {
            for (int i = 0; i < charData.characters.Count; i++)
            {
                if (charData.characters[i].UseID == usingData.talkChar[usingData.nowNumber])
                {
                    obSetting.nameText.text = charData.characters[i].name;
                }
            }

        }
        else
        {
            obSetting.nameText.text = "";
        }

    }






    void selectionFuncSetting(int button)
    {
        if (button == 1)
        {
            obSetting.selectionButton[0].gameObject.SetActive(true);
            ButtonSetting(1);
        }
        else if (button == 2)
        {
            obSetting.selectionButton[1].gameObject.SetActive(true);
            obSetting.selectionButton[2].gameObject.SetActive(true);
            ButtonSetting(2);
        }
        else if (button == 3)
        {
            obSetting.selectionButton[3].gameObject.SetActive(true);
            obSetting.selectionButton[4].gameObject.SetActive(true);
            obSetting.selectionButton[5].gameObject.SetActive(true);
            ButtonSetting(3);
        }
    }






    void EvnetCGSetting(string transBool, string EventCG)
    {
        obSetting.eventCG.gameObject.SetActive(true);
        for (int i = 0; i < eventUse.eventCGs.Count; i++)
        {
            if (EventCG == eventUse.eventCGs[i].cGID)
            {
                if (transBool == "t")
                {
                    obSetting.eventCG.sprite = eventUse.eventCGs[i].usedEventSprite;
                    obSetting.eventCG.DOFade(1f, 1f);
                }
                else
                {
                    obSetting.eventCG.sprite = eventUse.eventCGs[i].usedEventSprite;
                    obSetting.eventCG.DOFade(1f, 1f);
                }

            }
        }
    }






    void ScreenTransition()
    {
        isTransition = true;
        obSetting.ScreenTransition.DOFade(1, 1f);
        StartCoroutine(TransitionSet());
    }

    IEnumerator TransitionSet()
    {
        yield return new WaitForSeconds(1f);
        obSetting.ScreenTransition.DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);
        isTransition = false;
    }


    void DialogueTyping()
    {
        StartCoroutine(Typing(usingData.dialogues[usingData.nowNumber]));
    }


    IEnumerator Typing(string text)
    {
        int index = 0;
        isTyping = true;
        NameSet();

        while (index < text.Length + 1)
        {
            obSetting.talkText.text = text.Substring(0, index);
            index++;

            if (index == text.Length)
            {
                isTyping = false;
            }

            if (isTyping == false)
            {
                obSetting.talkText.text = text;
                index = text.Length + 1;
                obSetting.endIcon.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(typingSpd);
        }
    }

    IEnumerator Typing2(string text)
    {
        int index = 0;
        isTyping = true;

        while (index < text.Length + 1)
        {
            obSetting.onetalkText.text = text.Substring(0, index);
            index++;

            if (index == text.Length)
            {
                isTyping = false;
            }

            if(isTyping == false)
            {
                obSetting.onetalkText.text = text;
                index = text.Length + 1;
            }
            yield return new WaitForSeconds(typingSpd);
        }
    }


    void ButtonSetting(int numset)
    {
        if(numset == 1)
        {
            obSetting.selectionButton[0].onClick.AddListener(()=>Selection(1));
        }
        else if(numset == 2)
        {
            obSetting.selectionButton[0].onClick.AddListener(() => Selection(1));
            obSetting.selectionButton[1].onClick.AddListener(() => Selection(2));
        }
        else if(numset == 3)
        {
            obSetting.selectionButton[0].onClick.AddListener(() => Selection(1));
            obSetting.selectionButton[1].onClick.AddListener(() => Selection(2));
            obSetting.selectionButton[2].onClick.AddListener(() => Selection(3));
        }
        nowselection = true;
    }

    void Selection(int set)
    {
        for(int i = 0; i<obSetting.selectionButton.Count; i++)
        {
            obSetting.selectionButton[i].gameObject.SetActive(false);
        }
        GameManager.instance.playerIndexData.Add(set);
        usingData.nowNumber++;
        nowselection = false;
    }



}
