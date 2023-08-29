using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameoverMenu : MonoBehaviour
{
    public void Retrygame()
    {
        SceneManager.LoadScene(0);
    }
}
