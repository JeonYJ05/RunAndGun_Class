using UnityEngine;
using UnityEngine.Tilemaps;

namespace Core.UI
{
    public class GunChoiceUI : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private GameObject _uiPanel;
        [SerializeField] private Tile _targetTile;

        private bool isUi = false;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
                Vector3Int cellPosition = _tileMap.WorldToCell(mousePos);

                Tile clickedTile = _tileMap.GetTile<Tile>(cellPosition);

                if (clickedTile == _targetTile)
                {
                    OpenUi();
                }
                
            }
            CloseUi();
        }

        private void OpenUi()
        {
            _uiPanel.SetActive(true);
            isUi = true;
        }
        private void CloseUi()
        {
            if(isUi)
            {
                if(Input.GetKey(KeyCode.Escape))
                {
                    _uiPanel.SetActive(false);
                }
            }
        }

        public void QuitBtn()
        {
            _uiPanel.SetActive(false);   
        }
    }
}
