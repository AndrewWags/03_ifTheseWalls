using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    [SerializeField] Transform mouseCursor;
    Vector3 mousePos;

    private float camZoomSize;
    private bool isZoomedOut;
    private bool isZooming;
    public float camFOVmax = 1.0f;
    public float camFOVmin = 5.0f;



    // Start is called before the first frame update
    void Start()
    {
        mousePos = transform.position;
        mouseCursor.position = transform.position;
        camZoomSize = Camera.main.orthographicSize;
        isZoomedOut = true;
        isZooming = false;

    }

    // Update is called once per frame
    void Update()
    {
        VisualZoom();
    }

    //when right mouse button is held down, the camera zooms to the location of the mouse pointer
    private void VisualZoom()
    {
        //move mouse cursor to match location of mouse on screen
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseCursor.position = mousePos;

        if (Input.GetMouseButtonDown(1))
        {
            print("Clicked the right mouse button");

            //slowly zoom in the camera at a given speed - using a coroutine
        }
    }

    IEnumerator CameraZoom( )
    {


        if (camZoomSize == camFOVmax || isZooming == false)
        {
            isZoomedOut = true;
            yield return new WaitForSeconds(0.05f);
        }
        else if(isZooming == true)
        {
            isZoomedOut = false;
        }

        //if camera ortho size is zoomed out, then zoom in, otherwise zoom out. 
        /*
        if (isZoomedOut == true || isZooming == false)
        {
            for(camZoomSize = camFOVmax; camZoomSize >= -0.05f; camZoomSize -= 0.05f)
            {
                yield return new WaitForSeconds(0.05f);
            }
        }
        */
    }
}

