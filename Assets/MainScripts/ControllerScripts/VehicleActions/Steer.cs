using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steer : Actions {


    public Steer(Controller _controller) : base(_controller)
    {
    }

    public override void execute()
    {
        
        Vector3 relativePos = controller.vehicle.transform.InverseTransformPoint(controller.vehicle.nodes[controller.vehicle.current_node].position); // makes the car turn towards the nodes in the path object on 
        float steer = (relativePos.x / relativePos.magnitude) * controller.vehicle.max_steer_angle; // divides the x axis of the position by the length of the position, then multiply by the steer angle to turn

        controller.vehicle.FL_wheel.steerAngle = Mathf.Lerp(controller.vehicle.FL_wheel.steerAngle, steer, Time.deltaTime * controller.vehicle.steer_speed); // added more realistic steering
        controller.vehicle.FR_wheel.steerAngle = Mathf.Lerp(controller.vehicle.FR_wheel.steerAngle, steer, Time.deltaTime * controller.vehicle.steer_speed);
        
    }
    
}
