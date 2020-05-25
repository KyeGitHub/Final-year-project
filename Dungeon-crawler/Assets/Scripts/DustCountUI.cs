using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DustCountUI : MonoBehaviour
{
    [SerializeField]
    private Text amount;
    void Update()
    {
        amount.text = Inventory.dustAmount.ToString();

    }
}
