using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Controle das Espadas")]
    [SerializeField] private int espadasDisponiveis = 7;
    private int espadaAtual = 0;

    [Header("Spawn das Espadas")]
    [SerializeField] private GameObject espadaParaSpawnar;
    [SerializeField] private Vector2 posicaoInicialDaEspada = new Vector2(0f, -2.5f);

    [Header("Game Over")]
    [SerializeField] private float tempoParaAtivarPainelFinal = 1f;

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
        UIManager.Instance.CarregarIconesDasEspadas(espadasDisponiveis);
        SpawnarNovaEspada();
    }

    public void SpawnarNovaEspada()
    {
        Instantiate(espadaParaSpawnar, posicaoInicialDaEspada, Quaternion.identity);
    }

    public void QuandoAtingirAlvo()
    {
        UIManager.Instance.AtualizarIconeDaEspada(espadaAtual);

        espadasDisponiveis--;
        espadaAtual++;

        if (espadasDisponiveis <= 0)
        {
            StartCoroutine("AtivarPainelFinalCoroutine", true);
        }
        else
        {
            SpawnarNovaEspada();
        }
    }

    public void QuandoAtingirEspada()
    {
        StartCoroutine("AtivarPainelFinalCoroutine", false);
    }

    private IEnumerator AtivarPainelFinalCoroutine(bool venceu)
    {
        yield return new WaitForSeconds(tempoParaAtivarPainelFinal);
        UIManager.Instance.AtivarPainelFinal(venceu);
    }
}
