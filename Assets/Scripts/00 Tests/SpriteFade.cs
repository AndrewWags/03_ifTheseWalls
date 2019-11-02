using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
    SpriteRenderer m_sprightRenderer;
    Color m_color;
    float opacity;

    bool isFading;

    IEnumerator currentMoveCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        m_sprightRenderer = GetComponent<SpriteRenderer>();
        m_color = m_sprightRenderer.color;
        opacity = m_color.a;
        opacity = 1f;
        isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //If already performing Coroutine while pressing button again, cancel previous coroutine
            if (currentMoveCoroutine != null)
            {
                StopCoroutine(currentMoveCoroutine);
            }

            currentMoveCoroutine = Fade();
            StartCoroutine(currentMoveCoroutine);
        }
    }

    IEnumerator Fade()
    {
        //Fade out if opaque
        if (opacity ==1 || isFading == false)
        {
            for (opacity = m_color.a; opacity >= -0.05; opacity -= 0.05f)
            {
                m_color.a = opacity;
                m_sprightRenderer.color = m_color;
                isFading = true;
                yield return new WaitForSeconds(0.05f);
            }
        }
        //otherwise fade in
        else if(isFading == true)
        {
            for (opacity = m_color.a; opacity < 1; opacity += 0.05f)
            {
                m_color.a = opacity;
                m_sprightRenderer.color = m_color;
                isFading = false;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}