using DG.Tweening;
using UnityEngine.UI;
using _Source.interfaces;

namespace _Source.MainLogic
{
    public class FadeService : IFadeService
    {
        public void FadeIn(Image image, float duration)
        {
            if (image == null)
            {
                return;
            }

            image.gameObject.SetActive(true);
            image.DOFade(1f, duration).SetUpdate(true);
        }

        public void FadeOut(Image image, float duration)
        {
            if (image == null)
            {
                return;
            }

            image.DOFade(0f, duration).SetUpdate(true).OnComplete(() =>
            {
                image.gameObject.SetActive(false);
            });
        }
    }
}