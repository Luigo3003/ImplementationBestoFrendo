using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BFS_Behaviour : MonoBehaviour
{
    public SimpleGraph simpleGraph;
    public Transform startNode;
    public Transform endNode;

    public bool initAlgorithm = false;
    private bool algorithmIsActive = false;
    public static bool algorithmCompleted = false;

    Queue<Vector2> frontier;
    public static Dictionary<Vector2, Vector2> cameFrom;
    //==================================================
    void Update()
    {
        if (initAlgorithm && !algorithmIsActive)
        {
            Vector2 startPosition = RoundPosition(startNode.position);
            Vector2 endPosition = RoundPosition(endNode.position);
            InitBFS_Algorithm(startPosition);
            algorithmIsActive = true;
        }

        if (algorithmIsActive)
        {
            BFS_Algorithm();
        }

        

    }
    // Inicio del algoritmo BFS, define las variables necesarias
    // y establece la posición del nodo de inicio
    void InitBFS_Algorithm(Vector2 startPosition)
    {
        frontier = new Queue<Vector2>();
        frontier.Enqueue(startPosition);
        cameFrom = new Dictionary<Vector2, Vector2>();
        cameFrom.Add(startPosition, startPosition);
    }

    // Función que implementa el algoritmo BFS
    void BFS_Algorithm()
    {
        if (frontier.Count > 0)
        {
            Vector2 currentNode = frontier.Dequeue();
            foreach (Vector2 nextNode in simpleGraph.NeighbourPositions(currentNode))
            {
                if (!cameFrom.ContainsKey(nextNode))
                {
                    frontier.Enqueue(nextNode);
                    cameFrom.Add(nextNode, currentNode);
                    simpleGraph.LightNode(nextNode);
                }
            }

            // Condición para detener el algoritmo BFS
            if (currentNode == RoundPosition(endNode.position))
            {
                algorithmIsActive = false;
                initAlgorithm = false;
                algorithmCompleted = true;
                // Ordenar la reconstrucción de la trayectoria
                ReconstructPath();
            }

        }
    }

    // Devuelve una posición 2D dentro del grafo
    // Su objetivo es asegurar que una posición
    // dada se corresponda con una posición del grafo.
    public Vector2 RoundPosition(Vector3 vec)
    {
        Vector2Int size = simpleGraph.size;
        int x = (int)Mathf.Round(vec.x);
        int y = (int)Mathf.Round(vec.y);

        x = Mathf.Clamp(x, 0, size.x);
        y = Mathf.Clamp(y, 0, size.y);

        return new Vector2(x, y);
    }

    // ===================================================
    void ReconstructPath()
    {
        Vector2 current = RoundPosition(endNode.position);
        Vector2 startPosition = RoundPosition(startNode.position);

        List<Vector2> path = new List<Vector2>();

        while (current != startPosition)
        {
            path.Add(current);
            current = cameFrom[current];
        }
        path.Add(startPosition);
        path.Reverse();

        GetComponent<LineRenderer>().positionCount = path.Count;
        int i = 0;
        foreach (Vector3 v in path)
        {
            GetComponent<LineRenderer>().SetPosition(i, v);
            i++;
        }
    }
}
