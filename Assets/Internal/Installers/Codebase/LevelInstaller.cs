using Internal.Arrow.CodeBase.ArrowRotation;
using Internal.Bow.Trajectory.CodeBase;
using UnityEngine;
using Zenject;

namespace Internal.Installers.Codebase
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Trajectory trajectory;
        [SerializeField] private ArrowMovement arrow;
        [SerializeField] private Bow.CodeBase.Bow bow;

        public override void InstallBindings()
        {
            Container.Bind<Trajectory>().FromInstance(trajectory).AsSingle();
            Container.Bind<ArrowMovement>().FromInstance(arrow).AsSingle();
            Container.Bind<Bow.CodeBase.Bow>().FromInstance(bow).AsSingle();
        }
    }
}