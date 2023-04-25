﻿/****************************************************************************
 * Copyright (c) 2016 - 2023 liangxiegame UNDER MIT License
 * 
 * http://qframework.cn
 * https://github.com/liangxiegame/QFramework
 * https://gitee.com/liangxiegame/QFramework
 ****************************************************************************/

using System;
using UnityEngine;

namespace QFramework
{
    public class Lerp : IAction
    {
        private static readonly SimpleObjectPool<Lerp> mPool =
            
            new SimpleObjectPool<Lerp>(() => new Lerp(), null, 10);

        public float A;
        public float B;
        public float Duration;
        public Action<float> OnLerp;
        public Action OnLerpFinish;

        private float mCurrentTime = 0.0f;

        public static Lerp Allocate(float a, float b, float duration, Action<float> onLerp = null,Action onLerpFinish = null)
        {
            var retNode = mPool.Allocate();
            retNode.ActionID = ActionKit.ID_GENERATOR++;
            retNode.Deinited = false;
            retNode.Reset();
            retNode.A = a;
            retNode.B = b;
            retNode.Duration = duration;
            retNode.OnLerp = onLerp;
            retNode.OnLerpFinish = onLerpFinish;
            return retNode;
        }

        public ulong ActionID { get; set; }

        public bool Paused { get; set; }
        public void Reset()
        {
            Status = ActionStatus.NotStart;
            mCurrentTime = 0.0f;
        }

        public void Deinit()
        {
            if (!Deinited)
            {
                Deinited = true;
                OnLerp = null;
                OnLerpFinish = null;
                mPool.Recycle(this);
            }
        }

        public ActionStatus Status { get; set; }
        public void OnStart()
        {
            mCurrentTime = 0.0f;
            OnLerp?.Invoke(Mathf.Lerp(A, B, 0));

        }

        public void OnExecute(float dt)
        {
            mCurrentTime += dt;
            if (mCurrentTime < Duration)
            {
                OnLerp?.Invoke(Mathf.Lerp(A, B, mCurrentTime / Duration));
            }
            else
            {
                this.Finish();
            }
        }

        public void OnFinish()
        {
            OnLerp?.Invoke(Mathf.Lerp(A, B, 1.0f));
            OnLerpFinish?.Invoke();
        }

        public bool Deinited { get; set; }
    }
    
    public static class LerpExtension
    {
        public static ISequence Lerp(this ISequence self, float a,float b,float duration,Action<float> onLerp = null,Action onLerpFinish = null)
        {
            return self.Append(QFramework.Lerp.Allocate(a,b,duration,onLerp,onLerpFinish));
        }
        
    }
}