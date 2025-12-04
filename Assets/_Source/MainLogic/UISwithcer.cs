using _Source.GamePlay;
using _Source.interfaces;

namespace _Source.MainLogic
{
    public class UISwitcher
    {
        private readonly IUIState _mainState;
        private readonly IUIState _panelState;
        private readonly MainView _mainView;
        private readonly PanelView _panelView;

        private IUIState _current;

        public UISwitcher(IUIState mainState, IUIState panelState, MainView mainView, PanelView panelView)
        {
            _mainState = mainState;
            _panelState = panelState;
            _mainView = mainView;
            _panelView = panelView;
        }

        public void StartWithMain()
        {
            _current = _mainState;
            _current.Enter();
            _panelView.PanelImage.gameObject.SetActive(false);
            _panelView.PanelImage.color = new UnityEngine.Color(1f, 1f, 1f, 0f);
        }

        public void SwitchToPanel()
        {
            _current.Exit();
            _mainView.SetOpenInteractable(false);

            _current = _panelState;
            _current.Enter();
        }

        public void SwitchToMain()
        {
            _current.Exit();
            _current = _mainState;
            _current.Enter();
            _mainView.SetOpenInteractable(true);
        }
    }
}