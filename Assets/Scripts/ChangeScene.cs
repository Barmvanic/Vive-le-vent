using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreen : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene();
    }

    void ChangeScene()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            if (SceneManager.GetActiveScene().buildIndex != (Application.levelCount - 1))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene("Main_SCN");
        }
    }
}
