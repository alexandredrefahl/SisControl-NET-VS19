Public Class crtlNegocio

    Public Overrides Function ToString() As String
        Return _id
    End Function

    'Um enumerador de Cores
    Private Enum Status_Negocio
        Ideia = 0
        Contactado = 1
        Necessidades = 2
        Negociacao = 3
        Proposta = 4
        Fechado = 5
    End Enum

    'Define as cores padrão
    Private Ideia As System.Drawing.Color = Color.White
    Private Contactado As System.Drawing.Color = Color.Yellow
    Private Necessidades As System.Drawing.Color = Color.Orange
    Private Negociacao As System.Drawing.Color = Color.Red
    Private Proposta As System.Drawing.Color = Color.Purple
    Private Fechado As System.Drawing.Color = Color.Green

    Private Cores(6) As System.Drawing.Color

    ''' <summary>
    ''' Nome do cliente
    ''' </summary>
    Private _Nome As String
    Public Property Nome() As String
        Get
            Return _Nome
        End Get
        Set(ByVal value As String)
            _Nome = value
        End Set
    End Property

    ''' <summary>
    ''' Valor do Negócio
    ''' </summary>
    Private _Valor As Double
    Public Property Valor() As Double
        Get
            Return _Valor
        End Get
        Set(ByVal value As Double)
            _Valor = value
        End Set
    End Property

    ''' <summary>
    ''' Id do registro no Banco de Dados
    ''' </summary>
    Private _id As Integer
    Public Property NegID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    ''' <summary>
    ''' Data da última Alteração
    ''' </summary>
    Private _data As String
    Public Property Data() As String
        Get
            Return _data
        End Get
        Set(ByVal value As String)
            _data = value
        End Set
    End Property

    '***
    '*
    '*  Overrides da Função New com Diversos Parâmetros 
    '*
    '***

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Inicializa_Cores()
    End Sub
    'Cria um Override para inicializar com dados
    Public Sub New(ByVal Nome As String, ByVal width As Integer, ByVal height As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        Inicializa_Cores()
        Me.Name = Nome
        Me.Size = New System.Drawing.Size(width, height)
    End Sub

    'Cria um Override para inicializar com dados
    Public Sub New(ByVal Nome As String, ByVal width As Integer, ByVal height As Integer, ByVal NegID As Integer, ByVal Cliente As String, ByVal Valor As Double, ByVal Status As Integer, ByVal Data As String)
        ' This call is required by the designer.
        InitializeComponent()
        Inicializa_Cores()
        Me.Name = Nome
        Me.Size = New System.Drawing.Size(width, height)
        _id = NegID
        _Nome = Cliente
        _Valor = Valor
        'Mostra os dados no controle
        lblCliente.Text = _Nome
        lblValor.Text = IIf(_Valor = 0, String.Empty, Format(_Valor, "N2"))
        lblCor.BackColor = Cores(Status)
        lblData.Text = Data
    End Sub

    Private Sub Inicializa_Cores()
        Cores(Status_Negocio.Ideia) = Ideia
        Cores(Status_Negocio.Contactado) = Contactado
        Cores(Status_Negocio.Necessidades) = Necessidades
        Cores(Status_Negocio.Proposta) = Proposta
        Cores(Status_Negocio.Negociacao) = Negociacao
        Cores(Status_Negocio.Fechado) = Fechado
    End Sub

    Private Sub crtlNegocio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub crtlNegocio_MouseHover(sender As Object, e As EventArgs) Handles MyBase.MouseHover
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private Sub crtlNegocio_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Me.BorderStyle = System.Windows.Forms.BorderStyle.None
    End Sub
End Class
