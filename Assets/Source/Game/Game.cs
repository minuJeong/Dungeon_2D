using Assets.Source.Game.Blueprinting;
using System;
using UnityEngine;

namespace Assets.Source.Game
{
    public class Game : MonoBehaviour
    {
        [SerializeField] public GameGrid m_GameGrid;
        [SerializeField] public Camera m_WorldCamera;
        private BlueprintWallDrag m_BlueprintDrag;

        void Start()
        {
            Debug.Assert(m_GameGrid);
            Debug.Assert(m_WorldCamera);

            m_BlueprintDrag = new BlueprintWallDrag();
        }

        private void Update()
        {
            UpdateInput();
        }

        private void UpdateInput()
        {
            if (Input.GetMouseButtonDown(0)) { OnMouseDown(); }
            else if (Input.GetMouseButtonUp(0)) { OnMouseUp(); }
            else if (Input.GetMouseButton(0)) { OnMousePressed(); }
        }

        private void OnMousePressed()
        {
            Vector3 worldPos = m_WorldCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = m_GameGrid.WorldToCell(worldPos);
            m_GameGrid.ClearBlueprint();
            m_BlueprintDrag.DragBlueprint(cell).ForEach(m_GameGrid.PutBlueprint);
        }

        private void OnMouseUp()
        {
            Vector3 worldPos = m_WorldCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = m_GameGrid.WorldToCell(worldPos);
            m_GameGrid.ClearBlueprint();
            m_BlueprintDrag.StopDragBlueprint(cell).ForEach(m_GameGrid.PutBlueprint);
        }

        private void OnMouseDown()
        {
            Vector3 worldPos = m_WorldCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = m_GameGrid.WorldToCell(worldPos);
            m_BlueprintDrag.StartDragBlueprint(cell);
        }
    }
}