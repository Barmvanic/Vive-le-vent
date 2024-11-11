using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool ShowLetter;
    public int LettersCollected = 0;
    public int LettersNeeded = 5;
    private Timer timer;
    [SerializeField] private GameObject LetterUI;
    [SerializeField] TextMeshProUGUI UIText;
    [SerializeField] TextMeshProUGUI TimerText;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        ShowLetter = false;
        LetterUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = LettersCollected.ToString() + " / " + LettersNeeded.ToString();

        TimerCount();
        PrintTime();

        if (ShowLetter)
        {
            CloseLetter();
        }

        
    }

    void PrintTime()
    {
        float minutes = Mathf.FloorToInt(timer.CurrentTime / 60);
        float seconds = Mathf.FloorToInt(timer.CurrentTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void TimerCount()
    {
        if (!ShowLetter)
            timer.CurrentTime -= 1 * Time.deltaTime;
        
        if (timer.CurrentTime <= 0)
        {
            timer.CurrentTime = 0;
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }
    }

    void CloseLetter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LetterUI.SetActive(false);
            ShowLetter = false;

            // End game
            if (LettersCollected == LettersNeeded)
            {
               
                Timer.BestTime = timer.CurrentTime;

                if (SceneManager.GetActiveScene().buildIndex != (SceneManager.sceneCountInBuildSettings - 1))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                else
                    SceneManager.LoadScene("Main_SCN");
            }
        }
    }
}
