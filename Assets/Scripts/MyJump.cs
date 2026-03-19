using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MyJump : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float power = 200f;                              //점프 힘 선언
    public Text timeUI;
    public float Timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;                      //타이머를 상승 시키고
        timeUI.text = Timer.ToString();                      //타이머 숫자를 문자열 변수로 변경한 후 표시 한다.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            power = power + Random.Range(-100, 200);         //Power를 랜덤 값을 더해서 변형시킨다 
            rigidbody.AddForce(transform.up * power);        //AddForce power 200의 힘 값으로 위쪽으로 힘을 줌
        }

        if(this.gameObject.transform.position.y > 5.5 || this.gameObject.transform.position.y < -3.5)
        {
            // 이 오브젝으의 y 좌표점 위치가 5보다 크거나 -3 보다 작을경우 
            Destroy(this.gameObject);             // 오브젝트 파괴
        }
    }
}
