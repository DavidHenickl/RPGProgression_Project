using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAttributeOversight : MonoBehaviour
{
    [SerializeField] int remaining;
    [SerializeField] GameObject canvas;

    [SerializeField] TMPro.TextMeshProUGUI m_TextMeshPro;

    private void Start()
    {
        m_TextMeshPro.text = "Remaining Points: " + remaining.ToString();
    }

    public void AddAttribute()
    {
        remaining--;
        m_TextMeshPro.text = "Remaining Points: " + remaining.ToString();

        if(remaining <= 0)
        {
            canvas.SetActive(false);
        }
    }
}
