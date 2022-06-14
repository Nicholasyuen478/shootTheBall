using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float force = 5;
    private Rigidbody rb;

    public List<Material> MaterialsList;

    private int meteorForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Marks.Instance.challenge)
        {
            meteorForce = Random.Range(20, 40);
        }
        else
        {
            meteorForce = Random.Range(5, 10);
        }
        rb.AddForce(Vector3.back * force * meteorForce);
    }
    void OnEnable()
    {

        Debug.Log("Count" + MaterialsList.Count);
        GetComponent<Renderer>().material = MaterialsList[Random.Range(0, MaterialsList.Count)];
    }
}
