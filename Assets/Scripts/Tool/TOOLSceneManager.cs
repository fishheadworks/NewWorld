using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TOOLSceneManager : Manager
{
    public static void LoadApp()
    {
        SceneManager.LoadScene((int)Enums.eScene.APP);
    }

    public Enums.eScene CurScene { get; private set; }
    public Ruler CurRuler { get; private set; }
    public void LoadScene(Enums.eScene eScene)
    {
        if (this.CurRuler != null)
            this.CurRuler.Close();

        // :: DOTween 전부 제거
        DOTween.KillAll();

        var async = SceneManager.LoadSceneAsync((int)eScene);
        async.completed += (ele) =>
        {
            while (true)
            {
                if (ele.isDone)
                {
                    this.CurScene = eScene;
                    Debug.LogFormat(
                        ":: {0} Load Complete", eScene.ToString());

                    var ruler = GameObject.FindObjectOfType<Ruler>();
                    ruler.Init();
                    ruler.Open();
                    this.CurRuler = ruler;
                    break;
                }
            }
        };
    }
}
