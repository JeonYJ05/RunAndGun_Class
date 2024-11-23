using Core.Pawns.Player;
using UnityEngine;

public class Potion : MonoBehaviour
{
    // 플레이어에게 닿을시 파괴 및 돈 증가
    // 회전 추가 

    [SerializeField] private int _potionValue = 1;

    [SerializeField] float amplitude = 0.1f; //진폭
    [SerializeField] float frequency = 1f; // 주기
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newY = _startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(_startPosition.x, newY, _startPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerControler>(out PlayerControler player))
        {
            Destroy(gameObject);
        }
    }

    public void SetPotionValue(int value)
    {
        _potionValue = value;
    }
}