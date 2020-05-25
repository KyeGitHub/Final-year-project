using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public Button craftButton;
    public Text amount;
    public Item item;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
            Tooltip.ShowToolTip_Static(item.GetTooltip());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideToolTip_Static();
    }
}