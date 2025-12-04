using System.IO;
using _Source.interfaces;
using UnityEngine;

namespace _Source.Saver
{
    public class JsonSaver : ISaver
    {
        private readonly Score _score;

        public JsonSaver(Score score)
        {
            _score = score;
        }

        public void Save(string path = null)
        {
            var finalPath = path;
            if (string.IsNullOrEmpty(finalPath))
            {
                finalPath = Path.Combine(Application.persistentDataPath, "score.json");
            }

            var dto = new ScoreDto { score = _score.CurrentScore };
            var json = JsonUtility.ToJson(dto);
            File.WriteAllText(finalPath, json);
#if UNITY_EDITOR
            Debug.Log($"JsonSaver: saved {_score.CurrentScore} to {finalPath}");
#endif
        }

        [System.Serializable]
        private class ScoreDto
        {
            public int score;
        }
    }
}