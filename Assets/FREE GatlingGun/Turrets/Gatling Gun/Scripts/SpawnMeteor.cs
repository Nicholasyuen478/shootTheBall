using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{

    public ObjectPooling objectPooling;
    public bool canSpawn = true;
    public float second;

    private float xPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        objectPooling = ObjectPooling.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (canSpawn && Marks.Instance.gameStart)
        {
            xPosition = Random.Range(-3f, 4f);
            objectPooling.SpawnFromPool("Meteor", new Vector3(xPosition, 0, 8), Quaternion.identity);
            canSpawn = false;
            StartCoroutine(spawnCoolDown(second));
        }

    }

    IEnumerator spawnCoolDown(float sec)
    {
        yield return new WaitForSeconds(sec);
        canSpawn = true;
    }
}
