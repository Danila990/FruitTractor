using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI
{
    public class LockLevelButton : MonoBehaviour
    {
        private void Start()
        {
            Button[] buttons = GetComponentsInChildren<Button>();
            
            for (int i = 0; i < YandexGame.savesData.LevelComplete; i++)
            {
                buttons[i].interactable = true;
            }
        }
    }
}