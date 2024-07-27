using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseExperianceGate : MonoBehaviour
{

    [SerializeField] Dialog dialog;
    [SerializeField] int removeExp;

    public void CheckGate()
    {
        DialogManager.instance.ShowDialog(dialog);
        GameObject.Find("StatManager").GetComponent<ExperianceManager>().RemoveExp(removeExp); ;
        this.gameObject.SetActive(false);
    }
}
