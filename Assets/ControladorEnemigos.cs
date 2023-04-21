using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControladorEnemigos : MonoBehaviour
{
    // Start is called before the first frame update
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private float tiempoEnemigos;
    private float tiempoSigEnemigo;
    void Start()
    {
        maxX=puntos.Max(puntos => puntos.position.x);
        minX=puntos.Min(puntos=> puntos.position.x);
        maxY=puntos.Max(puntos =>puntos.position.y);
        minY= puntos.Min(puntos=>puntos.position.y);

        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoSigEnemigo += Time.deltaTime;
        if(tiempoSigEnemigo>= tiempoEnemigos){
            tiempoSigEnemigo=0;
            CrearEnemigos();
        }
    }
    private void CrearEnemigos(){
        int nuemeroEnemigo= Random.Range(0,enemigos.Length);
        Vector2 posiciónAle = new Vector2(Random.Range(minX,maxX),Random.Range(minX,maxY));
        Instantiate(enemigos[nuemeroEnemigo],posiciónAle,Quaternion.identity);

    }
}
