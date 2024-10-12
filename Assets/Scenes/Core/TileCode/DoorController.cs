using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : MonoBehaviour
{
    [SerializeField] Tilemap _tilemap;
    [SerializeField] Tile _leftOpenDoor;
    [SerializeField] Tile _rightOpenDoor;
    [SerializeField] GameObject _doorPosition;    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Vector3Int leftcellPosition = _tilemap.WorldToCell(_doorPosition.transform.position) + new Vector3Int(-1, 0, 0);
            Vector3Int rightcellPosition = _tilemap.WorldToCell(_doorPosition.transform.position) + new Vector3Int(0, 0, 0);
            _tilemap.SetTile(leftcellPosition, _leftOpenDoor);
            _tilemap.SetTile(rightcellPosition, _rightOpenDoor);

            Debug.Log("´ê");
        }
    }
}
