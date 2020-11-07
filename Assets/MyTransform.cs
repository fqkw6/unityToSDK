using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTransform : MonoBehaviour
{
    public Matrix4x4 matrix;

    // Use this for initialization
    void Start()
    {
        matrix.SetTRS(transform.position, transform.rotation, transform.localScale);
        //MyTranslate();
        // MySclae();
        MyRotation();
    }
    public Vector4 v;
    void MyTranslate()
    {
        v = new Vector4(transform.position.x, transform.position.y,
            transform.position.z, 1);
        matrix = Matrix4x4.identity;
        matrix.m03 = 1;
        matrix.m13 = 2;
        matrix.m23 = 3;
        v = matrix * v;
        transform.position = new Vector3(v.x, v.y, v.z);

    }

    void MySclae()
    {
        v = new Vector4(transform.localScale.x, transform.localScale.y,
            transform.localScale.z, 1);
        matrix = Matrix4x4.identity;
        matrix.m00 = 1;
        matrix.m11 = 2;
        matrix.m22 = 3;
        v = matrix * v;
        transform.localScale = v;

    }


    public float angle;
    public enum Axle { X, Y, Z };
    public Axle axle;

    void MyRotation()
    {
        matrix = Matrix4x4.identity;
        if (axle == Axle.X)
        {
            matrix.m11 = Mathf.Cos(angle * Mathf.Deg2Rad);
            matrix.m12 = -Mathf.Sin(angle * Mathf.Deg2Rad);
            matrix.m21 = Mathf.Sin(angle * Mathf.Deg2Rad);
            matrix.m22 = Mathf.Cos(angle * Mathf.Deg2Rad);
        }
        if (axle == Axle.Y)
        {
            matrix.m00 = Mathf.Cos(angle * Mathf.Deg2Rad);
            matrix.m02 = Mathf.Sin(angle * Mathf.Deg2Rad);
            matrix.m20 = -Mathf.Sin(angle * Mathf.Deg2Rad);
            matrix.m22 = Mathf.Cos(angle * Mathf.Deg2Rad);
        }
        if (axle == Axle.Z)
        {
            matrix.m00 = Mathf.Cos(angle * Mathf.Deg2Rad);
            matrix.m01 = -Mathf.Sin(angle * Mathf.Deg2Rad);
            matrix.m10 = Mathf.Sin(angle * Mathf.Deg2Rad);
            matrix.m11 = Mathf.Cos(angle * Mathf.Deg2Rad);
        }

        float qw = Mathf.Sqrt(1f + matrix.m00 + matrix.m11
            + matrix.m22) / 2;
        float w = 4 * qw;
        float qx = (matrix.m21 - matrix.m12) / w;
        float qy = (matrix.m02 - matrix.m20) / w;
        float qz = (matrix.m10 - matrix.m01) / w;
        transform.rotation = new Quaternion(qx, qy, qz, qw);


    }
}
