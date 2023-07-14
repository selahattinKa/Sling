using System.Collections.Generic;
using UnityEngine;

 public class GridManager : MonoBehaviour
    {
        public int gridWidth = 16;
        public int gridHeight = 8;
        public float wait = 0.25f;
        public int minPthLength = 30;

        public GridCellSO[] gridCells;
    
        private PathGenerator _pathGenerator;


    

        // Start is called before the first frame update
        void Start()
        {
            _pathGenerator = new PathGenerator(gridWidth, gridHeight);
       
            List<Vector2Int> pathCells = _pathGenerator.GeneratePath();
            int pathSize = pathCells.Count;
        
            while (pathSize < minPthLength)
            {
                pathCells = _pathGenerator.GeneratePath();
                pathSize = pathCells.Count;
            

            }

            LayPathCells(pathCells);
        
        
        }

        private void LayPathCells(List<Vector2Int> pathCells)
        {
            foreach (Vector2Int pathCell in pathCells)
            {
                int neighbourValue = _pathGenerator.getCellNeighbourValue(pathCell.x, pathCell.y);
                // Debug.Log( "Tile: "+ pathCell.x + ", " + pathCell.y + " Neighbour Value = " + neighbourValue);
                GameObject pathTile = gridCells[neighbourValue].cellPrefab;
                GameObject pathTileCell = Instantiate(pathTile, new Vector3(pathCell.y, pathCell.x, 0f), Quaternion.identity);
                PathDirection pathDirection = pathTileCell.GetComponent<PathDirection>();
                // if (_pathGenerator.direction == 0)
                // {
                //     pathDirection.PatikaYonu = PathDirection.patikaYonu.Up;
                //     Debug.Log(_pathGenerator.direction);
                // } 
                // else if (_pathGenerator.direction == 1)
                // {
                //     pathDirection.PatikaYonu = PathDirection.patikaYonu.Right;
                //     Debug.Log(_pathGenerator.direction);
                //
                // } 
                // else if (_pathGenerator.direction == 2)
                // {
                //     pathDirection.PatikaYonu = PathDirection.patikaYonu.Left;
                //     Debug.Log(_pathGenerator.direction);
                //
                // }
                pathTileCell.transform.Rotate(0f, 0f, gridCells[neighbourValue].ZRotation, Space.Self);

            }
        }
    }
