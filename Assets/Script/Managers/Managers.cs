using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성 보장
    static Managers Instance {  get{ Init(); return s_instance; }} // 유일한 매니저를 갖고온다. Instance가 null 일 때 Init()을 가져온다.

    InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } } //_input을 사용하고 싶으면 Input 이라는 이름으로 불러오겠다

    void Start()
    {
        Init();
    }

    void Update()
    {
        _input.OnUpdate();
    }

    static void Init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers"); //GameObject가 존재하는지 체크
            //만약 없다면
            if (go == null)
            {
                go = new GameObject { name = "@Managers" }; //GameObject 생성하기 기존 Hierarchy 작업, 빈 Managers 게임 오브젝트
                go.AddComponent<Managers>(); //Managers 라는 Component 제작
            }
            DontDestroyOnLoad(go); //삭제되지 않는다.
            s_instance = go.GetComponent<Managers>();    //Managers 라는 GameObject에 있는 부품(Component)인 Managers 가져오기
        }
        
    }
}
