using UnityEngine;

public class CameraBreathing : MonoBehaviour
{
    [Header("Posición")]
    [Tooltip("Distancia máxima que se moverá la cámara desde su punto inicial.")]
    public float intensidadPosicion = 0.05f;

    [Tooltip("Velocidad del movimiento de posición (valores bajos = más lento).")]
    public float velocidadPosicion = 0.5f;

    [Header("Rotación (Opcional)")]
    [Tooltip("Ángulo máximo de rotación sutil.")]
    public float intensidadRotacion = 0.2f;

    [Tooltip("Velocidad de la rotación.")]
    public float velocidadRotacion = 0.3f;

    // Variables internas para guardar el origen
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    // Offsets aleatorios para que X, Y y Z no se muevan idénticos
    private float seedX;
    private float seedY;
    private float seedZ;

    void Start()
    {
        // Guardamos el punto y rotación de origen en el mundo
        posicionInicial = transform.localPosition;
        rotacionInicial = transform.localRotation;

        // Generamos semillas aleatorias al iniciar para variar la trayectoria
        seedX = Random.Range(0f, 100f);
        seedY = Random.Range(100f, 200f);
        seedZ = Random.Range(200f, 300f);
    }

    void Update()
    {
        // Usamos Time.time que es independiente del framerate
        float tiempoPos = Time.time * velocidadPosicion;
        float tiempoRot = Time.time * velocidadRotacion;

        // --- CÁLCULO DE POSICIÓN ---
        // Remapeamos el PerlinNoise de [0, 1] a [-1, 1]
        float offsetX = (Mathf.PerlinNoise(seedX + tiempoPos, 0f) * 2f - 1f) * intensidadPosicion;
        float offsetY = (Mathf.PerlinNoise(seedY + tiempoPos, 0f) * 2f - 1f) * intensidadPosicion;

        Vector3 nuevaPosicion = posicionInicial + new Vector3(offsetX, offsetY, 0f);

        // --- CÁLCULO DE ROTACIÓN SUTIL ---
        float rotX = (Mathf.PerlinNoise(seedX + tiempoRot, 10f) * 2f - 1f) * intensidadRotacion;
        float rotY = (Mathf.PerlinNoise(seedY + tiempoRot, 10f) * 2f - 1f) * intensidadRotacion;
        float rotZ = (Mathf.PerlinNoise(seedZ + tiempoRot, 10f) * 2f - 1f) * (intensidadRotacion * 0.5f);

        Quaternion nuevaRotacion = rotacionInicial * Quaternion.Euler(rotX, rotY, rotZ);

        // Aplicamos la posición y rotación relativas
        transform.localPosition = nuevaPosicion;
        transform.localRotation = nuevaRotacion;
    }
}
