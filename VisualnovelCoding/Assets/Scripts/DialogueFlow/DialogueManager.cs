using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    DialogueSET direct;
    public int playercount = 0;
    bool gameend = false;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => direct.DialogueUpdate());
    }
}
