using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions {

    // abstract class to execute specific actions.

    public abstract void execute();

    protected Controller controller;

    public Actions(Controller _controller) // constructor takes the controller as a parameter to enable variables from the controller and vehicle class.
    {
        this.controller = _controller;
        execute();
    }

}
