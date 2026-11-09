using System.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class UrucaBullet : MonoBehaviour
{
    // Prefab do inimigo (arraste no Inspector)
    public GameObject bulletPrefab;

    // Intervalo entre spawns (segundos)
    public float intervalo = 2f;

    // Limites de spawn no cenário
    public float limiteX = 8f;
    public float limiteY = 4f;

    // Velocidade de movimento dos inimigos
    public float velocidade = 5f;

    // Limite X para destruir o inimigo ao sair da tela
    public float limiteDestruicaoX = -12f;

    void Start()
    {
        // Começa a gerar inimigos repetidamente
        InvokeRepeating("GerarBullet", 0f, intervalo);
    }

    void GerarBullet()
    {
        // Define posição de spawn (à direita da tela)
        float x = limiteX;
        float y = Random.Range(-limiteY, limiteY);
        Vector2 posicaoAleatoria = new Vector2(x, y);

        // Instancia o inimigo
        GameObject bullet = Instantiate(bulletPrefab, posicaoAleatoria, Quaternion.identity);

        // Inicia o movimento automático (corrotina)
        StartCoroutine(MoverBullet(bullet));

    }

    IEnumerator MoverBullet(GameObject bullet)
    {
        while (bullet != null)
        {
            // Move o inimigo da direita para a esquerda
            bullet.transform.Translate(Vector2.left * velocidade * Time.deltaTime);

            // Se o inimigo sair do limite visível, destrói o objeto
            if (bullet.transform.position.x < limiteDestruicaoX)
            {
                Destroy(bullet);
                yield break; // Sai da corrotina
            }

            yield return null; // Espera o próximo frame
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
