using UnityEngine;
using System.Collections.Generic;

public class path : MonoBehaviour
{
    public Color linecolor;

    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = linecolor;

        Transform[] pathtransform = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i = 0; i < pathtransform.Length; i++)
        {
            if(pathtransform[i]!=transform)
            {
                nodes.Add(pathtransform[i]);
            }
        }

        for(int i=0;i<nodes.Count;i++)
        {
            Vector3 currentNode = nodes[i].position;
            Vector3 previousNode=Vector3.zero;
            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }else if(i==0&& nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }
            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawSphere(currentNode, 30f);
        }
        
    }
}
