using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject playerPrefab;

    public int width;
    public int height;
    private Cell[][] grid;
    private Player player;
    public List<Door> doors;

    // Start is called before the first frame update
    void Awake()
    {
        grid = new Cell[height][];
        for (int i = 0; i < grid.Length; i++) {
            grid[i] = new Cell[width];
            for (int j = 0; j < grid[i].Length; j++) {
                Vector3 position = new Vector3(j, i);
                grid[i][j] = GameObject.Instantiate(cellPrefab, position, new Quaternion(), transform).GetComponent<Cell>();
                grid[i][j].grid = this;
            }
        }
        // Set the neighbours of each cell
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (j > 0) {
                    grid[i][j].left = grid[i][j - 1];
                }
                if (j < grid[i].Length - 1) {
                    grid[i][j].right = grid[i][j + 1];
                }
                if (i > 0) {
                    grid[i][j].below = grid[i - 1][j];
                }
                if (i < grid.Length - 1) {
                    grid[i][j].above = grid[i + 1][j];
                }
            }
        }
        player = GameObject.Instantiate(playerPrefab).GetComponent<Player>();
        player.MoveTo(grid[0][0]);
    }

    public bool CellsAreAll(CellType cellType)
    {
        if (cellType == CellType.Any) {
            // This is equivalent to having all switchable tiles as either 
            // one colour or the other
            return CellsAreAll(CellType.Red) || CellsAreAll(CellType.Blue);
        }
        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (!grid[i][j].CellIs(cellType)) {
                    return false;
                }
            }
        }
        return true;
    }

    public void RecalculateDoors()
    {
        foreach (Door door in doors) {
            door.CheckOpen();
        }
    }
}
