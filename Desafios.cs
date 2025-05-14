using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TargetSistemas
{
    public class Desafio3
    {
        public int dia { get; set; }
        public double valor { get; set; }
    }

    class Desafios
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando desafios...\n");
            ExecutarDesafio1(); // Soma até 13
            ExecutarDesafio2();
            ExecutarDesafio3(); // Faturamento diário (menor, maior e dias acima da média)
            ExecutarDesafio4(); // Percentual por estado
            ExecutarDesafio5(); // Inversão de string

            Console.WriteLine("\nTodos os desafios foram executados.");
        }

        static void ExecutarDesafio1()
        {
            Console.WriteLine("Desafio 1 - Soma até 13:\n");

            int INDICE = 13;
            int SOMA = 0;
            int K = 0;

            while (K < INDICE)
            {
                K = K + 1;
                SOMA = SOMA + K;
            }

            Console.WriteLine($"Valor final da variável SOMA: {SOMA}\n");
        }
        static void ExecutarDesafio2()
        {
            Console.WriteLine("Desafio 2 - Verifica se um número pertence à sequência de Fibonacci:\n");

            Console.Write("Informe um número: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int numero))
            {
                if (numero < 0)
                {
                    Console.WriteLine("Por favor, informe um número inteiro não negativo.\n");
                    return;
                }

                bool pertence = VerificaFibonacci(numero);

                if (pertence)
                    Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.\n");
                else
                    Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci.\n");
            }
            else
            {
                Console.WriteLine("Entrada inválida! Digite um número inteiro.\n");
            }
        }

        static bool VerificaFibonacci(int numero)
        {
            int a = 0;
            int b = 1;

            while (a <= numero)
            {
                if (a == numero)
                    return true;

                int temp = a;
                a = b;
                b = temp + b;
            }

            return false;
        }
        static void ExecutarDesafio3()
        {
            Console.WriteLine("Desafio 3 - Análise de Faturamento Diário (JSON):\n");

            string caminhoArquivo = "dados/dados.json";

            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine("Arquivo JSON não encontrado.\n");
                return;
            }

            string json = File.ReadAllText(caminhoArquivo);

            List<Desafio3> dados;
            try
            {
                dados = JsonSerializer.Deserialize<List<Desafio3>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o JSON: {ex.Message}\n");
                return;
            }

            var diasComFaturamento = dados.Where(d => d.valor > 0).ToList();

            if (diasComFaturamento.Count == 0)
            {
                Console.WriteLine("Não há dias com faturamento positivo.\n");
                return;
            }

            double menorFaturamento = diasComFaturamento.Min(d => d.valor);
            double maiorFaturamento = diasComFaturamento.Max(d => d.valor);
            double mediaMensal = diasComFaturamento.Average(d => d.valor);
            int diasAcimaDaMedia = diasComFaturamento.Count(d => d.valor > mediaMensal);

            Console.WriteLine($"Menor faturamento do mês: R$ {menorFaturamento:F2}");
            Console.WriteLine($"Maior faturamento do mês: R$ {maiorFaturamento:F2}");
            Console.WriteLine($"Número de dias com faturamento acima da média mensal: {diasAcimaDaMedia}\n");
        }
        static void ExecutarDesafio4()
        {
            // Dicionário com os valores de faturamento por estado
            Dictionary<string, double> faturamentoPorEstado = new Dictionary<string, double>()
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

            // Calcula o total do faturamento
            double totalFaturamento = 0;
            foreach (var valor in faturamentoPorEstado.Values)
            {
                totalFaturamento += valor;
            }

            // Exibe o percentual de cada estado
            Console.WriteLine("Desafio 4 - Percentual de Faturamento por Estado:\n");

            foreach (var estado in faturamentoPorEstado)
            {
                double percentual = (estado.Value / totalFaturamento) * 100;
                Console.WriteLine($"{estado.Key}: {percentual:F2}%\n");
            }
        }
        static void ExecutarDesafio5()
        {
            Console.WriteLine("Desafio 5 - Inversão de String:\n");
            Console.WriteLine("Digite o texto que deseja inverter");
            string textoOriginal = Console.ReadLine();
            string textoInvertido = "";

            for (int i = textoOriginal.Length - 1; i >= 0; i--)
            {
                textoInvertido += textoOriginal[i];
            }

            Console.WriteLine("Texto original: " + textoOriginal);
            Console.WriteLine("Texto invertido: " + textoInvertido);
        }


    }


}
