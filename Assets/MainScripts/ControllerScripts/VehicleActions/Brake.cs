using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : Actions {
    public Brake(Controller _controller) : base(_controller)
    {
    }

    public override void execute()
    {
        // sets motor torques to 0, then sets brake torque to 100
        controller.vehicle.FL_wheel.motorTorque = 0;
        controller.vehicle.FR_wheel.motorTorque = 0;

        controller.vehicle.FL_wheel.brakeTorque = 100;
        controller.vehicle.FR_wheel.brakeTorque = 100;

    }

}
