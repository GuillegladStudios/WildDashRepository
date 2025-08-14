using System.Collections;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.InputSystem;

public class JugadorScript : MonoBehaviour
{
    [SerializeField] private float velocidadInicial = 5f; // Velocidad inicial del jugador
    [SerializeField] private float velocidadIncremento = 0.5f; // Incremento de velocidad en el tiempo
    [SerializeField] private float velocidadIncrementoIntervalo = 10.0f;
    [SerializeField] private float velocidadActiveCorrer = 5.0f; // Velocidad activa para correr

    [SerializeField] private float fuerzaSalto = 10f; // Fuerza del salto del jugador
    [SerializeField] private float fuerzaSaltoAdicional = 40.0f; // Fuerza adicional al saltar
    [SerializeField] private float maxTiempoSalto = 0.35f; // Tiempo máximo de salto
    [SerializeField] private float MultiplicadorGravedadCayendo = 2.0f; // Multiplicador de gravedad al caer

    [SerializeField] private InputActionReference accionSaltar; // Referencia a la acción de salto

    [SerializeField] private VoidEvent OnSaltar; // Evento que se dispara al saltar 
    [SerializeField] private VoidEvent OnCorrer; // Evento que se dispara al correr
    [SerializeField] private VoidEvent OnCaminar; // Evento que se dispara al caminar

    private float _velocidad; // Velocidad actual del jugador
    private bool _estaCorriendo = false; // Indica si el jugador está corriendo
    private Rigidbody2D miRigidBody; // Referencia al Rigidbody2D del jugador
    private Coroutine _incrementarVelocidadRutina; // Coroutine para incrementar la velocidad del jugador

    private bool _estaSaltando = false; // Indica si el jugador está saltando
    private float _tiempoSalto; // Contador de tiempo para el salto
    private float _escalaGravedad; // Escala de gravedad del Rigidbody2D

    private void Awake()
    {
        miRigidBody = GetComponent<Rigidbody2D>(); // Obtener el Rigidbody2D del jugador
        _escalaGravedad = miRigidBody.gravityScale; // Guardar la escala de gravedad actual del Rigidbody2D
    }
    private void Start()
    {
        _velocidad = velocidadInicial; // Inicializar la velocidad del jugador 
    }
    private void OnEnable()
    {
        accionSaltar.action.Enable(); // Habilitar la acción de salto

        accionSaltar.action.started += OnSaltoInicio; // Registrar el evento de inicio del salto
        accionSaltar.action.canceled += OnSaltoCancelado; // Registrar el evento de cancelación del salto


        _incrementarVelocidadRutina = StartCoroutine(IncrementaVelocidadRutina()); // Iniciar la coroutine para incrementar la velocidad

    }

    private void OnDisable()
    {
        accionSaltar.action.started -= OnSaltoInicio; // Desregistrar el evento de inicio del salto
        accionSaltar.action.canceled -= OnSaltoCancelado; // Desregistrar el evento de cancelación del salto

        accionSaltar.action.Disable(); // Deshabilitar la acción de salto

        if (_incrementarVelocidadRutina != null)
        {
            StopCoroutine(_incrementarVelocidadRutina); // Detener la coroutine de incremento de velocidad
        }
    }

    private IEnumerator IncrementaVelocidadRutina()
    {
        while (true) // Bucle infinito para incrementar la velocidad
        {
            yield return new WaitForSeconds(velocidadIncrementoIntervalo); // Esperar el intervalo de tiempo
            _velocidad += velocidadIncremento; // Incrementar la velocidad del jugador
            if (_velocidad >= velocidadActiveCorrer && !_estaCorriendo)
            {
                _estaCorriendo = true; // Marcar que el jugador está corriendo
                OnCorrer.Raise(); // Disparar el evento de correr
            }
        }
    }
    public void ActivaCaminar()
    {
        _velocidad = Mathf.Max(velocidadInicial, _velocidad / 2);
        if (_incrementarVelocidadRutina != null)
        {
            StopCoroutine(_incrementarVelocidadRutina);
            _incrementarVelocidadRutina = StartCoroutine(IncrementaVelocidadRutina());
        }
        if (_estaCorriendo && _velocidad < velocidadActiveCorrer)
        {
            _estaCorriendo = false;
            OnCaminar.Raise();
        }
    }

    private void OnSaltoInicio(InputAction.CallbackContext context)
    {
        if (Mathf.Abs(miRigidBody.velocity.y) < 0.01f && !_estaSaltando) // Verificar si el jugador está en el suelo
        {
            _estaSaltando = true; // Marcar que el jugador está saltando
            _tiempoSalto = maxTiempoSalto; // Reiniciar el contador de tiempo de salto
            miRigidBody.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse); // Aplicar fuerza de salto inicial
            OnSaltar.Raise(); // Disparar el evento de salto
        }
    }
    public void OnSaltoInicio()
    {
        if (Mathf.Abs(miRigidBody.velocity.y) < 0.01f && !_estaSaltando) // Verificar si el jugador está en el suelo
        {
            _estaSaltando = true; // Marcar que el jugador está saltando
            _tiempoSalto = maxTiempoSalto; // Reiniciar el contador de tiempo de salto
            miRigidBody.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse); // Aplicar fuerza de salto inicial
            OnSaltar.Raise(); // Disparar el evento de salto
        }
    }

    private void OnSaltoCancelado(InputAction.CallbackContext context)
    {
        if (_estaSaltando) // Verificar si el jugador está saltando
        {
            _estaSaltando = false; // Marcar que el jugador ya no está saltando
        }
    }

    public void OnSaltoCancelado()
    {
        if (_estaSaltando) // Verificar si el jugador está saltando
        {
            _estaSaltando = false; // Marcar que el jugador ya no está saltando
        }
    }

    private void FixedUpdate()
    {
        miRigidBody.velocity = new Vector2(_velocidad, miRigidBody.velocity.y); // Actualizar la velocidad del jugador

        if (_estaSaltando && _tiempoSalto > 0) // Maneja el salto si el boton aun esta presionado
        {
            miRigidBody.AddForce(new Vector2(0, fuerzaSaltoAdicional), ForceMode2D.Force); // Aplicar fuerza adicional al salto
            _tiempoSalto -= Time.fixedDeltaTime; // Reducir el tiempo de salto restante
        }
        else
        {
            _estaSaltando = false; // Marcar que el jugador ya no está saltando
        }
        miRigidBody.gravityScale = miRigidBody.velocity.y < 0 ? _escalaGravedad * MultiplicadorGravedadCayendo : _escalaGravedad; // Ajustar la gravedad al caer
    }
}