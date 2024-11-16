using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeSCN");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ChangeSCN()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
