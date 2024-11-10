using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool ShowLetter;
    public int LettersCollected = 0;
    public int LettersNeeded = 5;
    [SerializeField] private GameObject LetterUI;
    [SerializeField] TextMeshProUGUI UIText;

    // Start is called before the first frame update
    void Start()
    {
        ShowLetter = false;
        LetterUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = LettersCollected.ToString() + " / " + LettersNeeded.ToString();

        if (ShowLetter)
        {
            CloseLetter();
        }
    }

    void CloseLetter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LetterUI.SetActive(false);
            ShowLetter = false;
        }
    }
}
