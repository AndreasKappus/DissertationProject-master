using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightView : MonoBehaviour {
    // button and camera declarations to reference the game-objects
    public Button btn_right_view;
    public Camera default_view;
    public Camera overhead_view;
    public Camera left_view;
    public Camera right_view;

    public void Start()
    {
        // links the method to an event listener
        GetComponent<Button>().onClick.AddListener(rightViewSwitch);
    }

    void rightViewSwitch()
    {
        // disable all cameras and enable right_view camera
        default_view.enabled = false;
        overhead_view.enabled = false;
        left_view.enabled = false;
        right_view.enabled = true;
    }
}
