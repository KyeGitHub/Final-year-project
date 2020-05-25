using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Unlock/Attack Up")]
public class AttackUp : Unlock
{
    [SerializeField]
    public int damageModifier;

    public override string GetTooltip()
    {
        string tooltipText;

        StringBuilder builder = new StringBuilder();
        builder.Append(name).AppendLine();
        builder.Append(useText).Append(damageModifier).Append(".").AppendLine();
        tooltipText = builder.ToString();
        return tooltipText;
    }

    public override void Purchase()
    {
        PlayerPrefs.SetInt("unlockedDamage", damageModifier);
    }

}
