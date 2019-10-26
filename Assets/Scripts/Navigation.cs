using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    [SerializeField] Transform mouseCursor;
    Vector3 mousePos;
    Vector3 clickPos;

    private float camZoomSize;
    private bool isZoomingIn;
    public float camFOVmax = 1.0f;
    public float camFOVmin = 5.0f;

    IEnumerator currentMoveCoroutine;



    // Start is called before the first frame update
    void Start()
    {
        mousePos = transform.position;
        clickPos = Camera.main.transform.position;
        mouseCursor.position = transform.position;
        camZoomSize = Camera.main.orthographicSize;
        isZoomingIn = false;

    }

    // Update is called once per frame
    void Update()
    {
        //move mouse cursor to match location of mouse on screen
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseCursor.position = mousePos;
    }

    private void LateUpdate()
    {
        CameraNavigation();
    }

    //when right mouse button is clicked, enable Camera zoom coroutines
    private void CameraNavigation()
    {

        if (Input.GetMouseButtonDown(1))
        {
            clickPos = mousePos;

            if(currentMoveCoroutine != null)
            {
                StopCoroutine(currentMoveCoroutine);
            }

            print("Clicked the right mouse button");
            currentMoveCoroutine = CameraZoom();
            StartCoroutine(currentMoveCoroutine);
        }
    }

    IEnumerator CameraZoom( )
    {
        //camera needs to start moving towards the click point


        if (camZoomSize == camFOVmax || isZoomingIn == false)
        {
            //Zoom in softly
            for (camZoomSize = Camera.main.orthographicSize; camZoomSize > camFOVmin; camZoomSize -= 0.05f )
            {
                Camera.main.orthographicSize = camZoomSize;
               // Camera.main.transform.position = clickPos;

           
                print("is zooming in");
                isZoomingIn = true;
                yield return new WaitForSeconds(0.05f);
            }
        }
        else if(isZoomingIn == true)
        {
            //Zoom out softly
            for (camZoomSize = Camera.main.orthographicSize; camZoomSize < camFOVmax; camZoomSize += 0.05f)
            {
                Camera.main.orthographicSize = camZoomSize;
                print("is zooming out");
                isZoomingIn = false;
                yield return new WaitForSeconds(0.05f);
            }
            print("is zooming out");

        }

    }
}

