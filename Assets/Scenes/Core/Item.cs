using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // 아이템 데이터를 관리하는 클래스
    [System.Serializable]
    public class ItemData
    {
        public int Count; 
        public Sprite Sprite; // 아이템 이미지
    }

    [SerializeField] private Sprite _potionSprite;
    [SerializeField] private Sprite _shotGunSprite;
    [SerializeField] ItemData[] _slots = new ItemData[8];
    private Dictionary<string, ItemData> _inventory = new Dictionary<string, ItemData>();
    public int Count;

    private void Start()
    {
        InitializeInventory();
    }

    private void InitializeInventory()
    {
        _inventory["Potion"] = new ItemData { Count = 0, Sprite = _potionSprite };
        _inventory["ShotGun"] = new ItemData { Count = 0, Sprite = _shotGunSprite };

        for (int i = 0; i < _slots.Length; ++i)
        {
            _slots[i] = new ItemData { Count = 0, Sprite = null };
        }
    }

    private void AddItem(string name)
    {
        string itemName = name.Replace("(Clone)", "").Trim();

        if (_inventory.TryGetValue(itemName, out ItemData itemData))
        {
            itemData.Count++;
            Debug.Log($"아이템갯수추가 :+ {itemName} {itemData.Count} ");
            UpdateSlots(itemName);

           
        }
        else
        {
            Sprite itemSprite = null;

            // 아이템 이름에 따라 스프라이트 설정
            if (itemName == "Potion")
                itemSprite = _potionSprite;
            else if (itemName == "ShotGun")
                itemSprite = _shotGunSprite;

            if (itemSprite != null)
            {
                // 새 아이템을 추가
                _inventory[itemName] = new ItemData { Count = 1, Sprite = itemSprite }; // 이미지 설정
                Debug.Log($"아이템 추가: + {itemName} {1} ");
                UpdateSlots(itemName);
                
            }
            else
            {
                Debug.Log($"아이템 '{itemName}'에 대한 스프라이트가 설정되어 있지 않습니다.");
            }
        }
    }

    private void UpdateSlots(string itemName)
    {
        // 아이템의 스프라이트와 수량을 슬롯에 추가
        for (int i = 0; i < _slots.Length; ++i)
        {
            if (_slots[i].Count == 0) 
            {
                _slots[i] = _inventory[itemName];
                FindObjectOfType<ItemDisplay>()?.AddItemToSlot(_slots[i]);
                //_slots[i].Sprite = _inventory[itemName].Sprite;
                break; 
            }
        }

        FindObjectOfType<ItemDisplay>()?.UpdateUI(_slots);
    }

    // 아이템 사용 메서드
    private void UseItem(string name)
    {
        if (_inventory.TryGetValue(name, out ItemData itemData))
        {
            itemData.Count--;
            if (itemData.Count <= 0)
            {
                _inventory.Remove(name); // 수량이 0이면 아이템 제거
            }
        }
    }

    // 아이템 주울 때 호출하는 메서드
    public void PickupItem(string name)
    {

        AddItem(name);
        //FindObjectOfType<ItemDisplay>()?.UpdateUI(_slots);
    }

    public Dictionary<string, ItemData> GetInventory() => _inventory;
}