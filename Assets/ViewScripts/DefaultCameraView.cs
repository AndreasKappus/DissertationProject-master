using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultCameraView : MonoBehaviour {

    // button and camera declarations to reference the game-objects
    public Button btn_default_view;
    public Camera default_view;
    public Camera overhead_view;
    public Camera left_view;
    public Camera right_view;

    public void Start()
    {
        // links the method to an event listener
        GetComponent<Button>().onClick.AddListener(defaultViewSwitch);
    }

    void defaultViewSwitch()
    {
        // disable all cameras and enable the default_view camera
        default_view.enabled = true;
        overhead_view.enabled = false;
        left_view.enabled = false;
        right_view.enabled = false;
    }
}
