﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:2.0.50727.3615
'
'     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
'     o código for gerado novamente.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by wsdl, Version=2.0.50727.1432.
'

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432"),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Web.Services.WebServiceBindingAttribute(Name:="NfeCancelamento2Soap12", [Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeCancelamento2")>  _
Partial Public Class NfeCancelamento2
    Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
    
    Private nfeCabecMsgValueField As nfeCabecMsg
    
    Private nfeCancelamentoNF2OperationCompleted As System.Threading.SendOrPostCallback
    
    '''<remarks/>
    Public Sub New(ByVal V_Url As String)
        MyBase.New()
        Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
        Me.Url = V_Url
    End Sub
    
    Public Property nfeCabecMsgValue() As nfeCabecMsg
        Get
            Return Me.nfeCabecMsgValueField
        End Get
        Set
            Me.nfeCabecMsgValueField = value
        End Set
    End Property
    
    '''<remarks/>
    Public Event nfeCancelamentoNF2Completed As nfeCancelamentoNF2CompletedEventHandler
    
    '''<remarks/>
    <System.Web.Services.Protocols.SoapHeaderAttribute("nfeCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut),  _
     System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NfeCancelamento2/nfeCancelamentoNF2", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)>  _
    Public Function nfeCancelamentoNF2(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeCancelamento2")> ByVal nfeDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeCancelamento2")> System.Xml.XmlNode
        Dim results() As Object = Me.Invoke("nfeCancelamentoNF2", New Object() {nfeDadosMsg})
        Return CType(results(0),System.Xml.XmlNode)
    End Function
    
    '''<remarks/>
    Public Function BeginnfeCancelamentoNF2(ByVal nfeDadosMsg As System.Xml.XmlNode, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
        Return Me.BeginInvoke("nfeCancelamentoNF2", New Object() {nfeDadosMsg}, callback, asyncState)
    End Function
    
    '''<remarks/>
    Public Function EndnfeCancelamentoNF2(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
        Dim results() As Object = Me.EndInvoke(asyncResult)
        Return CType(results(0),System.Xml.XmlNode)
    End Function
    
    '''<remarks/>
    Public Overloads Sub nfeCancelamentoNF2Async(ByVal nfeDadosMsg As System.Xml.XmlNode)
        Me.nfeCancelamentoNF2Async(nfeDadosMsg, Nothing)
    End Sub
    
    '''<remarks/>
    Public Overloads Sub nfeCancelamentoNF2Async(ByVal nfeDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
        If (Me.nfeCancelamentoNF2OperationCompleted Is Nothing) Then
            Me.nfeCancelamentoNF2OperationCompleted = AddressOf Me.OnnfeCancelamentoNF2OperationCompleted
        End If
        Me.InvokeAsync("nfeCancelamentoNF2", New Object() {nfeDadosMsg}, Me.nfeCancelamentoNF2OperationCompleted, userState)
    End Sub
    
    Private Sub OnnfeCancelamentoNF2OperationCompleted(ByVal arg As Object)
        If (Not (Me.nfeCancelamentoNF2CompletedEvent) Is Nothing) Then
            Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
            RaiseEvent nfeCancelamentoNF2Completed(Me, New nfeCancelamentoNF2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
        End If
    End Sub
    
    '''<remarks/>
    Public Shadows Sub CancelAsync(ByVal userState As Object)
        MyBase.CancelAsync(userState)
    End Sub
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432"),  _
 System.SerializableAttribute(),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeCancelamento2"),  _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeCancelamento2", IsNullable:=false)>  _
Partial Public Class nfeCabecMsg
    Inherits System.Web.Services.Protocols.SoapHeader
    
    Private cUFField As String
    
    Private versaoDadosField As String
    
    Private anyAttrField() As System.Xml.XmlAttribute
    
    '''<remarks/>
    Public Property cUF() As String
        Get
            Return Me.cUFField
        End Get
        Set
            Me.cUFField = value
        End Set
    End Property
    
    '''<remarks/>
    Public Property versaoDados() As String
        Get
            Return Me.versaoDadosField
        End Get
        Set
            Me.versaoDadosField = value
        End Set
    End Property
    
    '''<remarks/>
    <System.Xml.Serialization.XmlAnyAttributeAttribute()>  _
    Public Property AnyAttr() As System.Xml.XmlAttribute()
        Get
            Return Me.anyAttrField
        End Get
        Set
            Me.anyAttrField = value
        End Set
    End Property
End Class

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")>  _
Public Delegate Sub nfeCancelamentoNF2CompletedEventHandler(ByVal sender As Object, ByVal e As nfeCancelamentoNF2CompletedEventArgs)

'''<remarks/>
<System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432"),  _
 System.Diagnostics.DebuggerStepThroughAttribute(),  _
 System.ComponentModel.DesignerCategoryAttribute("code")>  _
Partial Public Class nfeCancelamentoNF2CompletedEventArgs
    Inherits System.ComponentModel.AsyncCompletedEventArgs
    
    Private results() As Object
    
    Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
        MyBase.New(exception, cancelled, userState)
        Me.results = results
    End Sub
    
    '''<remarks/>
    Public ReadOnly Property Result() As System.Xml.XmlNode
        Get
            Me.RaiseExceptionIfNecessary
            Return CType(Me.results(0),System.Xml.XmlNode)
        End Get
    End Property
End Class
