using Internal.Arrow.CodeBase.ArrowRotation;
using UnityEngine;


namespace Internal.Factories.ArrowFactory
{
    public class ArrowFactory 
    {
        private const string ArrowPath = "Arrow/Arrow";
        
        public ArrowMovement CreateArrow(Transform at)
        {
            var arrowPrefab = Resources.Load<ArrowMovement>(ArrowPath);
            return GameObject.Instantiate<ArrowMovement>(arrowPrefab, at);
        }
    }
}