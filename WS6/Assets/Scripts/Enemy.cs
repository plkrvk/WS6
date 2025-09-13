using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject cubePiecePrefab;
    public float explodeForce = 500f;
    [SerializeField] private TextMeshProUGUI textScore; // drag UI field here

    private void Start()
    {
        // При старте можно установить начальное значение текста, если Progress уже есть
        if (Progress.Instance != null)
            textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ExplodeCube();
            AddScore();
        }
    }

    private void AddScore()
    {
        if (Progress.Instance != null)
        {
            Progress.Instance.PlayerInfo.Score += 10;
            if (textScore != null)
                textScore.text = "Score: " + Progress.Instance.PlayerInfo.Score.ToString();

            // Условие перезапуска сцены при достижении 100 очков
            if (Progress.Instance.PlayerInfo.Score >= 100)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainLevel");
            }
        }
    }

    private void ExplodeCube()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int z = 0; z < 4; z++)
                {
                    Vector3 piecePosition = transform.position + new Vector3(x, y, z) * 0.5f;
                    GameObject piece = Instantiate(cubePiecePrefab, piecePosition, Quaternion.identity);
                    Rigidbody pieceRigidbody = piece.GetComponent<Rigidbody>();
                    if (pieceRigidbody != null)
                        pieceRigidbody.AddExplosionForce(explodeForce, transform.position, 5f);
                }
            }
        }
        // можно воспроизвести звук разрушения, если AudioSource есть на объекте
        AudioSource a = GetComponent<AudioSource>();
        if (a != null) a.Play();

        Destroy(gameObject);
    }
}
