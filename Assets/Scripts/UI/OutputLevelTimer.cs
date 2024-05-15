using TMPro;
using UnityEngine;
using Zenject;

namespace Code
{
    public class OutputLevelTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private LevelTimer _levelTimer;

        [Inject]
        private void Construct(LevelTimer levelTimer)
        {
            _levelTimer = levelTimer;
            _levelTimer.OnLevelTime += Output;
        }

        private void OnDestroy()
        {
            _levelTimer.OnLevelTime -= Output;
        }

        private void Output(int time)
        {
            _text.text = time.ToString();
        }
    }
}