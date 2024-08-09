using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcheryGameController : MonoBehaviour
{
    public int playerScore = 0;

    public int closePoint = 10;
    public int midPoint = 30;
    public int farPoint = 50;
    public int playerArrowCount = 0;

    private int maxArrowCount = 10;

    private static ArcheryGameController instance;

    public static ArcheryGameController Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerArrowCount >= maxArrowCount)
        {
            //게임 종료 처리
            //유저의 게임 점수: playerScore를 서버로 보내기
            //유저의 게임을 했다는 정보(bool)를 서버로 보내기
            // 씬을 나가는 처리를 넣어도 됨
        }
    }
}
