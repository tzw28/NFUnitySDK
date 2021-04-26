using NFrame;
using NFSDK;
using UnityEngine;

public class NFModelInput : MonoBehaviour
{
    private NFUIModule mUIModule;
    private NFLoginModule mLoginModule;
    private NFIKernelModule mKernelModule;
    private NFNetModule mNetModule;

    private NFUIJoystick mJoystick;


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

        mKernelModule = NFRoot.Instance().GetPluginManager().FindModule<NFIKernelModule>();
    }

    void LoadTextureEvent(string raw)
    {
        Debug.Log("LoadTextureEvent");
        mNetModule.RequireModelRaw(mLoginModule.mRoleID);
    }

    void JoyOnKeyPressModelLoadHandler(string raw)
    {
        LoadTextureEvent(raw);

        fLastEventTime = Time.time;
        fLastEventRaw = raw;
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
                mJoystick.SetKeyPressModelLoadHandler(JoyOnKeyPressModelLoadHandler);
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
