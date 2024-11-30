using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private Image[] _slots; // ���� �̹��� �迭
    [SerializeField] private Text[] _quantityTexts; // ���� ���� �ؽ�Ʈ �迭

    // ���� �ʱ�ȭ
    private void Start()
    {
        // ��� ������ �ʱ�ȭ
        for (int i = 0; i < _slots.Length; ++i)
        {
            _slots[i].sprite = null; 
            _quantityTexts[i].text = "0"; 
        }
    }

    public void UpdateUI(Item.ItemData[] slots)
    {
        // ���� ������ UI�� �߰�
        for (int i = 0; i < _slots.Length; ++i)
        {
            if (i < slots.Length && slots[i].Count == 1) 
            {
                _slots[i].sprite = slots[i].Sprite;
                Debug.Log($"���� ī��Ʈ = + {slots[i].Count}");
                _quantityTexts[i].text = slots[i].Count.ToString(); 
            }
            else if(i < slots.Length && slots[i].Count > 1)
            {
                _quantityTexts[i].text = slots[i].Count.ToString();
            }
            else
            {
                _slots[i].sprite = null;
                Debug.Log("�̹����� ����");
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
                // ���� ����
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