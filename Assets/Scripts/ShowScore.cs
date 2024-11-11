using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    TextMeshProUGUI BestText;

    // Start is called before the first frame update
    void Start()
    {
        PrintScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrintScore()
    {
        BestText = GetComponent<TextMeshProUGUI>();
        BestText.text = Timer.BestTime.ToString();
    }

}
