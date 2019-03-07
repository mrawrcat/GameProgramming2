using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    private Scene scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scneSwitch(string scnename)
    {
        SceneManager.LoadScene(scnename);
    }
    public void sceneswwitch()
    {
        SceneManager.LoadScene("asset test 3");
    }
    public void restartlvl()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
