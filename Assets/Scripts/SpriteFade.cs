using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{

    SpriteRenderer m_sprightRenderer;
    Color m_color;
    float opacity;

    IEnumerator currentMoveCotoutine;

    // Start is called before the first frame update
    void Start()
    {
        m_sprightRenderer = GetComponent<SpriteRenderer>();
        m_color = m_sprightRenderer.color;
        opacity = m_color.a;
        opacity = 1f;
        m_sprightRenderer.color = m_color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (currentMoveCotoutine != null)
            {
                StopCoroutine(currentMoveCotoutine);
            }
            

            if (opacity <= 0)
            {
                currentMoveCotoutine = FadeIn(opacity);
                StartCoroutine(currentMoveCotoutine);
            }
            else
            {
                currentMoveCotoutine = FadeOut(opacity);
                StartCoroutine(currentMoveCotoutine);
            }

        }
    }


    IEnumerator FadeOut(float alphaOut)
    {

        for (alphaOut = 1f; alphaOut >= -0.05; alphaOut -= 0.05f)
        {
            m_color = m_sprightRenderer.color;
            m_color.a = alphaOut;
            m_sprightRenderer.color = m_color;
            yield return new WaitForSeconds(0.05f);

        }

    }

    IEnumerator FadeIn(float alphaIn)
    {
        for (alphaIn = 0.05f; alphaIn < 1; alphaIn += 0.05f)
        {
            m_color = m_sprightRenderer.color;
            m_color.a = alphaIn;
            m_sprightRenderer.color = m_color;
            yield return new WaitForSeconds(0.05f);
        }
    }

}