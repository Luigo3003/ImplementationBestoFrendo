using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;

public class InstantingNodes : MonoBehaviour
{
    private SimpleGraph simpGraph;
    public GameObject SimpGPrefab;
    public TMP_Text NodeTag;
    private Vector3 GraphPos = new Vector3(400f, 500f, 0f);
    public int SizeX = 0;
    public int SizeY = 0;
    public int Index = 0;
    void Start()
    {
        //simpGraph = new SimpleGraph(SizeX, SizeY);
        //foreach (Vector3 NodeTemp in simpGraph.nodes)
        //{
        //    GameObject nodeClone = Instantiate(SimpGPrefab, GraphPos, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);

        //}

    }
    void Update()
    {
    }
}
  
