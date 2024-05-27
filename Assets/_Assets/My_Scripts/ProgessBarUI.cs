using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgessBarUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image progressBar;
    [SerializeField] private CuttingCounter cuttingCounter;
    void Start()
    {
        cuttingCounter.OnCuttingProgressChange += CuttingCounter_OnCuttingProgressChange;
        progressBar.fillAmount = 0;
        hideProgressBar();

    }
    private void CuttingCounter_OnCuttingProgressChange(object sender, CuttingCounter.CuttingProgressChangeEventArgs e)
    {
        progressBar.fillAmount = e.progressNormalized;
        if(e.progressNormalized == 1|| e.progressNormalized == 0){
            hideProgressBar();
        }else{
            showProgressBar();
        }


    }

    private void showProgressBar()
    {
       gameObject.SetActive(true);
    }
    private void hideProgressBar()
    {
        gameObject.SetActive(false);
    }

}
