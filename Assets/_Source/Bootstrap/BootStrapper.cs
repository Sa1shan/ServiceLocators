using _Source.GamePlay;
using _Source.interfaces;
using _Source.MainLogic;
using _Source.Saver;
using UnityEngine;

namespace _Source.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Views")]
        [SerializeField] private MainView mainView;
        [SerializeField] private PanelView panelView;

        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip openClip;
        [SerializeField] private AudioClip closeClip;

        [Header("Saver choice")]
        [SerializeField] private bool usePlayerPrefsSaver = true;
        [SerializeField] private string jsonSavePath = "";

        private void Awake()
        {
            var score = new Score(0);
            var fadeService = new FadeService();
            var soundPlayer = new SoundPlayer(audioSource, openClip, closeClip);
            var locator = new ServiceLocator();
            locator.Register<IFadeService>(fadeService);
            locator.Register<ISoundPlayer>(soundPlayer);
            locator.Register<Score>(score);
            
            ISaver saver;
            if (usePlayerPrefsSaver)
            {
                saver = new PlayerPrefsSaver(score);
            }
            else
            {
                saver = new JsonSaver(score);
            }

            locator.Register<ISaver>(saver);
            
            var switcher = CreateSwitcher(locator, score);
            switcher.StartWithMain();
        }

        private UISwitcher CreateSwitcher(ServiceLocator locator, Score score)
        {
            var mainController = new MainController(mainView, null);
            var panelController = new PanelController(panelView, locator, score, null);
            var switcher = new UISwitcher(mainController, panelController, mainView, panelView);
            mainController.SetSwitcher(switcher);
            panelController.SetSwitcher(switcher);
            return switcher;
        }

    }
}
