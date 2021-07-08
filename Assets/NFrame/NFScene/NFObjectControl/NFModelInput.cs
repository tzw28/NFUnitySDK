using NFrame;
using NFSDK;
using UnityEngine;

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

    public void LoadModelEvent(int target, int level)
    {
        mNetModule.RequireModelTarget(mLoginModule.mRoleID, target, level);
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
        sync.sync_on = sync.sync_on ? false : true;
        //Vector3 angles = mMainCamera.transform.eulerAngles;
        // angles.x = angles.x >= 180f ? angles.x - 360f : angles.x;
        //angles.y = angles.y >= 180f ? angles.y - 360f : angles.y;
        //mNetModule.RequireViewSync(mLoginModule.mRoleID, mMainCamera.transform.position, angles,
        // gameObject.transform.position, gameObject.transform.eulerAngles, gameObject.transform.localScale);
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
