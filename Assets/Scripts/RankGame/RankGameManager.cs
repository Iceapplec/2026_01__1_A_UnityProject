using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class RankGameManager : MonoBehaviour
{
    public int gridWidth = 7;
    public int gridHeight = 7;
    public float CellSize = 1.3f;
    public GameObject cellPrefabs;
    public Transform gridContainer;

    public GameObject rankPrefabs;
    public Sprite[] rankSprites;
    public int maxRankLevel = 7;

    public GridCell[,] grid;
    
    void InitializeGrid()
    {
        grid = new GridCell[gridWidth, gridHeight];

        for(int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3
                    (
                        x * CellSize - (gridWidth * CellSize / 2) + CellSize / 2,
                        y * CellSize - (gridWidth * CellSize / 2) + CellSize / 2, 1f
                    );

                GameObject cellObj = Instantiate(cellPrefabs, position, Quaternion.identity, gridContainer);
                GridCell  cell = cellObj.AddComponent<GridCell>();
                cell.Initialize(x, y);

                grid[x, y] = cell; 
            }
        }
    }

    void Start()
    {
        InitializeGrid();

        for (int i = 0; i < 4; i++)
        {
            SpawnNewRank();
        }
    }

    public DraggableRank CreateRankInCell(GridCell cell, int Level)
    {
        if (cell == null || !cell.isEmpty()) return null;
        Level = Mathf.Clamp(Level, 1, maxRankLevel);
        Vector3 rankPosition = new Vector3(cell.transform.position.x, cell.transform.position.y, 0f);
        GameObject rankObj = Instantiate(rankPrefabs, rankPosition, Quaternion.identity, gridContainer);
        rankObj.name = "Rank_Level_" + Level;
        DraggableRank rank = rankObj.AddComponent<DraggableRank>();
        rank.SetRankLevel(Level);
        cell.SetRank(rank);
        return rank;
    }

    private GridCell FineEmptyCell()
    {
        List<GridCell> emptyCells = new List<GridCell>();
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (grid[x, y].isEmpty())
                {
                    emptyCells.Add(grid[x, y]);
                }
            }
        }

        if (emptyCells.Count == 0)
        {
            return null;
        }

        return emptyCells[Random.Range(0, emptyCells.Count)];
    }


    public bool SpawnNewRank()
    {
        GridCell emptyCell = FineEmptyCell();
        if (emptyCell == null)
        {
            return false;
        }
        int rankLevel = Random.Range(0, 100) < 80 ? 1 : 2;
        CreateRankInCell(emptyCell, rankLevel);
        return true;
    }

}
