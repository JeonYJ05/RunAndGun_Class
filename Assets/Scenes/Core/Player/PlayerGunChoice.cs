using Unity.VisualScripting;
using UnityEngine;

namespace Core.Pawns.Player
{
    public class PlayerGunChoice : MonoBehaviour
    {
        private GameObject _gunPrefab;
        private Transform _firePoint;

        [SerializeField] GameObject _normalGun;
        [SerializeField] GameObject _shotGun;
        [SerializeField] GameObject _muchineGun;

        private GameObject _currentGun;

        private void Awake()
        {
            _firePoint = GameObject.Find("PlayerFirePoint").transform;
            if(_firePoint == null )
            {
                Debug.Log("ã��������");
            }
        }

        private void SpawnGun()
        {
            if (_currentGun != null)
            {
                Destroy(_currentGun);
            }

            if (_gunPrefab != null && _firePoint != null)
            {
                _currentGun = Instantiate(_gunPrefab, _firePoint.transform.position, _firePoint.transform.rotation);
                _currentGun.transform.SetParent(_firePoint.transform);
                _currentGun.transform.localPosition = Vector3.zero;
                _currentGun.transform.localRotation = Quaternion.identity;

                Rigidbody2D rb = _currentGun.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.isKinematic = true; 
                }
            }
        }

        public void NormalGunChoice()
        {
            _gunPrefab = _normalGun;
            SpawnGun();
        }

        public void ShotGunChoice()
        {
            _gunPrefab = _shotGun;
            SpawnGun();
        }

        public void MuchineGunChoice()
        {
            _gunPrefab = _muchineGun;
            SpawnGun();
        }

    }

}