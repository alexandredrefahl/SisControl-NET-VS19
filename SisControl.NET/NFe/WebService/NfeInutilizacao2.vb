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

Namespace Inutilizacao2

    '
    'This source code was auto-generated by wsdl, Version=2.0.50727.1432.
    '

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432"), _
     System.SerializableAttribute(), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeInutilizacao2"), _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeInutilizacao2", IsNullable:=False)> _
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
            Set(ByVal value As String)
                Me.cUFField = value
            End Set
        End Property

        '''<remarks/>
        Public Property versaoDados() As String
            Get
                Return Me.versaoDadosField
            End Get
            Set(ByVal value As String)
                Me.versaoDadosField = value
            End Set
        End Property

        '''<remarks/>
        <System.Xml.Serialization.XmlAnyAttributeAttribute()> _
        Public Property AnyAttr() As System.Xml.XmlAttribute()
            Get
                Return Me.anyAttrField
            End Get
            Set(ByVal value As System.Xml.XmlAttribute())
                Me.anyAttrField = value
            End Set
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")> _
    Public Delegate Sub nfeInutilizacaoNF2CompletedEventHandler(ByVal sender As Object, ByVal e As nfeInutilizacaoNF2CompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code")> _
    Partial Public Class nfeInutilizacaoNF2CompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs

        Private results() As Object

        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub

        '''<remarks/>
        Public ReadOnly Property Result() As System.Xml.XmlNode
            Get
                Me.RaiseExceptionIfNecessary()
                Return CType(Me.results(0), System.Xml.XmlNode)
            End Get
        End Property
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432"), _
     System.Diagnostics.DebuggerStepThroughAttribute(), _
     System.ComponentModel.DesignerCategoryAttribute("code"), _
     System.Web.Services.WebServiceBindingAttribute(Name:="NfeInutilizacao2Soap12", [Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeInutilizacao2")> _
    Partial Public Class NfeInutilizacao2
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private nfeCabecMsgValueField As nfeCabecMsg

        Private nfeInutilizacaoNF2OperationCompleted As System.Threading.SendOrPostCallback

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
            Set(ByVal value As nfeCabecMsg)
                Me.nfeCabecMsgValueField = Value
            End Set
        End Property

        '''<remarks/>
        Public Event nfeInutilizacaoNF2Completed As nfeInutilizacaoNF2CompletedEventHandler

        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("nfeCabecMsgValue", Direction:=System.Web.Services.Protocols.SoapHeaderDirection.InOut), _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NfeInutilizacao2/nfeInutilizacaoNF2", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)> _
        Public Function nfeInutilizacaoNF2(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeInutilizacao2")> ByVal nfeDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NfeInutilizacao2")> System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("nfeInutilizacaoNF2", New Object() {nfeDadosMsg})
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Function BeginnfeInutilizacaoNF2(ByVal nfeDadosMsg As System.Xml.XmlNode, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("nfeInutilizacaoNF2", New Object() {nfeDadosMsg}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndnfeInutilizacaoNF2(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Overloads Sub nfeInutilizacaoNF2Async(ByVal nfeDadosMsg As System.Xml.XmlNode)
            Me.nfeInutilizacaoNF2Async(nfeDadosMsg, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub nfeInutilizacaoNF2Async(ByVal nfeDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.nfeInutilizacaoNF2OperationCompleted Is Nothing) Then
                Me.nfeInutilizacaoNF2OperationCompleted = AddressOf Me.OnnfeInutilizacaoNF2OperationCompleted
            End If
            Me.InvokeAsync("nfeInutilizacaoNF2", New Object() {nfeDadosMsg}, Me.nfeInutilizacaoNF2OperationCompleted, userState)
        End Sub

        Private Sub OnnfeInutilizacaoNF2OperationCompleted(ByVal arg As Object)
            If (Not (Me.nfeInutilizacaoNF2CompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent nfeInutilizacaoNF2Completed(Me, New nfeInutilizacaoNF2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
    End Class

End Namespace