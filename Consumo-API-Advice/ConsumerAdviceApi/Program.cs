using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumerAdviceApi
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            string url = "https://api.adviceslip.com/advice";

            Console.WriteLine("Iniciando requisição para obter dados de um conselho:");
            Console.WriteLine(url);
            Console.WriteLine();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var adviceData = JsonSerializer.Deserialize<AdviceResponse>(responseBody);

                if (adviceData?.Slip != null)
                {
                    Console.WriteLine("Conselho de Hoje:");
                    Console.WriteLine(adviceData.Slip.Advice);
                }
                else
                {
                    Console.WriteLine("Não foi possível processar o conselho recebido.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro na requisição HTTP: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para encerrar...");
            Console.ReadKey();
        }
    }
}