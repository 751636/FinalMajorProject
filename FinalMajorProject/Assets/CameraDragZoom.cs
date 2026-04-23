using UnityEngine;

public class CameraDragZoom : MonoBehaviour
{
    [Header("Pan Settings")]
    public int mouseButton = 0;
    public float basePanSpeed = 1f;

    private Vector3 lastMousePosition;

    [Header("Zoom Settings")]
    public float zoomSpeed = 5f;
    public float minZoom = 3f;
    public float maxZoom = 15f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        HandlePan();
        HandleZoom();
    }

    void HandlePan()
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(mouseButton))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;

            // 🔑 Scale pan speed based on zoom level
            float zoomScale = cam.orthographicSize;

            Vector3 move = new Vector3(-delta.x, -delta.y, 0f) 
                           * basePanSpeed 
                           * zoomScale 
                           * Time.deltaTime;

            transform.Translate(move);

            lastMousePosition = Input.mousePosition;
        }
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}