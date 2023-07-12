using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float movementSpeed = 15f;
    public float acceleration = 0.8f;
    public float maxSpeed = 100f;
    public float jumpForce = 8f;

    private float currentSpeed = 11f;
    private bool canJump = true;
    private Rigidbody rb;


    private void Start()
    {          
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        // ���������� �������� ������ � ������� �������� ����
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // �������� ������ �������������
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        transform.Translate(Vector3.forward * -currentSpeed * Time.deltaTime);
        PlayerPrefs.SetInt("currentSpeed", (int)currentSpeed);

        // ���������� ����� � ������ � ������� ������ "A" � "D"
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * -horizontalInput * movementSpeed * Time.deltaTime);

        // ������
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �������� ������� � ������ ��� ����������� ������
        if (collision.gameObject.CompareTag("Terrain"))
        {
            canJump = true;
        }
    }
}



/*public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Transform characterTransform; // ������ �� ��������� Transform ���������

    public float speed = 500f;
    public float sensitivity = 1f;
    public float rotationSpeed = 10f;
    public float RotationX = 0f;
    public float RotationY = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterTransform = transform; // �������� ������ �� ��������� Transform ���������
        Physics.gravity *= 9; // �������� ������������� ����������
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ����������� ���� ���������� � ��������� ������������ ���������
        Vector3 movement = characterTransform.TransformDirection(new Vector3(-h, 0f, -v)) * speed;
        rb.velocity = movement;

        // ������������ �������� �� ����������� ��������
        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement.normalized);
            characterTransform.rotation = Quaternion.Lerp(characterTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        RotationY += mouseX * sensitivity;

        // ������� ��������� ������ ��� ��������� ��� Y
        characterTransform.localEulerAngles = new Vector3(0f, RotationY, 0f);
    }
}*/

/*using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 50f;
    public float sensitivity = 1f;

    public float RotationX = 0f;
    public float RotationY = 0f;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0f, v) * speed;
        transform.Translate(movement);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        RotationY += mouseX * sensitivity;
        RotationY %= 360f;

        Mathf.Clamp(RotationY, -180, 180);

        RotationX -= mouseY * sensitivity;

        Mathf.Clamp(RotationX, -90, 90);
        transform.localEulerAngles = new Vector3(RotationX, RotationY, 0f);
    }
}
*/