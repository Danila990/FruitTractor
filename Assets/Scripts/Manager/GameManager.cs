using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        private readonly List<Action> _restartEvents = new List<Action>();
        private readonly List<Action> _playEvents = new List<Action>();
        private readonly List<Action> _stopEvents = new List<Action>();
        private readonly List<Action> _lossEvents = new List<Action>();
        private readonly List<Action> _winEvents = new List<Action>();

        public bool _isPlayGame { get; private set; } = false;
        
        public void SubRestartEvent(Action eventAction) => _restartEvents.Add(eventAction);
        public void SubPlayEvent(Action eventAction) => _playEvents.Add(eventAction);
        public void SubStopEvent(Action eventAction) => _stopEvents.Add(eventAction);
        public void SubLossEvent(Action eventAction) => _lossEvents.Add(eventAction);
        public void SubWinEvent(Action eventAction) => _winEvents.Add(eventAction);
        
        public void UnsubRestartEvent(Action eventAction) => _restartEvents.Remove(eventAction);
        public void UnsubPlayEvent(Action eventAction) => _playEvents.Remove(eventAction);
        public void UnsubStopEvent(Action eventAction) => _stopEvents.Remove(eventAction);
        public void UnsubLossEvent(Action eventAction) => _lossEvents.Remove(eventAction);
        public void UnsubWinEvent(Action eventAction) => _winEvents.Remove(eventAction);

        public void RestartEvent()
        {
            StopEvent();
            foreach (Action actionEvent in _restartEvents)
                actionEvent();
        }
        
        public void PlayEvent()
        {
            _isPlayGame = true;
            foreach (Action actionEvent in _playEvents)
                actionEvent();
        }
        
        public void StopEvent()
        {
            _isPlayGame = false;
            foreach (Action actionEvent in _stopEvents)
                actionEvent();
        }
        
        public void LossEvent()
        {
            StopEvent();
            foreach (Action actionEvent in _lossEvents)
                actionEvent();
        }
        
        public void WinEvent()
        {
            StopEvent();
            foreach (Action actionEvent in _winEvents)
                actionEvent();
        }
    }
}