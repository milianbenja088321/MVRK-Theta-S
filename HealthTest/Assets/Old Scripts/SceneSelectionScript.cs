using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectionScript : MonoBehaviour
{
    
    public void OpenScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);

    }
}
