using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneration : MonoBehaviour
{
    public GameObject wall;
    public GameObject cameraRig;
    public int cornDensetiy;

    /* 'W' = Wall
     * 'S' = Starting position. Needs _ all around it
     * '_' = Path   
     */
    private char[,] maze = new char[,]
    {
        {'W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W'},
        {'W','_','_','_','_','_','W','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','S','_','W','_','W','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','W','W','W','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','W','_','_','_','W','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','W','W','W','_','W','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','W','_','W','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','W','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
        {'W','_','W','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
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
                        for (int i = 0; i < cornDensetiy; i++)
                        {
                            GameObject corn = Instantiate(wall, new Vector3(x + Random.Range(-0.5f, 0.5f), 2.05f, y + Random.Range(-0.5f, 0.5f)), Quaternion.identity);
                            corn.transform.Rotate(-88.411f, Random.Range(0f, 360f), 0f);
                        }
                        break;
                    case 'S':
                        cameraRig.transform.position = new Vector3(x, 0, y);
                        break;
                }
                

            }
        }
    }
}
