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

            _monsters.Add(monster);             // �ּ� ctrl + k + c                // �ּ� ctrl + k + u
            isSpawend = true;
            monster.OnDeath = RemoveMonster;

            //Action �⺻�� ��ȯ �� �Ű������� ����
            //Action<> ���ʹ� �Ű������� �߰��� �� �ִ�.

        }
       // private void VV(Monster monster)
       // {
       //     monster.OnDeath = (�����Ű�����) => RemoveMonster(�����Ű�����);
       // }


        private void RemoveMonster(Monster monster)
        {
            _monsters.Remove(monster); 
            Debug.Log($"���� ���� �� + {_monsters.Count}");
            if(_monsters.Count == 0)
            {
                Debug.Log("���� = 0  ���� ������");
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
            //Debug.Log("���� ���ͼ�" + _monsters.Count);
            if (allDead)
            {
                Debug.Log("���� 0");
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

            Debug.Log("�� Ÿ�� ����");
        }

        public void ResetStage()
        {
            _monsters.Clear();
            isSpawend = false;
            Debug.Log("�������� �ʱ�ȭ");
        }

        public void UnactiveTileMap()
        {
            foreach (var tilemapGameObject in Colortilemaps)
            {
                Tilemap tilemap = tilemapGameObject.GetComponent<Tilemap>();
                if (tilemap != null)
                {
                    tilemap.color = new Color(0.5f, 0.5f, 0.5f, 1f); // ȸ������ dim ȿ��
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
                    tilemap.color = Color.white; // ���� �������� ����
                }
            }
        }
    }
}