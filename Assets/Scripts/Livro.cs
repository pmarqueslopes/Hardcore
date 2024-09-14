using UnityEngine;
using UnityEngine.UI;

public class Livro : MonoBehaviour
{
    public GameObject[] paginas;  // Array de GameObjects representando as páginas do livro
    public Button botaoProximaPagina;
    public Button botaoPaginaAnterior;
    public Button[] marcadores;  // Array de botões para pular para páginas específicas
    public int paginaAtual = 0;

    void Start()
    {
        // Inicialmente, todas as páginas devem ser desativadas
        DesativarTodasAsPaginas();

        // Ativar a primeira página
        AtivarPagina(paginaAtual);

        // Configurar os botões
        botaoProximaPagina.onClick.AddListener(ProximaPagina);
        botaoPaginaAnterior.onClick.AddListener(PaginaAnterior);

        for (int i = 0; i < marcadores.Length; i++)
        {
            int paginaDestino = i;  // A página correspondente ao marcador
            marcadores[i].onClick.AddListener(() => IrParaPagina(paginaDestino));
        }
    }

    void DesativarTodasAsPaginas()
    {
        foreach (GameObject pagina in paginas)
        {
            pagina.SetActive(false);
        }
    }

    void AtivarPagina(int pagina)
    {
        paginas[pagina].SetActive(true);
    }

    void ProximaPagina()
    {
        if (paginaAtual < paginas.Length - 1)
        {
            paginas[paginaAtual].SetActive(false);
            paginaAtual++;
            AtivarPagina(paginaAtual);
            //book.index = paginaAtual;
        }
    }

    void PaginaAnterior()
    {
        if (paginaAtual > 0)
        {
            paginas[paginaAtual].SetActive(false);
            paginaAtual--;
            AtivarPagina(paginaAtual);
            //book.index = paginaAtual;
        }
    }

    void IrParaPagina(int paginaDestino)
    {
        if (paginaDestino >= 0 && paginaDestino < paginas.Length)
        {
            paginas[paginaAtual].SetActive(false);
            paginaAtual = paginaDestino;
            AtivarPagina(paginaAtual);
            //book.index = paginaAtual;
        }
    }
}
