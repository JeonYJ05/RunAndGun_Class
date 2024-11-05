using Core.Controller;
using UnityEngine;

public class StageON : MonoBehaviour
{
    [SerializeField] StageController _nextStageController; // ���� ���������� StageController
    [SerializeField] StageController _currentStage; // ���� �������� ������Ʈ
    [SerializeField] Collider2D _collisionLine;


    private void OnTriggerEnter2D(Collider2D other)
    {
        _collisionLine = other.GetComponent<Collider2D>();

        if (_collisionLine.CompareTag("Player")) // �÷��̾ Ʈ���ſ� ����� ��
        {
            _currentStage.RestoreTileMap();

            //_nextStageController.ResetStage();
            Debug.Log("�������� ON");
        }
    }
}