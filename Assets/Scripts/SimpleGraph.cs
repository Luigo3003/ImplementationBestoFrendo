using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGraph : MonoBehaviour
{

    // Vector que contiene dos números enteros que representan el tamaño del grafo
    // size.x = número de nodos de ancho
    // size.y = número de nodos de alto
    public Vector2Int size;

    // Variable booleana para indicar la creación de obstaculos
    // Los obstaculos se simulan con la omisión de nodos
    public bool hasObstacles;

    // Referencia al prefab que representa un nodo
    public GameObject nodePrefab;

    // Lista que contiene a los gameobjects de los nodos
    [System.NonSerialized]
    public List<GameObject> nodes = new List<GameObject>();

    // Lista que contiene a las posiciones de los nodos
    [System.NonSerialized]
    public List<Vector2> nodePositions = new List<Vector2>();

    Vector2 MousePos;

    void Awake()
    {
        // Crea a los nodos de nuestro grafo
        // Nótese que las posiciones se corresponden con los
        // valores de (i, j) de los ciclos for
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Vector2 newNodePosition = new Vector2(i, j);
                GameObject newNode = Instantiate(nodePrefab, this.transform);
                newNode.transform.position = newNodePosition;
                nodes.Add(newNode);
                nodePositions.Add(newNodePosition);

                // El número 50 controla la probabilidad de que se genere un obstaculo
                bool createObstacle = Random.Range(1, 101) < 50;

                if (hasObstacles && createObstacle)
                {
                    nodes.Remove(newNode);
                    nodePositions.Remove(newNodePosition);
                    Destroy(newNode);
                }

            }
        }
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //        RemoveNode();
    //}
    // Dada la posición de un nodo, ENTREGA una lista con las posiciones de sus respectivos vecinos
    public List<Vector2> NeighbourPositions(Vector2 nodePosition)
    {
        List<Vector2> directions = new List<Vector2> {Vector2.right,
                                                      Vector2.up,
                                                      Vector2.left,
                                                      Vector2.down };

        List<Vector2> list = new List<Vector2>();

        foreach (Vector2 direction in directions)
        {
            Vector2 neighbourPosition = nodePosition + direction;
            if (nodePositions.Contains(neighbourPosition))
                list.Add(neighbourPosition);
        }

        return list;
    }
    // Ilumina el nodo en la posición nodePosition
    public void LightNode(Vector2 nodePosition)
    {
        int index = nodePositions.IndexOf(nodePosition);
        nodes[index].GetComponent<SpriteRenderer>().color = Color.white;
    }

    //void RemoveNode()
    //{
    //    mouse
    // MousePos = Camera.main.ScreenPointToRay();  
    //}
}
