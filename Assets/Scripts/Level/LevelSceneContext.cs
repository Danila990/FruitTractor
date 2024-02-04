using Level.Grid;
using Level.Grid.Generators;
using Level.Grid.Setting;
using Systems;
using UnityEngine;

namespace Level
{
    public class LevelSceneContext : Singleton<LevelSceneContext>
    {
        [field: SerializeField] public GridController GridController { get; private set; }
        [field: SerializeField] public GridGenerator GridGenerator { get; private set; }
        [field: SerializeField] public InputSystem InputSystem { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            
            InputSystem.Initialization();
            GridGenerator.Initialization(GridController);
        }
    }
}