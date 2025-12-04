using _Source.GamePlay;
using _Source.interfaces;
using _Source.Saver;

namespace _Source.MainLogic
{
    public class PanelController : IUIState
    {
        private readonly PanelView _view;
        private readonly IService _services;
        private readonly Score _score;
        private UISwitcher _switcher;
        private readonly IFadeService _fade;
        private readonly ISoundPlayer _sound;

        private const float FadeDuration = 0.3f;

        public PanelController(PanelView view, IService services, Score score, UISwitcher switcher)
        {
            _view = view;
            _services = services;
            _score = score;
            _switcher = switcher;
            _fade = _services?.GetService<IFadeService>();
            _sound = _services?.GetService<ISoundPlayer>();
        }
        
        public void SetSwitcher(UISwitcher switcher)
        {
            _switcher = switcher;
        }
        
        public void Enter()
        {
            _view.OnClose += HandleClose;
            _view.OnCollect += HandleCollect;
            _view.SetScoreText(_score.CurrentScore.ToString());
            _fade.FadeIn(_view.PanelImage, FadeDuration);
            _sound?.PlayStartSound();
        }

        public void Exit()
        {
            _view.OnClose -= HandleClose;
            _view.OnCollect -= HandleCollect;
            
            _fade.FadeOut(_view.PanelImage, FadeDuration);
            _sound?.PlayEndSound();
            
            var saver = _services.GetService<ISaver>();
            saver?.Save();
        }

        private void HandleCollect()
        {
            _score.Add(1);
            _view.SetScoreText(_score.CurrentScore.ToString());
        }

        private void HandleClose()
        {
            _switcher.SwitchToMain();
            
        }
    }
}