using UnityEngine;

public class MyCharacter : MonoBehaviour
{
    public int Health = 100;                   //체력(변수)를 선언한다
    void Start()
    {
        Health = Health + 100;                 //첫 시작시 100의 체력을 추가한다
    }
    void Update()
    {
        
    }
}
