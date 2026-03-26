using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;

    public Rigidbody rb;

    public bool isGrounded = true;

    public int coinCount = 0;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector3(moveHorizontal * moveSpeed, rb.linearVelocity.y, moveVertical * moveSpeed);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded=true;
        }
    }

    private void OnTriggerEnter(Collider other)              //캐릭터가 특정 지역을 들어갈때(충돌범위) 체크 하는 함수
    {
        if (other.CompareTag("Coin"))                        //Tag 가 코인일경우
        {
            coinCount++;                                     //코인 변수를 1 올린다
            Destroy(other.gameObject);                       //오브젝트 삭제
        }
    }

}
