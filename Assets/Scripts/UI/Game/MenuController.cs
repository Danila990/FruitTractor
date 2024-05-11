using System;
using Enums;
using Manager;
using UnityEngine;
using YG;

namespace UI.Game
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private MenuData[] _menuData;

        private void Start()
        {
            /*OpenMenu(TypeMenu.TapScreen);
            GameManager gameManager = GameSceneContext.Instance._gameManager;*/
            
            /*gameManager.SubRestartEvent(() => OpenMenu(TypeMenu.TapScreen));
            gameManager.SubLossEvent(() => OpenMenu(TypeMenu.Loss));
            gameManager.SubWinEvent(LevelWin);*/
        }
        
        public void OpenMenu(TypeMenu typeMenu)
        {
            foreach (MenuData menuData in _menuData)
            {
                if (typeMenu.Equals(menuData._typeMenu))
                {
                    menuData._canvas.gameObject.SetActive(true);
                    continue;
                }
                menuData._canvas.gameObject.SetActive(false);
            }
        }

        private void LevelWin()
        {
            /*if (YandexGame.savesData.LevelComplete <= SceneLoadManager.Instance._currentLoadScene 
                && YandexGame.savesData.LevelComplete != YandexGame.savesData._maxLevel)
            {
                YandexGame.savesData.LevelComplete++;
                YandexGame.SaveProgress();
            }
            
            OpenMenu(TypeMenu.Win);*/
        }
    }

    [Serializable]
    public class MenuData
    {
        [field: SerializeField] public Canvas _canvas { get; private set; }
        [field: SerializeField] public TypeMenu _typeMenu { get; private set; }
    }
}