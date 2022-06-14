using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseline : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame

    public GameObject RestartBtn;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("other213" + other);
        if (Marks.Instance.gameStart && other.gameObject.tag == "Enemy")
        {
            Marks.Instance.gameStart = false;
            RestartBtn.SetActive(true);
        }
    }
}
