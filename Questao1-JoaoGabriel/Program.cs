using System;
using System.Collections.Generic;
using System.Linq;

// Demonstração de LISTS

Console.WriteLine("--- Seção: Listas (com exemplos alterados) ---\n");

// Exemplo 1: Lista de Cidades (string)
List<string> cidades = new List<string>();
cidades.Add("Fortaleza");
cidades.AddRange(new[] { "Recife", "Salvador", "São Paulo" });

Console.WriteLine("Cidades na lista:");
cidades.ForEach(cidade => Console.WriteLine(cidade));

string primeiraCidade = cidades[0];
Console.WriteLine($"\nA primeira cidade da lista é: {primeiraCidade}");
cidades[0] = "Brasília"; // Alterando o primeiro elemento
Console.WriteLine($"Primeira cidade alterada para: {cidades[0]}");

cidades.Remove("Salvador");
Console.WriteLine("\nLista de cidades após remover 'Salvador':");
cidades.ForEach(c => Console.WriteLine(c));

// Adicionando mais cidades para o próximo exemplo
cidades.AddRange(new[] { "Manaus", "Curitiba", "Belo Horizonte" });

cidades.RemoveAll(c => c.StartsWith("B")); // Remove "Brasília" e "Belo Horizonte"
Console.WriteLine("\nLista após remover cidades que começam com 'B':");
cidades.ForEach(c => Console.WriteLine(c));


// Exemplo 2: Lista de Preços de Produtos (int)
List<int> precos = new List<int> { 15, 99, 50, 25, 120 };
Console.WriteLine($"\nLista de preços inicial: [{string.Join(", ", precos)}]");

bool temPreco99 = precos.Contains(99);
Console.WriteLine($"\nA lista contém o preço 99? {temPreco99}");

int indiceDoPreco50 = precos.IndexOf(50);
Console.WriteLine($"O índice do preço 50 é: {indiceDoPreco50}");

int totalDePrecos = precos.Count;
Console.WriteLine($"Total de preços na lista: {totalDePrecos}");

precos.Sort(); // Ordena a lista
Console.WriteLine($"\nLista de preços ordenada: [{string.Join(", ", precos)}]");

precos.Reverse(); // Inverte a ordem da lista (agora decrescente)
Console.WriteLine($"Lista de preços invertida: [{string.Join(", ", precos)}]");

int primeiroPrecoAcimaDe100 = precos.Find(p => p > 100);
Console.WriteLine($"\nPrimeiro preço encontrado maior que 100: {primeiroPrecoAcimaDe100}");

List<int> precosAbaixoDe60 = precos.FindAll(p => p < 60);
Console.WriteLine($"Preços na lista menores que 60: [{string.Join(", ", precosAbaixoDe60)}]");

cidades.Clear(); // Esvazia a lista de cidades
Console.WriteLine($"\nTotal de cidades na lista após .Clear(): {cidades.Count}");

// Demonstração de DICTIONARY

Console.WriteLine("\n\n--- Seção: Dicionários (com exemplos alterados) ---\n");

// Exemplo 1: Dicionário de Notas de Alunos
Dictionary<string, int> notasAlunos = new Dictionary<string, int>();

// Adicionando dados diferentes
notasAlunos.Add("Ana", 9);
notasAlunos["Bruno"] = 7;
notasAlunos.Add("Carlos", 10);

Console.WriteLine($"A nota de Ana é: {notasAlunos["Ana"]}");

// Tentando pegar uma nota de forma segura
bool sucesso = notasAlunos.TryGetValue("Bruno", out int notaDoBruno);
if (sucesso)
{
    Console.WriteLine($"A nota de Bruno é: {notaDoBruno} (obtido com TryGetValue)");
}

bool temNotaDoCarlos = notasAlunos.ContainsKey("Carlos");
Console.WriteLine($"Dicionário contém a chave 'Carlos'? {temNotaDoCarlos}");

bool alguemTirou10 = notasAlunos.ContainsValue(10);
Console.WriteLine($"Alguém no dicionário tirou nota 10? {alguemTirou10}");

notasAlunos.Remove("Ana");
Console.WriteLine($"\nDicionário após remover 'Ana':");
foreach (KeyValuePair<string, int> par in notasAlunos)
{
    Console.WriteLine($"Aluno: {par.Key}, Nota: {par.Value}");
}

