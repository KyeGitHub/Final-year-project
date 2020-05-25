using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public GameObject statsUI;
    [SerializeField] private Text statText;

    [SerializeField] private PlayerStats playerStats;
    private void Update()
    {
        statText.text = getStatText();
    }
    public void Hide()
    {
        statsUI.SetActive(!statsUI.activeSelf);
    }

    public string getStatText()
    {
        string statText;

        StringBuilder builder = new StringBuilder();
        builder.Append("Max Health: ").Append(playerStats.maxHealth).AppendLine();
        builder.Append("Damage: ").Append(playerStats.damage.GetValue()).AppendLine();
        builder.Append("Armour: ").Append(playerStats.armour.GetValue()).AppendLine();

        statText = builder.ToString();
        return statText;
    }



}
