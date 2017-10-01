using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Lang;

namespace Assets.Map
{
    public class MapGrid : MonoBehaviour
    {
        public int Width;
        public int Height;
        public int LandTileRows;

        private MapTile[,] _mapTiles;
        private Camera _cam;
        private GameObject _land;
        private GameObject _sea;
        private GameObject _shore;

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
            _cam = GameObject.FindObjectOfType<Camera>();
            _mapTiles = new MapTile[Width, Height];
            _land = Resources.Load<GameObject>("Map/Land_placeholder");
            _sea = Resources.Load<GameObject>("Map/Sea_placeholder");
            _shore = Resources.Load<GameObject>("Map/Shore_placeholder");
            CreateTiles();
            PlaceTiles();
        }

        void CreateTiles()
        {
            for (int i = 0; i < Width; ++i)
            {
                for (int j = 0; j < Height; ++j)
                {
                    GameObject obj;
                    MapTile.TileType tileType = i < LandTileRows ? MapTile.TileType.Land : MapTile.TileType.Sea;
                    switch (tileType)
                    {
                        case MapTile.TileType.Land:
                            obj = Instantiate(_land);
                            break;
                        case MapTile.TileType.Sea:
                            if (i > 0 && GetTile(i - 1, j).TType == MapTile.TileType.Land)
                                obj = Instantiate(_shore);
                            else
                                obj = Instantiate(_sea);
                            break;
                        default:
                            obj = Instantiate(_sea);
                            break;
                    }
                    MapTile t = obj.AddComponent<MapTile>();
                    t.TType = tileType;
                    SetTile(i, j, t);
                }
            }
        }

        void PlaceTiles()
        {
            _cam = FindObjectOfType<Camera>();
            for (int x = 0; x < Width; ++x)
            {
                for (int y = 0; y < Height; ++y)
                {
                    MapTile t = GetTile(x, y);
                    Vector3 position = new Vector3((float)x / Width, (float)y / Height, -_cam.transform.position.z);
                    t.gameObject.transform.position = _cam.ViewportToWorldPoint(position);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}