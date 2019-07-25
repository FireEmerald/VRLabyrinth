using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneration : MonoBehaviour
{
    public GameObject wall;
    public GameObject cameraRig;
    public int cornDensetiy;

    private const char WALL = 'W';
    private const char STARTPOS = 'S';
    private const char PATH = '_';
    private const char END = 'E';
    struct WallItem
    {
        public int x;
        public int y;

        public WallItem(int x, int y) : this()
        {
            this.x = x;
            this.y = y;
        }
    };

    private List<WallItem> WallList = new List<WallItem>();
    private char[,] maze = new char[11, 17];

    /* 'W' = Wall
     * 'S' = Starting position. Needs _ all around it
     * '_' = Path   
     */

    //{
    //Wall(x,y)
    //    {'W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W','W'},X
    //    {'W','_','_','_','_','_','W','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','_','S','_','W','_','W','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','_','_','_','W','W','W','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','_','W','_','_','_','W','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','_','W','W','W','_','W','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','_','W','_','W','_','_','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','_','_','_','W','_','_','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','_','W','_','_','_','_','_','_','_','_','_','_','_','_','_','W'},
    //    {'W','W','W','W','W','W','W','W','W','_','W','W','W','W','W','W','W'}
    //};    Y    

    void Start()
    {
        randomizeMap();
        generateMap();
    }

    private void randomizeMap()
    {
        generateWall();
        int random = UnityEngine.Random.Range(1, maze.GetLength(1)-2);
        maze[0, random] = END;
        AddAdjacentWalls( 0, random);
        do
        {
            PickWall();
        } while (WallList.Count != 0);
        getStartPosition(random);
    }

    private void getStartPosition(int start)
    {
        int position;
        if (start > maze.GetLength(1) / 2)
        {
            position = 2;
        }
        else
        {
            position = maze.GetLength(1) - 3;
        }
        int mazeMaxRow = maze.GetLength(0)- 2;
        maze[mazeMaxRow, position - 1] = PATH;
        maze[mazeMaxRow, position] = PATH;
        maze[mazeMaxRow, position + 1] = PATH;
        maze[mazeMaxRow - 1, position - 1] = PATH;
        maze[mazeMaxRow - 1, position] = STARTPOS;
        maze[mazeMaxRow - 1, position + 1] = PATH;
        maze[mazeMaxRow - 2, position - 1] = PATH;
        maze[mazeMaxRow - 2, position] = PATH;
        maze[mazeMaxRow - 2, position + 1] = PATH;
    }

    private void AddAdjacentWalls(int x, int y)
    {
        if (x > 0 && maze[x-1, y] == WALL)
        {
            WallList.Add(new WallItem(x-1, y));
        }
        if (x < maze.GetLength(0) - 1 && maze[x+1, y] == WALL)
        {
            WallList.Add(new WallItem(x + 1, y));
        }
        if (y > 0 && maze[x,y-1] == WALL)
        {
            WallList.Add(new WallItem(x, y-1));
        }
        if (y < maze.GetLength(1) - 1 && maze[x, y + 1] == WALL)
        {
            WallList.Add(new WallItem(x, y + 1));
        }
        //check for doubles??

    }

    private void PickWall()
    {
        WallItem randomWall = WallList[UnityEngine.Random.Range(0, WallList.Count)];
        WallList.Remove(randomWall);
        if (checkAdjacent(randomWall))
        {
            maze[randomWall.x, randomWall.y] = PATH;
            AddAdjacentWalls(randomWall.x, randomWall.y);
        }
    }

    private bool checkAdjacent(WallItem randomWall)
    {
        int walls = 0;

        if (randomWall.x > 0 && maze[randomWall.x - 1, randomWall.y] == WALL)
        {
            walls++;
        }
        if (randomWall.x < maze.GetLength(0) - 1 && maze[randomWall.x + 1, randomWall.y] == WALL)
        {
            walls++;
        }
        if (randomWall.y > 0 && maze[randomWall.x, randomWall.y - 1] == WALL)
        {
            walls++;
        }
        if (randomWall.y < maze.GetLength(1) - 1 && maze[randomWall.x, randomWall.y + 1] == WALL)
        {
            walls++;
        }

        if (walls == 3)
        {
            return true;
        }
        return false;
    }

    private void generateWall()
    {
       for (int i = 0; i < maze.GetLength(1); i++)
       {
            for (int j = 0; j < maze.GetLength(0); j++)
            {
                    maze[j, i] = WALL;
            }
       }
    }

    private void generateMap()
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                char type = maze[x, y];

                switch (type)
                {
                    case WALL:
                        for (int i = 0; i < cornDensetiy; i++)
                        {
                            GameObject corn = Instantiate(wall, new Vector3(x + UnityEngine.Random.Range(-0.5f, 0.5f), 2.05f, y + UnityEngine.Random.Range(-0.5f, 0.5f)), Quaternion.identity);
                            corn.transform.Rotate(-88.411f, UnityEngine.Random.Range(0f, 360f), 0f);
                        }
                        break;
                    case STARTPOS:
                        cameraRig.transform.position = new Vector3(x, 0, y);
                        break;
                }


            }
        }
    }
}
