using ExamenMercadolibreMutantes.Dto;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace StressTestConsole
{
    class Program
    {
        static private Random random = new Random();
        static HttpClient client = new HttpClient();

        static async Task<string> CallMutantsEndpoint(RequestDto request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);

            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(
                "mutant", httpContent);
            
            return response.StatusCode.ToString();
        } 

        static void Main()
        {
            client.BaseAddress = new Uri("https://examenmercadolibremutantes-dev-as.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(

                new MediaTypeWithQualityHeaderValue("application/json"));

            for (int i = 0; i < 1000; i++)
            {
                Thread t = new Thread(new ThreadStart(ThreadProc));
                t.Start();
            }

            Console.ReadLine();

        }

        static void ThreadProc()
        {
            RunAsync();
        }

        static async void RunAsync()
        {

            try
            {
                RequestDto request = CreateRamdomDNA();                

                var response = await CallMutantsEndpoint(request);
                Console.WriteLine($"Response: {response}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        static private RequestDto CreateRamdomDNA()
        {
            int length = random.Next(4, 10);

            string[] randomDna = new string[length];

            for (int i = 0; i < length; i++)
            {
                randomDna[i] = RandomString(length);
            }

            return new RequestDto { dna = randomDna };


        }

        static public string RandomString(int length)
        {
            const string chars = "ATCG";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}