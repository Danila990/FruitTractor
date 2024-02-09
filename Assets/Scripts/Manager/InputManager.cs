using Services;
using UnityEngine;
using YG;

namespace Manager
{
    public class InputManager : MonoBehaviour, IInit
    {
        [SerializeField] private bool _isMobile = false;
        
        public IInputService _inputService { get; private set; }

        public void Init()
        {
            if (_isMobile || YandexGame.EnvironmentData.isMobile)
                _inputService = gameObject.AddComponent<MobileInputService>();
            else
                _inputService = gameObject.AddComponent<PcInputService>();
        }
    }
}