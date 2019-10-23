using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 clickPosition;

    private float cameraFOV;
    public float minFOV = 5.0f;
    public float maxFOV = 1.0f;
    public float zoomSensitivity = 1.0f;

    public float moveSpeed = 3.0f;

    void Start()
    {
        clickPosition = transform.position;
        cameraFOV = Camera.main.orthographicSize;
    }

    void Update()
    {
        EyeControl();
    }

    //Mouse click player motion control
    void EyeControl()
    {
        //Move Player position (X and Y axis) to position of mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Button Pressed");
            clickPosition = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.position = clickPosition;
            //this should be refactored so that it has to hit the colider of the environment, limiting the click movement only environment

        }
        if ((Vector3)transform.position != clickPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, clickPosition, moveSpeed * Time.deltaTime);
        }

        //Zoom in and out player position with scroll wheel
        //scroll wheel controls size of orthographic camera
        cameraFOV += Input.mouseScrollDelta.y * zoomSensitivity;
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

    }
}
