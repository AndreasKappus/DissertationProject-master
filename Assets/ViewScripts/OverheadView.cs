using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheadView : MonoBehaviour {

    // button and camera declarations to reference the game-objects
    public Button btn_overhead_view;
    public Camera default_view;
    public Camera overhead_view;
    public Camera left_view;
    public Camera right_view;

    public void Start()
    {
        // links the method to an event listener
        GetComponent<Button>().onClick.AddListener(overheadViewSwitch);
    }

    void overheadViewSwitch()
    {
        // disable all cameras and enable overhead_view camera
        default_view.enabled = false;
        overhead_view.enabled = true;
        left_view.enabled = false;
        right_view.enabled = false;
    }
}
