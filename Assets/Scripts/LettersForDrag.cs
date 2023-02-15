using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LettersForDrag : MonoBehaviour
{
    [SerializeField] Transform centerDraggingArea;
    [SerializeField] Transform levelWords;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject textBox;
    [SerializeField] string[] levelLetters;
    [SerializeField] float radius = 0.25f;
    [SerializeField] float radiusLetter = 0.35f;
    
    Camera mainCamera;
    List<LetterDetection> letters = new List<LetterDetection>();
    WordListReader wordListReader;

    string currentWord = String.Empty;
    int numbLetters, score;
    int wordTemp;

    private void Awake()
    {
        //Initialize word list
        wordListReader = GetComponent<WordListReader>();
    }

    void Start()
    {
        //Get score and level value
        int score = PlayerPrefs.GetInt("score");
        scoreText.text = score.ToString();
        mainCamera = Camera.main;
        int level = PlayerPrefs.GetInt("level");
        
        LettersForLevel(level);
        GenerateLetters();
    }

    void Update()
    {
        //When touch ends
        if (Input.touchCount == 0 && currentWord != string.Empty)
        {
            VerifyWord();
            CleanCurrWord();
        }
    }

    //Generate letters onto the circle panel
    private void GenerateLetters()
    {
        for (int i = 0; i < numbLetters; i++)
        {
            //Print the letters of the level on the dragging area through a circumference depending on the number of letters the level has
            Vector3 pos = transform.position + new Vector3(Mathf.Cos(i * (2 * Mathf.PI) / numbLetters), Mathf.Sin(i * (2 * Mathf.PI) / numbLetters), -1) * radius;

            GameObject createdLetter = Instantiate(textBox, pos, Quaternion.identity, transform);
            createdLetter.GetComponentInChildren<TextMeshProUGUI>().text = levelLetters[i];
            LetterDetection letter = createdLetter.GetComponentInChildren<LetterDetection>();
            letter.OnTouchEnter+= (t) =>
            {
                currentWord += t;
            };
            letters.Add(letter);
        }
    }

    //Verify if the word formed is on the board (+2 points), in the word list (+1 point) or none
    void VerifyWord()
    {
        foreach (Transform child in levelWords)
        {
            if (!child.gameObject.activeSelf && child.name.ToUpper() == currentWord.ToUpper())
            {
                child.gameObject.SetActive(true);
                wordTemp += 1;
                score = PlayerPrefs.GetInt("score");
                PlayerPrefs.SetInt("score", score + 2);
                scoreText.text = score.ToString();
                if (wordTemp == levelWords.childCount)
                {
                    NextLevel();
                }
                return;
            }
        }

        if (wordListReader.words.Contains(currentWord.ToUpper()))
        {
            score = PlayerPrefs.GetInt("score");
            PlayerPrefs.SetInt("score", score + 1);
            scoreText.text = score.ToString();
        }
        else
        {
            //Toast Message "Invalid Word"
        }
    }

    //Clean formed word
    void CleanCurrWord()
    {
        currentWord = string.Empty;
        foreach (LetterDetection letter in letters)
        {
            letter.EnableLetter();
        }
    }

    //Change level to next one
    void NextLevel()
    {
        int level = PlayerPrefs.GetInt("level") + 1;
        PlayerPrefs.SetInt("level", level);
        SceneManager.LoadScene(level);
    }

    //Define words for the level and define number of letters depending on the level variable value
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
            levelLetters = new string[] { "R", "A", "D", "T", "I", "A", "E", "N", "T" };
        }
        numbLetters = levelLetters.Length;
    }
}
