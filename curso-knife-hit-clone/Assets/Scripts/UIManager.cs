using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject painelDasEspadas;
    [SerializeField] private GameObject imagemDaEspada;

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
        
    }

    public void CarregarImagensDasEspadas(int espadasDisponiveis)
    {
        for (int i = 0; i < espadasDisponiveis; i++)
        {
            Instantiate(imagemDaEspada, painelDasEspadas.transform);
        }
    }

    public void AtualizarImagemDaEspada(int espadaAtual)
    {
        // Deixa preta a imagem da espada que foi lançada
        painelDasEspadas.transform.GetChild(espadaAtual).GetComponent<Image>().color = Color.black;
    }
}
