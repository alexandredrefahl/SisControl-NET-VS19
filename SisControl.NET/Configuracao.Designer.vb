﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3074
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace Config
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")>  _
    Partial Friend NotInheritable Class Configuracao
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As Configuracao = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Configuracao),Configuracao)
        
        Public Shared ReadOnly Property [Default]() As Configuracao
            Get
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10.1.1.6")>  _
        Public ReadOnly Property Servidor() As String
            Get
                Return CType(Me("Servidor"),String)
            End Get
        End Property
    End Class
End Namespace
