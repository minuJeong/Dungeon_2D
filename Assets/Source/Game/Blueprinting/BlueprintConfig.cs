using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Source.Game.Blueprinting
{
    [CreateAssetMenu]
    public class BlueprintConfig : ScriptableObject
    {
        [SerializeField] public Tile m_BlueprintTile;
    }
}