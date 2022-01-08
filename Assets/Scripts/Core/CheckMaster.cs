using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindObjectOfType<Master>() == null)
            SceneManager.LoadSceneAsync((int)Enums.eScene.LOGIN);
    }
}
