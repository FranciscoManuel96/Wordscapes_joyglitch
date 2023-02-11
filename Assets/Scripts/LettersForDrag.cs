using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LettersForDrag : MonoBehaviour
{
    [SerializeField] float radius = 0.3f;
    [SerializeField] Transform centerDraggingArea;
    [SerializeField] string[] levelLetters;
    [SerializeField] GameObject textBox;

    int temp = 3;
    int numbLetters;



    // Start is called before the first frame update
    void Start()
    {
        LettersForLevel(temp);
        print(numbLetters);
        for (int i = 0; i < numbLetters; i++)
        {
            //circunferencia de raio radius com letras espalhadas pelo Pi de acordo com a quantidade de letras
            Vector3 pos = transform.position + new Vector3(Mathf.Cos(i*(2 * Mathf.PI) / numbLetters), Mathf.Sin(i * (2 * Mathf.PI) / numbLetters), -1) * radius;
            GameObject createdLetter = Instantiate(textBox, pos, Quaternion.identity, transform);
            createdLetter.GetComponent<TextMeshProUGUI>().text = levelLetters[i];
            print("teste");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LettersForLevel(int level)
    {
        if (level == 1) 
        { 
            levelLetters = new string[] { "A", "B", "E", "T" };
        }
        else if (level == 2) 
        { 
            levelLetters = new string[] { "A", "R", "O", "R", "W" };
        }
        else if (level == 3) 
        { 
            levelLetters = new string[] { "I", "N", "E", "T", "R", "N", "T", "E" };
        }
        else if (level == 4) 
        { 
            levelLetters = new string[] { "F", "R", "S", "T", "O", "Y", "A", "U" };
        }
        else if (level == 5) 
        { 
            levelLetters = new string[] { "R", "A", "D", "T", "I", "A", "E", "N" };
        }
        numbLetters = levelLetters.Length;
    }
}
