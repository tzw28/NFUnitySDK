using System;
using System.Collections.Generic;
using UnityEngine;

public class NFModelSyncBuffer : MonoBehaviour
{
    protected List<Keyframe> _keyframes = new List<Keyframe>();
    //pool manager
    public class Keyframe
    {
        public int InterpolationTime;
        public string raw;
    }

    public Keyframe NextKeyframe()
    {
        if (_keyframes.Count > 0)
        {
            Keyframe keyframe = _keyframes[0];
            _keyframes.RemoveAt(0);
            return keyframe;
        }

        return null;
    }

    public Keyframe LastKeyframe()
    {
        if (_keyframes.Count > 0)
        {
            Keyframe keyframe = _keyframes[_keyframes.Count - 1];
            _keyframes.Clear();

            return keyframe;
        }

        return null;
    }

    public virtual void AddKeyframe(Keyframe keyframe)
    {
        _keyframes.Add(keyframe);
    }

    public virtual void AddKeyframe(string newRaw)
    {
        // prevent long first frame if some keyframes was skipped before the first frame

        var keyframe = new Keyframe
        {
            raw = newRaw
        };

        _keyframes.Add(keyframe);
    }


    public virtual void Clear()
    {
        _keyframes.Clear();
    }

    public int Size()
    {
        return _keyframes.Count;
    }
}
