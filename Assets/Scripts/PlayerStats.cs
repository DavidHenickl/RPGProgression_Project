using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int attack, defense, agility, intelligence;

    [SerializeField] TMP_Text attackText, defenseText, agilityText, intelligenceText;

    [SerializeField] TMP_Text attackPreText, defensePreText, agilityPreText, intelligencePreText;
    public Image previewImage;

    [SerializeField] GameObject selectedItemStats, selectedItemImage;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEquipment();
    }

    public void UpdateEquipment()
    {
        attackText.text = attack.ToString();
        defenseText.text = defense.ToString();
        agilityText.text = agility.ToString();
        intelligenceText.text = intelligence.ToString();
    }

    public void PreviewEquipmentStats(int attack, int defense, int agility, int intelligence, Sprite itemSprite)
    {
        attackPreText.text = attack.ToString();
        defensePreText.text = defense.ToString();
        agilityPreText.text = agility.ToString();
        intelligencePreText.text = intelligence.ToString();

        previewImage.sprite = itemSprite;

        selectedItemStats.SetActive(true);
        selectedItemImage.SetActive(true);
    }

    public void TurnOffPreview()
    {
        selectedItemStats.SetActive(false);
        selectedItemImage.SetActive(false);
    }

    public void IncreaseStat()
    {

    }
}
