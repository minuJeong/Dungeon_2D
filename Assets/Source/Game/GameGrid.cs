using Assets.Source.Game.Blueprinting;
using UnityEngine;

namespace Assets.Source.Game
{
    public class GameGrid : MonoBehaviour
    {
        [SerializeField] public BlueprintTile m_BlueprintTile;
        [SerializeField] public BlueprintTile m_BlueprintPreviewTile;
        [SerializeField] public Grid m_WorldGrid;

        private void Start()
        {
            Debug.Assert(m_WorldGrid);
            Debug.Assert(m_BlueprintTile);
        }

        public Vector3Int WorldToCell(Vector3 worldPos)
        {
            return m_WorldGrid.WorldToCell(worldPos);
        }

        public void PutBlueprint(Vector3 pos)
        {
            PutBlueprint(WorldToCell(pos));
        }

        public void PutBlueprint(Vector3Int pos)
        {
            m_BlueprintTile.PutBlueprint(pos);
        }

        public void ClearBlueprint()
        {
            m_BlueprintTile.ClearBlueprint();
        }

        public void ClearBlueprintPreview()
        {
            m_BlueprintTile.ClearBlueprint();
        }
    }
}
