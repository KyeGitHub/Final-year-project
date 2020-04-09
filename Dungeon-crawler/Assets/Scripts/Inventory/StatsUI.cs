using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    public GameObject statsUI;

    public void Hide()
    {
        statsUI.SetActive(!statsUI.activeSelf);
    }




}
