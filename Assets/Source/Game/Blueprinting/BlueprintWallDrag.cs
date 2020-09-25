using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Game.Blueprinting
{
    public class BlueprintWallDrag
    {
        private Vector3Int m_DragStartedPos;
        private Vector3Int m_DraggedPos;
        private readonly List<Vector3Int> m_DraggedPositions = new List<Vector3Int>();
        private readonly List<Vector3Int> m_DraggingPositions = new List<Vector3Int>();

        private void BuildDrag(Vector3Int from, Vector3Int to, List<Vector3Int> positions)
        {
            positions.Clear();
            positions.Add(from);

            int dx = from.x - to.x;
            int dy = from.y - to.y;
            int adx = Mathf.Abs(dx);
            int ady = Mathf.Abs(dy);
            int steps;
            Vector3Int direction;
            if (adx > ady)
            {
                steps = adx;
                direction = dx < 0 ? Vector3Int.right : Vector3Int.left;
            }
            else
            {
                steps = ady;
                direction = dy < 0 ? Vector3Int.up : Vector3Int.down;
            }

            for (int i = 0; i < steps; i++)
            {
                positions.Add(from + direction * i);
            }
        }

        public void StartDragBlueprint(Vector3Int mousePos)
        {
            m_DragStartedPos = mousePos;
        }

        public List<Vector3Int> DragBlueprint(Vector3Int mousePos)
        {
            m_DraggedPos = mousePos;
            BuildDrag(m_DragStartedPos, m_DraggedPos, m_DraggingPositions);
            return m_DraggingPositions;
        }

        public List<Vector3Int> StopDragBlueprint(Vector3Int mousePos)
        {
            m_DraggedPos = mousePos;
            BuildDrag(m_DragStartedPos, m_DraggedPos, m_DraggedPositions);
            return m_DraggedPositions;
        }
    }
}
