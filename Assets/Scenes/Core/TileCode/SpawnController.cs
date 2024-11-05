using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Controller
{
    public class SpawnController : MonoBehaviour
    {

        [System.Serializable]
        public class SpawnPoint
        {
            public Transform SpawnTransform;
            public GameObject[] MonsterPrefabs;
        }
        [SerializeField] SpawnPoint[] _spawnPoints;
        [SerializeField] int _monsterSpawn;
        private bool _hasSpawned = false;

        [SerializeField] StageController _stageController;


        private void Awake()
        {
            _stageController = FindObjectOfType<StageController>(); 
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                SpawnedMonster();
            }
        }

        private void SpawnedMonster()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                for (int i = 0; i < _monsterSpawn; ++i)
                {
                    int randomMonsterIndex = Random.Range(0, spawnPoint.MonsterPrefabs.Length);
                    GameObject monster = Instantiate(spawnPoint.MonsterPrefabs[randomMonsterIndex], spawnPoint.SpawnTransform.position, Quaternion.identity);

                    if(_stageController != null)
                    {
                        _stageController.RegisterMonster(monster.GetComponent<Monster>());
                        Debug.Log("몬스터 등록");
                    }
                }
            }
            _hasSpawned = true;
            //this.gameObject.SetActive(false);
        }
    }
}