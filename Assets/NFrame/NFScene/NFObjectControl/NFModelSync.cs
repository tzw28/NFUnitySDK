using NFrame;
using NFSDK;
using UnityEngine;

public class NFModelSync : MonoBehaviour
{
    private NFModelSyncBuffer mxSyncBuffer;

    private NFNetModule mNetModule;
    private NFLoginModule mLoginModule;
    private NFHelpModule mHelpModule;
    private NFIKernelModule mKernelModule;

    private float SYNC_TIME = 0.02f;
    public bool sync_on = false;

    private GameObject mMainCamera;

    void Awake()
    {

    }

    private void Start()
    {
        mxSyncBuffer = GetComponent<NFModelSyncBuffer>();

        mNetModule = NFRoot.Instance().GetPluginManager().FindModule<NFNetModule>();
        mLoginModule = NFRoot.Instance().GetPluginManager().FindModule<NFLoginModule>();
        mHelpModule = NFRoot.Instance().GetPluginManager().FindModule<NFHelpModule>();
        mKernelModule = NFRoot.Instance().GetPluginManager().FindModule<NFIKernelModule>();
        mMainCamera = GameObject.Find("Main Camera");
    }

    bool CheckState()
    {
        return true;
    }

    private bool MeetGoalCallBack()
    {
        if (mxSyncBuffer.Size() > 0)
        {
            FixedUpdate();
            return true;
        }

        return false;
    }

    float moveSpeed = 2.0f;
    int lastInterpolationTime = 0;
    private void FixedUpdate()
    {
        ReportView();

        NFModelSyncBuffer.Keyframe keyframe;
        if (mxSyncBuffer == null)
        {
            gameObject.AddComponent<NFModelSyncBuffer>();
            mxSyncBuffer = gameObject.GetComponent<NFModelSyncBuffer>();
        }
        if (mxSyncBuffer.Size() > 1)
        {
            keyframe = mxSyncBuffer.LastKeyframe();
        }
        else
        {
            keyframe = mxSyncBuffer.NextKeyframe();
        }

        if (keyframe != null)
        {
            // update positon or moter

            lastInterpolationTime = keyframe.InterpolationTime;
        }
    }

    Vector3 lastPos = Vector3.zero;
    float lastReportTime = 0f;
    bool canFixFrame = true;
    void ReportView()
    {
        if (!sync_on)
        {
            return;
        }
        Vector3 angles = mMainCamera.transform.eulerAngles;
        if (lastReportTime <= 0f)
        {
            mNetModule.RequireViewSync(mLoginModule.mRoleID, mMainCamera.transform.position, angles,
                gameObject.transform.position, gameObject.transform.eulerAngles, gameObject.transform.localScale);
        }
        mNetModule.RequireViewSync(mLoginModule.mRoleID, mMainCamera.transform.position, angles,
            gameObject.transform.position, gameObject.transform.eulerAngles, gameObject.transform.localScale);

        if (Time.time > (SYNC_TIME + lastReportTime))
        {
            lastReportTime = Time.time;
            mNetModule.RequireViewSync(mLoginModule.mRoleID, mMainCamera.transform.position, angles,
                gameObject.transform.position, gameObject.transform.eulerAngles, gameObject.transform.localScale);
        }
    }
    /*
    public void AddSyncData(int sequence, NFMsg.PosSyncUnit syncUnit)
    {
        Clear();

        Vector3 pos = new Vector3();
        Vector3 dir = new Vector3();

        if (syncUnit.Pos != null)
        {
            pos.x = syncUnit.Pos.X;
            pos.y = syncUnit.Pos.Y;
            pos.z = syncUnit.Pos.Z;
        }

        if (syncUnit.Orientation != null)
        {
            dir.x = syncUnit.Orientation.X;
            dir.y = syncUnit.Orientation.Y;
            dir.z = syncUnit.Orientation.Z;
        }

        var keyframe = new NFModelSyncBuffer.Keyframe();
        keyframe.InterpolationTime = sequence;

        if (mxSyncBuffer)
        {
            Debug.Log(keyframe.InterpolationTime + " move " + this.transform.position.ToString() + " TO " + keyframe.raw);

            mxSyncBuffer.AddKeyframe(keyframe);
        }
    }*/

    public void Clear()
    {
        if (mxSyncBuffer)
        {
            mxSyncBuffer.Clear();
        }
    }
}
