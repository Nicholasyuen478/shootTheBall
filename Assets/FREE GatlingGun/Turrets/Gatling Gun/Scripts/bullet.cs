using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitEffect;
    public ObjectPooling objectPooling;
    private Rigidbody rb;
    private GameObject effect;
    public float volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objectPooling = ObjectPooling.Instance;
        SoundManagement.Instance.playShootSound();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("other" + other);
        shakeCamera.Instance.shake(1f, .1f);
        // audioSource.PlayOneShot(SoundManagement.Instance.shootSFX, 0.5f);
        if (other.gameObject.tag == "Enemy")
        {
            SoundManagement.Instance.playHitSound();
            effect = objectPooling.SpawnFromPool("hitEffect", transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            Invoke("setActiveDelay", 2f);
            // Destroy(effect, 5f);
            // Destroy(gameObject);
            Marks.Instance.Score++;
        }
    }
    public void setActiveDelay()
    {
        effect?.SetActive(false);
    }

}
