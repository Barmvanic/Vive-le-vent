using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
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
        StartTime = CurrentTime;
        StartMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
       
        rotate();

        moveForward();
        
    }

    
    void rotate()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.x = mousePos.x - (Screen.width / 2);
        mousePos.y = mousePos.y - (Screen.height / 2);

        xAngle = mousePos.x / Screen.width;
        yAngle = mousePos.y / Screen.height;

        transform.Rotate(-yAngle * rotateSpeed, xAngle * rotateSpeed * 1.5f, 0f, Space.Self);

        Debug.Log(xAngle + "____" + yAngle);
    }

    void moveForward()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Speed increase
        if ((yAngle - exYAngle > 0.01f) && (xAngle - exXAngle > 0.015f))
        {
            CurrentTime = StartTime;
            moveSpeed = StartMoveSpeed;

        }
        else
        {
            CurrentTime -= 1 * Time.deltaTime;
            moveSpeed += (StartMoveSpeed * Time.deltaTime);

            if (CurrentTime <= 0)
            {
                CurrentTime = 0;
                moveSpeed = StartMoveSpeed + (StartMoveSpeed * StartTime);
            } 
        }

        exYAngle = yAngle;
        exXAngle = xAngle;
    }
}
