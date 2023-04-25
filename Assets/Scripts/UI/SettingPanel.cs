using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	public class SettingPanelData : UIPanelData
	{
	}
	public partial class SettingPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as SettingPanelData ?? new SettingPanelData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
