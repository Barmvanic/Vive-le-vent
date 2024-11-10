using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameManager gameManager;

    public bool fast;
    public float fastSpeed = 10f;
    public float moveSpeed = 1f;
    private float StartMoveSpeed;

    [SerializeField] private float rotateSpeed = 2f;
    private float xAngle, yAngle;
    private float exXAngle = 0f; 
    private float exYAngle = 0f;

    // Timer
    [SerializeField] private float StartTime;
    [SerializeField] private float CurrentTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartTime = CurrentTime;
        StartMoveSpeed = moveSpeed;

        fast = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (gameManager.ShowLetter == false)
        {
            rotate();
            moveForward();
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
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

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
}
