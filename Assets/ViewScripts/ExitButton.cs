using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {

    public Button btn_exit;

	void Start () {

        GetComponent<Button>().onClick.AddListener(exitButtonPressed);

	}
	
    // button press only works when running the executable file
	void exitButtonPressed()
    {
        Application.Quit();
    }
}
