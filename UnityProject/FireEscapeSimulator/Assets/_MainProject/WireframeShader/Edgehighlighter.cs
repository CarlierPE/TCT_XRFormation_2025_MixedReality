using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class EdgeHighlighter : MonoBehaviour
{
    public Material edgeMaterial;
    public float edgeWidth = 0.02f;
    public Color edgeColor = Color.green;
    public bool worldPositionStays = false;

    private class EdgeLine
    {
        public LineRenderer line;
        public Vector3 localA, localB;
    }

    List<EdgeLine> edgesList = new List<EdgeLine>();

    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        Vector3[] verts = mesh.vertices;
        int[,] edges = {
            {0,1},{1,3},{2,0},{3,2},
            {4,5},{5,7},{6,4},{7,6},
            {3,5},{1,7},{6,0},{4,2}
        };

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            int ia = edges[i, 0], ib = edges[i, 1];

            GameObject go = new GameObject($"Edge_{ia}_{ib}");
            go.transform.SetParent(transform, worldPositionStays);

            LineRenderer lr = go.AddComponent<LineRenderer>();
            lr.positionCount = 2;
            lr.startWidth = lr.endWidth = edgeWidth;
            var mat = new Material(edgeMaterial) { color = edgeColor };
            lr.material = mat;
            lr.startColor = lr.endColor = edgeColor;
            lr.useWorldSpace = true;
            lr.alignment = LineAlignment.View;

            edgesList.Add(new EdgeLine
            {
                line = lr,
                localA = verts[ia],
                localB = verts[ib]
            });
        }
    }

    void Update()
    {
        foreach (var e in edgesList)
        {
            Vector3 worldA = transform.TransformPoint(e.localA);
            Vector3 worldB = transform.TransformPoint(e.localB);
            e.line.SetPosition(0, worldA);
            e.line.SetPosition(1, worldB);
        }
    }
}