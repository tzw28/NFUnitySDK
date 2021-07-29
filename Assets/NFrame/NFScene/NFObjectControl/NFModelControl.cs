using NFrame;
using NFSDK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public enum ModelRawType
{
    STL_ASCII,
    FORMATTED
}

public class NFModelControl : MonoBehaviour
{
    private string mRaw;

    private List<Vector3> mVertices;
    private List<Vector2> mUvs;
    private List<int> mTriangles;
    private int mTriangleNumber = 0;
    private float mModelViewSize = 8.0f;

    private NFLoginModule mLoginModule;

    private GameObject mMainCamera;
    private GameObject mHint;

    private List<GameObject> mParts;

    // Start is called before the first frame update
    void Start()
    {
        mVertices = new List<Vector3>();
        mUvs = new List<Vector2>();
        mTriangles = new List<int>();

        mLoginModule = NFRoot.Instance().GetPluginManager().FindModule<NFLoginModule>();
        mMainCamera = GameObject.Find("Main Camera");
        mParts = new List<GameObject>();
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

    public void LoadPartFromRaw(string raw, string partName)
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        int triangleNumber = 0;
        LoadFormattedModelPart(ref raw, vertices, triangles, ref triangleNumber);

        Mesh m = new Mesh();
        m.vertices = vertices.ToArray();
        m.triangles = triangles.ToArray();
        m.RecalculateBounds();
        m.RecalculateNormals();

        GameObject partObject = new GameObject(partName);
        partObject.transform.parent = gameObject.transform;
        MeshFilter mf = partObject.AddComponent<MeshFilter>();
        mf.mesh = m;
        float newScaleX = mModelViewSize / m.bounds.size.x;
        float newScaleY = mModelViewSize / m.bounds.size.y;
        float newScaleZ = mModelViewSize / m.bounds.size.z;
        float newScale = Math.Min(Math.Min(newScaleX, newScaleY), newScaleZ);
        partObject.transform.localScale = new Vector3(newScale, newScale, newScale);
        MeshRenderer mr = partObject.AddComponent<MeshRenderer>();
        mr.material = new Material(Resources.Load<Material>("Utility/Materials/EthanGrey"));
        partObject.transform.localPosition = new Vector3(0, 0, 0);

        var partCtl = partObject.AddComponent<NFModelPartControl>();
        partCtl.SetPartId(mParts.Count());
        partObject.AddComponent<MeshCollider>();
        var outline = partObject.AddComponent<Outline>();
        outline.enabled = false;
        mParts.Add(partObject);
    }

    public void UnifyPartScales()
    {
        float minScale = mModelViewSize;
        foreach (var p in mParts)
        {
            float s = p.transform.localScale.x;
            if (minScale > s)
                minScale = s;
        }
        foreach (var p in mParts)
        {
            p.transform.localScale = new Vector3(
                minScale, minScale, minScale
            );
        }

    }

    public void SelectionSync(NFGUID playID, int hovered, List<int> selected)
    {
        if (playID == mLoginModule.mRoleID)
            return;
        for (int i = 0; i < mParts.Count(); i++)
        {
            if (hovered == i)
                mParts[i].GetComponent<NFModelPartControl>().SetSharedHover(true);
            else
                mParts[i].GetComponent<NFModelPartControl>().SetSharedHover(false);
            if (selected.Contains(i))
                mParts[i].GetComponent<NFModelPartControl>().SetSharedSelect(true);
            else
                mParts[i].GetComponent<NFModelPartControl>().SetSharedSelect(false);
        }
    }

    public void LoadTextureFromRaw(string raw, ModelRawType rawType)
    {
        mRaw = raw;
        if (rawType == ModelRawType.FORMATTED)
        {
            LoadFormattedModel();
        } 
        else if (rawType == ModelRawType.STL_ASCII)
        {

            LoadStlAscii();
        }
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
        m.RecalculateBounds();
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
        /*
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
        */

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

    
    private void LoadFormattedModel()
    {
        mVertices.Clear();
        mTriangles.Clear();
        mTriangleNumber = 0;
        int verticeNumber;
        string[] lines = mRaw.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] strs = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        verticeNumber = int.Parse(strs[0]);
        mTriangleNumber = int.Parse(strs[1]);
        for (int i = 1; i < verticeNumber + 1; i++)
        {
            strs = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Vector3 vec = new Vector3(
                float.Parse(ChangeDataToD(strs[0])),
                float.Parse(ChangeDataToD(strs[1])),
                float.Parse(ChangeDataToD(strs[2]))
            );
            mVertices.Add(vec);
        }
        strs = lines[verticeNumber + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < mTriangleNumber * 3; i++)
        {
            mTriangles.Add(int.Parse(strs[i]));
        }
        // TestRead();
    } 

    private void LoadFormattedModelPart(ref string raw, List<Vector3> vertices, List<int> triangles, ref int triangleNumber)
    {
        vertices.Clear();
        triangles.Clear();
        triangleNumber = 0;
        int verticeNumber;
        string[] lines = raw.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        string[] strs = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        verticeNumber = int.Parse(strs[0]);
        triangleNumber = int.Parse(strs[1]);
        for (int i = 1; i < verticeNumber + 1; i++)
        {
            strs = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Vector3 vec = new Vector3(
                float.Parse(ChangeDataToD(strs[0])),
                float.Parse(ChangeDataToD(strs[1])),
                float.Parse(ChangeDataToD(strs[2]))
            );
            vertices.Add(vec);
        }
        strs = lines[verticeNumber + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < triangleNumber * 3; i++)
        {
            triangles.Add(int.Parse(strs[i]));
        }
        // TestRead();
    }

    private Vector3 parseVerticeLine(string line)
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
