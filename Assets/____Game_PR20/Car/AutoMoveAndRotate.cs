using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class AutoMoveAndRotate : MonoBehaviour
    {
        public Vector3andSpace moveUnitsPerSecond;
        public Vector3andSpace rotateDegreesPerSecond;
        public Vector3 maxmovedistance;
        public Vector3 tranlateside;
        public bool ignoreTimescale;
        private float m_LastRealTime;
        private float totalMoveddis = 0;


        private void Start()
        {
            m_LastRealTime = Time.realtimeSinceStartup;
        }


        // Update is called once per frame
        private void Update()
        {
            float deltaTime = Time.deltaTime;
            if (ignoreTimescale)
            {
                deltaTime = (Time.realtimeSinceStartup - m_LastRealTime);
                m_LastRealTime = Time.realtimeSinceStartup;
            }
            Vector3 dis = moveUnitsPerSecond.value * deltaTime;
            totalMoveddis = totalMoveddis + dis.magnitude;
            transform.Translate(dis, moveUnitsPerSecond.space);
            if(!(totalMoveddis<maxmovedistance.magnitude))
            {
                transform.Translate(tranlateside);
                transform.Rotate(rotateDegreesPerSecond.value/* * deltaTime*/, moveUnitsPerSecond.space);
                totalMoveddis = 0f;
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
