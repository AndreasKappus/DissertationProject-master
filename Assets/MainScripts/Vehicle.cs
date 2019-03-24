using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

    public Transform path; // used as a reference to the path game-object
    //public Vector3 centre_mass;
    public Rigidbody car; // rigid body declaration to be used as a reference for other classes.

    [Header("Movement and Turning")]
    public bool is_braking = false; // boolean flag to check if the vehicle is braking
    public float max_steer_angle = 30f; // set the maximum steering angle to 45 for relatively authentic turning
    public float steer_speed = 5f;
    public float max_motor_torque = 60;
    public float current_speed; // this can be used for the GUI application which could become thread from the GUI to get the current speed during runtime
    public float max_speed = 20; // adjust until suitable speed found
    public float reverse_torque = -20;

    [Header("Wheels")]
    public WheelCollider RR_wheel; // declaration for the wheel colliders, so they can be run and called within the simulation to set speeds, torque etc
    public WheelCollider RL_wheel;
    public WheelCollider FR_wheel;
    public WheelCollider FL_wheel;

    [Header("Sensors")]
    [HideInInspector] public float short_sensor_length = 1f;
    [HideInInspector] public float sensor_length = 4f;
    [HideInInspector] public Vector3 front_sensor_pos = new Vector3(0.5f, 0.02f, 0f);
    [HideInInspector] public float front_side_sensor = 0.1f;

    [Header("Path")]
    [HideInInspector]public List<Transform> nodes;
    [HideInInspector] public int current_node = 0;

    [Header("Avoidance")]
    [HideInInspector] public bool is_avoiding = false;
    [HideInInspector] public float avoid = 0;

    

    void Start () {

        // gets the path nodes to enable the waypoint 
        Transform[] paths = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        // iterate through the path transforms to add to the node list.
        for (int i = 0; i < paths.Length; i++)
        {
            if (paths[i] != path.transform)
            {
                nodes.Add(paths[i]); // adds paths if the amount is not equal to the amount created in the simulation
            }
        }

    }

}
