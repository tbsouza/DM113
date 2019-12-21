using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EstoqueEntityModel
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da interface "IServicoEstoque" no arquivo de código e configuração ao mesmo tempo.
    [ServiceContract]
    public interface IServicoEstoque
    {
        [OperationContract]
        void DoWork();
    }
}
