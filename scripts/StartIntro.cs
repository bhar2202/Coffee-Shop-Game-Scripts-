using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartIntro : MonoBehaviour
{
    public void loadIntro()
    {
        SceneManager.LoadScene(1);
    }
}
