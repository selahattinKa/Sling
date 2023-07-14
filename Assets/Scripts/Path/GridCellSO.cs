using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridCell", menuName = "SlingDrift/Grid Cell")]
public class GridCellSO : ScriptableObject
{
    public enum CellType { Path, Ground }

    public CellType cellType;
    public GameObject cellPrefab;
    public int ZRotation;
    
    

}
