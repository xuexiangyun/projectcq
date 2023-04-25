using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:edd7e82a-ef13-42ed-9832-24634187e148
	public partial class SettingPanel
	{
		public const string Name = "SettingPanel";
		
		
		private SettingPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
			mData = null;
		}
		
		public SettingPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		SettingPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new SettingPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
