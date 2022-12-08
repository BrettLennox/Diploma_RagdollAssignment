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
        //sets targetFrameRate to the the current options value selected on the dropdown (converted from string to int value)
        Application.targetFrameRate = int.Parse(FrameRate.options[FrameRate.value].text);
        switch (Application.targetFrameRate)
        {
            //if value 
            case 60: //is 60
                QualitySettings.vSyncCount = 1; //sets vSyncCount to 1
                break;
            case 30: //is 30
                QualitySettings.vSyncCount = 2; //sets vSyncCount to 2
                break;
            case 20: //is 20
                QualitySettings.vSyncCount = 3; //sets vSyncCount to 3
                break;
        }
    }
}