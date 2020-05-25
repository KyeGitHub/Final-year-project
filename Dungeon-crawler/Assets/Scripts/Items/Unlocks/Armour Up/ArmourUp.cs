using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Unlock/Armour Up")]
public class ArmourUp : Unlock
{
    [SerializeField]
    public int armourModifier;

    public override string GetTooltip()
    {
        string tooltipText;

        StringBuilder builder = new StringBuilder();
        builder.Append(name).AppendLine();
        builder.Append(useText).Append(armourModifier).Append(".").AppendLine();
        tooltipText = builder.ToString();
        return tooltipText;
    }

    public override void Purchase()
    {
        PlayerPrefs.SetInt("unlockedArmour", armourModifier);
    }

}
