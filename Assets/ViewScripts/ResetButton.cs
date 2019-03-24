using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour {

    public Button reset_button;

	void Start () {
        // event listener to call method when triggered
        GetComponent<Button>().onClick.AddListener(resetSimulation);
	}

    private void resetSimulation()
    {
        // loads the current scene again as a way of resetting the program
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
