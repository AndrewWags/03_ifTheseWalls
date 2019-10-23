using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] Transform mouseTarget;
    private Vector2 mousePosition;
    private Vector2 clickPosition;
    private Vector3 mouseStart;

    private float camDistance;
    public float camLimitX = 6.0f;
    public float CamLimitY = 3.0f;

    private float cameraFOV;
    public float minFOV = 5.0f;
    public float maxFOV = 1.0f;
    public float zoomSensitivity = 1.0f;

    public float moveSpeed = 3.0f;

    void Start()
    {
        mousePosition = transform.position;
        clickPosition = transform.position;

        camDistance = Camera.main.transform.position.z;
        cameraFOV = Camera.main.orthographicSize;
    }

    void Update()
    {
        EyeControl();
        EarControl();
    }

    //Navigation and visual controls
    void EyeControl()
    {
        //move mouseTarget game object to match mouse position on screen
        mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTarget.position = mousePosition;

        //Click and drag mouse to move camera position
        if (Input.GetMouseButtonDown(2))
        {
            mouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance);
            mouseStart = Camera.main.ScreenToWorldPoint(mouseStart);
            mouseStart.z = Camera.main.transform.position.z;
        }
        else if (Input.GetMouseButton(2))
        {
            Vector3 mouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDistance);
            mouseMove = Camera.main.ScreenToWorldPoint(mouseMove);
            mouseMove.z = Camera.main.transform.position.z;
            Camera.main.transform.position = Camera.main.transform.position - (mouseMove - mouseStart);
            //Need to figure out how to limit camera movemnt in X and Y
        }

        //Zoom in and out player position with scroll wheel
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
        Debug.Log("2nd Mouse Button Pressed");

        clickPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseTarget.position = clickPosition;

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Button 1 is pressed");
        }

        if ((Vector2)transform.position != clickPosition && Input.GetMouseButton(1))
        {
            transform.position = clickPosition;
            //transform.position = Vector2.MoveTowards(transform.position, clickPosition, moveSpeed * Time.deltaTime);
        }

    }
}
