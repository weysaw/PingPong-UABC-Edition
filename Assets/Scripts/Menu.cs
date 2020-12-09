using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Acciones que hace el menu del juego
 * 
 * @author Ornelas Munguía Axel Leonardo
 * @version 09.12.2020
 */
public class Menu : MonoBehaviour
{
    /**
     * Cambia de escena a jugar
     */ 
    public void Jugar() {
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);
    }
    /**
     * Se la sale de la aplicación
     */
    public void Salir() {
        Application.Quit();
    }

}
