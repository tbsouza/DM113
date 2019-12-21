using ServicoEstoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost servicoEstoqueHost = new ServiceHost(typeof(EstoqueService));
            servicoEstoqueHost.Open();

            Console.WriteLine("Serviço Ativado");
            Console.ReadLine();
            Console.WriteLine("Desativando Serviço");

            servicoEstoqueHost.Close();
        }
    }
}
