using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBlender : MonoBehaviour
{
    SpriteRenderer m_sprightRenderer;

    public Color opaque, transparent;
    private Color currentColor;

    float fadeSpeed = 1.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        m_sprightRenderer = GetComponent<SpriteRenderer>();
        m_sprightRenderer.color = opaque;
        currentColor = opaque;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(currentColor == opaque)
            {
                currentColor = transparent;
            }
            else
            {
                currentColor = opaque;
            }
        }

        m_sprightRenderer.color = Color.Lerp(m_sprightRenderer.color, currentColor, 0.1f);

    }
}
