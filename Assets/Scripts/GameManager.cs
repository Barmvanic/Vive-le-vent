using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool ShowLetter;
    [SerializeField] private GameObject LetterUI;

    // Start is called before the first frame update
    void Start()
    {
        ShowLetter = false;
        LetterUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
