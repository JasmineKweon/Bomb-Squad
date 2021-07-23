using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float x_Start, y_Start;

    public int columnLength, rowLength;
    public float x_Space, y_Space;
    public GameObject boxPrefab;

    float x_Position;
    float y_Position;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            x_Position = x_Start + (x_Space * (i % columnLength));
            y_Position = y_Start + (y_Space * (i / columnLength)); 

            Vector2 position = new Vector3(x_Position, y_Position, 0);
        
            if(Physics2D.Raycast(position, Vector2.up, 0.5f)!=true)
            {
                Instantiate(boxPrefab, position, Quaternion.identity);
            }
            
            //Instantiate(boxPrefab, new Vector3(x_Position, y_Position), Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
