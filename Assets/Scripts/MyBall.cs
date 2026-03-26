using System.Xml.Serialization;
using UnityEngine;

public class MyBall : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)      //Unity 가 지원하는 충돌 체크 함수
    {
        Debug.Log(collision.gameObject.name + "와 충돌함"); //충돌체의 이름을 기억한다

        if (collision.gameObject.tag == "Ground")           //충돌이 일어난 물체의 Tag가 Ground인 경우
        {
            Debug.Log("땅과 충돌");
        }
    }

    //OnTriggerStay

    void OnTriggerEnter(Collider other)                     //플레이어가 특정 지역을 들어갈때(충돌범위) 체크 함수
    {
        Debug.Log("Trigger 안으로 들어옴");
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger 밖으로 나감");
    }
}
