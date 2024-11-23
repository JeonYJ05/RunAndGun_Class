using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Count;


    [SerializeField] private Sprite _potionSprite; // ���� �̹���
    [SerializeField] private Sprite _shotGunSprite; // ���� �̹���

    // ������ �����͸� �����ϴ� Ŭ����
    [System.Serializable]
    public class ItemData
    {
        public int Count; // ������ ����
        public Sprite Sprite; // ������ �̹���
    }


    private Dictionary<string, ItemData> _inventory = new Dictionary<string, ItemData>();

    private void Start()
    {
        // �ʱ� �κ��丮 ����
        _inventory["Potion"] = new ItemData { Count = 0, Sprite = _potionSprite };
        _inventory["ShotGun"] = new ItemData { Count = 0, Sprite = _shotGunSprite };
    }

    // ������ �߰� �޼���
    private void AddItem(string name)
    {
        string itemName = name.Replace("(Clone)", "").Trim();

        if (_inventory.TryGetValue(itemName, out ItemData itemData))
        {
            itemData.Count++;
            Debug.Log($"�����۰����߰� :+ {itemName} {itemData.Count} ");
        }
        else
        {
            // �� ������ �߰� �� ��������Ʈ�� �ùٸ��� ����
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
            }
            else
            {
                Debug.Log($"������ '{itemName}'�� ���� ��������Ʈ�� �����Ǿ� ���� �ʽ��ϴ�.");
            }
        }
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
        FindObjectOfType<ItemDisplay>()?.UpdateUI();
    }

    public Dictionary<string, ItemData> GetInventory() => _inventory;
}