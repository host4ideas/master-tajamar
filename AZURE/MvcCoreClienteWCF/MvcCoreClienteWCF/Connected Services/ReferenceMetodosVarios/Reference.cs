﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReferenceMetodosVarios
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReferenceMetodosVarios.IMetodosVariosContract")]
    public interface IMetodosVariosContract
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMetodosVariosContract/GetNumeroDoble", ReplyAction="http://tempuri.org/IMetodosVariosContract/GetNumeroDobleResponse")]
        System.Threading.Tasks.Task<int> GetNumeroDobleAsync(int numero);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMetodosVariosContract/GetSaludo", ReplyAction="http://tempuri.org/IMetodosVariosContract/GetSaludoResponse")]
        System.Threading.Tasks.Task<string> GetSaludoAsync(string nombre);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMetodosVariosContract/GetTablaMultiplicar", ReplyAction="http://tempuri.org/IMetodosVariosContract/GetTablaMultiplicarResponse")]
        System.Threading.Tasks.Task<int[]> GetTablaMultiplicarAsync(int numero);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public interface IMetodosVariosContractChannel : ReferenceMetodosVarios.IMetodosVariosContract, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    public partial class MetodosVariosContractClient : System.ServiceModel.ClientBase<ReferenceMetodosVarios.IMetodosVariosContract>, ReferenceMetodosVarios.IMetodosVariosContract
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public MetodosVariosContractClient() : 
                base(MetodosVariosContractClient.GetDefaultBinding(), MetodosVariosContractClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IMetodosVariosContract.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MetodosVariosContractClient(EndpointConfiguration endpointConfiguration) : 
                base(MetodosVariosContractClient.GetBindingForEndpoint(endpointConfiguration), MetodosVariosContractClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MetodosVariosContractClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(MetodosVariosContractClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MetodosVariosContractClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(MetodosVariosContractClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MetodosVariosContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<int> GetNumeroDobleAsync(int numero)
        {
            return base.Channel.GetNumeroDobleAsync(numero);
        }
        
        public System.Threading.Tasks.Task<string> GetSaludoAsync(string nombre)
        {
            return base.Channel.GetSaludoAsync(nombre);
        }
        
        public System.Threading.Tasks.Task<int[]> GetTablaMultiplicarAsync(int numero)
        {
            return base.Channel.GetTablaMultiplicarAsync(numero);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMetodosVariosContract))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMetodosVariosContract))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:51798/ServiceMetodosVarios.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return MetodosVariosContractClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IMetodosVariosContract);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return MetodosVariosContractClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IMetodosVariosContract);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IMetodosVariosContract,
        }
    }
}
