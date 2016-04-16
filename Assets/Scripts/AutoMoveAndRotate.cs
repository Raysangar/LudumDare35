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


        void Start()
        {
            m_LastRealTime = Time.realtimeSinceStartup;
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
				transform.Translate(moveUnitsPerSecond.value*deltaTime, moveUnitsPerSecond.space);
				transform.Rotate(rotateDegreesPerSecond.value*deltaTime, moveUnitsPerSecond.space);
			}
			if(stopPosition != null){
				if(Vector3.Distance(transform.position, stopPosition.position) < 0.2){

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
