using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ItemDisplay : MonoBehaviour
{
    [SerializeField] GameObject _itemSlotPrefab;
    [SerializeField] Transform _inventoryPanel;
    private Item _item;

    private void Start()
    {
        _item = FindObjectOfType<Item>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Transform child in _inventoryPanel)
        {
            Destroy(child.gameObject);
        }


        foreach(KeyValuePair<string, Item.ItemData> kvp in _item.GetInventory())
        {
            if(kvp.Value.Count > 0)
            {
                GameObject slot = Instantiate(_itemSlotPrefab, _inventoryPanel);
                Image itemImage = slot.GetComponent<Image>();
                itemImage.sprite = kvp.Value.Sprite;

               // Text quantityTxt = slot.transform.Find("QuantityTxt").GetComponent<Text>();
               // quantityTxt.text = kvp.Value.Count.ToString();
            }
        }


        int totalSlots = _inventoryPanel.childCount;
        int maxSlots = 0;

        for (int i = totalSlots; i < maxSlots; ++i)
        {
            GameObject emptySlot = Instantiate(_itemSlotPrefab, _inventoryPanel);
            emptySlot.GetComponent<Image>().color = Color.clear;
        }
    }
}