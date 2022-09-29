using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    public List<DialogueData> dialSet;
    public List<string> testString;
    DialogueData DeaultData;
    List<Dictionary<string, object>> data_Dialogue1;

    private void Start()
    {

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
    }
}
