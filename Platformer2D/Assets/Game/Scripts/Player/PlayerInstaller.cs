using DG.Tweening;
using Game.Scripts.Components;
using Game.Scripts.Components.Flip;
using Game.Scripts.Components.Health;
using Game.Scripts.Components.Jump;
using Game.Scripts.Components.Move;
using Game.Scripts.Components.Sensors;
using Game.Scripts.Components.Vfx;
using Game.Scripts.Data;
using Game.Scripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [Title("Refs")]
        [SerializeField]
        public Transform body;

        [SerializeField]
        private Transform feelPoint;

        [SerializeField]
        private Transform pushPoint;

        [SerializeField]
        private Rigidbody2D rigidbodyComponent;

        [SerializeField]
        private LayerMask groundLayer;

        [SerializeField]
        private TriggerSensor hit;

        [Title("Settings")]
        [SerializeField]
        private float moveSpeed = 5;

        [SerializeField]
        private float jumpForce = 10;

        [SerializeField]
        private int maxHealth = 10;

        [Title("UI")]
        [SerializeField]
        private HealthBarView playerHealthBar;

        [Title("VFX")]
        [SerializeField]
        private BlinkSpriteComponent blinkFx;

        public override void InstallBindings()
        {
            BindSensors();

            BindParams();

            BindUI();

            BindVFX();
        }

        private void BindVFX()
        {
            Container.Bind<IVisualFX>()
                     .WithId(NameProvider.Vfx.Blink)
                     .FromInstance(blinkFx)
                     .AsTransient();
        }


        private void BindUI()
        {
            Container.Bind<HealthBarView>()
                     .FromInstance(playerHealthBar)
                     .AsSingle();
        }

        private void BindParams()
        {
            Container.BindInterfacesTo<HealthComponent>()
                     .AsSingle()
                     .WithArguments(maxHealth, maxHealth);

            Container.BindInterfacesTo<MoveComponent>()
                     .AsSingle()
                     .WithArguments(rigidbodyComponent, moveSpeed);

            Container.BindInterfacesTo<JumpComponent>()
                     .AsSingle()
                     .WithArguments(rigidbodyComponent, jumpForce);
        }

        private void BindSensors()
        {
            Container.BindInterfacesTo<FlipComponent>()
                     .AsSingle()
                     .WithArguments(body);

            Container.BindInterfacesTo<GroundRaycastSensor>()
                     .AsSingle()
                     .WithArguments(feelPoint, groundLayer);
            
            Container.Bind<ITriggerProxy>()
                     .FromInstance(hit)
                     .AsSingle();
        }
    }
}