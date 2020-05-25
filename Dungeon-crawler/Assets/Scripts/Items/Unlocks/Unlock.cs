using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Unlock")]
public class Unlock : ScriptableObject
{
    [SerializeField] public string useText = "Something";
    new public string name = "New Item";
    public string tooltipText;
    public Sprite icon = null;


    public virtual string GetTooltip()
    {
        string tooltipText;

        StringBuilder builder = new StringBuilder();
        builder.Append(name).AppendLine();
        builder.Append(useText).AppendLine();


        tooltipText = builder.ToString();
        return tooltipText;
    }

    public virtual void Purchase()
    {
        Debug.Log("Bought");
    }

}
