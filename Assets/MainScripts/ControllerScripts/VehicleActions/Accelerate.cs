﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : Actions {
    public Accelerate(Controller _controller) : base(_controller)
    {
    }

    public override void execute()
    {

        controller.vehicle.current_speed = 2 * Mathf.PI * controller.vehicle.FL_wheel.radius * controller.vehicle.FL_wheel.rpm; // speed = 2 * 3.14 * radius of wheel * revs per minute

        // driving is controlled by the wheel colliders instead of the rigidbody, so motor torque is used and set to the motor torque declared in the Vehicle class.
        controller.vehicle.FL_wheel.motorTorque = controller.vehicle.max_motor_torque; 
        controller.vehicle.FR_wheel.motorTorque = controller.vehicle.max_motor_torque;
        controller.vehicle.FL_wheel.brakeTorque = 0;
        controller.vehicle.FR_wheel.brakeTorque = 0;
  
    }
}
