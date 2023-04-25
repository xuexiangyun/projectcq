using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	// Generate Id:3ecd6118-bcad-4ac1-8643-a0b04122c118
	public partial class MainPanel
	{
		public const string Name = "MainPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button NewGame;
		[SerializeField]
		public UnityEngine.UI.Button ContinueGame;
		[SerializeField]
		public UnityEngine.UI.Button Setting;
		[SerializeField]
		public UnityEngine.UI.Button About;
		[SerializeField]
		public UnityEngine.UI.Button Exit;
		
		private MainPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			NewGame = null;
			ContinueGame = null;
			Setting = null;
			About = null;
			Exit = null;
			
			mData = null;
		}
		
		public MainPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		MainPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new MainPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
