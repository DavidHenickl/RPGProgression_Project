using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIAddAttribute : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI m_TextMeshPro; 
    [SerializeField] Button m_Button;
    [SerializeField] ItemSO.AttributesToChange m_AttributesToChange;
    [SerializeField] UIAttributeOversight m_AttributeOversight;

    private PlayerStats m_PlayerStats;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerStats = GameObject.Find("StatManager").GetComponent<PlayerStats>();
        UpdateText();
        m_Button.onClick.AddListener(AddStatOnClick);
    }

    private void AddStatOnClick()
    {
        if (m_AttributesToChange.ToString() == "health")
        {
            GameObject.Find("hero").GetComponent<PlayerManager>().IncreaseHealth(1);
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + GameObject.Find("hero").GetComponent<PlayerManager>().health;
        }
        if (m_AttributesToChange.ToString() == "attack")
        {
            m_PlayerStats.attack += 1;
            m_PlayerStats.UpdateEquipment();
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + m_PlayerStats.attack;
        }
        if (m_AttributesToChange.ToString() == "defense")
        {
            m_PlayerStats.defense += 1;
            m_PlayerStats.UpdateEquipment();
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + m_PlayerStats.defense;
        }
        if (m_AttributesToChange.ToString() == "agility")
        {
            m_PlayerStats.agility += 1;
            m_PlayerStats.UpdateEquipment();
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + m_PlayerStats.agility;
        }
        if (m_AttributesToChange.ToString() == "intelligence")
        {
            m_PlayerStats.intelligence += 1;
            m_PlayerStats.UpdateEquipment();
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + m_PlayerStats.intelligence;
        }
        m_AttributeOversight.AddAttribute();
    }

    private void UpdateText()
    {
        if(m_AttributesToChange.ToString() == "health")
        {
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + GameObject.Find("hero").GetComponent<PlayerManager>().health;
        }
        if (m_AttributesToChange.ToString() == "attack")
        {
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + m_PlayerStats.attack;
        }
        if (m_AttributesToChange.ToString() == "defense")
        {
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + m_PlayerStats.defense;
        }
        if (m_AttributesToChange.ToString() == "agility")
        {
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + m_PlayerStats.agility;
        }
        if (m_AttributesToChange.ToString() == "intelligence")
        {
            m_TextMeshPro.text = m_AttributesToChange.ToString() + ": " + m_PlayerStats.intelligence;
        }
    }
}
