using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Source.Game.Blueprinting
{
    public class BlueprintTile : MonoBehaviour
    {
        [SerializeField] public Tilemap m_BlueprintTilemap;
        [SerializeField] public BlueprintConfig m_BlueprintConfig;

        private void Start()
        {
            Debug.Assert(m_BlueprintTilemap);
            Debug.Assert(m_BlueprintConfig);
        }

        public void PutBlueprint(Vector3Int pos)
        {
            m_BlueprintTilemap.SetTile(pos, m_BlueprintConfig.m_BlueprintTile);
        }

        public void ClearBlueprint()
        {
            m_BlueprintTilemap.ClearAllTiles();
        }
    }
}
