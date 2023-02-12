using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class WordListReader : MonoBehaviour
{
    public HashSet<string> words;
    [SerializeField] TextAsset csvFile;

    //usar hashset para guardar a lista de palavras
    void ReadCSV()
    {
        string[] tempWords = csvFile.text.Split("\r\n");
        words = new HashSet<string>(tempWords);
    }
    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }
}
