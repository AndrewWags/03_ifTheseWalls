using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFade : MonoBehaviour
{
    SpriteRenderer m_sprightRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_sprightRenderer = GetComponent<SpriteRenderer>();
        Color m_color = m_sprightRenderer.color;
        m_color.a = 1f;
        m_sprightRenderer.color = m_color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine("FadeIn");
        }
    }

    IEnumerator FadeIn()
    {
        for (float f = 1f; f >= -0.05; f -= 0.05f)
        {
            Color c = m_sprightRenderer.color;
            c.a = f;
            m_sprightRenderer.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

}