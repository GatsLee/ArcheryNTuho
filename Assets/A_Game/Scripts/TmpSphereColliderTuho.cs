using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TmpSphereColliderTuho : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("blueSpear") ||
            collision.gameObject.CompareTag("redSpear"))
       {
           SceneManager.LoadScene("ArcheryScene");
       }
   }
}
