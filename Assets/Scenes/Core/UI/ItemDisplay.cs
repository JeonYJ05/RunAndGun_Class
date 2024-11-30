using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private Image[] _slots; // 슬롯 이미지 배열
    [SerializeField] private Text[] _quantityTexts; // 슬롯 수량 텍스트 배열

    // 슬롯 초기화
    private void Start()
    {
        // 모든 슬롯을 초기화
        for (int i = 0; i < _slots.Length; ++i)
        {
            _slots[i].sprite = null; 
            _quantityTexts[i].text = "0"; 
        }
    }

    public void UpdateUI(Item.ItemData[] slots)
    {
        // 슬롯 내용을 UI에 추가
        for (int i = 0; i < _slots.Length; ++i)
        {
            if (i < slots.Length && slots[i].Count == 1) 
            {
                _slots[i].sprite = slots[i].Sprite;
                Debug.Log($"현재 카운트 = + {slots[i].Count}");
                _quantityTexts[i].text = slots[i].Count.ToString(); 
            }
            else if(i < slots.Length && slots[i].Count > 1)
            {
                _quantityTexts[i].text = slots[i].Count.ToString();
            }
            else
            {
                _slots[i].sprite = null;
                Debug.Log("이미지가 없다");
                _quantityTexts[i].text = "0"; 
            }
        }
    }

    public void AddItemToSlot(Item.ItemData itemData)
    {
        
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].sprite == itemData.Sprite) 
            {
                // 수량 증가
                int currentCount = int.Parse(_quantityTexts[i].text);
                currentCount++;
                _quantityTexts[i].text = currentCount.ToString(); 
                return; 
            }
        }

        
        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].sprite == null) 
            {
                _slots[i].sprite = itemData.Sprite; 
                _quantityTexts[i].text = "1"; 
                break; 
            }
        }
    }


   
}