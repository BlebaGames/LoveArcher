using System;
using UnityEngine;

namespace Internal.Arrow.CodeBase.ArrowRotation
{
    public class ArrowMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody2D;
        [SerializeField] private Collider2D collider;

        public Vector3 Position => transform.position;

        public void Push(Vector2 force) => rigidbody2D.AddForce(force, ForceMode2D.Impulse);

        public void ActivateRigidBody() => rigidbody2D.isKinematic = false;
        public void DisactivateRigidBody()
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.angularVelocity = 0f;
            rigidbody2D.isKinematic = true;
        }
    }
}
