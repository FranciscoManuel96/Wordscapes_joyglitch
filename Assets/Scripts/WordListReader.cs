using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class WordListReader : MonoBehaviour
{
    public HashSet<string> words;
    [SerializeField] TextAsset csvFile;

    void Start()
    {
        ReadCSV();
    }

    //Use hashset to save the words read from the Word List file
    void ReadCSV()
    {
        string[] tempWords = csvFile.text.Split("\r\n");
        words = new HashSet<string>(tempWords);
    }
}
