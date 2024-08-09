using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuhoGameController : MonoBehaviour
{
    public int playerOneScore = 0;
    //public int playerTwoScore = 0;
    public int playerOneCount = 0;
    //public int playerTwoCount = 0;


    public int smallPoint = 10;
    public int largePoint = 20;
    //public int playerTurn = 0; // 0:One(Blue) 1:Two(Red)

    public bool isScored = false; 

    private static TuhoGameController instance;

    public static TuhoGameController Instance
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
        if (playerOneCount == 6)
        {
            //���� ���� ó��
            //������ ���� ����: playerOneScore�� ������ ������
            //������ ������ �ߴٴ� ����(bool)�� ������ ������
            // ���� ������ ó���� �־ ��
        }
    }
}
