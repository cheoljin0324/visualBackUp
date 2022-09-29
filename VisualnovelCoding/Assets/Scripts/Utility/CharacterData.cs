using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterData : MonoBehaviour
{
    [SerializeField]
    public List<Character> characters;

}
[System.Serializable]
public struct Character
{
    public string name;
    public string UseID;
    public Sprite[] Emotion;

}


