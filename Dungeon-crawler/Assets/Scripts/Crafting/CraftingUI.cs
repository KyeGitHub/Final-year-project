using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] RectTransform arrowParent;
	[SerializeField] RectTransform craftParent;
	[SerializeField] CraftingSlot[] itemSlots;

    public CraftingRecipe craftingRecipe;
	private void Start()
	{
		SetCraftingRecipe(craftingRecipe);
		
	}
	public CraftingRecipe CraftingRecipe
    {
        get { return craftingRecipe; }
        set { SetCraftingRecipe(value); }

    }

	private void SetCraftingRecipe(CraftingRecipe newCraftingRecipe)
	{
		craftingRecipe = newCraftingRecipe;

		if (craftingRecipe != null)
		{
			int slotIndex = 0;
			slotIndex = SetSlots(craftingRecipe.Materials, slotIndex);
			//Debug.Log("Index = " + slotIndex);
			arrowParent.SetSiblingIndex(slotIndex);
			//Debug.Log("pos: " +arrowParent.GetSiblingIndex());
			slotIndex = SetSlots(craftingRecipe.Results, slotIndex);
			craftParent.SetSiblingIndex(slotIndex+1);

			for (int i = slotIndex; i < itemSlots.Length; i++)
			{
				itemSlots[i].transform.gameObject.SetActive(false);
			}

			gameObject.SetActive(true);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}

	private int SetSlots(IList<ItemAmount> itemAmountList, int slotIndex)
	{
		for (int i = 0; i < itemAmountList.Count; i++, slotIndex++)
		{
			ItemAmount itemAmount = itemAmountList[i];
			CraftingSlot itemSlot = itemSlots[slotIndex];

			itemSlot.item = itemAmount.item;
			itemSlot.icon.sprite = itemAmount.item.icon;
			itemSlot.icon.enabled = true;
			itemSlot.amount.text = itemAmount.amount.ToString();
			itemSlot.transform.parent.gameObject.SetActive(true);
		}
		return slotIndex;
	}

	public void onCraftButton()
	{
		craftingRecipe.Craft(Inventory.instance);

	}

}
