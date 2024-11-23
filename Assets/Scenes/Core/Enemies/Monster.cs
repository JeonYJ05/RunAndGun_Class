using Core.Bullets;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] float _nextFireTime;
    private Rigidbody2D _rb;
    private bool isDeath;
    
    public Action<Monster> OnDeath;

    [Header("Coin")]
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] int _coinDropCount = 1;
    [SerializeField] int _coinValue = 1;

    [Header("Item")]
    [SerializeField] GameObject _potionPrefab;
    [SerializeField] int _potionDropCount = 1;

    [Header("Chase Player")]
    [SerializeField] float _moveSpeed;
    private Transform _player;
    private float _detactRange = 9.0f;    // 적을 탐지하는 거리
    private float _followDistance = 10.0f;  // 따라오는 거리
    private float _maxDistance = 5.0f;     // 플레이어와 적이 유지할 최대거리
    private float _fireRate = 2.0f;

    // event 는 함수가 여러개 들어가야할때만(복수)  
    // Action 은 (단수) 딱 1개
    public float CurrentHealth = 20.0f;
    public float EnemyCurrentHealth { get { return CurrentHealth; } }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   

    private void Update()
    {
        if (_player == null) return;

        float distancePlayer = Vector2.Distance(transform.position, _player.position);

        if (distancePlayer < _detactRange)
        {
            if (distancePlayer < _followDistance && distancePlayer > _maxDistance)
            {
                ChasePlayer();
            }
            LookPlayer();
            Attack();
        }
    }
    private void ChasePlayer()
    {
        Vector2 dir = (_player.position - transform.position).normalized;

        _rb.MovePosition(_rb.position + dir * _moveSpeed * Time.deltaTime);
        
    }
    protected void ShootPlayer()
    {

        if (_bulletPrefab != null && _firePoint != null  && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + _fireRate;
            var Bulletinstance = Instantiate(_bulletPrefab, _firePoint.transform.position, _firePoint.transform.rotation);
            EnemyBullet Ebullet = Bulletinstance.GetComponent<EnemyBullet>();

            Vector3 dir = transform.up;
            if (Ebullet != null)
            {
                Ebullet.Create(3, 10);
                Ebullet.SetDirection(dir);  
            }
        }
    }
    public virtual void Attack()
    {
        ShootPlayer();
        Debug.Log("발사");
    }

   // private IEnumerator FireTime()
   // {
   //     while (true)
   //     {
   //         Attack();
   //         yield return new WaitForSeconds(3);
   //     }
   // }
    private void LookPlayer()
    {
        Vector2 dir = (_player.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;   // LookAt을 쓸라했지만 2d 에서는   
        transform.rotation = Quaternion.Euler(dir.x, dir.y, angle - 90);
    }

    public void TakeDamage(float damage)
    {
        if (!isDeath)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) Death();
        }
    }

    private void Death()
    {
        OnDeath?.Invoke(this);
        isDeath = true;
        {
            CoinDrop();
            PotionDrop();
            DestroyEnemy();
        }
        Debug.Log("사망");
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void CoinDrop()
    {
        for(int i=0; i< _coinDropCount; ++i)
        {
            Vector3 spawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-1.0f,1.0f),UnityEngine.Random.Range(-1.0f,1.0f),0);
            GameObject coinInstance = Instantiate(_coinPrefab , spawnPosition , Quaternion.identity);
            Coin coin = coinInstance.GetComponent<Coin>();
            if (coin != null)
            {
                coin.SetCoinValue(_coinValue);
            }
        }
    }

    public void PotionDrop()
    {
        for (int i = 0; i < _potionDropCount; ++i)
        {
            Vector3 spawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), 0);
            GameObject potionInstance = Instantiate(_potionPrefab, spawnPosition, Quaternion.identity);
            Potion potion = potionInstance.GetComponent<Potion>();
            //if (potion != null)
            //{
            //    potion.SetPotionValue(_potionValue);
            //}
        }
    }
}




// public class Item
//{
// public int Count
//}
// private Dictionary<String , Item> _inventory = new();
//{

//}

// private void AddItem(string name)
//{
//    if(_inventory.TryGetValue(name, out Item value))

//}
//else
//{
//    _inventory[name] = new Item() {Count = 1};
//}


