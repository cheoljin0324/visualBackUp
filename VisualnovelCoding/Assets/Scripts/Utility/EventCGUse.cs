using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCGUse : MonoBehaviour
{
    public List<EventCG> eventCGs;
}

[System.Serializable]
public struct EventCG{

    public Sprite usedEventSprite;
    public string cGID;

}
