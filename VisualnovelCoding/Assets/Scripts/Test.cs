using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Test : MonoBehaviour
{
    void Start()
    {
        List<Dictionary<string, object>> data_Dialouge = CSVReader.Read("Test");
        for (int i = 0; i< data_Dialouge.Count; i++)
        {
            print(data_Dialouge[i]["Second"].ToString());
        }
    }
}
