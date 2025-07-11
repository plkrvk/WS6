using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Rigidbody cube1;
    public Rigidbody cube2;
    public Rigidbody cube3;
    public GameObject winText;

    private int winningCube;

    void Start()
    {
        // Выбираем случайный куб (1, 2 или 3)
        winningCube = Random.Range(1, 4);
        Debug.Log("Winning cube: " + winningCube); // Для проверки в консоли
    }

    public void ChooseCube(int cubeNumber)
    {
        // Включаем гравитацию для всех кубов
        cube1.useGravity = true;
        cube2.useGravity = true;
        cube3.useGravity = true;

        // Если выбран правильный куб
        if (cubeNumber == winningCube)
        {
            // Отключаем гравитацию у него
            if (cubeNumber == 1) cube1.useGravity = false;
            else if (cubeNumber == 2) cube2.useGravity = false;
            else if (cubeNumber == 3) cube3.useGravity = false;

            // Показываем текст "YOU WIN"
            winText.SetActive(true);
        }
    }
}
