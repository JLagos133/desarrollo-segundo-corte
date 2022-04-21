using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject Ganar;
    [SerializeField] int conteo;
    [SerializeField] Text tiempo;


    public megaman vida;

    float contador;
    float num;
    // Start is called before the first frame update
    void Start()
    {
        vida = FindObjectOfType<megaman>();

    }

    // Update is called once per frame
    void Update()
    {
        contadorTiempo();
        PauseGame();
        perder();
    }
    public void contE()
    {
        conteo = conteo - 1;
        if (conteo < 1)
        {
            ganar();
        }
    }

    void ganar()
    {
        Ganar.SetActive(true);
    }
    void contadorTiempo()
    {
        contador += Time.deltaTime;
        if (contador >= 1f)
        {
            num++;
            tiempo.text = num.ToString();
            contador = 0;
        }
        if (num >= 500f)
        {

            SceneManager.LoadScene(1);
        }
    }
    void perder()
    {
        if (vida.vida <= 0)
        {
            gameOverMenu.SetActive(true);
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    void PauseGame()
    {
        //pausar y "despausar" el juego
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }

    }
}
