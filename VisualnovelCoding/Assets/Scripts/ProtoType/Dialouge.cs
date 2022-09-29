using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialouge : MonoBehaviour
{
    [SerializeField]
    public List<DialogueData> dialSet = new List<DialogueData>();

    private void Start()
    {
        List<Dictionary<string, object>> data_Dialogue1 = CSVReader.Read("Dialogue1");
        for (int i = 0; i < data_Dialogue1.Count; i++)
        {

            dialSet.Add(null);
            dialSet[i].dialogueNumber = data_Dialogue1[i]["N"].ToString();
            dialSet[i].backGround = data_Dialogue1[i]["BackGround"].ToString();
            dialSet[i].talkType = data_Dialogue1[i]["TalkType"].ToString();

            if (data_Dialogue1[i]["UseCharacter(1)"].ToString().Length != 0)
            {
                dialSet[i].useCheracter[0] = data_Dialogue1[i]["UseCharacter(1)"].ToString();
                dialSet[i].useEmotion[0] = data_Dialogue1[i]["Emotion(1)"].ToString();
                dialSet[i].charPos[0] = data_Dialogue1[i]["characterPos(1)"].ToString();
            }

            if (data_Dialogue1[i]["UseCharacter(2)"].ToString().Length != 0)
            {
                dialSet[i].useCheracter[1] = data_Dialogue1[i]["UseCharacter(2)"].ToString();
                dialSet[i].useEmotion[1] = data_Dialogue1[i]["Emotion(2)"].ToString();
                dialSet[i].charPos[1] = data_Dialogue1[i]["characterPos(2)"].ToString();
            }

            if (data_Dialogue1[i]["UseCharacter(3)"].ToString().Length != 0)
            {
                dialSet[i].useCheracter[2] = data_Dialogue1[i]["UseCharacter(3)"].ToString();
                dialSet[i].useEmotion[2] = data_Dialogue1[i]["Emotion(3)"].ToString();
                dialSet[i].charPos[2] = data_Dialogue1[i]["characterPos(3)"].ToString();
            }

            dialSet[i].useCG = data_Dialogue1[i]["UseCG"].ToString();
            dialSet[i].dialogue = data_Dialogue1[i]["Dialogue"].ToString();

            if (data_Dialogue1[i]["Z"].ToString() == "true") dialSet[i].zoom = true;
            else dialSet[i].zoom = false;

            if (data_Dialogue1[i]["PrintImage"].ToString().Length != 0)
            {
                dialSet[i].printImage = data_Dialogue1[i]["PrintImage"].ToString();
            }

            if (data_Dialogue1[i]["Selection1"].ToString().Length != 0)
            {
                dialSet[i].selection[0] = data_Dialogue1[i]["Selection1"].ToString();
                dialSet[i].selectionEvent[0] = data_Dialogue1[i]["SelectionEvent1"].ToString();
            }
            if (data_Dialogue1[i]["Selection2"].ToString().Length != 0)
            {
                dialSet[i].selection[1] = data_Dialogue1[i]["Selection2"].ToString();
                dialSet[i].selectionEvent[1] = data_Dialogue1[i]["SelectionEvent2"].ToString();
            }
            if (data_Dialogue1[i]["Selection3"].ToString().Length != 0)
            {
                dialSet[i].selection[2] = data_Dialogue1[i]["Selection3"].ToString();
                dialSet[i].selectionEvent[2] = data_Dialogue1[i]["SelectionEvent3"].ToString();
            }
            if(data_Dialogue1[i]["talkChar"].ToString().Length != 0)
            {
                dialSet[i].talkChar = data_Dialogue1[i]["talkChar"].ToString();
            }
        }
    }

}

[System.Serializable]
public class DialogueData
{
    public string dialogueNumber;
    public string backGround;
    public string talkType;
    public List<string> useCheracter;
    public List<string> useEmotion;
    public List<string> charPos;
    public string useCG;
    [TextArea(3, 5)]
    public string dialogue;
    public bool zoom;
    public string printImage;
    public List<string> selection;
    public List<string> selectionEvent;
    public string talkChar;
}
