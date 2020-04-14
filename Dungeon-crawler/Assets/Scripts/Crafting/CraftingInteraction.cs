﻿using UnityEngine;

public class CraftingInteraction : Interactable
{
    public GameObject craftingInterface;

     public override void Interact()
    {
        Debug.Log("Interacting");
        base.Interact();
        craftingInterface.SetActive(true);
    }

    public override void OnDeFocus()
    {
        base.OnDeFocus();
        craftingInterface.SetActive(false);
    }
}
