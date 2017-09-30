using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Map
{
    public class MapTile : MonoBehaviour
    {
        public enum TileType
        {
            Land,
            Sea,
        }

        public TileType TType { get; set; }

        public MapTile(TileType type = TileType.Sea)
        {
            TType = type;
        }

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}