using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public Text amount;
    public Unlock unlock;
    public Button purchase;
    public ShopRecipe shopRecipe;
    [SerializeField]
    private bool purchased = false;

    private void Start()
    {
        SetSlot(shopRecipe);
    }

    private void SetSlot(ShopRecipe shopRecipe)
    {
        if(shopRecipe != null && !purchased)
        {
            unlock = shopRecipe.Results;
            icon.sprite = unlock.icon;
            amount.text = shopRecipe.cost.ToString();
            gameObject.SetActive(true);

        }
        else
            gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (unlock != null)
            Tooltip.ShowToolTip_Static(unlock.GetTooltip());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.HideToolTip_Static();
    }

    public void onButton()
    {
        if(Inventory.dustAmount >= shopRecipe.cost && !purchased)
        {
            unlock.Purchase();
            Inventory.dustAmount -= shopRecipe.cost;
            purchased = true;
        }
        
    }
}