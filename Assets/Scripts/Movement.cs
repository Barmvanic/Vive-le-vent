using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameManager gameManager;

    // MOVE AGAINST WALL
    private bool bump;
    [SerializeField] private float knockbackForce = 10f;
    private Vector3 moveWall;
    private Rigidbody rb;

    // AUDIO
    private bool firstMove;
    AudioSource WindSource;
    public AudioClip SFX_Wind;

    // MOVEMENT
    public bool fast;
    public float fastSpeed = 10f;
    public float moveSpeed = 1f;
    private float StartMoveSpeed;

    // ROTATION
    [SerializeField] private float rotateSpeed = 2f;
    private float xAngle, yAngle;
    private float exXAngle = 0f; 
    private float exYAngle = 0f;

    // TIMER
    [SerializeField] private float StartTime;
    [SerializeField] private float CurrentTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        WindSource = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        StartTime = CurrentTime;
        StartMoveSpeed = moveSpeed;

        fast = false;

        firstMove = true;
        WindSource.clip = SFX_Wind;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.ShowLetter == false)
        {
            if (firstMove)
            {
                AudioManager.PlayWind(WindSource);
                firstMove = false;
            }

            rotate();
            
            if (!bump)
                moveForward();
            else 
                moveAgainstWall();

        }
        else
        {
            StartCoroutine(AudioManager.StartFade(WindSource, 1f, 0f));
            firstMove = true;
        }
        
        Debug.Log(moveSpeed);
    }


    void rotate()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.x = mousePos.x - (Screen.width / 2);
        mousePos.y = mousePos.y - (Screen.height / 2);

        xAngle = mousePos.x / Screen.width;
        yAngle = mousePos.y / Screen.height;

        transform.Rotate(-yAngle * rotateSpeed, xAngle * rotateSpeed * 1.5f, 0f, Space.Self);

    }

    void moveForward()
    {
        // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // rb.velocity = Vector3.forward * moveSpeed;
        rb.velocity = (transform.forward) * moveSpeed;

        // Speed increase
        if ((yAngle - exYAngle > 0.01f) && (xAngle - exXAngle > 0.015f))
        {
            CurrentTime = StartTime;
            if (!fast)
                moveSpeed = StartMoveSpeed;
            else
                moveSpeed = StartMoveSpeed + fastSpeed;

        }
        else
        {
            CurrentTime -= 1 * Time.deltaTime;
            moveSpeed += (StartMoveSpeed * Time.deltaTime);

            if (CurrentTime <= 0)
            {
                CurrentTime = 0;
                if (!fast)
                    moveSpeed = StartMoveSpeed + (StartMoveSpeed * StartTime);
                else
                    moveSpeed = StartMoveSpeed + (StartMoveSpeed * StartTime) + fastSpeed;
            } 
        }

        exYAngle = yAngle;
        exXAngle = xAngle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Letter")
        {
            bump = true;

            // Knockback
            // Vector3 direction = (collision.gameObject.transform.position - transform.position).normalized;
            // Debug.Log("direction" + direction);
            // moveWall = direction * knockbackForce;
        }
           

    }
    private void OnCollisionExit(Collision collision)
    {
        bump = false;
    }


    void moveAgainstWall()
    {
        CurrentTime = StartTime;
        moveSpeed = StartMoveSpeed / 1.5f;
        rb.velocity = (transform.forward) * moveSpeed;
    } 

}
