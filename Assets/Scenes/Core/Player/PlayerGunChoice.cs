using Unity.VisualScripting;
using UnityEngine;

namespace Core.Pawns.Player
{
    public class PlayerGunChoice : MonoBehaviour
    {
        private GameObject _gunPrefab;
        [SerializeField] GameObject _firePoint;

        [SerializeField] GameObject _normalGun;

        private GameObject _currentGun;

        private void Update()
        {
            SpawnGun();
        }

        private void SpawnGun()
        {
            if(_currentGun != null)
            {
                Destroy(_currentGun);
            }

            _currentGun = Instantiate(_gunPrefab , _firePoint.transform.position, _firePoint.transform.rotation);
            _currentGun.transform.SetParent(_firePoint.transform);
        }

        public void NormalGunChoice()
        {
            _gunPrefab = _normalGun;
        }

    }

}