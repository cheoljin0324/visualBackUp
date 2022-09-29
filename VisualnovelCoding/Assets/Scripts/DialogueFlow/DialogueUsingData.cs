using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUsingData : MonoBehaviour
{
    public int nowNumber = 0;

    [SerializeField]
    private string excelName;

    public List<string> dialogueNumber;
    public List<string> backGround;
    public List<string> talkType;
    public List<string> useCharacter1;
    public List<string> useCharacter2;
    public List<string> useCharacter3;
    public List<string> emotion1;
    public List<string> emotion2;
    public List<string> emotion3;
    public List<string> useCG;
    public List<string> dialogues;
    public List<string> zoom;
    public List<string> selection1;
    public List<string> selection2;
    public List<string> selection3;
    public List<string> selectionEvent1;
    public List<string> selectionEvent2;
    public List<string> selectionEvent3;
    public List<string> selectionMent1;
    public List<string> selectionMent2;
    public List<string> selectionMent3;
    public List<string> talkChar;
    public List<string> eventTrans;
    public List<string> bgmSound;
    public List<string> voiceSound;
   



    private void Awake()
    {
            List<Dictionary<string, object>> data_Dialogue = CSVReader.Read(excelName);
            for (int i = 0; i < data_Dialogue.Count; i++)
            {
                dialogueNumber.Add(null);
                backGround.Add(null);
                talkType.Add(null);
                useCharacter1.Add(null);
                useCharacter2.Add(null);
                useCharacter3.Add(null);
                emotion1.Add(null);
                emotion2.Add(null);
                emotion3.Add(null);
                useCG.Add(null);
                dialogues.Add(null);
                zoom.Add(null);
                selection1.Add(null);
                selection2.Add(null);
                selection3.Add(null);
                selectionEvent1.Add(null);
                selectionEvent2.Add(null);
                selectionEvent3.Add(null);
                selectionMent1.Add(null);
                selectionMent2.Add(null);
                selectionMent3.Add(null);
                talkChar.Add(null);
                eventTrans.Add(null);
                bgmSound.Add(null);
                voiceSound.Add(null);


                dialogueNumber[i] = data_Dialogue[i]["N"].ToString();
                backGround[i] = data_Dialogue[i]["BackGround"].ToString();
                talkType[i] = data_Dialogue[i]["TalkType"].ToString();
                useCharacter1[i] = data_Dialogue[i]["UseCharacter(1)"].ToString();
                useCharacter2[i] = data_Dialogue[i]["UseCharacter(2)"].ToString();
                useCharacter3[i] = data_Dialogue[i]["UseCharacter(3)"].ToString();
                emotion1[i] = data_Dialogue[i]["Emotion(1)"].ToString();
                emotion2[i] = data_Dialogue[i]["Emotion(2)"].ToString();
                emotion3[i] = data_Dialogue[i]["Emotion(3)"].ToString();
                useCG[i] = data_Dialogue[i]["UseCG"].ToString();
                dialogues[i] = data_Dialogue[i]["Dialogue"].ToString();
                zoom[i] = data_Dialogue[i]["Z"].ToString();
                selection1[i] = data_Dialogue[i]["Selection1"].ToString();
                selection2[i] = data_Dialogue[i]["Selection2"].ToString();
                selection3[i] = data_Dialogue[i]["Selection3"].ToString();
                selectionEvent1[i] = data_Dialogue[i]["SelectionEvent1"].ToString();
                selectionEvent2[i] = data_Dialogue[i]["SelectionEvent2"].ToString();
                selectionEvent3[i] = data_Dialogue[i]["SelectionEvent3"].ToString();
                selectionMent1[i] = data_Dialogue[i]["selection ment1"].ToString();
                selectionMent1[i] = data_Dialogue[i]["selection ment2"].ToString();
                selectionMent1[i] = data_Dialogue[i]["selection ment3"].ToString();
                talkChar[i] = data_Dialogue[i]["talkChar"].ToString();
                eventTrans[i] = data_Dialogue[i]["EventTrans"].ToString();
                bgmSound[i] = data_Dialogue[i]["BGM"].ToString();
                voiceSound[i] = data_Dialogue[i]["Voice"].ToString();

            
        }
    }
        

}
