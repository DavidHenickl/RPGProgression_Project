using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationGate : MonoBehaviour
{
    [SerializeField] ReputationManager manager;
    [SerializeField] ReputationGroup.RepGroups repGroup;
    public int reqire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckGate()
    {
        if (manager.GetRep(repGroup.ToString()) >= reqire)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //Debug.Log("Collision");
            if (manager.GetRep(repGroup.ToString()) >= reqire )
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
