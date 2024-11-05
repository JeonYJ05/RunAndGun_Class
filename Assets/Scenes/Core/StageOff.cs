using Core.Controller;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageOff : MonoBehaviour
{
    [SerializeField] StageController _nextStageController; // ���� ���������� StageController
    [SerializeField] StageController _currentStage; // ���� �������� ������Ʈ
    [SerializeField] Collider2D _collisionLine;

    
    [SerializeField] GameObject _wallPrefab;



    private void OnTriggerEnter2D(Collider2D other)
    {
        _collisionLine = other.GetComponent<Collider2D>();

        if (_collisionLine.CompareTag("Player")) // �÷��̾ Ʈ���ſ� ����� ��
        {
            _currentStage.UnactiveTileMap();
            
            //_nextStageController.ResetStage();
            Debug.Log("�������� OFF");

          
        }
    }

  
}