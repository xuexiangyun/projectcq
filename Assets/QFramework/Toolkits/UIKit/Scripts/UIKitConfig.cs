/****************************************************************************
 * Copyright (c) 2017 ~ 2020.1 liangxie
 * 
 * http://qframework.io
 * https://github.com/liangxiegame/QFramework
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using Codice.Client.BaseCommands;
using System.Linq;

namespace QFramework
{
    public class UIKitConfig
    {
        public virtual UIRoot Root
        {
            get { return UIRoot.Instance; }
        }
        

        public virtual void LoadPanelAsync(PanelSearchKeys panelSearchKeys, Action<IPanel> onPanelLoad)
        {
            var panelLoader = PanelLoaderPool.AllocateLoader();

            panelLoader.LoadPanelPrefabAsync(panelSearchKeys, (handle) =>
            {
                var obj = Object.Instantiate(handle.Result);

                var retScript = obj.GetComponent<UIPanel>();

                var panelInterface = retScript as IPanel;
                panelInterface.Loader = panelLoader;

                onPanelLoad?.Invoke(retScript);
            });
        }


        public IPanelLoaderPool PanelLoaderPool = new AAPanelLoaderPool();

        public virtual void SetDefaultSizeOfPanel(IPanel panel)
        {
            var panelRectTrans = panel.Transform as RectTransform;

            panelRectTrans.offsetMin = Vector2.zero;
            panelRectTrans.offsetMax = Vector2.zero;
            panelRectTrans.anchoredPosition3D = Vector3.zero;
            panelRectTrans.anchorMin = Vector2.zero;
            panelRectTrans.anchorMax = Vector2.one;

            panelRectTrans.localScale = Vector3.one;
        }
    }

    /// <summary>
    /// 如果想要定制自己的加载器，自定义 IPanelLoader 以及
    /// </summary>
    public interface IPanelLoader
    {

        void LoadPanelPrefabAsync(PanelSearchKeys panelSearchKeys, Action<AsyncOperationHandle<GameObject>> onPanelPrefabLoad);

        void Unload();
    }


    public interface IPanelLoaderPool
    {
        IPanelLoader AllocateLoader();
        void RecycleLoader(IPanelLoader panelLoader);
    }

    public abstract class AbstractPanelLoaderPool : IPanelLoaderPool
    {
        private Stack<IPanelLoader> mPool = new Stack<IPanelLoader>(16);

        public IPanelLoader AllocateLoader()
        {
            return mPool.Count > 0 ? mPool.Pop() : CreatePanelLoader();
        }

        protected abstract IPanelLoader CreatePanelLoader();

        public void RecycleLoader(IPanelLoader panelLoader)
        {
            mPool.Push(panelLoader);
        }
    }

    //public class DefaultPanelLoaderPool : AbstractPanelLoaderPool
    //{
    //    /// <summary>
    //    /// Default
    //    /// </summary>
    //    public class DefaultPanelLoader : IPanelLoader
    //    {
    //        private GameObject mPanelPrefab;

    //        public void LoadPanelPrefabAsync(PanelSearchKeys panelSearchKeys, Action<AsyncOperation> onPanelLoad)
    //        {
    //            var request = Resources.LoadAsync<GameObject>(panelSearchKeys.GameObjName);

    //            request.completed += onPanelLoad;
    //        }

    //        public void Unload()
    //        {
    //            mPanelPrefab = null;
    //        }
    //    }

    //    protected override IPanelLoader CreatePanelLoader()
    //    {
    //        return new DefaultPanelLoader();
    //    }
    //}

    public class AAPanelLoaderPool : AbstractPanelLoaderPool
    {

        public class AAPanelLoader : IPanelLoader
        {
            AsyncOperationHandle<GameObject> handle1;
            public void LoadPanelPrefabAsync(PanelSearchKeys panelSearchKeys, Action<AsyncOperationHandle<GameObject>> onPanelPrefabLoad)
            {

                AsyncOperationHandle<GameObject> handle1 = Addressables.LoadAssetAsync<GameObject>(panelSearchKeys.GameObjName);
                handle1.Completed += onPanelPrefabLoad;
            }


            public void Unload()
            {
                if(handle1.IsValid())
                    Addressables.Release(handle1);
            }
        }
        protected override IPanelLoader CreatePanelLoader()
        {
            return new AAPanelLoader();
        }
    }
}