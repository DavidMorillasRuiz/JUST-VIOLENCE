using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Volver : MonoBehaviour
{
    public float WaitSec;
    private int WaitSecInt;
    public Text text;



    private void FixedUpdate()
    {
        if(WaitSec > 0)
        {
            WaitSec -= Time.deltaTime;
            WaitSecInt = (int)WaitSec;
            text.text = WaitSecInt.ToString();
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }


}
