using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    Image BarImage;
    [SerializeField]
    TextMeshProUGUI progressTxt;

    private int currentProg = 0;

    public int MaxProgress;
    
    public int CurrentProgress
    {
        get { return currentProg; }
        set
        {
            currentProg = value;
            UpdateProgress();
        }
    }


    #region Unity Events
    private void Awake()
    {
        if (BarImage == null)
        {
            BarImage = this.GetComponent<Image>();
            progressTxt = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }
    }

    #endregion


    #region Progress Methods
    private void UpdateProgress()
    {
        if(CurrentProgress<=MaxProgress)
        {
          BarImage.fillAmount = currentProg / (float)MaxProgress;
          progressTxt.text = $"Loading . . . ({(currentProg / (float)MaxProgress) * 100}%)";
        }
    }

    #endregion
}
