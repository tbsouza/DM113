using System.Collections.Generic;
using System.Runtime.Serialization;

using System.ServiceModel;

namespace Estoque
{
    // Definição do contrato de dados
    [DataContract]
    public class ProductData
    {
        [DataMember]
        public string NumeroProduto;

        [DataMember]
        public string NomeProduto;

        [DataMember]
        public string DescricaoProduto;

        [DataMember]
        public int EstoqueProduto;
    }

    // Definiçao do contrato de serviço v1
    [ServiceContract]
    public interface IEstoqueService
    {
        [OperationContract]
        List<string> ListarProdutos();

        [OperationContract]
        bool IncluirProduto(ProductData Produto);

        [OperationContract]
        bool RemoverProduto(string NumeroProduto);

        [OperationContract]
        int ConsultarEstoque(string NumeroProsuto);

        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        ProductData VerProduto(string NumeroProduto);
    }

    // Definiçao do contrato de serviço v1
    [ServiceContract]
    public interface IEstoqueServiceV2
    {
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);

        [OperationContract]
        int ConsultarEstoque(string NumeroProsuto);
    }


}