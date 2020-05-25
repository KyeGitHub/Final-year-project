using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : Interactable
{   
    [SerializeField]
    private GameObject shopUI;
    public override void Interact()
    {
        shopUI.SetActive(true);
    }

    public override void OnDeFocus()
    {
        shopUI.SetActive(false);
    }
}
