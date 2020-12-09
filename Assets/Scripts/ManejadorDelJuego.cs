using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ManejadorDelJuego : MonoBehaviour
{
    [Header("Jugador 1")]
    public TextMeshProUGUI contadorJ1;
    private int puntosJ1;

    [Header("Jugador 2")]
    public TextMeshProUGUI contadorJ2;
    private int puntosJ2;

    private bool pausa;

    [Header("Interfaz en juego")]
    public GameObject interfazJuego;
    public Text aceleracion;
    public GameObject salir;
    public GameObject bPausa;

    [Header("Interfaz en pausa")]
    public GameObject interfazPausa;
    
    [Header("Postes")]
    public GameObject posteArriba;
    public GameObject posteAbajo;
    public GameObject posteIzquierda;
    public GameObject posteDerecha;


    
    private void Start() {
        pausa = false;
        //Posiciona los postes dependiendo de la pantalla
        PosicionarPostes();
    }
    /**
     * Posiciona los postes dependiendo de la forma de la pantalla
     */ 
    private void PosicionarPostes() {
        Camera camaraMain = Camera.main;
        float ancho = camaraMain.scaledPixelWidth;
        float altura = camaraMain.scaledPixelHeight;
        posteArriba.transform.position = camaraMain.ScreenToWorldPoint(new Vector3(ancho/2, altura * 1.02f, 1));
        posteAbajo.transform.position = camaraMain.ScreenToWorldPoint(new Vector3(ancho/2, altura * -0.02f, 1));
        posteIzquierda.transform.position = camaraMain.ScreenToWorldPoint(new Vector3(ancho * -0.02f, altura/2, 1));
        posteDerecha.transform.position = camaraMain.ScreenToWorldPoint(new Vector3(ancho * 1.02f, altura/2, 1));
    }

    /**
     * Aumenta el contador de gol indicado por el jugador
     */ 
    public void GolJugador(bool jugador) {
        //True es el J1 y false es el J2
        if(jugador) {
            //Incrementa los puntos
            puntosJ1++;
            contadorJ1.text = puntosJ1.ToString();
            //Pregunta si es más de 10 los puntos
            FinDelJuego(puntosJ1, jugador);
        } else {
            //Incrementa los puntos
            puntosJ2++;
            contadorJ2.text = puntosJ2.ToString();
            //Pregunta si es más de 10 los puntos
            FinDelJuego(puntosJ2, jugador);
        }
    }
    /**
     * Verifica si ya es el fin del juego indicado por los puntos del jugador
     */
    void FinDelJuego(int puntos, bool jugador) {
        if(puntos >= 10) {
            if(jugador) {
                contadorJ1.text = "GANADOR J1";
            } else {
                contadorJ2.text = "GANADOR J2";
            }
            //Oculta el boton de pausa y muestra el boton de salir
            bPausa.SetActive(false);
            salir.SetActive(true);
            //Pone el tiempo en pausa
            Time.timeScale = 0f;
            
        }
    }
    /**
     * Pausa el juego y muestra el menu de pausa
     */ 
    public void PausarJuego() {
        pausa = !pausa;
        if(pausa) {
            //Detiene el tiempo
            Time.timeScale = 0f;
            //Muestra el menu de pausa
            interfazJuego.SetActive(false);
            interfazPausa.SetActive(true);
        } else {
            //Sigue el tiempo en curso
            Time.timeScale = 1f;
            //Muestra la interfaz de juegos
            interfazPausa.SetActive(false);
            interfazJuego.SetActive(true);
        }
    } 
    /**
     * Sale de la escena y se va al menu principal
     */ 
    public void SalirEscena() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
    }

    public void ReducirTiempo(int tiempo) {
        int resu = 7 - tiempo;

        aceleracion.text = "Aceleración: " + resu;
    }
}
