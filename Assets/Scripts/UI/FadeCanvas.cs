using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;
using Unity.Mathematics;

namespace GameUI
{
	public class FadeCanvas : UIElement
	{
		private CanvasGroup canvas;
		public override string ComponentName => this.GetType().Name;

		private FadeState curState;

		private enum FadeState
		{
			Nomral,Fadein,Fadeout
        }

		public static readonly float fadeTime = 1.5f;

        private void Awake()
        {
			canvas = GetComponent<CanvasGroup>();
            EnumEventSystem.Global.Register(GamePlayEvnetEnum.SceneFade,OnFadeCanvas);
        }

		private void OnFadeCanvas(object[] objects)
		{
			FadeStyle nextStyle = (FadeStyle)objects[0];
			if (curState != FadeState.Nomral)
				CancelFade();

			Fade(nextStyle);
        }

		private void CancelFade()
		{
			canvas.DOKill();
            canvas.alpha = 0;
            curState = FadeState.Nomral;
        }

		private void Fade(FadeStyle style)
		{
			float _nexta;
			if(style == FadeStyle.FadeIn)
			{
				curState = FadeState.Fadein;
				_nexta = 1f;
            }
            else
			{
                curState = FadeState.Fadeout;
				_nexta = 0f;
            }

			canvas.DOFade(math.abs(_nexta - 1), _nexta, fadeTime).onComplete += CancelFade;
        }
    }
}
