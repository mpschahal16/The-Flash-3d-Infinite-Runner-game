using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform path;
    private List<Transform> nodes;
    private int currentNode = 0;
    public float maxstearangle = 90f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelBL;
    public WheelCollider wheelBR;

    public float maxbreaktorque = 2000;
    public float maxtorque = 1500f;
    public float maxspeed = 200f;
    public float currentspeed;

    public bool diskbreaking = false;

    public Vector3 centerofmass;

  /*  [Header("Sensors")]
    public float sensorLength = .2F;
    public float frontcentersensorpos = 0.5f;
    public float frontsidesensorpos = 0.2f;*/




    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerofmass;
        Transform[] pathtransform =path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathtransform.Length; i++)
        {
            if (pathtransform[i] != path.transform)
            {
                nodes.Add(pathtransform[i]);
            }
        }

    }

    private void FixedUpdate()
    {
        //Sensors();
        ApplyStear();
        drive();
        checkwaypointdis();
        breaking();
    }

   /* private void Sensors()
    {
        RaycastHit hit;
        Vector3 sensorstartpos = transform.position;
        sensorstartpos.z -= frontcentersensorpos;
        if(Physics.Raycast(sensorstartpos,transform.forward,out hit, sensorLength))
        {

        }
        Debug.DrawLine(sensorstartpos, hit.point);

        sensorstartpos.x += frontcentersensorpos;
        if (Physics.Raycast(sensorstartpos, transform.forward, out hit, sensorLength))
        {

        }
        Debug.DrawLine(sensorstartpos, hit.point);

        sensorstartpos.x -= 2*frontcentersensorpos;
        if (Physics.Raycast(sensorstartpos, transform.forward, out hit, sensorLength))
        {

        }
        Debug.DrawLine(sensorstartpos, hit.point);
    }*/

    private void ApplyStear()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newsteroangle= (relativeVector.x / relativeVector.magnitude)*maxstearangle;
        wheelFL.steerAngle = newsteroangle;
        wheelFR.steerAngle = newsteroangle;
    }

    private void drive()
    {
        currentspeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;
        if(currentspeed<maxspeed)
        {
            wheelFL.motorTorque = maxtorque;
            wheelFR.motorTorque = maxtorque;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
       
    }

    private void checkwaypointdis()
    {
        if(Vector3.Distance(transform.position,nodes[currentNode].position)<10f)
        {

            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }

    private void breaking()
    {
        if(diskbreaking)
        {
            wheelBL.brakeTorque = maxbreaktorque;
            wheelBR.brakeTorque = maxbreaktorque;
        }
        else
        {
            wheelBL.brakeTorque = 0;
            wheelBR.brakeTorque = 0;

        }
    }


}
