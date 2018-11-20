using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Buttons : MonoBehaviour {
    public Scene goToScene;
    public void LoadMyScene(string SceneToGoTo)
    {
        SceneManager.LoadScene(SceneToGoTo);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
