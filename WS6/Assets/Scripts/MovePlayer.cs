using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 10.0f;         // ���� ���������
    public float maxSpeed = 15.0f;      // ����������� ��������
    public float rotationSpeed = 360f;  // �������� �������� (����/���)
    public float mouseSensitivity = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // ������������ X � Z �������� ����� ���, ���� �����:
        rb.freezeRotation = true;
    }

    void Update()
    {
        // �������� ����� (�������� ���������� � Update � �������)
        float mouseX = Input.GetAxis("Mouse X");
        float yaw = mouseX * rotationSpeed * mouseSensitivity * Time.deltaTime;
        transform.Rotate(0f, yaw, 0f);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveVertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // ��������� �����������: ������/����� = z, �����/������ = x
        Vector3 localMovement = new Vector3(moveHorizontal, 0f, moveVertical);

        // ��������� ���� ������������ ��������� ������� ���������
        // (AddRelativeForce ��������� ������� �������)
        rb.AddRelativeForce(localMovement * speed, ForceMode.Force);

        // ����������� �������� �� ����� ��������
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limited = horizontalVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limited.x, rb.linearVelocity.y, limited.z);
        }
    }
}
