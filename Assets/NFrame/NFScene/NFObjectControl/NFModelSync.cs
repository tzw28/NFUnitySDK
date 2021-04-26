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

    private float SYNC_TIME = 0.05f;

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
        // ReportPos();

        NFModelSyncBuffer.Keyframe keyframe;
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
    void ReportPos()
    {
        /*
        if (lastReportTime <= 0f)
        {
            mNetModule.RequireMove(mLoginModule.mRoleID, (int)NFAnimaStateType.NONE, mxHeroMotor.transform.position);
        }

        if (Time.time > (SYNC_TIME + lastReportTime))
        {
            lastReportTime = Time.time;

            if (mLoginModule.mRoleID == mxBodyIdent.GetObjectID())
            {
                if (lastPos != mxHeroMotor.transform.position)
                {
                    if (mxHeroMotor.moveToPos != Vector3.zero)
                    {
                        //是玩家自己移动
                        lastPos = mxHeroMotor.moveToPos;
                        canFixFrame = false;
                    }
                    else
                    {
                        //是其他技能导致的唯一，比如屠夫的钩子那种
                        lastPos = mxHeroMotor.transform.position;
                        canFixFrame = false;
                    }

                    mNetModule.RequireMove(mLoginModule.mRoleID, (int)mAnimaStateMachine.CurState(), lastPos);
                }
                else
                {
                    //fix last pos
                    if (canFixFrame)
                    {
                        canFixFrame = false;
                        mNetModule.RequireMove(mLoginModule.mRoleID, (int)mAnimaStateMachine.CurState(), lastPos);
                    }
                }
            }
        }
        */
    }

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
    }

    public void Clear()
    {
        if (mxSyncBuffer)
        {
            mxSyncBuffer.Clear();
        }
    }
}
