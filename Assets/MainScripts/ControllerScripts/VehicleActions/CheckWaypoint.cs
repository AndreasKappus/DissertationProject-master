using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWaypoint : Actions {
    public CheckWaypoint(Controller _controller) : base(_controller)
    {
    }

    public override void execute()
    {
        if(Vector3.Distance(controller.vehicle.transform.position, controller.vehicle.nodes[controller.vehicle.current_node].position) < 1f) // checks the distance from the car to the current node's position
        {
            if (controller.vehicle.current_node == controller.vehicle.nodes.Count - 1) // check if its on the last node, if so then, go back to start node, this enables the waypoint objects to be constantly looping around
            {
                controller.vehicle.current_node = 0;
            }
            else
            {
                controller.vehicle.current_node++;
            }
        }
    }

}
