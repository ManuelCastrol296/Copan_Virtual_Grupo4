using UnityEngine;
using UnityEngine.InputSystem;

public class FPS : MonoBehaviour
{
    public float velocidad = 3f;
    public float sensibilidad = 2f;
    public Transform ojos;

    CharacterController controller;
    float rotX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (ojos == null) ojos = transform.GetChild(0);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mouse
        float mouseX = 0, mouseY = 0;
        if (Mouse.current != null)
        {
            mouseX = Mouse.current.delta.ReadValue().x * 0.1f;
            mouseY = Mouse.current.delta.ReadValue().y * 0.1f;
        }

        rotX -= mouseY * sensibilidad;
        rotX = Mathf.Clamp(rotX, -80f, 80f);
        ojos.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.Rotate(Vector3.up * mouseX * sensibilidad);

        // WASD con Input System nuevo
        Vector2 input = Vector2.zero;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) input.y += 1;
            if (Keyboard.current.sKey.isPressed) input.y -= 1;
            if (Keyboard.current.aKey.isPressed) input.x -= 1;
            if (Keyboard.current.dKey.isPressed) input.x += 1;
        }

        Vector3 move = transform.right * input.x + transform.forward * input.y;
        controller.SimpleMove(move * velocidad);

        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
            Cursor.lockState = CursorLockMode.None;
    }
}