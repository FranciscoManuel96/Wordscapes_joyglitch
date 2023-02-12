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
    [SerializeField] float radiusLetter = 0.35f;
    Camera mainCamera;

    int level = 1;
    int numbLetters;

    void Start()
    {
        mainCamera = Camera.main;
        LettersForLevel(level);
        GenerateLetters();
    }

    //[ContextMenu("generate")]
    private void GenerateLetters()
    {
        for (int i = 0; i < numbLetters; i++)
        {
            //print the letters of the level on the dragging area through a circumference depending on the number of letters the level has
            Vector3 pos = transform.position + new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / numbLetters), Mathf.Sin(i * (2 * Mathf.PI) / numbLetters), -1) * radius;
            GameObject createdLetter = Instantiate(textBox, pos, Quaternion.identity, transform);
            createdLetter.GetComponent<TextMeshProUGUI>().text = levelLetters[i];
        }
    }

    void Update()
    {
        //detetar touch (posiçao inicial e se interceptou algum dos colliders das letras)
        //if (Input.touchCount > 0)
        //{
        //    print("touch");
        //    Vector2 touchPoint = Input.touches[0].position;
        //    if (Vector2.Distance(touchPoint, (Vector2)transform.position + Vector2.right) <= radiusLetter)
        //    {
        //        Debug.Log("acertou");
        //    }
        //}
        if (Input.GetMouseButton(0))
        {
            
            Vector2 touchPoint = Input.mousePosition - transform.position;
            print(transform.position);
            //print(touchPoint);
            //print((Vector2)transform.position + Vector2.right);
            if (Vector2.Distance(touchPoint, (Vector2)transform.position + Vector2.right) <= radiusLetter)
            {
                Debug.Log("acertou");
            }
        }
        
    }


    //guardar a letra do respectivo collider onde tocou numa variavel
    //verificar se a palavra formada esta na grid (+2 pontos) ou se está na wordlist (+1 ponto)
    //

    //Hardcoded letters for the levels
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

    private void OnDrawGizmos()
    {
        for (int i = 0; i < numbLetters; i++)
        {
            //print the letters of the level on the dragging area through a circumference depending on the number of letters the level has
            Vector3 pos = transform.position + new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / numbLetters), Mathf.Sin(i * (2 * Mathf.PI) / numbLetters), -1) * radius;
            Gizmos.DrawSphere(pos, radiusLetter);
        }
    }
}
