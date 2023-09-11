using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjmatrix : MonoBehaviour
{
    public int Index = 0; 
    private List<Vector2Int> Neighbours = new List<Vector2Int>();
    public int[,] adjMatrix = { {0,1,0,0,0,0,0},
                                {1,0,1,0,0,0,0},
                                {0,1,0,1,0,1,0},
                                {0,0,1,0,0,1,0},
                                {0,0,0,1,0,1,0},
                                {0,0,1,0,1,0,1},
                                {0,0,0,0,0,1,0} };
    void Start()
    {
        foreach(var item in FindNodeNeighbours(Index))
        {
            Debug.Log(item);
        }
        Neighbours.Add(new Vector2Int(1, 1));  
    }
    void Update()
    {
        
    }

    public List<int> FindNodeNeighbours(int NodeIndex)
    {
        List<int> neighbourList = new List<int>();
        for (int j = 0; j < 7; j++)
        {
            if (adjMatrix[NodeIndex, j] == 1)
            {
                neighbourList.Add(j);
            }
        }
        return neighbourList;
    }

}
