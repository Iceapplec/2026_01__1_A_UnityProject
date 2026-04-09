using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CubeGameUI : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float Timer;


    void Update()
    {
        Timer += Time.deltaTime;                                        //타이머 시간을 늘려준다.
        TimerText.text = "생존시간 : " + Timer.ToString("0.00");        //문자열 형태로 변환해서 보여준다.
    }
}
