using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : Interactable

{
    public override void Interact()
    {
        base.Interact();
        Inventory.instance.ConvertToDust();
        EquipmentManager.instance.ConvertToDust();
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }
}
