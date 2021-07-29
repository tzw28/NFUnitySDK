using NFrame;
using NFSDK;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class NFModelInput : MonoBehaviour
{
    private NFUIModule mUIModule;
    private NFLoginModule mLoginModule;
    private NFIKernelModule mKernelModule;
    private NFNetModule mNetModule;
    private NFSceneModule mSceneModule;

    private NFUIJoystick mJoystick;

    private GameObject mMainCamera;

    public bool mbInputEnable = false;
    
    private JSONNode mModelStrucure;
    private List<int> mCurrentSelectedParts;
    private int mCurrentHoverPart;
 
    public void SetInputEnable(bool bEnable)
    {
        mbInputEnable = bEnable;
    }

    void Start()
    {
        mUIModule = NFRoot.Instance().GetPluginManager().FindModule<NFUIModule>();
        mLoginModule = NFRoot.Instance().GetPluginManager().FindModule<NFLoginModule>();
        mNetModule = NFRoot.Instance().GetPluginManager().FindModule<NFNetModule>();
        mSceneModule = NFRoot.Instance().GetPluginManager().FindModule<NFSceneModule>();

        mKernelModule = NFRoot.Instance().GetPluginManager().FindModule<NFIKernelModule>();

        mMainCamera = GameObject.Find("Main Camera");
        GetModelInfoList();
        // mSceneModule.SetCurrentModel(-1);
    }

    void LoadTextureEvent(string raw)
    {
        Debug.Log("LoadTextureEvent");
        mNetModule.RequireModelRaw(mLoginModule.mRoleID);
    }

    public void LoadModelEvent(int target, int level, string structureContent)
    {
        // mNetModule.RequireModelTarget(mLoginModule.mRoleID, target, level);

        // RequireModelTargetHttp(target, level);

        mModelStrucure = JSON.Parse(structureContent);
        foreach (var p in mModelStrucure["parts"])
        {
            string partName = p.Value["name"];
            LoadModelPart(target, partName);
        }
        mCurrentSelectedParts = new List<int>();
        mCurrentHoverPart = -1;
    }

    void SwitchModelEvent()
    {
        int target = mSceneModule.GetCurrentModelIndex();
        target = (target + 1) % mSceneModule.CountModelNumber();
        mNetModule.RequireModelSwitch(mLoginModule.mRoleID, target);
    }

    void ViewSyncEvent()
    {
        NFModelSync sync = GetComponent<NFModelSync>();
        sync.mViewSyncOn = sync.mViewSyncOn ? false : true;
        //Vector3 angles = mMainCamera.transform.eulerAngles;
        // angles.x = angles.x >= 180f ? angles.x - 360f : angles.x;
        //angles.y = angles.y >= 180f ? angles.y - 360f : angles.y;
        //mNetModule.RequireViewSync(mLoginModule.mRoleID, mMainCamera.transform.position, angles,
        // gameObject.transform.position, gameObject.transform.eulerAngles, gameObject.transform.localScale);
    }

    public void SelectPart(int id)
    {
        mCurrentSelectedParts.Add(id);
        SelectionSyncEvent();
    }

    public void UnselectPart(int id)
    {
        mCurrentSelectedParts.Remove(id);
        SelectionSyncEvent();
    }

    public void HoverPart(int id)
    {
        mCurrentHoverPart = id;
        SelectionSyncEvent();
    }

    public void UnhoverPart(int id)
    {
        mCurrentHoverPart = -1;
        SelectionSyncEvent();
    }

    public void SelectionSyncEvent()
    {
        NFModelSync sync = GetComponent<NFModelSync>();
        sync.ReportSelection(mCurrentHoverPart, mCurrentSelectedParts);
    }

    void GetModelInfoList()
    {
        mNetModule.RequireModelList(mLoginModule.mRoleID);
    }

    void JoyOnKeyPressModelLoadHandler(string raw)
    {
        LoadTextureEvent(raw);

        fLastEventTime = Time.time;
        fLastEventRaw = raw;
    }

    void JoyOnKeyPressModelSwitchHandler()
    {
        SwitchModelEvent();

        fLastEventTime = Time.time;
    }

    void JoyOnKeyPressViewSyncHandler()
    {
        ViewSyncEvent();

        fLastEventTime = Time.time;
    }

    void JoyOnKeyPressGetModelListHandler()
    {
        GetModelInfoList();

        fLastEventTime = Time.time;
    }

    private string UnGZipHttpData(Byte[] data)
    {
        string buf = "";//声明空字符串用来接收解压缩后的数据
        Stream ff = null;
        ff = new GZipStream(new MemoryStream(data), CompressionMode.Decompress);
        using (StreamReader reader = new StreamReader(ff, Encoding.UTF8))
        {
            buf = reader.ReadToEnd();
        }
        return buf;
    }

    // 获取模型数据Http
    private IEnumerator SendHttpRequest(string url, string data)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            if (!string.IsNullOrEmpty(webRequest.error))
            {
                Debug.LogError(webRequest.error);
            }
            data = UnGZipHttpData(webRequest.downloadHandler.data);
            // string data = webRequest.downloadHandler.text;
        }
    }

    public IEnumerator RequireModelTargetHttp(int tar, int level)
    {
        string url = "http://" + mNetModule.strGameServerIP + ":9001/model";
        url += "?target=" + tar.ToString() + "&level=" + level.ToString();
        string data = "";
        // StartCoroutine(SendModelRequest(url));
        yield break;
        var resp = JSON.Parse(data);
        string msg = resp["msg"].Value;
        byte[] temp = Convert.FromBase64String(msg);
        msg = Encoding.UTF8.GetString(temp);
        string raw = resp["sync_unit"]["raw"].Value;
        temp = Convert.FromBase64String(raw);
        raw = Encoding.UTF8.GetString(temp);

        System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
        long timeStamp = (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差秒数
        Debug.Log("receive msg " + timeStamp);
        // NFMsg.MsgBase xMsg = NFMsg.MsgBase.Parser.ParseFrom(System.Text.Encoding.Unicode.GetBytes(stream));
        // NFMsg.ReqAckModelTarget xData = NFMsg.ReqAckModelTarget.Parser.ParseFrom(xMsg.MsgData);
        // Debug.Log(xData.Msg.ToStringUtf8());
        // string[] msgs = xData.Msg.ToStringUtf8().Split(' ');
        string[] msgs = msg.Split(' ');
        List<long> times = new List<long>();
        times.Add(long.Parse(msgs[1]) - long.Parse(msgs[0]));
        times.Add(long.Parse(msgs[2]) - long.Parse(msgs[1]));
        times.Add(timeStamp - long.Parse(msgs[2]));
        // if (xData.SyncUnit.Raw == null)
        if (raw == null)
        {
            Debug.Log("model ack null");
        }
        GameObject xModelObject = mSceneModule.GetModelObject();
        NFModelControl modelCtl = xModelObject.GetComponent<NFModelControl>();
        // string raw = xData.SyncUnit.Raw.ToStringUtf8();
        // System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        // stopwatch.Start(); //  开始监视代码运行时间

        DateTime beforDT = System.DateTime.Now;
        Debug.Log(String.Format("开始{0}ms.", beforDT.Millisecond));
        modelCtl.LoadTextureFromRaw(raw, ModelRawType.FORMATTED);
        // stopwatch.Stop(); //  停止监视
        // System.TimeSpan timespan = stopwatch.Elapsed;
        // double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
        DateTime afterDT = System.DateTime.Now;
        Debug.Log(String.Format("结束{0}ms.", afterDT));
        TimeSpan ts = afterDT.Subtract(beforDT);
        Debug.Log(String.Format("总共花费{0}ms.", ts.TotalMilliseconds));
        times.Add((long)ts.TotalMilliseconds);
        // Debug.Log("Recalculate Normals " + milliseconds);
        NFUIMain mainUI = mUIModule.GetUI<NFUIMain>();

        mainUI.SetMessage(0, "读取模型: " + times[0].ToString() + " ms");
        mainUI.SetMessage(1, "网格转换: " + times[1].ToString() + " ms");
        mainUI.SetMessage(2, "网络传输: " + times[2].ToString() + " ms");
        mainUI.SetMessage(3, "模型加载: " + times[3].ToString() + " ms");
    }

    // 获取模型部分数据Http
    private IEnumerator SendHttpRequestForPart(string url, string partName)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            if (!string.IsNullOrEmpty(webRequest.error))
            {
                Debug.LogError(webRequest.error);
            }
            string data = UnGZipHttpData(webRequest.downloadHandler.data);
            var resp = JSON.Parse(data);
            string msg = resp["msg"].Value;
            string raw = resp["sync_unit"]["raw"].Value;
            byte[] temp = Convert.FromBase64String(raw);
            raw = Encoding.UTF8.GetString(temp);
            if (raw == null)
            {
                Debug.Log("model ack null");
            }
            GameObject xModelObject = mSceneModule.GetModelObject();
            NFModelControl modelCtl = xModelObject.GetComponent<NFModelControl>();
            modelCtl.LoadPartFromRaw(raw, partName);
            modelCtl.UnifyPartScales();

            NFUIMain mainUI = mUIModule.GetUI<NFUIMain>();
            mainUI.SetMessage(0, "读取模型: " + "-1 ms");
            mainUI.SetMessage(1, "网格转换: " + "-1 ms");
            mainUI.SetMessage(2, "网络传输: " + "-1 ms");
            mainUI.SetMessage(3, "模型加载: " + "-1 ms");
            // string data = webRequest.downloadHandler.text;
        }
    }
    private void LoadModelPart(int target, string part)
    {
        string url = "http://" + mNetModule.strGameServerIP + ":9001/model/part";
        url += "?target=" + target.ToString() + "&part=" + part;
        StartCoroutine(SendHttpRequestForPart(url, part));
    }


    float fLastEventTime = 0f;
    string fLastEventRaw;
    public void FixedUpdate()
    {
        if (mJoystick == null)
        {
            mJoystick = mUIModule.GetUI<NFUIJoystick>();

            if (mJoystick)
            {
                mJoystick.SetKeyPressViewSyncHandler(JoyOnKeyPressViewSyncHandler);
                mJoystick.SetKeyPressModelLoadHandler(JoyOnKeyPressModelLoadHandler);
                mJoystick.SetKeyPressModelSwitchHandler(JoyOnKeyPressModelSwitchHandler);
                mJoystick.SetKeyPressGetModelListHandler(JoyOnKeyPressGetModelListHandler);
            }
        }

        if (fLastEventTime > 0f && Time.time > (fLastEventTime + 0.1f))
        {
            fLastEventTime = Time.time;
        }
    }

    void OnDestroy()
    {
    }
}
