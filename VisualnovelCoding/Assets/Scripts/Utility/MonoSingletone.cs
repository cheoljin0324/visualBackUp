using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletone<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance { get; private set; }
    void Awake() => instance = FindObjectOfType(typeof(T)) as T;
}