// Exemplo 2: Dicionário de Siglas
Dictionary<string, string> siglas = new Dictionary<string, string>
{
    { "API", "Application Programming Interface" },
    { "SQL", "Structured Query Language" },
    { "HTML", "HyperText Markup Language" }
};
Console.WriteLine("\nSignificado das siglas:");
foreach (var (sigla, significado) in siglas)
{
    Console.WriteLine($"{sigla}: {significado}");
}

// Demonstração de LINQ

Console.WriteLine("\n\n--- Seção: LINQ (com exemplos alterados) ---\n");

// Exemplo: Temperaturas registradas em uma semana
List<int> temperaturas = new List<int> { 28, 31, 29, 30, 33, 31, 27 };
Console.WriteLine($"Lista de temperaturas para os testes LINQ: [{string.Join(", ", temperaturas)}]");

// Filtragem: dias com temperatura de 30 graus ou mais
var diasQuentes = temperaturas.Where(t => t >= 30);
Console.WriteLine($"\nFiltragem (temperaturas >= 30°C): [{string.Join(", ", diasQuentes)}]");

// Transformação: converter temperaturas para Fahrenheit
var tempsEmFahrenheit = temperaturas.Select(t => Math.Round(t * 1.8 + 32, 1));
Console.WriteLine($"\nTransformação (Celsius para Fahrenheit): [{string.Join(", ", tempsEmFahrenheit)}]");

// Ordenação: temperaturas da mais fria para a mais quente
var ordenadoCrescente = temperaturas.OrderBy(t => t);
Console.WriteLine($"\nOrdenação (crescente): [{string.Join(", ", ordenadoCrescente)}]");

// Agregação: calculando estatísticas do clima
double mediaTemp = temperaturas.Average();
Console.WriteLine($"\nAgregação (média): {Math.Round(mediaTemp, 2)}°C");
int maxTemp = temperaturas.Max();
Console.WriteLine($"Agregação (máxima): {maxTemp}°C");
int minTemp = temperaturas.Min();
Console.WriteLine($"Agregação (mínima): {minTemp}°C");

// Quantificadores: verificando condições sobre o clima
bool todosDiasAcimaDe25 = temperaturas.All(t => t > 25);
Console.WriteLine($"\nQuantificadores (todos os dias foram acima de 25°C?): {todosDiasAcimaDe25}");
bool algumDiaAcimaDe32 = temperaturas.Any(t => t > 32);
Console.WriteLine($"Quantificadores (houve algum dia acima de 32°C?): {algumDiaAcimaDe32}");

// Partição: pegando os primeiros e os últimos registros
var primeirasTresTemps = temperaturas.Take(3);
Console.WriteLine($"\nPartição (as 3 primeiras temperaturas): [{string.Join(", ", primeirasTresTemps)}]");
var pularAsDuasPrimeiras = temperaturas.Skip(2);
Console.WriteLine($"Partição (pular as 2 primeiras): [{string.Join(", ", pularAsDuasPrimeiras)}]");

// Operações de elemento: pegando registros específicos
int primeiraTempRegistrada = temperaturas.First();
Console.WriteLine($"\nOperações de Elemento (primeira temperatura): {primeiraTempRegistrada}");
int ultimaTempRegistrada = temperaturas.Last();
Console.WriteLine($"Operações de Elemento (última temperatura): {ultimaTempRegistrada}");
// Para Single() funcionar, o elemento deve ser único. 33 é único na nossa lista.
int tempUnica = temperaturas.Where(t => t == 33).Single();
Console.WriteLine($"Operações de Elemento (a única temperatura de 33°C): {tempUnica}");

// Grouping: agrupar temperaturas em "Quente" (>30) e "Ameno" (<=30)
var gruposDeClima = temperaturas.GroupBy(t => t > 30 ? "Quente" : "Ameno");
Console.WriteLine("\nGrouping (agrupado por tipo de clima):");
foreach (var grupo in gruposDeClima)
{
    Console.WriteLine($"Clima: {grupo.Key}, Temperaturas: [{string.Join(", ", grupo)}]");
}

// Sintaxe de Consulta (alternativa) para encontrar temperaturas amenas e ordená-las
var consultaTemperaturas = from temp in temperaturas
                           where temp < 30
                           orderby temp
                           select temp;
Console.WriteLine($"\nSintaxe de Consulta (temps < 30°C): [{string.Join(", ", consultaTemperaturas)}]");