using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // ������ �����͸� �����ϴ� Ŭ����
    [System.Serializable]
    public class ItemData
    {
        public int Count; 
        public Sprite Sprite; // ������ �̹���
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
            Debug.Log($"�����۰����߰� :+ {itemName} {itemData.Count} ");
            UpdateSlots(itemName);

           
        }
        else
        {
            Sprite itemSprite = null;

            // ������ �̸��� ���� ��������Ʈ ����
            if (itemName == "Potion")
                itemSprite = _potionSprite;
            else if (itemName == "ShotGun")
                itemSprite = _shotGunSprite;

            if (itemSprite != null)
            {
                // �� �������� �߰�
                _inventory[itemName] = new ItemData { Count = 1, Sprite = itemSprite }; // �̹��� ����
                Debug.Log($"������ �߰�: + {itemName} {1} ");
                UpdateSlots(itemName);
                
            }
            else
            {
                Debug.Log($"������ '{itemName}'�� ���� ��������Ʈ�� �����Ǿ� ���� �ʽ��ϴ�.");
            }
        }
    }

    private void UpdateSlots(string itemName)
    {
        // �������� ��������Ʈ�� ������ ���Կ� �߰�
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

    // ������ ��� �޼���
    private void UseItem(string name)
    {
        if (_inventory.TryGetValue(name, out ItemData itemData))
        {
            itemData.Count--;
            if (itemData.Count <= 0)
            {
                _inventory.Remove(name); // ������ 0�̸� ������ ����
            }
        }
    }

    // ������ �ֿ� �� ȣ���ϴ� �޼���
    public void PickupItem(string name)
    {

        AddItem(name);
        //FindObjectOfType<ItemDisplay>()?.UpdateUI(_slots);
    }

    public Dictionary<string, ItemData> GetInventory() => _inventory;
}