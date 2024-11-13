using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private GameObject LetterUI;
    private RawImage LetterUImage;

    [SerializeField] Texture2D LetterImage;
    private Material mat;

    // AUDIO
    AudioSource SFXSource;
    public AudioClip SFX_Feuille;

    // Start is called before the first frame update
    void Start()
    {
        SFXSource = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mat = GetComponent<Renderer>().material;
        LetterUImage = LetterUI.GetComponent<RawImage>();

        mat.mainTexture = LetterImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        Debug.Log("Letter should be reading");

        if (col.CompareTag("Player"))
        {
            // AudioManager.PlaySFX(SFXSource, SFX_Feuille);

            SFXSource.PlayOneShot(SFX_Feuille);

            LetterUImage.texture = LetterImage;
            Reading();
            Destroy(this.gameObject);
        }
    }


    public void Reading()
    {
        gameManager.LettersCollected++;
        gameManager.ShowLetter = true;
        LetterUI.SetActive(true);
    }
}
