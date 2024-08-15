using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    [Header("Referências Gerais")]
    private Rigidbody2D oRigidbody2D;

    [Header("Lançamento da Espada")]
    [SerializeField] private float forcaDoLancamento = 20f;
    private bool foiLancada = false;

    private void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReceberInput();
    }

    private void ReceberInput()
    {
        if (Input.GetMouseButtonDown(0) && !foiLancada)
        {
            LancarEspada();
        }
    }

    private void LancarEspada()
    {
        // Arremesa a Espada para cima e reativa sua gravidade
        oRigidbody2D.AddForce(new Vector2(0f, forcaDoLancamento), ForceMode2D.Impulse);
        oRigidbody2D.gravityScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (!foiLancada)
        {
            // Se colidir com o alvo: zera a velocidade da espada, desativa sua gravidade e torna-a filha dele
            if (collisionInfo.gameObject.GetComponent<Alvo>() != null)
            {
                oRigidbody2D.velocity = Vector2.zero;
                oRigidbody2D.gravityScale = 0f;
                oRigidbody2D.bodyType = RigidbodyType2D.Static;
                transform.SetParent(collisionInfo.gameObject.transform);

                GameManager.Instance.QuandoAtingirAlvo();
                AudioManager.Instance.impactoAlvo.Play();
            }
            // Se colidir com outra espada: zera sua velocidade
            else if (collisionInfo.gameObject.GetComponent<Espada>() != null)
            {
                oRigidbody2D.velocity = Vector2.zero;

                GameManager.Instance.QuandoAtingirEspada();
                AudioManager.Instance.impactoEspada.Play();
            }

            foiLancada = true;
        }
    }
}
