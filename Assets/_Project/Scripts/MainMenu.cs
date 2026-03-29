using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NuovaPartita()
    {
        SceneManager.LoadScene(1);
    }

    public void Continua()
    {
        SceneManager.LoadScene(1);
    }

    public void Esplora()
    {
        SceneManager.LoadScene(1);
    }

    public void Sfide()
    {
        Debug.Log("Modalità sfide");
    }

    public void Personalizza()
    {
        Debug.Log("Personalizzazione");
    }

    public void Opzioni()
    {
        Debug.Log("Apri opzioni");
    }

    public void Esci()
    {
        Debug.Log("Chiudo Gioco");
        Application.Quit();
    }
}
