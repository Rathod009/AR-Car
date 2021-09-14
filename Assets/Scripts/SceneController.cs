using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Text txt;
    public static bool isEntry = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        txt.text = isEntry ? "Play" : "Restart";
    }

    public void ChangeScene(string sname)
    {
        SceneNew(sname);   
    }

    public static void SceneNew(string sname)
    {
        SceneManager.LoadScene(sname);
    }

    public void AppExit()
    {
        Application.Quit();
    }
}
