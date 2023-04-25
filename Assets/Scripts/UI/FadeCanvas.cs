using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	public class FadeCanvasData : UIPanelData
	{
	}
	public partial class FadeCanvas : UIPanel
	{
		private enum FadeState
		{

		}
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as FadeCanvasData ?? new FadeCanvasData();
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
