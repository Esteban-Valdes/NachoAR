using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicaBotones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneAR(){
        SceneManager.LoadScene("SceneAR");
    }

    public void ScenePrincipal(){
        SceneManager.LoadScene("ScenePrincipal");
    }

}
