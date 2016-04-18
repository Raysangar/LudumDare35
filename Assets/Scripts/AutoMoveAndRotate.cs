using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class AutoMoveAndRotate : MonoBehaviour
    {
        public Vector3andSpace moveUnitsPerSecond;
        public Vector3andSpace rotateDegreesPerSecond;
        public bool ignoreTimescale;
        private float m_LastRealTime;

		public bool isMoving;
		public Transform stopPosition;

		private Actor actor;

        void Start()
        {
            m_LastRealTime = Time.realtimeSinceStartup;
			actor = GetComponent<Actor>();
			isMoving = true;
        }

        // Update is called once per frame
        private void Update()
        {
			if(isMoving){
				float deltaTime = Time.deltaTime;
				if (ignoreTimescale)
				{
					deltaTime = (Time.realtimeSinceStartup - m_LastRealTime);
					m_LastRealTime = Time.realtimeSinceStartup;
				}
//				transform.Translate(moveUnitsPerSecond.value*deltaTime, moveUnitsPerSecond.space);
				if(actor.currentAction.TypeOfAction == ActionType.Move)
				{
					transform.LookAt(stopPosition.transform);
					transform.position += (stopPosition.position - transform.position).normalized * Time.deltaTime;
				}

				if(ActionManager.Instance.CurrentAction.TypeOfAction == ActionType.Rotate){
					transform.Rotate(rotateDegreesPerSecond.value*deltaTime, moveUnitsPerSecond.space);
				}
			}
			if(stopPosition != null){
				if(Vector3.Distance(transform.position, stopPosition.position) < 0.1 && ActionManager.Instance.CurrentAction.TypeOfAction == ActionType.Move){
					moveUnitsPerSecond.value = Vector3.zero;
					isMoving = false;
				}	
			}
        }

        [Serializable]
        public class Vector3andSpace
        {
            public Vector3 value;
            public Space space = Space.Self;
        }
    }
}
