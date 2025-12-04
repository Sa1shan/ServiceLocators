using _Source.interfaces;
using UnityEngine;

namespace _Source.Saver
{
    public class PlayerPrefsSaver : ISaver
    {
        private readonly Score _score;
        private readonly string _key;

        public PlayerPrefsSaver(Score score, string key = "saved_score")
        {
            _score = score;
            _key = key;
        }

        public void Save(string path = null)
        {
            PlayerPrefs.SetInt(_key, _score.CurrentScore);
            PlayerPrefs.Save();
#if UNITY_EDITOR
            Debug.Log($"PlayerPrefsSaver: saved {_score.CurrentScore} to key {_key}");
#endif
        }
    }
}