using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
            if (gameObject.transform.position.y <= -10)
            {
            Application.LoadLevel("SampleScene");
            }
    }
}
