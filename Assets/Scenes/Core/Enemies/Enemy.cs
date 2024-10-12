using Core.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform _firePoint;

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _moveSpeed;
    
    private float _detactRange = 9.0f;    // 적을 탐지하는 거리
    private float _followDistance = 10.0f;  // 따라오는 거리
    private float _maxDistance = 5.0f;     // 플레이어와 적이 유지할 최대거리
    private float _fireRate = 2.0f;
    private float _nextFireTime;
    private Rigidbody2D _rb;
    private bool isDeath;

    public float CurrentHealth = 20.0f;
    public float EnemyCurrentHealth { get { return CurrentHealth; } }
    private void Awake()
    {
      _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distancePlayer = Vector2.Distance(transform.position, _player.position);

        if (distancePlayer < _detactRange)
        {
            if(distancePlayer < _followDistance && distancePlayer > _maxDistance)
            {
                ChasePlayer();
            }
            ShootPlayer();
            LookPlayer();
        }
    }
    private void ChasePlayer()
    {
        Vector2 dir = (_player.position - transform.position).normalized;
        
        _rb.MovePosition(_rb.position + dir * _moveSpeed * Time.deltaTime);
        ;
    }
    private void ShootPlayer()
    {
       
        if (_bulletPrefab != null && _firePoint != null && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + _fireRate;
            var Bulletinstance = Instantiate(_bulletPrefab, _firePoint.transform.position, _firePoint.transform.rotation);
            EnemyBullet Ebullet = Bulletinstance.GetComponent<EnemyBullet>();
            if (Ebullet != null)
            {
                Ebullet.Create(3, 10);
            }
        }
    }
    private void LookPlayer()              
    {
        Vector2 dir = (_player.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;   // LookAt을 쓸라했지만 2d 에서는 
        transform.rotation = Quaternion.Euler(dir.x, dir.y, angle - 90);
    }

    public void TakeDamage(float damage)
    {
        if(!isDeath)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) Death();
        }
    }
    
    private void Death()
    {
        isDeath = true;
        {
            DestroyEnemy();
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
