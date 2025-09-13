using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletVelocity = 20f;
    public AudioClip fireClip;         // �����������: ���� ��������
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (BulletPrefab == null) { Debug.LogWarning("BulletPrefab not assigned."); return; }

            GameObject newBullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            if (rb != null)
                rb.linearVelocity = transform.forward * BulletVelocity;
            else
                Debug.LogWarning("Bullet prefab has no Rigidbody!");

            if (audioSource != null && fireClip != null)
                audioSource.PlayOneShot(fireClip);
        }
    }
}
