using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelWithRequirements : MonoBehaviour, Interactable
{
    enum Stat
    {
        Level,

    };

    [SerializeField] Dialog dialog;

    [SerializeField] GameObject canvas;

    [SerializeField] ExperianceManager experianceManager;

    [SerializeField] Stat stat;

    [SerializeField] int requiredValue;

    public void Interact()
    {
        StartCoroutine(DialogManager.instance.ShowDialog(dialog));
        if (stat == Stat.Level)
        {
            Level();
        }
    }

    private void Level()
    {
        if (experianceManager.level >= requiredValue)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        //StartCoroutine(DialogManager.instance.ShowDialog(dialog));
        canvas.SetActive(true);
    }
}
