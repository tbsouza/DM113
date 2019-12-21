﻿using ProvedorEstoqueHost.ProductsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione ENTER quando o serviço for iniciado");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ServicoEstoqueClient proxy = new ServicoEstoqueV2Client("WS2007HttpBinding_IServicoEstoque");

           
            // Test the operations in the service
            Console.WriteLine("Cliente 2");
            Console.WriteLine();

            //**********************************************************************

            Console.WriteLine("Teste 1: Verificar estoque do produto 1");
            int estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque do produto 1: {0}", estoque);
            Console.WriteLine();

            //**********************************************************************

            Console.WriteLine("Teste 2: Adicionar estoque para produto 1");
            
            if (proxy.AdicionarEstoque("1000", 20))
            {
                Console.WriteLine("Estoque adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro na adição do estoque de produto!");
            }
            Console.WriteLine();

            //**********************************************************************

            Console.WriteLine("Teste 3: Verificar estoque do produto 1 novamente");
            
            Console.WriteLine("Estoque do produto 1: {0}", proxy.ConsultarEstoque("1000"));
            Console.WriteLine();

            //**********************************************************************

            Console.WriteLine("Teste 4: Verificar estoque do produto 5");
            
            Console.WriteLine("Estoque do produto 5: {0}", proxy.ConsultarEstoque("5000"));
            Console.WriteLine();

            //**********************************************************************

            Console.WriteLine("Teste 5: Remover estoque para produto 5");
            
            if (proxy.RemoverEstoque("5000", 10))
            {
                Console.WriteLine("Estoque removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro na remoção do estoque de produto!");
            }
            Console.WriteLine();

            //**********************************************************************

            Console.WriteLine("Teste 6: Verificar estoque do produto 5 novamente");
            
            Console.WriteLine("Estoque do produto 5: {0}", proxy.ConsultarEstoque("5000"));
            Console.WriteLine();

            //**********************************************************************

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();

        }
    }
}
