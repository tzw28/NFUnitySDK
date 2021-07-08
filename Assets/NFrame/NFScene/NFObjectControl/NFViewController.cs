using UnityEngine;

public class NFViewController : MonoBehaviour
{
    Vector3 mTargetPos;
    Vector3 mTargetRot;
    bool mMoveTag;

    public void SetTarget(Vector3 targetPos, Vector3 targetRot)
    {
        mTargetPos = targetPos;
        mTargetRot = targetRot;
        mMoveTag = true;
    }

    void Move()
    {
        mMoveTag = false;
        transform.position = mTargetPos;
        transform.eulerAngles = mTargetRot;
    }

    // Start is called before the first frame update
    void Start()
    {
        mMoveTag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mMoveTag)
        {
            Move();
        }
    }
}
