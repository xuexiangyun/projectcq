using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:6d722061-1eed-4baf-984f-5c111a4dd50e
	public partial class FadeCanvas
	{
		public const string Name = "FadeCanvas";
		
		
		private FadeCanvasData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public FadeCanvasData Data
		{
			get
			{
				return mData;
			}
		}
		
		FadeCanvasData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new FadeCanvasData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
