using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour {

    //Atributos de la pelota
    public Rigidbody2D rb;
    public bool inicio;
    public int max;
    public int min;
    
    private float tiempo;
    public ManejadorDelJuego manejador;

    // Start is called before the first frame update
    void Start() {
        //Lanza la pelota en un dirección aleatoria
        Lanzar(min, max);
        tiempo = 0f;
    }

    // Update is called once per frame
    void Update() {
        //Acumula el tiempo desde que meten gol
        tiempo += Time.deltaTime;
        manejador.ReducirTiempo((int) tiempo);
        //Si pasan más de 7 seg y no anotan aumenta la velocidad
        if (tiempo >= 7f) {
            tiempo = 0f;
            rb.velocity += new Vector2(rb.velocity.x, 1);
        }
    }

    /**
     * Lanza a la pelota dependiendo de los numeros indicados
     * 
     */ 
    void Lanzar(int min, int max) {
        float x, y;
        //Devuelve numeros aleatorios dependiendo del rango
        x = DevolverNumeros(min, max);
        y = DevolverNumeros(this.min, this.max);
        //Le asigna la velocidad de la pelota
        rb.velocity = new Vector2(x, y);
    }
    /**
     * Devuelve numeros aleatorios dependiendo del rango
     */ 
    int DevolverNumeros(int min, int max) {
        int num = Random.Range(min, max);
        if (num < 3 && num >= 0) {
            num += 4;
        } else if (num < 0 && num >= -3) {
            num -= 4;
        }
        return num;
    }
    /**
     * Accion que realiza si golpea algun objeto
     */ 
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.Equals("GolJugador1")) {
            Gol(0, 10);
            manejador.GolJugador(true);
        } else if (collision.gameObject.name.Equals("GolJugador2")) {
            Gol(-10, 0);
            manejador.GolJugador(false);          
        }

    }
    /**
     * Si anota vuelve a lanzar la pelota
     */ 
    void Gol(int min, int max) {
        rb.transform.position = new Vector3(0f, 0f);
        rb.velocity = Vector2.zero;
        Lanzar(min, max);
        tiempo = 0f;
    }
}
