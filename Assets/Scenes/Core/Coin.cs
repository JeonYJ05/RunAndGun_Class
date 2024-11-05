using Core.Pawns.Player;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // �÷��̾�� ������ �ı� �� �� ����
    // ȸ�� �߰� 

    [SerializeField] private int _coinValue = 1;

    [SerializeField] float amplitude = 0.1f; //����
    [SerializeField] float frequency = 1f; // �ֱ�
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;    
    }

    private void Update()
    {
        float newY = _startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(_startPosition.x , newY , _startPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<PlayerControler>(out PlayerControler player))
        {
            player.AddMoney(_coinValue);
            Destroy(gameObject);
        }
    }

    public void SetCoinValue(int value)
    {
        _coinValue = value;
    }
}