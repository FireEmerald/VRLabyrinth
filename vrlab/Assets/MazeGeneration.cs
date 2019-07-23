using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneration : MonoBehaviour
{
    public GameObject wall;
    public GameObject cameraRig;

    /* 'W' = Wall
     * 'S' = Starting position. Needs _ all around it
     * '_' = Path   
     */
    private char[,] maze = new char[,]
    {
        {'W','W','W','W','W','W','W','W','W','W','W'},
        {'W','_','_','_','_','_','_','_','W','_','W'},
        {'W','_','S','_','W','W','W','_','_','_','W'},
        {'W','_','_','_','W','_','W','_','W','W','W'},
        {'W','_','W','W','W','_','_','_','W','_','W'},
        {'W','_','_','W','W','W','W','W','W','_','W'},
        {'W','W','_','W','W','_','_','_','_','_','W'},
        {'W','W','_','W','W','_','W','W','_','W','W'},
        {'W','_','_','_','_','_','W','W','_','_','W'},
        {'W','W','W','W','W','W','W','W','W','_','W'}
    };

    void Start()
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                char type = maze[x, y];

                switch (type) {
                    case 'W':
                        Instantiate(wall, new Vector3(x, 1, y), Quaternion.identity);
                        break;
                    case 'S':
                        cameraRig.transform.position = new Vector3(x, 0, y);
                        break;
                }
                

            }
        }
    }
}
