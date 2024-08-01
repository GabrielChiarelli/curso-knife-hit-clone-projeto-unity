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
        SpawnarNovaEspada();
    }

    public void SpawnarNovaEspada()
    {
        Instantiate(espadaParaSpawnar, posicaoInicialDaEspada, Quaternion.identity);
    }

    public void QuandoAtingirAlvo()
    {
        espadasDisponiveis--;
        espadaAtual++;

        if (espadasDisponiveis <= 0)
        {
            Debug.Log("Ganhou!");
        }
        else
        {
            SpawnarNovaEspada();
        }
    }

    public void QuandoAtingirEspada()
    {
        Debug.Log("Perdeu.");
    }
}
