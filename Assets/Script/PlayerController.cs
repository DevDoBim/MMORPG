using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 벡터 연산
/*// 1. 위치 벡터
// 2. 방향 벡터
struct MyVector
{
    public float x;
    public float y;
    public float z;

    //      +
    //   +  +
    //+  +  +  
    public float magnitude { get { return Mathf.Sqrt(x * x+ y * y + z * z); } } // 삼각형의 길이(거리,크기) 구하기, 방향 벡터 크기 구하기 magnitude
    public MyVector normalized { get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); } } //실제 방향 구하기 -> 값이 1이 나오는 Vector가 완성된다.
    //normalized 는 단위벡터이다.
    public MyVector(float x, float y, float z) { this.x = x; this.y = y; this.z = z; }


    #region 벡터의 계산 방식
    public static MyVector operator + (MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z); //벡터 값 연산, MyVector의 계산 구조식
    }

    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z); 
    }
    public static MyVector operator * (MyVector a, float d) 
    {
        return new MyVector(a.x * d, a.y * d, a.z *d);
    }
    #endregion
}*/
#endregion


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        #region 벡터 연산
        /*MyVector to = new MyVector(10.0f, 0.0f, 0.0f); // MyVector을 이용하여 위치 지정
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);
        MyVector dir = to - from; //(5.0f, 0.0f, 0.0f); 벡터의 연산 방식

        dir = dir.normalized; //(1.0f, 0.0f, 0.0f);

        MyVector newPos = from + dir * _speed; //포지션을 이동하고 싶을 때

        //form 부터 원하는 방향(dir)로 _speed 만큼 이동

        //방향 벡터
        //1. 거리(크기)     5   magnitude
        //2. 실제 방향      -> */
        #endregion

        Managers.Input.KeyAction -= OnKeyborad; //만약 다른 곳에서 불러온 상태라면 끈 후 불러오겠다 오류 방지
        Managers.Input.KeyAction += OnKeyborad; //Input 매니저에게 어떠한 키가 입력되면 OnKeyborad를 실행시켜 주세요
    }

    //GameObject(Player)
    //Transform
    //PlayerController (*)

    void Update()
    {
       
    }
    void OnKeyborad()
    {
        //절대 회전값
        //transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);

        // +- delta
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));


        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.2f);
            transform.position += (Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.2f);
            transform.position += (Vector3.back * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.2f);
            transform.position += (Vector3.left * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.2f);
            transform.position += (Vector3.right * Time.deltaTime * _speed);
        }
    }
}
