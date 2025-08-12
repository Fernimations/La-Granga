using UnityEngine;

public class PonerHuevo : MonoBehaviour
{
    public GameObject huevo;
    public float intervalo = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(PonerUnHuevo), intervalo, intervalo);
        
    }

    // Update is called once per frame
    void PonerUnHuevo()
    {
        Instantiate(huevo, transform.position, Quaternion.identity);
        
    }
}
