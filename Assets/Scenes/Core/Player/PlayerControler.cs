using Core.Pawns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Pawns.Player
{
    public class PlayerControler : MonoBehaviour
    {
        [SerializeField] private PawnsMovement _movement;
        [SerializeField] private Transform _fireTransform;

        public Vector2 InputAxis { get; private set; }  
        public Vector2 MousePosition { get; private set; }

     

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            InputAxis = new Vector2(horizontal, vertical);  
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void FixedUpdate()
        {
            _movement.Movement(InputAxis);
            _movement.Rotate(MousePosition);
        }
    }
}
