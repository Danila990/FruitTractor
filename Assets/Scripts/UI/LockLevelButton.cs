using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI
{
    public class LockLevelButton : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        
        private void Start()
        {
            for (int i = 0; i < YandexGame.savesData.LevelComplete; i++)
            {
                _buttons[i].interactable = true;
            }
        }
    }
}