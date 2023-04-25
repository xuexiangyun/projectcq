using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace GameUI
{
	public class MainPanelData : UIPanelData
	{
	}
	public partial class MainPanel : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as MainPanelData ?? new MainPanelData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			NewGame.onClick.AddListener(OnClickStarGame);
			ContinueGame.onClick.AddListener(OnClickStarGame);
			Setting.onClick.AddListener(OnClickSetting);
			About.onClick.AddListener(OnClickAbout);
			Exit.onClick.AddListener(OnClickExitGame);
        }
	

		protected override void OnClose()
		{
			NewGame.onClick.RemoveAllListeners();
			ContinueGame.onClick.RemoveAllListeners();
			Setting.onClick.RemoveAllListeners();
			About.onClick.RemoveAllListeners();
			Exit.onClick.RemoveAllListeners();
        }

		private void OnClickStarGame()
		{

		}

		private void OnClickSetting()
		{

		}

		private void OnClickAbout()
		{

		}

		private void OnClickExitGame()
		{

		}
	}
}
