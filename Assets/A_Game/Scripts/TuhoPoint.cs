using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuhoPoint : MonoBehaviour
{
    private bool isThrown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "smallScore")
        {
            if (this.isThrown == false && this.tag == "blueSpear")
            {
                UpdatePlayerOnePoint(TuhoGameController.Instance.smallPoint);
            }
        }
        else if (other.gameObject.tag == "largeScore")
        {
            if (this.isThrown == false && this.tag == "blueSpear")
            {
                UpdatePlayerOnePoint(TuhoGameController.Instance.largePoint);
            }
        }
        else if (other.gameObject.tag == "Floor")
        {
            TuhoGameController.Instance.playerOneCount++;
            this.isThrown = true;
        }
    }

    void UpdatePlayerOnePoint(int curPoint)
    {
        TuhoGameController.Instance.playerOneScore += curPoint;
        TuhoGameController.Instance.playerOneCount++;
        this.isThrown = true;
    }
}
