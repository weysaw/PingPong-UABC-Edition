using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Realiza las acciones que necesita el palito del jugador
 *
 *@version 09.12.2020
 *@author Ornelas Munguía Axel Leonardo 
 */
public class Jugador : MonoBehaviour {
    //Sirve para determinar la posicion de los jugadores
    public float a, b;
    public bool jugador;

    private float velocidad;
    private Camera camaraMain;
    private float ancho, altura;

    // Start is called before the first frame update
    void Start() {
        velocidad = 10f;
        //Obtiene la camara principal
        camaraMain = Camera.main;
        //Obtiene el ancho de la camara
        ancho = camaraMain.scaledPixelWidth;
        //Obtiene la altura de la camara
        altura = camaraMain.scaledPixelHeight;
        //Posiciona al jugador dependiendo de la posicion de la camara
        transform.position = camaraMain.ScreenToWorldPoint(new Vector3(ancho * a, altura * b, 1));
    }

    // Update is called once per frame
    void Update() {
        //Recorre todos los touch que hay 
        for (int i = 0; i < Input.touchCount; i++) {
            //Obtiene el touch actual
            Touch touch = Input.GetTouch(i);
            //Obtiene las coordenadas del mundo usando el touch
            Vector3 coordenadaScreen = camaraMain.ScreenToWorldPoint(touch.position);
            //Mueve al jugador dependiendo de la zona de la pantalla
            if (transform.position.y != coordenadaScreen.y && coordenadaScreen.x < 0 && jugador) {
                Moverse(coordenadaScreen);
            } else if (transform.position.y != coordenadaScreen.y && coordenadaScreen.x > 0 && !jugador) {
                Moverse(coordenadaScreen);
            }
        }
    }
    /**
     * Mueve al jugador a las coordenadas deseadas
     * 
     */
    void Moverse(Vector3 coordenadaScreen) {
        //Realiza una diferencia de coordenadas
        float diferencia = transform.position.y - coordenadaScreen.y;
        //Si la diferencia es mayor a 0 significa que quiere ir hacia abajo
        float distancia = (diferencia > 0) ? -velocidad : velocidad;
        //Mueve al jugador poco a poco
        transform.position += new Vector3(0f, distancia) * Time.deltaTime;
    }
}
