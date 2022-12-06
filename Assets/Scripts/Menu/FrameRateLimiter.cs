using UnityEngine;
using UnityEngine.UI;

public class FrameRateLimiter : MonoBehaviour
{
    public Dropdown FrameRate;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 1;//or 2 or 3 or 4; essentially delaying frames

        Application.targetFrameRate = 60; //sets the targetFrameRate to 60 on start
    }

    public void UpdateFrameRate()
    {
        Application.targetFrameRate = int.Parse(FrameRate.options[FrameRate.value].text);
        switch (Application.targetFrameRate)
        {
            case 60:
                QualitySettings.vSyncCount = 1;
                break;
            case 30:
                QualitySettings.vSyncCount = 2;
                break;
            case 20:
                QualitySettings.vSyncCount = 3;
                break;
        }
    }
}