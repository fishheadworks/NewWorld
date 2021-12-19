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

    public int MaxProgress;

    public float CurrentProgress
    {
        get { return CurrentProgress; }
        set
        {
            CurrentProgress = value;
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
        BarImage.fillAmount = CurrentProgress / MaxProgress;
        progressTxt.text = $"Loading . . . ({(CurrentProgress / MaxProgress) * 100}%)";
    }

    #endregion
}
