using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float initialDistanceToTarget = 40;
    [SerializeField] private float rotationSpeedX = 10f;
    [SerializeField] private float rotationSpeedY = 10f;
    [SerializeField] private float zoomSpeed = 30f;
    [SerializeField] private float minDistanceToTarget = 15f;
    [SerializeField] private float maxDistanceToTarget = 75f;
    [SerializeField] private float fadeSpeed = 6f;

    private float distanceToTarget;
    private float currentXRotation;
    private float currentYRotation;
    private float targetDistanceToTarget;
    private float targetXRotation;
    private float targetYRotation;

    void Start()
    {
        distanceToTarget = initialDistanceToTarget;
        currentXRotation = transform.eulerAngles.y;
        currentYRotation = transform.eulerAngles.x;
        targetDistanceToTarget = distanceToTarget;
        targetXRotation = currentXRotation;
        targetYRotation = currentYRotation;
    }

    void LateUpdate()
    {
        // Actualizar los valores objetivo con los cambios de entrada
        if (Input.GetMouseButton(0))
        {
            targetXRotation += Input.GetAxis("Mouse X") * rotationSpeedX;
            targetYRotation -= Input.GetAxis("Mouse Y") * rotationSpeedY;
            targetYRotation = Mathf.Clamp(targetYRotation, 10f, 90f);
        }

        targetDistanceToTarget -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        targetDistanceToTarget = Mathf.Clamp(targetDistanceToTarget, minDistanceToTarget, maxDistanceToTarget);

        // Interpolar suavemente hacia los valores objetivo
        currentXRotation = Mathf.Lerp(currentXRotation, targetXRotation, Time.deltaTime * fadeSpeed);
        currentYRotation = Mathf.Lerp(currentYRotation, targetYRotation, Time.deltaTime * fadeSpeed);
        distanceToTarget = Mathf.Lerp(distanceToTarget, targetDistanceToTarget, Time.deltaTime * fadeSpeed);

        // Calcular la posición y la rotación
        Quaternion rotation = Quaternion.Euler(currentYRotation, currentXRotation, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distanceToTarget);
        Vector3 position = rotation * negDistance + target.position;

        // Aplicar la posición y la rotación a la cámara
        cam.transform.rotation = rotation;
        cam.transform.position = position;
    }
}