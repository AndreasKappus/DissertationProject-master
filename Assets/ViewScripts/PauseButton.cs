using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

    public Button pause_button;
	
	void Start ()
    {
        // adds a listener for a button press which when pressed invokes the pause method
        GetComponent<Button>().onClick.AddListener(pause);
        
	}

    private void pause()
    {
        // conditional operator, if timescale = 0: resume simulation, else: pause simulation
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0) ? 1f : 0f;
    }
}
