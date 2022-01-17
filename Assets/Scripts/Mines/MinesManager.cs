using System;
using UnityEngine;

public class MinesManager : MonoBehaviour
{
    Cell[,] cellsMatrix;

    public Vector2Int dimension;

    [SerializeField] Cell cellprefab;

    [Range(0,100)]public int minesPercent;

    public Sprite pressedSprite;

    public Sprite unpressedSprite;

    // Start is called before the first frame update
    void Start()
    {
        InitCellsMatrix();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitCellsMatrix() {

        if (cellsMatrix == null)
        {

            cellsMatrix = new Cell[dimension.x, dimension.y];

            CellMatrixLoop((i, j) =>
            {
                Cell cell = Instantiate(cellprefab, new Vector3(i, j), Quaternion.identity, transform);
                cell.name = String.Format("x : {0} , y: {1}", i, j);
                cellsMatrix[i, j] = cell;
            });

          
        }

        CellMatrixLoop((i, j) =>
        {
            //TODO
            cellsMatrix[i, j].Init(new Vector2Int(i, j),
                UnityEngine.Random.Range(0, 100) < minesPercent ? true : false, Activate);

            cellsMatrix[i, j].sprite = unpressedSprite;

        });
    }

    void Activate(int i, int j) {

        print(String.Format("x : {0} , y: {1} , isMine: {2}, isShow: {3}", i, j, cellsMatrix[i, j].IsMine, cellsMatrix[i, j].IsShowed));

        if (cellsMatrix[i, j].IsShowed)
            return;

        cellsMatrix[i, j].IsShowed = true;

        if (cellsMatrix[i, j].IsMine)
        {
            InitCellsMatrix();
        }
        else {
            cellsMatrix[i, j].sprite = pressedSprite;

            if (ArroundCount(i, j) == 0)
            {
                ActivateArround(i, j);

            }
            else 
            {
                cellsMatrix[i, j].texto = ArroundCount(i, j).ToString();
            }
        }


    }

     void CellMatrixLoop(Action<int, int> _event) {

        for (int i = 0; i < dimension.x; i++)
        {

            for (int j = 0; j < dimension.y; j++)
            {
                _event(i, j);

            }

        }

    }

    void ActivateArround(int i, int j)
    {
        if (PointInsideMatrix(i + 1, j))
            Activate(i + 1, j);
        if (PointInsideMatrix(i, j + 1))
            Activate(i, j + 1);
        if (PointInsideMatrix(i + 1, j + 1))
            Activate(i + 1, j + 1);
        if (PointInsideMatrix(i - 1, j))
            Activate(i - 1, j);
        if (PointInsideMatrix(i, j - 1))
            Activate(i, j - 1);
        if (PointInsideMatrix(i - 1, j - 1))
            Activate(i - 1, j - 1);
        if (PointInsideMatrix(i - 1, j + 1))
            Activate(i - 1, j + 1);
        if (PointInsideMatrix(i + 1, j - 1))
            Activate(i + 1, j - 1);
    }

    /// <summary>
    ///   Devuelve la cantidad de minas alrededor de una cordenada
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns>Int</returns>
    int ArroundCount(int i, int j)
    {
        int arround = 0;

        if (PointInsideMatrix(i + 1, j) && cellsMatrix[i + 1, j].IsMine)
            arround++;
        if (PointInsideMatrix(i, j + 1) && cellsMatrix[i, j + 1].IsMine)
            arround++;
        if (PointInsideMatrix(i + 1, j + 1) && cellsMatrix[i + 1, j + 1].IsMine)
            arround++;
        if (PointInsideMatrix(i - 1, j) && cellsMatrix[i - 1, j].IsMine)
            arround++;
        if (PointInsideMatrix(i, j - 1) && cellsMatrix[i, j - 1].IsMine)
            arround++;
        if (PointInsideMatrix(i - 1, j - 1) && cellsMatrix[i - 1, j - 1].IsMine)
            arround++;
        if (PointInsideMatrix(i - 1, j + 1) && cellsMatrix[i - 1, j + 1].IsMine)
            arround++;
        if (PointInsideMatrix(i + 1, j - 1) && cellsMatrix[i + 1, j - 1].IsMine)
            arround++;

        return arround;
    }

    bool PointInsideMatrix(int i, int j) {

        if(i >= cellsMatrix.GetLength(0))
            return false;
        if (i < 0)
            return false;
        if (j >= cellsMatrix.GetLength(1))
            return false;
        if (j < 0)
            return false;

        return true;
    }


}
