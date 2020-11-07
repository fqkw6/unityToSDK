using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] vertices;
    public int[] triangle;

    // Use this for initialization
    void Start()
    {
        //实例化网格
        mesh = new Mesh();
        //分配顶点
        mesh.vertices = vertices;
        //分配三角形顶点的索引
        mesh.triangles = triangle;
        //把预制好的三角形传给对应的组件
        GetComponent<MeshFilter>().mesh = mesh;
    }
}
