using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    [SerializeField] private PlayerMotor playerMotor;
    [SerializeField] private GameObject playerGFX;
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
        damage.baseValue += PlayerPrefs.GetInt("unlockedDamage");
        armour.baseValue += PlayerPrefs.GetInt("unlockedArmour");

    }

    void onEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            armour.AddModifier(newItem.armourModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
          
            armour.RemoveModifier(oldItem.armourModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die()
    {
        SceneManager.LoadScene("Hub", LoadSceneMode.Single);
    }
}
