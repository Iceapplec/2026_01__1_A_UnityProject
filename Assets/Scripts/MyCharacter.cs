using UnityEngine;

public class MyCharacter : MonoBehaviour
{
    public int Health = 20;                   //체력(변수)를 선언한다
    public float Timer = 2f;
    void Start()
    {
        Health = Health + 100;                 //첫 시작시 100의 체력을 추가한다
    }
    void Update()
    {
        Timer = Timer - Time.deltaTime;

        if(Timer < 0)
        {
            Timer = 1.0f;
            Health = Health - 20;
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health = Health + 2;
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
