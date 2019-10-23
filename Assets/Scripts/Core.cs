using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] Transform mouseTarget;
    private Vector2 mousePosition;
    private Vector2 clickPosition;

    private Vector3 MouseStart;
    private float dist;

    private float cameraFOV;
    public float minFOV = 5.0f;
    public float maxFOV = 1.0f;
    public float zoomSensitivity = 1.0f;

    public float moveSpeed = 3.0f;

    void Start()
    {
        mousePosition = transform.position;
        clickPosition = transform.position;
        cameraFOV = Camera.main.orthographicSize;

        dist = transform.position.z;
    }

    void Update()
    {
        EyeControl();
    }

    //Mouse click player motion control
    void EyeControl()
    {
        //move mouseTarget game object to match mouse position on screen
        mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTarget.position = mousePosition;

        //Click and drag mouse to move camera position
        if (Input.GetMouseButtonDown(2))
        {
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
            MouseStart.z = transform.position.z;

        }
        else if (Input.GetMouseButton(2))
        {
            Vector3 MouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
            MouseMove.z = transform.position.z;
            Camera.main.transform.position = transform.position - (MouseMove - MouseStart);
            
        }

        //Zoom in and out player position with scroll wheel
        //scroll wheel controls size of orthographic camera
        cameraFOV -= Input.mouseScrollDelta.y * zoomSensitivity;
        cameraFOV = Mathf.Clamp(cameraFOV, maxFOV, minFOV);
        Camera.main.orthographicSize = cameraFOV;

    }

    //selecting, tapping, grabbing functions
    void HandControl()
    {

    }

    //listening, locating, and sound management functions
    void EarControl()
    {
        //Move Player position (X and Y axis) to position of mouse click
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Button Pressed");
            clickPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.position = clickPosition;
            //this should be refactored so that it has to hit the colider of the environment, limiting the click movement only environment

        }

        if ((Vector2)transform.position != clickPosition && Input.GetMouseButton(0))
        {
            transform.position = Vector2.MoveTowards(transform.position, clickPosition, moveSpeed * Time.deltaTime);
        }
        */
    }
}
