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
        {'W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','S','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','W','W','W','W','W','W','W','W','_','W','W','W','W','W','W','W'}
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
                        GameObject g = Instantiate(wall, new Vector3(x, 2.05f, y), Quaternion.identity);
                        g.transform.Rotate(-88.411f, 0f, 0f);
                        break;
                    case 'S':
                        cameraRig.transform.position = new Vector3(x, 0, y);
                        break;
                }
                

            }
        }
    }
}
