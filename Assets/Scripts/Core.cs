using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{

    private Vector2 clickPosition;
    public float moveSpeed = 3.0f;
    

    [SerializeField] Transform target;

    void Start()
    {
        clickPosition = transform.position;

    }

    void Update()
    {
        EyeControl();
    }

    //Mouse click player motion control
    void EyeControl()
    {
        //Move Player position (X and Z axis) to position of mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Button Pressed");
            clickPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.position = clickPosition;

        }
        if ((Vector2)transform.position != clickPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, clickPosition, moveSpeed * Time.deltaTime);
        }

        //Zoom in and out player position with scroll wheel
        
    }

    //selecting, tapping, grabbing functions
    void HandControl()
    {

    }

    //listening, locating, and sound management functions
    void EarControl()
    {

    }
}
