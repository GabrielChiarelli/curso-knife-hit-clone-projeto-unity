using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI das Espadas")]
    [SerializeField] private GameObject painelDasEspadas;
    [SerializeField] private GameObject iconeDaEspada;

    [Header("UI do Painel Final")]
    [SerializeField] private GameObject painelFinal;
    [SerializeField] private Text textoDoResultado;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        painelFinal.SetActive(false);
    }

    public void CarregarIconesDasEspadas(int espadasDisponiveis)
    {
        for (int i = 0; i < espadasDisponiveis; i++)
        {
            Instantiate(iconeDaEspada, painelDasEspadas.transform);
        }
    }

    public void AtualizarIconeDaEspada(int espadaAtual)
    {
        // Deixa preta a imagem da espada que foi lançada
        painelDasEspadas.transform.GetChild(espadaAtual).GetComponent<Image>().color = Color.black;
    }

    public void AtivarPainelFinal(bool venceu)
    {
        if (venceu)
        {
            textoDoResultado.text = "VITÓRIA";
            AudioManager.Instance.vitoria.Play();
        }
        else
        {
            textoDoResultado.text = "GAME OVER";
            AudioManager.Instance.derrota.Play();
        }

        painelFinal.SetActive(true);
    }

    public void ReiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SairDoJogo()
    {
        Debug.Log("Saiu do jogo");
        Application.Quit();
    }
}
