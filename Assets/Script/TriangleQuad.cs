using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class TriangleQuad : MonoBehaviour
{
    public float R;
    public float G;
    public float B;
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    float dis = -0.5f;
    Color[] colors;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        setMeshData();
        createProceduralMesh();
    }

    void setMeshData()
    {
        vertices = new Vector3[] {
        new Vector3(0+dis, 0, 0+dis),
        new Vector3(0.5f+dis , 0, Mathf.Sqrt(3.0f) / 2.0f+dis),
        new Vector3(1+dis, 0, 0+dis),
        new Vector3(0.5f + dis, 0, 0.5f + dis)
        };

        colors = new Color[] {
        new Color(R, G, B, 0.3f),
        new Color(R, G, B, 1f),
        new Color(R, G, B, 0.3f),
        new Color(1f, 1f, 1f, 1f)
        };

        triangles = new int[] {
            1, 3, 0, // First Triangle
            1, 2, 3  // Second Triangle
        };
    }

    void createProceduralMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;
        mesh.RecalculateNormals();
    }
}