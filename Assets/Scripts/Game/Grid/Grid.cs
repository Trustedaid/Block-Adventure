using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float squareGap = 0.1f;
    public GameObject gridSquare;
    public Vector2 startPosition = new Vector2(0.0f, 0.0f);
    public float squareScale = 0.5f;
    public float everySquareOffset = 0.0f;

    private Vector2 offset = new Vector2(0.0f, 0.0f);
    private List<GameObject> gridSquares = new List<GameObject>();

    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        SpawnGridSquares();
        SetGridSquaresPosition();
    }

    private void SpawnGridSquares()
    {
        // 0, 1, 2, 3, 4,
        // 5, 6, 7, 8, 9

        int squareIndex = 0;

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; ++column)
            {
                gridSquares.Add(Instantiate(gridSquare) as GameObject);
                gridSquares[gridSquares.Count - 1].transform.SetParent(this.transform);
                gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
                gridSquares[gridSquares.Count - 1].GetComponent<GridSquare>().SetImage(squareIndex % 2 == 0);
                squareIndex++;
            }
        }
    }

    private void SetGridSquaresPosition()
    {
        int columnNumber = 0;
        int rowNumber = 0;
        Vector2 squareGapNumber = new Vector2(0.0f, 0.0f);
        bool rowMoved = false;

        var squareRect = gridSquares[0].GetComponent<RectTransform>();

        offset.x = squareRect.rect.width * squareRect.transform.localScale.x + everySquareOffset;
        offset.y = squareRect.rect.height * squareRect.transform.localScale.y + everySquareOffset;

        foreach (GameObject square in gridSquares)
        {
            if (columnNumber + 1 > columns)
            {
                squareGapNumber.x = 0;
                // go to the next column
                columnNumber = 0;
                rowNumber++;
                rowMoved = false;
            }

            var pos_x_offset = offset.x * columnNumber + (squareGapNumber.x * squareGap);
            var pos_y_offset = offset.y * rowNumber + (squareGapNumber.y * squareGap);
            if (columnNumber > 0 && columnNumber % 3 == 0)
            {
                squareGapNumber.x++;
                pos_x_offset += squareGap;
            }

            if (rowNumber > 0 && rowNumber % 3 == 0 && rowMoved == false)
            {
                rowMoved = true;
                squareGapNumber.y++;
                pos_y_offset += squareGap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x + pos_x_offset, startPosition.y - pos_y_offset);

            square.GetComponent<RectTransform>().localPosition = new Vector3(startPosition.x + pos_x_offset, startPosition.y - pos_y_offset, 0.0f);

            columnNumber++;
        }

    }


}
