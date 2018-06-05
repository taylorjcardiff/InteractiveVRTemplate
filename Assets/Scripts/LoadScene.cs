using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour {
    //public int index;
    public string levelName;
    public void loadScene()
    {
        //SceneManager.LoadScene(index);
        SceneManager.LoadScene(levelName);
    }
}
