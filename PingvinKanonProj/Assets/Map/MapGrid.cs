using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Lang;

namespace Assets.Map
{
    public class MapGrid : MonoBehaviour
    {
        public const int DefaultWidth = 32;
        public const int DefaultHeight = 24;
        public int Width { get; set; }
        public int Height { get; set; }

        private MapTile[,] _mapTiles;
        private Camera _cam;
        private Sprite _land;
        private Sprite _sea;

        MapTile GetTile(int x, int y)
        {
            return _mapTiles[x, y];
        }

        void SetTile(int x, int y, MapTile mapTile)
        {
            _mapTiles[x, y] = mapTile;
        }

        // Use this for initialization
        void Start()
        {
            _cam = GetComponent<Camera>();
            _mapTiles = new MapTile[Width, Height];
            CreateTiles();
            PlaceTiles();
        }

        void CreateTiles()
        {
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    GameObject tileObj = new GameObject();
                    tileObj.AddComponent<MapTile>();
                    tileObj.AddComponent<SpriteRenderer>();

                    MapTile t = tileObj.GetComponent<MapTile>();
                    SpriteRenderer sr = tileObj.GetComponent<SpriteRenderer>();
                    switch (t.TType)
                    {
                        case MapTile.TileType.Land:
                            sr.color = Color.green;
                            sr.size = new Vector2(32, 32);
                            sr.sprite = _land;
                            break;
                        case MapTile.TileType.Sea:
                            sr.color = Color.blue;
                            sr.size = new Vector2(32, 32);
                            sr.sprite = _sea;
                            break;
                    }

                    SetTile(i, j, t);
                }
            }
        }

        void PlaceTiles()
        {
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    MapTile t = GetTile(x, y);
                    t.gameObject.transform.position = _cam.ViewportToWorldPoint(new Vector2(x * 1.0f / Width, y * 1.0f / Height));
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}