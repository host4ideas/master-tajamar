using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LogicaPrimerServicioWCF
{
    [ServiceContract]
    internal interface IMetodosVariosContract
    {
        [OperationContract]
        int GetNumeroDoble(int numero);
        [OperationContract]
        string GetSaludo(string nombre);
        [OperationContract]
        List<int> GetTablaMultiplicar(int numero);
        string MetodoInvisible(int numero);
    }
}
