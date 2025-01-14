namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial = 0;
        private decimal PrecoPorHora = 0;
        private List<Veiculo> Veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            
            Veiculo veiculo = new(placa);
            Veiculos.Add(veiculo);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            Veiculo veiculoParaRemover = Veiculos.First(v => v.Placa.ToUpper() == placa.ToUpper());
            
            // Verifica se o veículo existe
            if (veiculoParaRemover != null)
            {
                double horas = DateTime.Now.Subtract(veiculoParaRemover.HoraEntrada).TotalHours;
                decimal horasArredondadas = Math.Ceiling(Convert.ToDecimal(horas));
                decimal valorTotal = PrecoInicial + PrecoPorHora * horasArredondadas;                
                Veiculos.Remove(veiculoParaRemover);

                Console.WriteLine($"O veículo {veiculoParaRemover.Placa} foi removido e o preço total foi de: R$ {valorTotal}");                
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (Veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                Veiculos.ForEach(veiculo =>
                {
                    Console.WriteLine(veiculo.Placa);
                });
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
