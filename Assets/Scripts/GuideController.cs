using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;

    public void Interact()
    {
        Debug.Log("You will talk to me.");
        StartCoroutine(DialogManager.instance.ShowDialog(dialog));
    }
}
