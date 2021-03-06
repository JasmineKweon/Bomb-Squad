using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float x_Start, y_Start;

    public int columnLength, rowLength;
    public float x_Space, y_Space;
    public GameObject boxPrefab;

    //public GameObject propPrefab;

    float x_Position;
    float y_Position;

    float column;
    float row;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            column = i % columnLength;
            row = i / columnLength;

            if (((column == 0) && (row == 0)) || ((column == columnLength-1) && (row == 0)) || ((column == 1) && (row == 0)) || ((column == 0) && (row == 1)) || ((column == columnLength - 2) && (row == 0)) || ((column == columnLength - 1) && (row == 1)))
            {
                continue;
            }
            else
            {
                x_Position = x_Start + (x_Space * column);
                y_Position = y_Start + (y_Space * row);

                Instantiate(boxPrefab, new Vector3(x_Position, y_Position), Quaternion.identity);
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
