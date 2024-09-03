using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            if(ValidaPlaca(placa)) //Valuda formato
            {
                veiculos.Add(placa);
            }
            else{Console.WriteLine("Placa inváida");}
            
        }

        public void RemoverVeiculo()
        {
            try
            {
                Console.WriteLine("Digite a placa do veículo para remover:");

                // Pedir para o usuário digitar a placa e armazenar na variável placa
                // *IMPLEMENTE AQUI*
                string placa = Console.ReadLine().ToUpper();

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    
                    int horas = Convert.ToInt16(Console.ReadLine());
                    decimal valorTotal = precoInicial + (precoPorHora * horas); 
                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        public bool ValidaPlaca(string placa) //Valida o formato da placa
        {
            string formatoAntigo = @"^[A-Z]{3}-\d{4}$";
            string formatoMercosul = @"^[A-Z]{3}-\d[A-Z]\d{2}$";

            // Criando objetos Regex para os padrões
            Regex regexAntigo = new Regex(formatoAntigo);
            Regex regexMercosul = new Regex(formatoMercosul);

            // Verifica se a placa corresponde a algum dos formatos
            return regexAntigo.IsMatch(placa) || regexMercosul.IsMatch(placa);

        }
    }
}
