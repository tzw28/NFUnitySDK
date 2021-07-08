using NFrame;
using NFSDK;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NFModelControl : MonoBehaviour
{
    private string mRaw;

    private List<Vector3> mVertices;
    private List<Vector2> mUvs;
    private List<int> mTriangles;
    private int mTriangleNumber = 0;
    private float mModelViewSize = 5.0f;

    private NFLoginModule mLoginModule;

    private GameObject mMainCamera;
    private GameObject mHint;

    // Start is called before the first frame update
    void Start()
    {
        mVertices = new List<Vector3>();
        mUvs = new List<Vector2>();
        mTriangles = new List<int>();

        mLoginModule = NFRoot.Instance().GetPluginManager().FindModule<NFLoginModule>();
        mMainCamera = GameObject.Find("Main Camera");
    }

    public void ViewSyncFromSource(NFGUID sourceID, string sourceType, Vector3 cameraPos, Vector3 cameraRot,
                                   Vector3 modelPos, Vector3 modelRot, Vector3 modelScale)
    {
        if (mLoginModule.mRoleID == sourceID)
        {
            return;
        }
        if (sourceType == "PC")
        {
            ViewSyncFromPC(cameraPos, cameraRot, modelPos, modelRot, modelScale);
        }
        else if (sourceType == "Hololens")
        {
            ViewSyncFromHololens(cameraPos, cameraRot, modelPos, modelRot, modelScale);
        }
    }

    private void ViewSyncFromPC(Vector3 cameraPos, Vector3 cameraRot,
        Vector3 modelPos, Vector3 modelRot, Vector3 modelScale)
    {
        NFHeroCameraFollow controller = mMainCamera.GetComponent<NFHeroCameraFollow>();
        controller.MoveTo(cameraPos, cameraRot);
        Vector3 newModelPos = new Vector3(modelPos.x, modelPos.y, modelPos.z);
        Vector3 newModelRot = new Vector3(modelRot.x, modelRot.y, modelRot.z);
        transform.position = newModelPos;
        transform.eulerAngles = newModelRot;
    }

    private void ViewSyncFromHololens(Vector3 cameraPos, Vector3 cameraRot,
        Vector3 modelPos, Vector3 modelRot, Vector3 modelScale)
    {
        Vector3 newCameraPos = new Vector3(
            cameraPos.x, cameraPos.y, cameraPos.z
            );
        Vector3 newCameraRot = new Vector3(
            cameraRot.x,
            cameraRot.y,
            cameraRot.z);
        NFHeroCameraFollow controller = mMainCamera.GetComponent<NFHeroCameraFollow>();
        controller.MoveTo(newCameraPos, newCameraRot);

        Vector3 newModelPos = new Vector3(modelPos.x, modelPos.y, modelPos.z);
        Vector3 newModelRot = new Vector3(modelRot.x, modelRot.y, modelRot.z);
        transform.position = newModelPos;
        transform.eulerAngles = newModelRot;
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
        float newScaleX = mModelViewSize / m.bounds.size.x;
        float newScaleY = mModelViewSize / m.bounds.size.y;
        float newScaleZ = mModelViewSize / m.bounds.size.z;
        float newScale = Math.Min(Math.Min(newScaleX, newScaleY), newScaleZ);
        gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);
        mr.material = new Material(Resources.Load<Material>("Utility/Materials/EthanGrey"));

    }


    void LoadStlAscii()
    {

        StreamWriter sw;
        FileInfo t = new FileInfo("D://UnityProj//temp.stl");
        if (!t.Exists)
        {
            sw = t.CreateText();
        }
        else
        {
            sw = t.CreateText();
        }
        sw.WriteLine(mRaw);
        sw.Close();
        sw.Dispose();

        mVertices.Clear();
        mTriangles.Clear();
        mTriangleNumber = 0;
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
            return dData.ToString();
        }
        return strData;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
