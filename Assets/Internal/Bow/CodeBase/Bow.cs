using System;
using Internal.Arrow.CodeBase.ArrowRotation;
using UnityEngine;
using Zenject;

namespace Internal.Bow.CodeBase
{
    public class Bow : MonoBehaviour
    {
        Camera cam;
        
        private ArrowMovement arrow;
        private Trajectory.CodeBase.Trajectory trajectory;
        [SerializeField] float pushForce = 4f;

        bool isDragging = false;

        Vector2 startPoint;
        Vector2 endPoint;
        Vector2 direction;
        Vector2 force;
        float distance;
        [SerializeField] private float rotationModifier;
        [SerializeField] private GameObject player;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private SpriteRenderer playerSpriteRenderer;
        public event Action OnRotate;

        [Inject]
        private void Construct(Trajectory.CodeBase.Trajectory trajectory, ArrowMovement arrowMovement)
        {
            this.trajectory = trajectory;
            arrow = arrowMovement;
        }

        private void Start ()
        {
            cam = Camera.main;
            arrow.DisactivateRigidBody(); 
        }

        private void Update ()
        {
            if (Input.GetMouseButtonDown (0)) {
                isDragging = true;
                OnDragStart ();
            }
            if (Input.GetMouseButtonUp (0)) {
                isDragging = false;
                OnDragEnd ();
            }

            if (isDragging) {
                OnDrag ();
            }
        }

        //-Drag--------------------------------------
        private void OnDragStart ()
        {
            arrow.DisactivateRigidBody();
            startPoint = cam.ScreenToWorldPoint (Input.mousePosition);

            trajectory.Show ();
        }

        private void OnDrag ()
        {
            endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
            distance = Vector2.Distance (startPoint, endPoint);
            direction = (startPoint - endPoint).normalized;
            force = direction * distance * pushForce;
            
            Rotate();

            //just for debug
            Debug.DrawLine (startPoint, endPoint);


            trajectory.UpdateDots (player.transform.position, force);
        }

        private void OnDragEnd ()
        {
            //push the ball
            arrow.ActivateRigidBody();

            arrow.Push (force);

            trajectory.Hide ();
        }

        private void Rotate()
        {
            OnRotate?.Invoke();
            
            Vector3 vectorToTarget = new Vector3(endPoint.x, endPoint.y, 0) - player.transform.position;
            Quaternion q = Quaternion.AngleAxis(Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + rotationModifier, Vector3.forward);
            player.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
    }
}