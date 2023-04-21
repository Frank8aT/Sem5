using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float velocidadM;
    [SerializeField] private float distance;
    [SerializeField] private LayerMask queEsPared;
    void Start()
    {
        rb2D= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity= new Vector2(velocidadM*transform.right.x, rb2D.velocity.y);
        RaycastHit2D informacionSuelo= Physics2D.Raycast(transform.position, transform.right, distance, queEsPared);
        if(informacionSuelo){
            Girar();
        }
    }
    private void Girar(){
        transform.eulerAngles= new Vector3(0, transform.eulerAngles.y+180,0);
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color= Color.blue;
        Gizmos.DrawLine(transform.position, transform.position+transform.right*distance);
    }
}
