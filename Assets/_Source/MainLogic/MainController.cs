using _Source.GamePlay;
using _Source.interfaces;

namespace _Source.MainLogic
{
    public class MainController : IUIState
    {
        private readonly MainView _view;
        private UISwitcher _switcher;

        public MainController(MainView view, UISwitcher switcher)
        {
            _view = view;
            _switcher = switcher;
        }
        
        public void SetSwitcher(UISwitcher switcher)
        {
            _switcher = switcher;
        }
        
        public void Enter()
        {
            _view.OnOpen += HandleOpen;
            _view.SetOpenInteractable(true);
        }

        public void Exit()
        {
            _view.OnOpen -= HandleOpen;
            _view.SetOpenInteractable(false);
        }

        private void HandleOpen()
        {
            _switcher.SwitchToPanel();
        }
    }
}