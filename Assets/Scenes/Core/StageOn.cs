using Core.Controller;
using UnityEngine;

public class StageON : MonoBehaviour
{
    [SerializeField] StageController _nextStageController; // 다음 스테이지의 StageController
    [SerializeField] StageController _currentStage; // 현재 스테이지 오브젝트
    [SerializeField] Collider2D _collisionLine;


    private void OnTriggerEnter2D(Collider2D other)
    {
        _collisionLine = other.GetComponent<Collider2D>();

        if (_collisionLine.CompareTag("Player")) // 플레이어가 트리거에 닿았을 때
        {
            _currentStage.RestoreTileMap();

            //_nextStageController.ResetStage();
            Debug.Log("스테이지 ON");
        }
    }
}