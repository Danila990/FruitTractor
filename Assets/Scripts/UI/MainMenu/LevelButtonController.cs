using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Code
{
    public class LevelButtonController : MonoBehaviour
    {
        [SerializeField] private LoadSceneButton[] _buttons;
        
        private void Start()
        {
            for (int i = 0; i < YandexGame.savesData.CurrentLevel; i++)
            {
                _buttons[i].GetComponent<Button>().interactable = true;
                _buttons[i].LoadSceneIndex = i + 1;
            }
        }
    }
}