﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//
//     对此文件的更改可能导致不正确的行为，并在以下条件下丢失:
//     代码重新生成。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JCWebService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="JCNoticeInfo", Namespace="http://tempuri.org/")]
    public partial class JCNoticeInfo : object
    {
        
        private string stateField;
        
        private string alertInfoField;
        
        private string supplierNameField;
        
        private string POCodeField;
        
        private string JCNoticeNoField;
        
        private string materialNameField;
        
        private double noticeNumField;
        
        private string packUnitField;
        
        private double volumeField;
        
        private double weightField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string alertInfo
        {
            get
            {
                return this.alertInfoField;
            }
            set
            {
                this.alertInfoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string supplierName
        {
            get
            {
                return this.supplierNameField;
            }
            set
            {
                this.supplierNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string POCode
        {
            get
            {
                return this.POCodeField;
            }
            set
            {
                this.POCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string JCNoticeNo
        {
            get
            {
                return this.JCNoticeNoField;
            }
            set
            {
                this.JCNoticeNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string materialName
        {
            get
            {
                return this.materialNameField;
            }
            set
            {
                this.materialNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public double noticeNum
        {
            get
            {
                return this.noticeNumField;
            }
            set
            {
                this.noticeNumField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string packUnit
        {
            get
            {
                return this.packUnitField;
            }
            set
            {
                this.packUnitField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public double volume
        {
            get
            {
                return this.volumeField;
            }
            set
            {
                this.volumeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public double weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="JCWebService.WebServiceForWMS_WEIXIJCSoap")]
    public interface WebServiceForWMS_WEIXIJCSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getJCNoticeByNo", ReplyAction="*")]
        System.Threading.Tasks.Task<JCWebService.getJCNoticeByNoResponse> getJCNoticeByNoAsync(JCWebService.getJCNoticeByNoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getJCNoticeByNoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getJCNoticeByNo", Namespace="http://tempuri.org/", Order=0)]
        public JCWebService.getJCNoticeByNoRequestBody Body;
        
        public getJCNoticeByNoRequest()
        {
        }
        
        public getJCNoticeByNoRequest(JCWebService.getJCNoticeByNoRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getJCNoticeByNoRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string JCNoticeNo;
        
        public getJCNoticeByNoRequestBody()
        {
        }
        
        public getJCNoticeByNoRequestBody(string JCNoticeNo)
        {
            this.JCNoticeNo = JCNoticeNo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class getJCNoticeByNoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="getJCNoticeByNoResponse", Namespace="http://tempuri.org/", Order=0)]
        public JCWebService.getJCNoticeByNoResponseBody Body;
        
        public getJCNoticeByNoResponse()
        {
        }
        
        public getJCNoticeByNoResponse(JCWebService.getJCNoticeByNoResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class getJCNoticeByNoResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public JCWebService.JCNoticeInfo getJCNoticeByNoResult;
        
        public getJCNoticeByNoResponseBody()
        {
        }
        
        public getJCNoticeByNoResponseBody(JCWebService.JCNoticeInfo getJCNoticeByNoResult)
        {
            this.getJCNoticeByNoResult = getJCNoticeByNoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public interface WebServiceForWMS_WEIXIJCSoapChannel : JCWebService.WebServiceForWMS_WEIXIJCSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public partial class WebServiceForWMS_WEIXIJCSoapClient : System.ServiceModel.ClientBase<JCWebService.WebServiceForWMS_WEIXIJCSoap>, JCWebService.WebServiceForWMS_WEIXIJCSoap
    {
        
        /// <summary>
        /// 实现此分部方法，配置服务终结点。
        /// </summary>
        /// <param name="serviceEndpoint">要配置的终结点</param>
        /// <param name="clientCredentials">客户端凭据</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WebServiceForWMS_WEIXIJCSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(WebServiceForWMS_WEIXIJCSoapClient.GetBindingForEndpoint(endpointConfiguration), WebServiceForWMS_WEIXIJCSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebServiceForWMS_WEIXIJCSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WebServiceForWMS_WEIXIJCSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebServiceForWMS_WEIXIJCSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WebServiceForWMS_WEIXIJCSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebServiceForWMS_WEIXIJCSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }

        public WebServiceForWMS_WEIXIJCSoapClient()
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<JCWebService.getJCNoticeByNoResponse> JCWebService.WebServiceForWMS_WEIXIJCSoap.getJCNoticeByNoAsync(JCWebService.getJCNoticeByNoRequest request)
        {
            return base.Channel.getJCNoticeByNoAsync(request);
        }
        
        public System.Threading.Tasks.Task<JCWebService.getJCNoticeByNoResponse> getJCNoticeByNoAsync(string JCNoticeNo)
        {
            JCWebService.getJCNoticeByNoRequest inValue = new JCWebService.getJCNoticeByNoRequest();
            inValue.Body = new JCWebService.getJCNoticeByNoRequestBody();
            inValue.Body.JCNoticeNo = JCNoticeNo;
            return ((JCWebService.WebServiceForWMS_WEIXIJCSoap)(this)).getJCNoticeByNoAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WebServiceForWMS_WEIXIJCSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.WebServiceForWMS_WEIXIJCSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WebServiceForWMS_WEIXIJCSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://supplier.mh-chine.com:8007/WebServiceForWMS_WEIXIJC.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.WebServiceForWMS_WEIXIJCSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://supplier.mh-chine.com:8007/WebServiceForWMS_WEIXIJC.asmx");
            }
            throw new System.InvalidOperationException(string.Format("找不到名称为“{0}”的终结点。", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            WebServiceForWMS_WEIXIJCSoap,
            
            WebServiceForWMS_WEIXIJCSoap12,
        }
    }
}