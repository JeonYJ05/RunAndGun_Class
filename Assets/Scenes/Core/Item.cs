using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int Count;


    [SerializeField] private Sprite _potionSprite; // 포션 이미지
    [SerializeField] private Sprite _shotGunSprite; // 샷건 이미지

    // 아이템 데이터를 관리하는 클래스
    [System.Serializable]
    public class ItemData
    {
        public int Count; // 아이템 수량
        public Sprite Sprite; // 아이템 이미지
    }


    private Dictionary<string, ItemData> _inventory = new Dictionary<string, ItemData>();

    private void Start()
    {
        // 초기 인벤토리 세팅
        _inventory["Potion"] = new ItemData { Count = 0, Sprite = _potionSprite };
        _inventory["ShotGun"] = new ItemData { Count = 0, Sprite = _shotGunSprite };
    }

    // 아이템 추가 메서드
    private void AddItem(string name)
    {
        string itemName = name.Replace("(Clone)", "").Trim();

        if (_inventory.TryGetValue(itemName, out ItemData itemData))
        {
            itemData.Count++;
            Debug.Log($"아이템갯수추가 :+ {itemName} {itemData.Count} ");
        }
        else
        {
            // 새 아이템 추가 시 스프라이트를 올바르게 설정
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
            }
            else
            {
                Debug.Log($"아이템 '{itemName}'에 대한 스프라이트가 설정되어 있지 않습니다.");
            }
        }
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
        FindObjectOfType<ItemDisplay>()?.UpdateUI();
    }

    public Dictionary<string, ItemData> GetInventory() => _inventory;
}