using System;
using UnityEngine;
using Zenject;

namespace Internal.Player.CodeBase
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        private Bow.CodeBase.Bow bow;

        [Inject]
        private void Construct(Bow.CodeBase.Bow bow) => this.bow = bow;

        private void Start()
        {
            bow.OnRotate += Rotate;
        }

        private void OnDisable()
        {
            bow.OnRotate -= Rotate;
        }

        private void Rotate()
        {
            if ((transform.eulerAngles.z > 270 && transform.eulerAngles.z < 360)
                || (transform.eulerAngles.z > 0 && transform.eulerAngles.z < 75))
                spriteRenderer.flipY = false;
            else spriteRenderer.flipY = true;
        }
    }
}