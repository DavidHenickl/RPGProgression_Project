using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    public ReputationGroup[] reputationGroups;

    public int GetRep(string name)
    {
        foreach (var group in reputationGroups)
        {
            if (group.GetRepGroups().ToString() == name)
            {
                return group.Reputation;
            }
        }

        return 0;
    }

    public void AddRep(string name, int num)
    {
        foreach (var group in reputationGroups)
        {
            if (group.GetRepGroups().ToString() == name)
            {
                group.Reputation += num;
            }
        }
    }
}
