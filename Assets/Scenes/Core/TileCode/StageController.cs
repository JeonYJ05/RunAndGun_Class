using System;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.Controller
{
    public class StageController : MonoBehaviour
    {
        [SerializeField] Tilemap _tilemap;
        [SerializeField] Tile _leftOpenDoor;
        [SerializeField] Tile _rightOpenDoor;
        [SerializeField] GameObject _doorPosition;
        private List<Monster> _monsters = new List<Monster>();
        private bool isSpawend = false;

        [SerializeField] GameObject[] Colortilemaps;

        public Action OnMonsterDead;

      

        private void Update()
        {
            if (isSpawend && isDetectDead())
            {
               OpenDoor();
               OnMonsterDead?.Invoke();
            }
        }

        public void RegisterMonster(Monster monster)
        {

            _monsters.Add(monster);             // 주석 ctrl + k + c                // 주석 ctrl + k + u
            isSpawend = true;
            monster.OnDeath = RemoveMonster;

            //Action 기본은 반환 및 매개변수가 없다
            //Action<> 부터는 매개변수를 추가할 수 있다.

        }
       // private void VV(Monster monster)
       // {
       //     monster.OnDeath = (받은매개변수) => RemoveMonster(받은매개변수);
       // }


        private void RemoveMonster(Monster monster)
        {
            _monsters.Remove(monster); 
            Debug.Log($"남은 몬스터 수 + {_monsters.Count}");
            if(_monsters.Count == 0)
            {
                Debug.Log("몬스터 = 0  문이 열린다");
                OpenDoor();
            }

        }

        private void CheckAllMonsterDead()
        {
            if(isDetectDead())
            {
                OpenDoor();
                OnMonsterDead?.Invoke();
            }
        }

        public bool isDetectDead()
        {
            _monsters.RemoveAll(m=>m == null || m.CurrentHealth <=0);
            bool allDead = _monsters.Count == 0;
            //Debug.Log("현재 몬스터수" + _monsters.Count);
            if (allDead)
            {
                Debug.Log("몬스터 0");
            }
            return allDead;
            
           
        }

        public void OpenDoor()
        {
            _tilemap.RefreshAllTiles();
            Vector3Int leftcellPosition = _tilemap.WorldToCell(_doorPosition.transform.position) + new Vector3Int(-1, 0, 0);
            Vector3Int rightcellPosition = _tilemap.WorldToCell(_doorPosition.transform.position) + new Vector3Int(0, 0, 0);
            _tilemap.SetTile(leftcellPosition, _leftOpenDoor);
            _tilemap.SetTile(rightcellPosition, _rightOpenDoor);

            Debug.Log("문 타일 설정");
        }

        public void ResetStage()
        {
            _monsters.Clear();
            isSpawend = false;
            Debug.Log("스테이지 초기화");
        }

        public void UnactiveTileMap()
        {
            foreach (var tilemapGameObject in Colortilemaps)
            {
                Tilemap tilemap = tilemapGameObject.GetComponent<Tilemap>();
                if (tilemap != null)
                {
                    tilemap.color = new Color(0.5f, 0.5f, 0.5f, 1f); // 회색으로 dim 효과
                }
            }
        }

        public void RestoreTileMap()
        {
            foreach (var tilemapGameObject in Colortilemaps)
            {
                Tilemap tilemap = tilemapGameObject.GetComponent<Tilemap>();
                if (tilemap != null)
                {
                    tilemap.color = Color.white; // 원래 색상으로 복구
                }
            }
        }
    }
}