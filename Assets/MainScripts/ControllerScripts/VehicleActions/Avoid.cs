using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoid : Actions {
    public Avoid(Controller _controller) : base(_controller)
    {
    }

    public override void execute()
    {
            controller.vehicle.FL_wheel.steerAngle = controller.vehicle.max_steer_angle * controller.vehicle.avoid; // multiplies the vehicle steering angle by the avoid multiplier
            controller.vehicle.FR_wheel.steerAngle = controller.vehicle.max_steer_angle * controller.vehicle.avoid;
    }

}
