using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiverController : MonoBehaviour, Interactable
{
    //[SerializeField] Dialog dialog;
    [SerializeField] Dialog positiveOutcome;
    [SerializeField] Dialog negativeOutcome;
    [SerializeField] QuestCheckItem Quest;

    public void Interact()
    {
        Debug.Log("You will talk to me.");
        
        bool check = Quest.CheckCondidtion();
        if (check)
        {
            //DialogManager.instance.MultiDialog(dialog, positiveOutcome);
            StartCoroutine(DialogManager.instance.ShowDialog(positiveOutcome));
        }
        else
        {
            //DialogManager.instance.MultiDialog(dialog, negativeOutcome);
            StartCoroutine(DialogManager.instance.ShowDialog(negativeOutcome));
        }
    }

    public IEnumerator speak(bool check)
    {
        //StartCoroutine(DialogManager.instance.ShowDialog(dialog));
        if (check)
        {
            //DialogManager.instance.MultiDialog(dialog, positiveOutcome);
            StartCoroutine(DialogManager.instance.ShowDialog(positiveOutcome));
        }
        else
        {
            //DialogManager.instance.MultiDialog(dialog, negativeOutcome);
            StartCoroutine(DialogManager.instance.ShowDialog(negativeOutcome));
        }
        yield return null;
    }
}
