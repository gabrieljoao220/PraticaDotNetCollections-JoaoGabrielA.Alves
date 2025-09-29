using System.Collections.Generic;
using System.Linq;

// Lista onde cada item é um dicionario
var filmes = new List<Dictionary<string, object>>();


//------- Adicionando alguns filmes -------

// Filme 1
var filme1 = new Dictionary<string, object>
{
    { "Titulo", "Parasita" },
    { "Ano", 2019 },
    { "Genero", "Suspense" },
    { "Duracao", 132 },
    { "Pais", "Coreia do Sul" },
    { "Artistas", new List<string> { "Song Kang-ho", "Lee Sun-kyun", "Cho Yeo-jeong" } }
};
filmes.Add(filme1);

// Filme 2
var filme2 = new Dictionary<string, object>
{
    { "Titulo", "Cidade de Deus" },
    { "Ano", 2002 },
    { "Genero", "Drama" },
    { "Duracao", 130 },
    { "Pais", "Brasil" },
    { "Artistas", new List<string> { "Alexandre Rodrigues", "Leandro Firmino", "Phellipe Haagensen" } }
};
filmes.Add(filme2);

// Filme 3
var filme3 = new Dictionary<string, object>
{
    { "Titulo", "O Senhor dos Anéis: A Sociedade do Anel" },
    { "Ano", 2001 },
    { "Genero", "Fantasia" },
    { "Duracao", 178 },
    { "Pais", "Nova Zelândia" },
    { "Artistas", new List<string> { "Elijah Wood", "Ian McKellen", "Viggo Mortensen" } }
};
filmes.Add(filme3);

// Função para exibir os filmes

void ExibirDetalhesDoFilme(Dictionary<string, object> filme)
{
    Console.WriteLine($"  - Título: {filme["Titulo"]}");
    Console.WriteLine($"    Ano: {filme["Ano"]}, Gênero: {filme["Genero"]}, País: {filme["Pais"]}");

    // Casting para exibir
    var artistas = (List<string>)filme["Artistas"];
    Console.WriteLine($"    Artistas: {string.Join(", ", artistas)}");
}


// --- Executando consultas solicitadas ---
// Usaremos LINQ para fazer as buscas

Console.WriteLine("--- Catálogo Completo ---");
foreach (var filme in filmes)
{
    ExibirDetalhesDoFilme(filme);
    Console.WriteLine(); // Linha em branco para separar
}

// Consulta por GÊNERO
Console.WriteLine("\n\n--- Consulta: Filmes do Gênero 'Drama' ---");
var filmesDeDrama = filmes.Where(f => (string)f["Genero"] == "Drama").ToList();
if (filmesDeDrama.Any())
{
    foreach (var filme in filmesDeDrama)
    {
        ExibirDetalhesDoFilme(filme);
    }
}
else
{
    Console.WriteLine("Nenhum filme encontrado para este gênero.");
}


// Consulta por ANO
Console.WriteLine("\n\n--- Consulta: Filmes lançados depois de 2010 ---");
var filmesRecentes = filmes.Where(f => (int)f["Ano"] > 2010).ToList();
if (filmesRecentes.Any())
{
    foreach (var filme in filmesRecentes)
    {
        ExibirDetalhesDoFilme(filme);
    }
}
else
{
    Console.WriteLine("Nenhum filme encontrado neste período.");
}

// Consulta por PAÍS
Console.WriteLine("\n\n--- Consulta: Filmes do 'Brasil' ---");
var filmesBrasileiros = filmes.Where(f => ((string)f["Pais"]).Equals("Brasil", StringComparison.OrdinalIgnoreCase)).ToList();
if (filmesBrasileiros.Any())
{
    foreach (var filme in filmesBrasileiros)
    {
        ExibirDetalhesDoFilme(filme);
    }
}
else
{
    Console.WriteLine("Nenhum filme brasileiro encontrado.");
}

// Consulta por TÍTULO (buscando uma parte do nome)
Console.WriteLine("\n\n--- Consulta: Filme que contém 'Senhor' no título ---");
var filmePorTitulo = filmes.FirstOrDefault(f => ((string)f["Titulo"]).Contains("Senhor"));
if (filmePorTitulo != null)
{
    ExibirDetalhesDoFilme(filmePorTitulo);
}
else
{
    Console.WriteLine("Nenhum filme encontrado com esse título.");
}