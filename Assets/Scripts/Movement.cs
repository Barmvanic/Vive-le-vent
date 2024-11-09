using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float rotateSpeed = 2f;
    private float xAngle, yAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        rotate();

        moveForward();
        
    }

    void moveForward()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void rotate()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.x = mousePos.x - (Screen.width / 2);
        mousePos.y = mousePos.y - (Screen.height / 2);

        xAngle = mousePos.x / Screen.width;
        yAngle = mousePos.y / Screen.height;

        transform.Rotate(-yAngle * rotateSpeed, xAngle * rotateSpeed * 1.5f, 0f, Space.Self);

        Debug.Log(mousePos.x + "____" + mousePos.y);
    }
}
