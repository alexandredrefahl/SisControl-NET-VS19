﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:4.0.30319.42000
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
'This source code was auto-generated by wsdl, Version=4.6.1055.0.
'
Namespace NFeStatusServicoV4

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0"),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Web.Services.WebServiceBindingAttribute(Name:="NFeStatusServico4Soap12", [Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4")>
    Partial Public Class NFeStatusServico4
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

        Private nfeStatusServicoNFOperationCompleted As System.Threading.SendOrPostCallback

        '''<remarks/>
        Public Sub New(ByVal URLSel As String)
            MyBase.New
            Me.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12
            Me.Url = URLSel
        End Sub

        '''<remarks/>
        Public Event nfeStatusServicoNFCompleted As nfeStatusServicoNFCompletedEventHandler

        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4/nfeStatusServicoNF", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Bare)>
        Public Function nfeStatusServicoNF(<System.Xml.Serialization.XmlElementAttribute([Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4")> ByVal nfeDadosMsg As System.Xml.XmlNode) As <System.Xml.Serialization.XmlElementAttribute("nfeResultMsg", [Namespace]:="http://www.portalfiscal.inf.br/nfe/wsdl/NFeStatusServico4", IsNullable:=True)> System.Xml.XmlNode
            Dim results() As Object = Me.Invoke("nfeStatusServicoNF", New Object() {nfeDadosMsg})
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Function BeginnfeStatusServicoNF(ByVal nfeDadosMsg As System.Xml.XmlNode, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("nfeStatusServicoNF", New Object() {nfeDadosMsg}, callback, asyncState)
        End Function

        '''<remarks/>
        Public Function EndnfeStatusServicoNF(ByVal asyncResult As System.IAsyncResult) As System.Xml.XmlNode
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0), System.Xml.XmlNode)
        End Function

        '''<remarks/>
        Public Overloads Sub nfeStatusServicoNFAsync(ByVal nfeDadosMsg As System.Xml.XmlNode)
            Me.nfeStatusServicoNFAsync(nfeDadosMsg, Nothing)
        End Sub

        '''<remarks/>
        Public Overloads Sub nfeStatusServicoNFAsync(ByVal nfeDadosMsg As System.Xml.XmlNode, ByVal userState As Object)
            If (Me.nfeStatusServicoNFOperationCompleted Is Nothing) Then
                Me.nfeStatusServicoNFOperationCompleted = AddressOf Me.OnnfeStatusServicoNFOperationCompleted
            End If
            Me.InvokeAsync("nfeStatusServicoNF", New Object() {nfeDadosMsg}, Me.nfeStatusServicoNFOperationCompleted, userState)
        End Sub

        Private Sub OnnfeStatusServicoNFOperationCompleted(ByVal arg As Object)
            If (Not (Me.nfeStatusServicoNFCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg, System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent nfeStatusServicoNFCompleted(Me, New nfeStatusServicoNFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub

        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
    End Class

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0")>
    Public Delegate Sub nfeStatusServicoNFCompletedEventHandler(ByVal sender As Object, ByVal e As nfeStatusServicoNFCompletedEventArgs)

    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.6.1055.0"),
 System.Diagnostics.DebuggerStepThroughAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code")>
    Partial Public Class nfeStatusServicoNFCompletedEventArgs
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
                Return CType(Me.results(0), System.Xml.XmlNode)
            End Get
        End Property
    End Class
End Namespace