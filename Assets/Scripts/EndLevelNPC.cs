using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelNPC : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    [SerializeField] GameObject canvas;

    public void Interact()
    {
        StartCoroutine(DialogManager.instance.ShowDialog(dialog));
        canvas.SetActive(true);
    }
}
