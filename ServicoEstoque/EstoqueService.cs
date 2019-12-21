using EstoqueEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;

namespace ServicoEstoque
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código e configuração ao mesmo tempo.

    // WCF service that implements the service contract
    // This implementation performs minimal error checking and exception handling
    [AspNetCompatibilityRequirements(
    RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class EstoqueService : IEstoqueService
    {
        public bool AdicionarEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Products.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    // Adiciona a quantidade ao estoque
                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto + Quantidade;

                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            // Sucesso
            return true;
        }

        public int ConsultarEstoque(string NumeroProsuto)
        {
            int estoqueProduto = 0;

            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Products.First(
                        p => String.Compare(p.NumeroProduto, NumeroProsuto) == 0);

                    estoqueProduto = produtoEstoque.EstoqueProduto;
                }
            }
            catch
            {

            }

            return estoqueProduto;
        }

        public bool IncluirProduto(ProductData Produto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.NumeroProduto = Produto.NumeroProduto;
                    produtoEstoque.NomeProduto = Produto.NomeProduto;
                    produtoEstoque.DescricaoProduto = Produto.DescricaoProduto;
                    produtoEstoque.EstoqueProduto = Produto.EstoqueProduto;

                    database.Products.Add(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;

        }

        public List<String> ListarProdutos()
        {
            // Create a list of products
            List<String> productsList = new List<String>();
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Fetch the products in the database
                    List<ProdutoEstoque> products = (from product in database.Products
                                                     select product).ToList();
                    foreach (ProdutoEstoque product in products)
                    {
                        productsList.Add(product.NomeProduto);
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the list of products
            return productsList;
        }

        public bool RemoverEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Products.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    // Remove a quantidade do estoque
                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto - Quantidade;

                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            // Sucesso
            return true;
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Products.First(
                        p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);

                    database.Products.Remove(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            // Product Removed
            return true;
        }

        public ProductData VerProduto(string NumeroProduto)
        {
            ProductData productData = null;

            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.Products.First(
                     p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);
                    productData = new ProductData()
                    {
                        NumeroProduto = matchingProduct.NumeroProduto,
                        NomeProduto = matchingProduct.NomeProduto,
                        DescricaoProduto = matchingProduct.DescricaoProduto,
                        EstoqueProduto = matchingProduct.EstoqueProduto
                    };
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the product
            return productData;
        }

    }
}
