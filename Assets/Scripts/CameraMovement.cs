using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float scrollSpeed = 250f;
    [SerializeField] private float rotateSpeed = 150f;
    [SerializeField] private float shiftMultiplier = 3f;
    [SerializeField] private float controlMultiplier = 0.3f;
    [SerializeField] private float baseSpeed = 1f;
    private float speedMultiplier;
    

    void FixedUpdate()
    {
        // Debug.Log(Input.GetKey(KeyCode.LeftShift));
        speedMultiplier = Input.GetKey(KeyCode.LeftShift) ? shiftMultiplier : baseSpeed;
        speedMultiplier = Input.GetKey(KeyCode.LeftControl) ? controlMultiplier : speedMultiplier;

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * moveSpeed * speedMultiplier * Time.deltaTime / Time.timeScale);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * moveSpeed * speedMultiplier * Time.deltaTime / Time.timeScale);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * moveSpeed * speedMultiplier * Time.deltaTime / Time.timeScale);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * moveSpeed * speedMultiplier * Time.deltaTime / Time.timeScale);
        }

        GetComponent<Camera>().fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime / Time.timeScale;
        GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 30, 90);


        if (!Input.GetKey(KeyCode.Tab) && (Input.GetMouseButton(0) || Input.GetMouseButton(1)))
        {
            //Clamp this
            transform.eulerAngles += rotateSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime / Time.timeScale;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}