using Services;
using UnityEngine;
using YG;

namespace Systems
{
    public class InputSystem : MonoBehaviour
    {
        public IInputService InputService { get; private set; }
        
        [SerializeField] private bool _isMobile = false;

        public void Initialization() => SetupInputService();

        private void SetupInputService()
        {
            if (_isMobile || YandexGame.EnvironmentData.isMobile)
                InputService = gameObject.AddComponent<MobileInputService>();
            else
                InputService = gameObject.AddComponent<PcInputService>();
        }
    }
}