using UnityEngine;
using UnityEngine.UI;

namespace _Source.interfaces
{
    public interface IFadeService
    {
        public void FadeIn(Image image, float duration);
        public void FadeOut(Image image, float duration);
    }
}