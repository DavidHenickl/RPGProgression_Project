using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationGroup : MonoBehaviour
{
    public enum RepGroups
    {
        Treeant,
        Mole,
        People,
        General
    }

    [SerializeField] private RepGroups repGroups;
    [SerializeField] private int startingRep;

    public int Reputation { get; set; }

    public RepGroups GetRepGroups()
    {
        return repGroups;
    }

    private void Awake()
    {
        Reputation = startingRep;
    }
}
