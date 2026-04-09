using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public CubeGenerator[] generatedCubes = new CubeGenerator[5];

    public float timer = 0.0f;
    public float interval = 3.0f;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            RandomizeCubeAcitivation();
            timer = 0.0f;
        }
        
    }


    public void RandomizeCubeAcitivation()              
    {
        for (int i = 0; i < generatedCubes.Length; i++)      //각 규브 생성 함수를 랜덤하게 호출
        {
            int randomNum = Random.Range(0, 2);              //랜덤값 0, 1 (50% 확률로 큐브 생성)

            if(randomNum == 1)                               //랜덤값이 1일 경우
            {
                generatedCubes[i].GenCube();                 //큐브 클래스의 생성 함수를 호출
            }
        }
    }

}
