
using UnityEngine;

public class Controller : MonoBehaviour {


    public Vehicle vehicle; // reference to the Vehicle class to get variables.
    private Actions actions; // reference to actions class to enable execution of commands such as accelerate .etc

    private void Start()
    {
 
    }

    private void FixedUpdate()
    {
        runController();
    }
    public void runController()
    {

        if (vehicle.is_braking) // checks the boolean break flag
        {
            setAction(new Brake(this));
        }

        if(!vehicle.is_braking) // overrides the actions abstract class to execute the specified classes below.
        {
            setAction(new Accelerate(this));
            
            if (vehicle.is_avoiding)
            {
                setAction(new Avoid(this));
            }
            else
            {
                setAction(new Steer(this));

            }

            setAction(new CheckWaypoint(this));

           
            sensors();
            
        }
        
    }

    // pass specified action through parameter to change the agent's behaviour
    public void setAction(Actions _action)
    {
        actions = _action;

    }

    private void sensors()
    {
        // sensor method to enable raycasts and turning

        RaycastHit hit;
        
        Vector3 startpos = transform.position; // transforms the raycast origin points to match agent's movement
        Vector3 leftpos = transform.position;
        Vector3 rightpos = transform.position;
        startpos += transform.forward * vehicle.front_sensor_pos.z; // transform the z axis to match the car as it moves
        leftpos += transform.forward * vehicle.front_sensor_pos.z;
        rightpos += transform.forward * vehicle.front_sensor_pos.z;

        startpos += transform.up * vehicle.front_sensor_pos.y;
        leftpos += transform.up * vehicle.front_sensor_pos.y;
        rightpos += transform.up * vehicle.front_sensor_pos.y;


        vehicle.avoid = 0; // avoid value to multiply by the steer angle, a simple method for collision avoidance
        vehicle.is_avoiding = false; // boolean flag for switching to collision avoidance.

        // set of if statements for the raycast hits and to set boolean flag to true if any of the raycasts hit.

        // front centre sensor
        if (Physics.Raycast(startpos, transform.forward, out hit, vehicle.sensor_length))
        {
            if (hit.collider)
            {
                Debug.DrawLine(startpos, hit.point, Color.red); // ensures that raycast is working by drawing a line from the car to the object
                vehicle.is_avoiding = true;
                if (hit.normal.x < 0) // hit.normal is the reflection direction of the raycast.
                {
                    if (hit.distance == vehicle.short_sensor_length) // distance checker to how much the agent needs to turn by
                    {
                        vehicle.avoid = -1f;
                    }
                    else
                    {
                        vehicle.avoid = -0.5f;
                    }
                    
                }
                else
                {
                    if (hit.distance == vehicle.short_sensor_length)
                    {
                        vehicle.avoid = 1f;
                    }
                    else
                    {
                        vehicle.avoid = 0.5f;
                    }
                }
            }
        }

        //// Rear Sensor
        if (Physics.Raycast(startpos, -transform.forward, out hit, vehicle.short_sensor_length))
        {
            if (hit.collider)
            {
                Debug.DrawLine(startpos, hit.point, Color.red);
                
                vehicle.is_avoiding = true;
                if (hit.normal.x > 0)
                {
                    vehicle.avoid = 1;
                }
                else
                {
                    vehicle.avoid = -1; 
                }
            }
        }

        // front right sensor
        startpos += transform.right * vehicle.front_side_sensor; // matches the car position for the right sensor by multiplying the red axis by front side sensor declared in Vehicle class (0.1)
        if (Physics.Raycast(startpos, transform.forward, out hit, vehicle.sensor_length)) // checks for a raycast hit followed by another check to see if an obstacle is hit
        {
            if (hit.collider)
            {
                Debug.DrawLine(rightpos, hit.point, Color.red); // allows for an angled raycast line
                vehicle.is_avoiding = true; // set boolean flag to true to allow collision avoidance.
                if (hit.distance == vehicle.short_sensor_length) // sensors hit 
                {
                    vehicle.avoid -= 1f; // object at closer distance would mean harsher steering
                }
                else
                {
                    vehicle.avoid -= 0.5f;
                }

            }
        }

        // front left sensor
        startpos -= transform.right * vehicle.front_side_sensor;
        if (Physics.Raycast(startpos, transform.forward, out hit, vehicle.short_sensor_length))
        {
            Debug.DrawLine(leftpos, hit.point, Color.red);
            vehicle.is_avoiding = true;
            if (hit.collider)
            {
                if (hit.distance == vehicle.short_sensor_length)
                {
                    vehicle.avoid += 0.5f;
                }
                else
                {
                    vehicle.avoid += 1f;
                }
            }
        }

    }
}
