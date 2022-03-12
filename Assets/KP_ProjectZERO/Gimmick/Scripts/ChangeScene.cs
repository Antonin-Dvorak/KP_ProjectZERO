using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void PushStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void ChangeToClearScene()
    {
        SceneManager.LoadScene("Clear");
    }
}
