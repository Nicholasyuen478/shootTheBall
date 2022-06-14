using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{


    public Camera cam;
    public Rigidbody rb;
    public GameObject head;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public ObjectPooling objectPooling;

    private float bulletForce = 20;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectPooling = ObjectPooling.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mousePos = raycastHit.point;
        }
        Vector3 lookDir = mousePos - rb.position;
        // Debug.Log("lookDir" + lookDir);
        float angle = Mathf.Atan2(lookDir.z, lookDir.x) * Mathf.Rad2Deg - 90f;
        // Debug.Log("angle" + angle);
        head.transform.eulerAngles = new Vector3(0f, -angle, 0f);
        if (Input.GetButtonDown("Fire1") && Marks.Instance.gameStart)
        {
            Shoot();
        }
        // Debug.Log("mousePos"+ mousePos);
    }

    void FixedUpdate()
    {

    }

    void Shoot()
    {
        // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, head.transform.rotation.y, 90));
        GameObject bullet = objectPooling.SpawnFromPool("Bullet", firePoint.position, Quaternion.Euler(0, head.transform.rotation.y, 90));
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }


}
