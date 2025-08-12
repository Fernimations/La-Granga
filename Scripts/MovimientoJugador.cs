using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    Rigidbody2D rb;
    public Vector2 entrada;
    private Animator animator;
    public GameObject trigoPreFab; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = entrada * velocidad;
    }

    public void Moverse(InputAction.CallbackContext contexto){
        
        Vector2 valorEntrada = contexto.ReadValue<Vector2>();

        animator.SetBool("estaCaminando", true);

        // Determinar el eje dominante
        if (Mathf.Abs(valorEntrada.x) > Mathf.Abs(valorEntrada.y))
        {
            // Movimiento horizontal
            entrada = new Vector2(Mathf.Sign(valorEntrada.x), 0);
        }
        else if (Mathf.Abs(valorEntrada.y) > 0)
        {
            // Movimiento vertical
            entrada = new Vector2(0, Mathf.Sign(valorEntrada.y));
        }
        else
        {
            entrada = Vector2.zero;
        }

        animator.SetFloat("entradax", entrada.x);
        animator.SetFloat("entraday", entrada.y);

        if(contexto.canceled){
            animator.SetBool("estaCaminando", false);
            }
    }

    public void SembrarTrigo(InputAction.CallbackContext contexto){
        if(contexto.started){
            Instantiate(trigoPreFab , transform.position , Quaternion.identity);
            }
    }      

    public void OnTriggerEnter2D(Collider2D colision){
        if(colision.CompareTag("nido")){
            Destroy(colision.gameObject);
            }
    }        
}
