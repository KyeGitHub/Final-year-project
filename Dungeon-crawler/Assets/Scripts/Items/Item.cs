using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    private GameManager gm;
    [SerializeField] public string useText = "Something";
    new public string name = "New Item";
    public string tooltipText;
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public bool isStackable;
    public int count;
    public int dustValue;
    private void Awake()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    public virtual void Use()
    {
        //use the item
        
        Debug.Log("USING " + name);
     
    }

    public void RemoveFromInventory()
    {
        if (isStackable & count > 1)
        {
            count--;
        }

        else
        {
            Inventory.instance.Remove(this);
        }
    }

    public virtual string GetTooltip()
    {
        string tooltipText;

        StringBuilder builder = new StringBuilder();
        builder.Append(name).AppendLine();
        builder.Append(useText).AppendLine();


        tooltipText = builder.ToString();
        return tooltipText;
    }
}
