using Core.Pawns;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.Pawns.Player
{
    public class PlayerControler : MonoBehaviour
    {
        [SerializeField] private PawnsMovement _movement;
        [SerializeField] private Transform _fireTransform;
        [SerializeField] private float _rollSpeed = 10f;
        [SerializeField] private float _rollDuration = 0.3f;

        private Rigidbody2D _rb;
        private Item _item;
        private float _rollCoolTime = 0.0f;
        private bool isRolling = false;
        private int _money;
        public Vector2 InputAxis { get; private set; }  
        public Vector2 MousePosition { get; private set; }


        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();  
            _item = FindObjectOfType<Item>();
            if(_item == null )
            {
                Debug.Log("찾을수없음");
            }
        }

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            InputAxis = new Vector2(horizontal, vertical);
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetKeyDown(KeyCode.LeftShift) && !isRolling)
            {
                StartRolling();
            }
        }
        private void FixedUpdate()
        {
            if (!isRolling)
            {
                _movement.Movement(InputAxis);
            }
            _movement.Rotate(MousePosition);

            if (isRolling)
            {
                _rollCoolTime += Time.deltaTime;
                if (_rollCoolTime >= _rollDuration)
                {
                    StopRolling();
                }
            }
        }

        private void StartRolling()
        {
            isRolling = true;
            _rollCoolTime = 0.0f;
            Vector2 rollDir = (MousePosition - (Vector2)transform.position).normalized;
            _rb.velocity = rollDir * _rollSpeed;
            Debug.Log("구르기");
        }

        private void StopRolling()
        {
            isRolling = false;
            _rb.velocity = new Vector2(0,_rb.velocity.y);
        }

       
        public void AddMoney(int value)
        {
            _money += value;
            Debug.Log($"현재 코인 : {_money}");
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Item"))
            {
                _item.PickupItem(other.gameObject.name);
                Destroy(other.gameObject);
            }
        }

    }
}
