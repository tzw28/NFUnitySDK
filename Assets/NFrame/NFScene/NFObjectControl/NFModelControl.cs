using System;
using System.Collections.Generic;
using UnityEngine;

public class NFModelControl : MonoBehaviour
{
    private string mRaw;

    private List<Vector3> mVertices;
    private List<Vector2> mUvs;
    private List<int> mTriangles;
    private int mTriangleNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        mVertices = new List<Vector3>();
        mUvs = new List<Vector2>();
        mTriangles = new List<int>();
    }

    public void LoadTextureFromRaw(string raw)
    {
        mRaw = raw;
        LoadStlAscii();
        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (!mf)
        {
            mf = gameObject.AddComponent<MeshFilter>();
        }
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        if (!mr)
        {
            mr = gameObject.AddComponent<MeshRenderer>();
        }

        Mesh m = new Mesh();
        m.vertices = mVertices.ToArray();
        m.triangles = mTriangles.ToArray();
        m.RecalculateNormals();

        mf.mesh = m;
        mr.material = new Material(Resources.Load<Material>("Utility/Materials/EthanGrey"));

    }


    void LoadStlAscii()
    {
        string[] lines = mRaw.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        string s = "";
        string[] strs;
        Vector3 facet;
        for (int i = 0; i < lines.Length; i++)
        {
            s = lines[i++].Trim();
            if (s.StartsWith("solid"))
            {
                continue;
            }
            if (s.StartsWith("facet"))
            {
                strs = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                facet = new Vector3(
                    float.Parse(ChangeDataToD(strs[2])),
                    float.Parse(ChangeDataToD(strs[3])),
                    float.Parse(ChangeDataToD(strs[4]))
                );
                s = lines[i++].Trim();
                if (s == "outer loop")
                {
                    do
                    {
                        s = lines[i++].Trim();
                        Vector3 vec1 = parseVerticeLine(s);
                        s = lines[i++].Trim();
                        Vector3 vec2 = parseVerticeLine(s);
                        s = lines[i++].Trim();
                        Vector3 vec3 = parseVerticeLine(s);
                        int tri1 = mVertices.FindIndex(delegate (Vector3 v) { return v == vec1; });
                        if (tri1 < 0)
                        {
                            mVertices.Add(vec1);
                            tri1 = mVertices.Count - 1;
                        }
                        int tri2 = mVertices.FindIndex(delegate (Vector3 v) { return v == vec2; });
                        if (tri2 < 0)
                        {
                            mVertices.Add(vec2);
                            tri2 = mVertices.Count - 1;
                        }
                        int tri3 = mVertices.FindIndex(delegate (Vector3 v) { return v == vec3; });
                        if (tri3 < 0)
                        {
                            mVertices.Add(vec3);
                            tri3 = mVertices.Count - 1;
                        }
                        mTriangles.Add(tri1);
                        mTriangles.Add(tri2);
                        mTriangles.Add(tri3);
                        /*
                        if (IsNormalMatch(vec1, vec2, vec3, facet))
                        {
                            mTriangles.Add(tri1);
                            mTriangles.Add(tri2);
                            mTriangles.Add(tri3);
                        }
                        else
                        {
                            triangles.Add(tri3);
                            triangles.Add(tri2);
                            triangles.Add(tri1);
                        }
                        */
                        mTriangleNumber += 1;
                    } while ((s = lines[i++].Trim()) != "endloop");
                }
            }
        }
    }


    Vector3 parseVerticeLine(string line)
    {
        string[] strs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Vector3 vec = new Vector3(
            float.Parse(ChangeDataToD(strs[1])),
            float.Parse(ChangeDataToD(strs[2])),
            float.Parse(ChangeDataToD(strs[3]))
        );
        return vec;
    }

    private string ChangeDataToD(string strData)
    {
        Decimal dData = 0.0M;
        if (strData.Contains("E") || strData.Contains("e"))
        {
            dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
        }
        return dData.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
