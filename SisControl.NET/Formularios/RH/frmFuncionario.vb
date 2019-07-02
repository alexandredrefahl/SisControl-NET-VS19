Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO


Public Class frmFuncionario
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'For the start-up form, the first instance created is the default instance.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'This form is an MDI child.
        'This code simulates the VB6 
        ' functionality of automatically
        ' loading and showing an MDI
        ' child's parent.
        'Me.MDIParent = SisControl.frmMenu.DefInstance.DefInstance
        'SisControl.frmMenu.DefInstance.DefInstance.Show
        'The MDI form in the VB6 project had its
        'AutoShowChildren property set to True
        'To simulate the VB6 behavior, we need to
        'automatically Show the form whenever it
        'is loaded.  If you do not want this behavior
        'then delete the following line of code
        'UPGRADE_NOTE: Remove the next line of code to stop form from automatically showing. Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2018"'
        Me.Show()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Public WithEvents btImprime As System.Windows.Forms.Button

    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents chkAtivo As System.Windows.Forms.CheckBox
    Public WithEvents chkVT As System.Windows.Forms.CheckBox
    Public WithEvents chkAposentado As System.Windows.Forms.CheckBox
    Public WithEvents cmbHoraMes As System.Windows.Forms.ComboBox
    Public WithEvents txtSetor As System.Windows.Forms.TextBox
    Public WithEvents txtPonto As System.Windows.Forms.TextBox
    Public WithEvents txtEmergencia As System.Windows.Forms.TextBox
    Public WithEvents txtNomeEmergencia As System.Windows.Forms.TextBox
    Public WithEvents txtEmail As System.Windows.Forms.TextBox
    Public WithEvents txtCelular As System.Windows.Forms.TextBox
    Public WithEvents txtFone As System.Windows.Forms.TextBox
    Public WithEvents txtCEP As System.Windows.Forms.TextBox
    Public WithEvents txtCidade As System.Windows.Forms.TextBox
    Public WithEvents txtCalca As System.Windows.Forms.TextBox
    Public WithEvents txtLuvas As System.Windows.Forms.TextBox
    Public WithEvents txtCalcado As System.Windows.Forms.TextBox
    Public WithEvents txtCamisa As System.Windows.Forms.TextBox
    Public WithEvents txtAltura As System.Windows.Forms.TextBox
    Public WithEvents txtPeso As System.Windows.Forms.TextBox
    Public WithEvents txtOlhos As System.Windows.Forms.TextBox
    Public WithEvents txtCabelos As System.Windows.Forms.TextBox
    Public WithEvents txtCor As System.Windows.Forms.TextBox
    Public WithEvents txtNumVT As System.Windows.Forms.TextBox
    Public WithEvents txtPIS As System.Windows.Forms.TextBox
    Public WithEvents txtBairro As System.Windows.Forms.TextBox
    Public WithEvents txtNum As System.Windows.Forms.TextBox
    Public WithEvents txtEndereco As System.Windows.Forms.TextBox
    Public WithEvents txtBeneficio As System.Windows.Forms.TextBox
    Public WithEvents txtMae As System.Windows.Forms.TextBox
    Public WithEvents txtPai As System.Windows.Forms.TextBox
    Public WithEvents txtInstrucao As System.Windows.Forms.TextBox
    Public WithEvents txtDependentes As System.Windows.Forms.TextBox
    Public WithEvents txtConjuge As System.Windows.Forms.TextBox
    Public WithEvents txtEstCivil As System.Windows.Forms.TextBox
    Public WithEvents txtRegiao As System.Windows.Forms.TextBox
    Public WithEvents txtRM As System.Windows.Forms.TextBox
    Public WithEvents txtSecao As System.Windows.Forms.TextBox
    Public WithEvents txtZona As System.Windows.Forms.TextBox
    Public WithEvents txtEleitor As System.Windows.Forms.TextBox
    Public WithEvents txtCategoria As System.Windows.Forms.TextBox
    Public WithEvents txtHabilitacao As System.Windows.Forms.TextBox
    Public WithEvents txtCBO As System.Windows.Forms.TextBox
    Public WithEvents txtTrabalho As System.Windows.Forms.TextBox
    Public WithEvents txtEmissor As System.Windows.Forms.TextBox
    Public WithEvents txtIdentidade As System.Windows.Forms.TextBox
    Public WithEvents txtCPF As System.Windows.Forms.TextBox
    Public WithEvents txtExperiencia As System.Windows.Forms.TextBox
    Public WithEvents txtSalario As System.Windows.Forms.TextBox
    Public WithEvents txtFuncao As System.Windows.Forms.TextBox
    Public WithEvents txtNome As System.Windows.Forms.TextBox

    Public WithEvents imgFoto As System.Windows.Forms.PictureBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Line3 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_10 As System.Windows.Forms.Label
    Public WithEvents Line2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Line1 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_59 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_58 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_56 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_55 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_54 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_53 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_52 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_51 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_50 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_49 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_48 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_47 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_46 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_45 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_44 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_43 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_42 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_41 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_40 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_39 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_38 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_37 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_36 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_35 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_33 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_32 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_30 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_29 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_28 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_27 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_26 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_25 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_24 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_23 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_22 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_21 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_20 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_19 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_18 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_17 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_16 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_15 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_14 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_13 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_12 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_11 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_9 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_8 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_7 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_6 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_5 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_4 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_2 As System.Windows.Forms.Label
    Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
    Friend WithEvents txtNascimento As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtAdmissao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDemissao As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtEntM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSaiM As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtEntT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtSaiT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDataPIS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DsCadastro As SisControl.NET.dsCadastro
    Friend WithEvents bsFuncionarios As System.Windows.Forms.BindingSource
    Friend WithEvents navFuncionarios As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FuncionariosBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents IdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ttInfo As System.Windows.Forms.ToolTip
    Friend WithEvents fdArquivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents taFuncionarios As SisControl.NET.dsCadastroTableAdapters.funcionariosTableAdapter
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Public WithEvents _lblLabels_0 As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFuncionario))
        Me.btImprime = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.chkAtivo = New System.Windows.Forms.CheckBox()
        Me.bsFuncionarios = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCadastro = New SisControl.NET.dsCadastro()
        Me.chkVT = New System.Windows.Forms.CheckBox()
        Me.chkAposentado = New System.Windows.Forms.CheckBox()
        Me.cmbHoraMes = New System.Windows.Forms.ComboBox()
        Me.txtSetor = New System.Windows.Forms.TextBox()
        Me.txtPonto = New System.Windows.Forms.TextBox()
        Me.txtEmergencia = New System.Windows.Forms.TextBox()
        Me.txtNomeEmergencia = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.txtFone = New System.Windows.Forms.TextBox()
        Me.txtCEP = New System.Windows.Forms.TextBox()
        Me.txtCidade = New System.Windows.Forms.TextBox()
        Me.txtCalca = New System.Windows.Forms.TextBox()
        Me.txtLuvas = New System.Windows.Forms.TextBox()
        Me.txtCalcado = New System.Windows.Forms.TextBox()
        Me.txtCamisa = New System.Windows.Forms.TextBox()
        Me.txtAltura = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtOlhos = New System.Windows.Forms.TextBox()
        Me.txtCabelos = New System.Windows.Forms.TextBox()
        Me.txtCor = New System.Windows.Forms.TextBox()
        Me.txtNumVT = New System.Windows.Forms.TextBox()
        Me.txtPIS = New System.Windows.Forms.TextBox()
        Me.txtBairro = New System.Windows.Forms.TextBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.txtEndereco = New System.Windows.Forms.TextBox()
        Me.txtBeneficio = New System.Windows.Forms.TextBox()
        Me.txtMae = New System.Windows.Forms.TextBox()
        Me.txtPai = New System.Windows.Forms.TextBox()
        Me.txtInstrucao = New System.Windows.Forms.TextBox()
        Me.txtDependentes = New System.Windows.Forms.TextBox()
        Me.txtConjuge = New System.Windows.Forms.TextBox()
        Me.txtEstCivil = New System.Windows.Forms.TextBox()
        Me.txtRegiao = New System.Windows.Forms.TextBox()
        Me.txtRM = New System.Windows.Forms.TextBox()
        Me.txtSecao = New System.Windows.Forms.TextBox()
        Me.txtZona = New System.Windows.Forms.TextBox()
        Me.txtEleitor = New System.Windows.Forms.TextBox()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.txtHabilitacao = New System.Windows.Forms.TextBox()
        Me.txtCBO = New System.Windows.Forms.TextBox()
        Me.txtTrabalho = New System.Windows.Forms.TextBox()
        Me.txtEmissor = New System.Windows.Forms.TextBox()
        Me.txtIdentidade = New System.Windows.Forms.TextBox()
        Me.txtCPF = New System.Windows.Forms.TextBox()
        Me.txtExperiencia = New System.Windows.Forms.TextBox()
        Me.txtSalario = New System.Windows.Forms.TextBox()
        Me.txtFuncao = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.imgFoto = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Line3 = New System.Windows.Forms.Label()
        Me._lblLabels_10 = New System.Windows.Forms.Label()
        Me.Line2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._lblLabels_59 = New System.Windows.Forms.Label()
        Me._lblLabels_58 = New System.Windows.Forms.Label()
        Me._lblLabels_56 = New System.Windows.Forms.Label()
        Me._lblLabels_55 = New System.Windows.Forms.Label()
        Me._lblLabels_54 = New System.Windows.Forms.Label()
        Me._lblLabels_53 = New System.Windows.Forms.Label()
        Me._lblLabels_52 = New System.Windows.Forms.Label()
        Me._lblLabels_51 = New System.Windows.Forms.Label()
        Me._lblLabels_50 = New System.Windows.Forms.Label()
        Me._lblLabels_49 = New System.Windows.Forms.Label()
        Me._lblLabels_48 = New System.Windows.Forms.Label()
        Me._lblLabels_47 = New System.Windows.Forms.Label()
        Me._lblLabels_46 = New System.Windows.Forms.Label()
        Me._lblLabels_45 = New System.Windows.Forms.Label()
        Me._lblLabels_44 = New System.Windows.Forms.Label()
        Me._lblLabels_43 = New System.Windows.Forms.Label()
        Me._lblLabels_42 = New System.Windows.Forms.Label()
        Me._lblLabels_41 = New System.Windows.Forms.Label()
        Me._lblLabels_40 = New System.Windows.Forms.Label()
        Me._lblLabels_39 = New System.Windows.Forms.Label()
        Me._lblLabels_38 = New System.Windows.Forms.Label()
        Me._lblLabels_37 = New System.Windows.Forms.Label()
        Me._lblLabels_36 = New System.Windows.Forms.Label()
        Me._lblLabels_35 = New System.Windows.Forms.Label()
        Me._lblLabels_33 = New System.Windows.Forms.Label()
        Me._lblLabels_32 = New System.Windows.Forms.Label()
        Me._lblLabels_30 = New System.Windows.Forms.Label()
        Me._lblLabels_29 = New System.Windows.Forms.Label()
        Me._lblLabels_28 = New System.Windows.Forms.Label()
        Me._lblLabels_27 = New System.Windows.Forms.Label()
        Me._lblLabels_26 = New System.Windows.Forms.Label()
        Me._lblLabels_25 = New System.Windows.Forms.Label()
        Me._lblLabels_24 = New System.Windows.Forms.Label()
        Me._lblLabels_23 = New System.Windows.Forms.Label()
        Me._lblLabels_22 = New System.Windows.Forms.Label()
        Me._lblLabels_21 = New System.Windows.Forms.Label()
        Me._lblLabels_20 = New System.Windows.Forms.Label()
        Me._lblLabels_19 = New System.Windows.Forms.Label()
        Me._lblLabels_18 = New System.Windows.Forms.Label()
        Me._lblLabels_17 = New System.Windows.Forms.Label()
        Me._lblLabels_16 = New System.Windows.Forms.Label()
        Me._lblLabels_15 = New System.Windows.Forms.Label()
        Me._lblLabels_14 = New System.Windows.Forms.Label()
        Me._lblLabels_13 = New System.Windows.Forms.Label()
        Me._lblLabels_12 = New System.Windows.Forms.Label()
        Me._lblLabels_11 = New System.Windows.Forms.Label()
        Me._lblLabels_9 = New System.Windows.Forms.Label()
        Me._lblLabels_8 = New System.Windows.Forms.Label()
        Me._lblLabels_7 = New System.Windows.Forms.Label()
        Me._lblLabels_6 = New System.Windows.Forms.Label()
        Me._lblLabels_5 = New System.Windows.Forms.Label()
        Me._lblLabels_4 = New System.Windows.Forms.Label()
        Me._lblLabels_3 = New System.Windows.Forms.Label()
        Me._lblLabels_2 = New System.Windows.Forms.Label()
        Me._lblLabels_1 = New System.Windows.Forms.Label()
        Me._lblLabels_0 = New System.Windows.Forms.Label()
        Me.txtNascimento = New System.Windows.Forms.MaskedTextBox()
        Me.txtAdmissao = New System.Windows.Forms.MaskedTextBox()
        Me.txtDemissao = New System.Windows.Forms.MaskedTextBox()
        Me.txtEntM = New System.Windows.Forms.MaskedTextBox()
        Me.txtSaiM = New System.Windows.Forms.MaskedTextBox()
        Me.txtEntT = New System.Windows.Forms.MaskedTextBox()
        Me.txtSaiT = New System.Windows.Forms.MaskedTextBox()
        Me.txtDataPIS = New System.Windows.Forms.MaskedTextBox()
        Me.navFuncionarios = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.FuncionariosBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.IdTextBox = New System.Windows.Forms.TextBox()
        Me.ttInfo = New System.Windows.Forms.ToolTip(Me.components)
        Me.fdArquivo = New System.Windows.Forms.OpenFileDialog()
        Me.taFuncionarios = New SisControl.NET.dsCadastroTableAdapters.funcionariosTableAdapter()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.bsFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCadastro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.navFuncionarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.navFuncionarios.SuspendLayout()
        Me.SuspendLayout()
        '
        'btImprime
        '
        Me.btImprime.BackColor = System.Drawing.SystemColors.Control
        Me.btImprime.Cursor = System.Windows.Forms.Cursors.Default
        Me.btImprime.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btImprime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btImprime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btImprime.Location = New System.Drawing.Point(696, 530)
        Me.btImprime.Name = "btImprime"
        Me.btImprime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btImprime.Size = New System.Drawing.Size(97, 25)
        Me.btImprime.TabIndex = 59
        Me.btImprime.Text = "Imprime Ficha"
        Me.ttInfo.SetToolTip(Me.btImprime, "Imprime direto na Impressora Padrão")
        Me.btImprime.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Command1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(647, 155)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(75, 23)
        Me.Command1.TabIndex = 15
        Me.Command1.Text = "Foto"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'chkAtivo
        '
        Me.chkAtivo.BackColor = System.Drawing.SystemColors.Control
        Me.chkAtivo.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAtivo.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.bsFuncionarios, "Ativo", True))
        Me.chkAtivo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAtivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAtivo.Location = New System.Drawing.Point(807, 534)
        Me.chkAtivo.Name = "chkAtivo"
        Me.chkAtivo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAtivo.Size = New System.Drawing.Size(57, 17)
        Me.chkAtivo.TabIndex = 60
        Me.chkAtivo.Text = "Ativo"
        Me.chkAtivo.UseVisualStyleBackColor = False
        '
        'bsFuncionarios
        '
        Me.bsFuncionarios.DataMember = "funcionarios"
        Me.bsFuncionarios.DataSource = Me.DsCadastro
        '
        'DsCadastro
        '
        Me.DsCadastro.DataSetName = "dsCadastro"
        Me.DsCadastro.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chkVT
        '
        Me.chkVT.BackColor = System.Drawing.SystemColors.Control
        Me.chkVT.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkVT.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.bsFuncionarios, "ValeTransporte", True))
        Me.chkVT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkVT.Location = New System.Drawing.Point(112, 440)
        Me.chkVT.Name = "chkVT"
        Me.chkVT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkVT.Size = New System.Drawing.Size(17, 25)
        Me.chkVT.TabIndex = 38
        Me.chkVT.UseVisualStyleBackColor = False
        '
        'chkAposentado
        '
        Me.chkAposentado.BackColor = System.Drawing.SystemColors.Control
        Me.chkAposentado.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAposentado.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.bsFuncionarios, "Aposentado", True))
        Me.chkAposentado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAposentado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAposentado.Location = New System.Drawing.Point(112, 424)
        Me.chkAposentado.Name = "chkAposentado"
        Me.chkAposentado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAposentado.Size = New System.Drawing.Size(17, 17)
        Me.chkAposentado.TabIndex = 36
        Me.chkAposentado.UseVisualStyleBackColor = False
        '
        'cmbHoraMes
        '
        Me.cmbHoraMes.BackColor = System.Drawing.SystemColors.Window
        Me.cmbHoraMes.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbHoraMes.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.bsFuncionarios, "Hora_Mes", True))
        Me.cmbHoraMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHoraMes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbHoraMes.Items.AddRange(New Object() {"Por Hora", "Por Mês"})
        Me.cmbHoraMes.Location = New System.Drawing.Point(288, 110)
        Me.cmbHoraMes.Name = "cmbHoraMes"
        Me.cmbHoraMes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbHoraMes.Size = New System.Drawing.Size(65, 21)
        Me.cmbHoraMes.TabIndex = 8
        '
        'txtSetor
        '
        Me.txtSetor.AcceptsReturn = True
        Me.txtSetor.BackColor = System.Drawing.SystemColors.Window
        Me.txtSetor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSetor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Setor", True))
        Me.txtSetor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSetor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSetor.Location = New System.Drawing.Point(480, 137)
        Me.txtSetor.MaxLength = 0
        Me.txtSetor.Name = "txtSetor"
        Me.txtSetor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSetor.Size = New System.Drawing.Size(117, 20)
        Me.txtSetor.TabIndex = 14
        '
        'txtPonto
        '
        Me.txtPonto.AcceptsReturn = True
        Me.txtPonto.BackColor = System.Drawing.SystemColors.Window
        Me.txtPonto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPonto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Ponto", True))
        Me.txtPonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPonto.Location = New System.Drawing.Point(168, 4)
        Me.txtPonto.MaxLength = 0
        Me.txtPonto.Name = "txtPonto"
        Me.txtPonto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPonto.Size = New System.Drawing.Size(49, 20)
        Me.txtPonto.TabIndex = 1
        Me.txtPonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEmergencia
        '
        Me.txtEmergencia.AcceptsReturn = True
        Me.txtEmergencia.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmergencia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmergencia.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Tel_Emergencia", True))
        Me.txtEmergencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmergencia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEmergencia.Location = New System.Drawing.Point(624, 472)
        Me.txtEmergencia.MaxLength = 0
        Me.txtEmergencia.Name = "txtEmergencia"
        Me.txtEmergencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEmergencia.Size = New System.Drawing.Size(105, 20)
        Me.txtEmergencia.TabIndex = 49
        '
        'txtNomeEmergencia
        '
        Me.txtNomeEmergencia.AcceptsReturn = True
        Me.txtNomeEmergencia.BackColor = System.Drawing.SystemColors.Window
        Me.txtNomeEmergencia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNomeEmergencia.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Emergencia", True))
        Me.txtNomeEmergencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomeEmergencia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNomeEmergencia.Location = New System.Drawing.Point(624, 448)
        Me.txtNomeEmergencia.MaxLength = 0
        Me.txtNomeEmergencia.Name = "txtNomeEmergencia"
        Me.txtNomeEmergencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNomeEmergencia.Size = New System.Drawing.Size(233, 20)
        Me.txtNomeEmergencia.TabIndex = 48
        '
        'txtEmail
        '
        Me.txtEmail.AcceptsReturn = True
        Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "email", True))
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEmail.Location = New System.Drawing.Point(576, 424)
        Me.txtEmail.MaxLength = 0
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEmail.Size = New System.Drawing.Size(281, 20)
        Me.txtEmail.TabIndex = 47
        '
        'txtCelular
        '
        Me.txtCelular.AcceptsReturn = True
        Me.txtCelular.BackColor = System.Drawing.SystemColors.Window
        Me.txtCelular.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCelular.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Celular", True))
        Me.txtCelular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCelular.Location = New System.Drawing.Point(752, 400)
        Me.txtCelular.MaxLength = 0
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCelular.Size = New System.Drawing.Size(105, 20)
        Me.txtCelular.TabIndex = 46
        '
        'txtFone
        '
        Me.txtFone.AcceptsReturn = True
        Me.txtFone.BackColor = System.Drawing.SystemColors.Window
        Me.txtFone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Telefone", True))
        Me.txtFone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFone.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFone.Location = New System.Drawing.Point(576, 400)
        Me.txtFone.MaxLength = 0
        Me.txtFone.Name = "txtFone"
        Me.txtFone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFone.Size = New System.Drawing.Size(121, 20)
        Me.txtFone.TabIndex = 45
        '
        'txtCEP
        '
        Me.txtCEP.AcceptsReturn = True
        Me.txtCEP.BackColor = System.Drawing.SystemColors.Window
        Me.txtCEP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCEP.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "CEP", True))
        Me.txtCEP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCEP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCEP.Location = New System.Drawing.Point(752, 375)
        Me.txtCEP.MaxLength = 0
        Me.txtCEP.Name = "txtCEP"
        Me.txtCEP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCEP.Size = New System.Drawing.Size(81, 20)
        Me.txtCEP.TabIndex = 44
        '
        'txtCidade
        '
        Me.txtCidade.AcceptsReturn = True
        Me.txtCidade.BackColor = System.Drawing.SystemColors.Window
        Me.txtCidade.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCidade.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Cidade", True))
        Me.txtCidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCidade.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCidade.Location = New System.Drawing.Point(576, 376)
        Me.txtCidade.MaxLength = 0
        Me.txtCidade.Name = "txtCidade"
        Me.txtCidade.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCidade.Size = New System.Drawing.Size(121, 20)
        Me.txtCidade.TabIndex = 43
        '
        'txtCalca
        '
        Me.txtCalca.AcceptsReturn = True
        Me.txtCalca.BackColor = System.Drawing.SystemColors.Window
        Me.txtCalca.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCalca.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Calca", True))
        Me.txtCalca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalca.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCalca.Location = New System.Drawing.Point(320, 542)
        Me.txtCalca.MaxLength = 0
        Me.txtCalca.Name = "txtCalca"
        Me.txtCalca.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCalca.Size = New System.Drawing.Size(33, 20)
        Me.txtCalca.TabIndex = 58
        '
        'txtLuvas
        '
        Me.txtLuvas.AcceptsReturn = True
        Me.txtLuvas.BackColor = System.Drawing.SystemColors.Window
        Me.txtLuvas.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLuvas.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Luvas", True))
        Me.txtLuvas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLuvas.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLuvas.Location = New System.Drawing.Point(232, 542)
        Me.txtLuvas.MaxLength = 0
        Me.txtLuvas.Name = "txtLuvas"
        Me.txtLuvas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLuvas.Size = New System.Drawing.Size(33, 20)
        Me.txtLuvas.TabIndex = 57
        '
        'txtCalcado
        '
        Me.txtCalcado.AcceptsReturn = True
        Me.txtCalcado.BackColor = System.Drawing.SystemColors.Window
        Me.txtCalcado.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCalcado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Calcado", True))
        Me.txtCalcado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalcado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCalcado.Location = New System.Drawing.Point(144, 542)
        Me.txtCalcado.MaxLength = 0
        Me.txtCalcado.Name = "txtCalcado"
        Me.txtCalcado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCalcado.Size = New System.Drawing.Size(33, 20)
        Me.txtCalcado.TabIndex = 56
        '
        'txtCamisa
        '
        Me.txtCamisa.AcceptsReturn = True
        Me.txtCamisa.BackColor = System.Drawing.SystemColors.Window
        Me.txtCamisa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCamisa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Camisa", True))
        Me.txtCamisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCamisa.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCamisa.Location = New System.Drawing.Point(56, 542)
        Me.txtCamisa.MaxLength = 0
        Me.txtCamisa.Name = "txtCamisa"
        Me.txtCamisa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCamisa.Size = New System.Drawing.Size(25, 20)
        Me.txtCamisa.TabIndex = 55
        '
        'txtAltura
        '
        Me.txtAltura.AcceptsReturn = True
        Me.txtAltura.BackColor = System.Drawing.SystemColors.Window
        Me.txtAltura.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAltura.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "altura", True))
        Me.txtAltura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAltura.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAltura.Location = New System.Drawing.Point(376, 517)
        Me.txtAltura.MaxLength = 0
        Me.txtAltura.Name = "txtAltura"
        Me.txtAltura.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAltura.Size = New System.Drawing.Size(41, 20)
        Me.txtAltura.TabIndex = 54
        '
        'txtPeso
        '
        Me.txtPeso.AcceptsReturn = True
        Me.txtPeso.BackColor = System.Drawing.SystemColors.Window
        Me.txtPeso.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPeso.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Peso", True))
        Me.txtPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeso.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPeso.Location = New System.Drawing.Point(264, 517)
        Me.txtPeso.MaxLength = 0
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPeso.Size = New System.Drawing.Size(41, 20)
        Me.txtPeso.TabIndex = 53
        '
        'txtOlhos
        '
        Me.txtOlhos.AcceptsReturn = True
        Me.txtOlhos.BackColor = System.Drawing.SystemColors.Window
        Me.txtOlhos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOlhos.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Olhos", True))
        Me.txtOlhos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOlhos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOlhos.Location = New System.Drawing.Point(264, 493)
        Me.txtOlhos.MaxLength = 0
        Me.txtOlhos.Name = "txtOlhos"
        Me.txtOlhos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOlhos.Size = New System.Drawing.Size(105, 20)
        Me.txtOlhos.TabIndex = 51
        '
        'txtCabelos
        '
        Me.txtCabelos.AcceptsReturn = True
        Me.txtCabelos.BackColor = System.Drawing.SystemColors.Window
        Me.txtCabelos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCabelos.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Cabelos", True))
        Me.txtCabelos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCabelos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCabelos.Location = New System.Drawing.Point(112, 517)
        Me.txtCabelos.MaxLength = 0
        Me.txtCabelos.Name = "txtCabelos"
        Me.txtCabelos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCabelos.Size = New System.Drawing.Size(97, 20)
        Me.txtCabelos.TabIndex = 52
        '
        'txtCor
        '
        Me.txtCor.AcceptsReturn = True
        Me.txtCor.BackColor = System.Drawing.SystemColors.Window
        Me.txtCor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Cor", True))
        Me.txtCor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCor.Location = New System.Drawing.Point(112, 493)
        Me.txtCor.MaxLength = 0
        Me.txtCor.Name = "txtCor"
        Me.txtCor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCor.Size = New System.Drawing.Size(97, 20)
        Me.txtCor.TabIndex = 50
        '
        'txtNumVT
        '
        Me.txtNumVT.AcceptsReturn = True
        Me.txtNumVT.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumVT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumVT.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "NumVale", True))
        Me.txtNumVT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumVT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumVT.Location = New System.Drawing.Point(352, 448)
        Me.txtNumVT.MaxLength = 0
        Me.txtNumVT.Name = "txtNumVT"
        Me.txtNumVT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumVT.Size = New System.Drawing.Size(33, 20)
        Me.txtNumVT.TabIndex = 39
        '
        'txtPIS
        '
        Me.txtPIS.AcceptsReturn = True
        Me.txtPIS.BackColor = System.Drawing.SystemColors.Window
        Me.txtPIS.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPIS.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "PIS", True))
        Me.txtPIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPIS.Location = New System.Drawing.Point(648, 200)
        Me.txtPIS.MaxLength = 0
        Me.txtPIS.Name = "txtPIS"
        Me.txtPIS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPIS.Size = New System.Drawing.Size(121, 20)
        Me.txtPIS.TabIndex = 19
        '
        'txtBairro
        '
        Me.txtBairro.AcceptsReturn = True
        Me.txtBairro.BackColor = System.Drawing.SystemColors.Window
        Me.txtBairro.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBairro.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Bairro", True))
        Me.txtBairro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBairro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBairro.Location = New System.Drawing.Point(576, 352)
        Me.txtBairro.MaxLength = 0
        Me.txtBairro.Name = "txtBairro"
        Me.txtBairro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBairro.Size = New System.Drawing.Size(121, 20)
        Me.txtBairro.TabIndex = 42
        '
        'txtNum
        '
        Me.txtNum.AcceptsReturn = True
        Me.txtNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtNum.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNum.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Numero", True))
        Me.txtNum.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNum.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNum.Location = New System.Drawing.Point(832, 328)
        Me.txtNum.MaxLength = 0
        Me.txtNum.Name = "txtNum"
        Me.txtNum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNum.Size = New System.Drawing.Size(41, 20)
        Me.txtNum.TabIndex = 41
        '
        'txtEndereco
        '
        Me.txtEndereco.AcceptsReturn = True
        Me.txtEndereco.BackColor = System.Drawing.SystemColors.Window
        Me.txtEndereco.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEndereco.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Endereco", True))
        Me.txtEndereco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndereco.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEndereco.Location = New System.Drawing.Point(576, 328)
        Me.txtEndereco.MaxLength = 0
        Me.txtEndereco.Name = "txtEndereco"
        Me.txtEndereco.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEndereco.Size = New System.Drawing.Size(249, 20)
        Me.txtEndereco.TabIndex = 40
        '
        'txtBeneficio
        '
        Me.txtBeneficio.AcceptsReturn = True
        Me.txtBeneficio.BackColor = System.Drawing.SystemColors.Window
        Me.txtBeneficio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBeneficio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Beneficio", True))
        Me.txtBeneficio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeneficio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBeneficio.Location = New System.Drawing.Point(352, 424)
        Me.txtBeneficio.MaxLength = 0
        Me.txtBeneficio.Name = "txtBeneficio"
        Me.txtBeneficio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBeneficio.Size = New System.Drawing.Size(113, 20)
        Me.txtBeneficio.TabIndex = 37
        '
        'txtMae
        '
        Me.txtMae.AcceptsReturn = True
        Me.txtMae.BackColor = System.Drawing.SystemColors.Window
        Me.txtMae.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMae.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "NomeMae", True))
        Me.txtMae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMae.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMae.Location = New System.Drawing.Point(112, 400)
        Me.txtMae.MaxLength = 0
        Me.txtMae.Name = "txtMae"
        Me.txtMae.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMae.Size = New System.Drawing.Size(353, 20)
        Me.txtMae.TabIndex = 35
        '
        'txtPai
        '
        Me.txtPai.AcceptsReturn = True
        Me.txtPai.BackColor = System.Drawing.SystemColors.Window
        Me.txtPai.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPai.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "NomePai", True))
        Me.txtPai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPai.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPai.Location = New System.Drawing.Point(112, 376)
        Me.txtPai.MaxLength = 0
        Me.txtPai.Name = "txtPai"
        Me.txtPai.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPai.Size = New System.Drawing.Size(353, 20)
        Me.txtPai.TabIndex = 34
        '
        'txtInstrucao
        '
        Me.txtInstrucao.AcceptsReturn = True
        Me.txtInstrucao.BackColor = System.Drawing.SystemColors.Window
        Me.txtInstrucao.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInstrucao.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Instrucao", True))
        Me.txtInstrucao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstrucao.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInstrucao.Location = New System.Drawing.Point(336, 352)
        Me.txtInstrucao.MaxLength = 0
        Me.txtInstrucao.Name = "txtInstrucao"
        Me.txtInstrucao.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInstrucao.Size = New System.Drawing.Size(129, 20)
        Me.txtInstrucao.TabIndex = 33
        '
        'txtDependentes
        '
        Me.txtDependentes.AcceptsReturn = True
        Me.txtDependentes.BackColor = System.Drawing.SystemColors.Window
        Me.txtDependentes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDependentes.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Dependentes", True))
        Me.txtDependentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDependentes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDependentes.Location = New System.Drawing.Point(112, 352)
        Me.txtDependentes.MaxLength = 0
        Me.txtDependentes.Name = "txtDependentes"
        Me.txtDependentes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDependentes.Size = New System.Drawing.Size(25, 20)
        Me.txtDependentes.TabIndex = 32
        Me.txtDependentes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtConjuge
        '
        Me.txtConjuge.AcceptsReturn = True
        Me.txtConjuge.BackColor = System.Drawing.SystemColors.Window
        Me.txtConjuge.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConjuge.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "NomeConjuge", True))
        Me.txtConjuge.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConjuge.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtConjuge.Location = New System.Drawing.Point(336, 328)
        Me.txtConjuge.MaxLength = 0
        Me.txtConjuge.Name = "txtConjuge"
        Me.txtConjuge.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtConjuge.Size = New System.Drawing.Size(129, 20)
        Me.txtConjuge.TabIndex = 31
        '
        'txtEstCivil
        '
        Me.txtEstCivil.AcceptsReturn = True
        Me.txtEstCivil.BackColor = System.Drawing.SystemColors.Window
        Me.txtEstCivil.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEstCivil.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "EstCivil", True))
        Me.txtEstCivil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstCivil.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEstCivil.Location = New System.Drawing.Point(112, 328)
        Me.txtEstCivil.MaxLength = 0
        Me.txtEstCivil.Name = "txtEstCivil"
        Me.txtEstCivil.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEstCivil.Size = New System.Drawing.Size(121, 20)
        Me.txtEstCivil.TabIndex = 30
        '
        'txtRegiao
        '
        Me.txtRegiao.AcceptsReturn = True
        Me.txtRegiao.BackColor = System.Drawing.SystemColors.Window
        Me.txtRegiao.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRegiao.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Regiao_RM", True))
        Me.txtRegiao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegiao.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRegiao.Location = New System.Drawing.Point(328, 272)
        Me.txtRegiao.MaxLength = 0
        Me.txtRegiao.Name = "txtRegiao"
        Me.txtRegiao.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRegiao.Size = New System.Drawing.Size(41, 20)
        Me.txtRegiao.TabIndex = 28
        '
        'txtRM
        '
        Me.txtRM.AcceptsReturn = True
        Me.txtRM.BackColor = System.Drawing.SystemColors.Window
        Me.txtRM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRM.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "RM", True))
        Me.txtRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRM.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRM.Location = New System.Drawing.Point(112, 272)
        Me.txtRM.MaxLength = 0
        Me.txtRM.Name = "txtRM"
        Me.txtRM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRM.Size = New System.Drawing.Size(121, 20)
        Me.txtRM.TabIndex = 27
        '
        'txtSecao
        '
        Me.txtSecao.AcceptsReturn = True
        Me.txtSecao.BackColor = System.Drawing.SystemColors.Window
        Me.txtSecao.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSecao.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Secao", True))
        Me.txtSecao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecao.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSecao.Location = New System.Drawing.Point(520, 248)
        Me.txtSecao.MaxLength = 0
        Me.txtSecao.Name = "txtSecao"
        Me.txtSecao.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSecao.Size = New System.Drawing.Size(41, 20)
        Me.txtSecao.TabIndex = 26
        '
        'txtZona
        '
        Me.txtZona.AcceptsReturn = True
        Me.txtZona.BackColor = System.Drawing.SystemColors.Window
        Me.txtZona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtZona.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Zona", True))
        Me.txtZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZona.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtZona.Location = New System.Drawing.Point(328, 248)
        Me.txtZona.MaxLength = 0
        Me.txtZona.Name = "txtZona"
        Me.txtZona.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtZona.Size = New System.Drawing.Size(41, 20)
        Me.txtZona.TabIndex = 25
        '
        'txtEleitor
        '
        Me.txtEleitor.AcceptsReturn = True
        Me.txtEleitor.BackColor = System.Drawing.SystemColors.Window
        Me.txtEleitor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEleitor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Eleitor", True))
        Me.txtEleitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEleitor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEleitor.Location = New System.Drawing.Point(112, 248)
        Me.txtEleitor.MaxLength = 0
        Me.txtEleitor.Name = "txtEleitor"
        Me.txtEleitor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEleitor.Size = New System.Drawing.Size(121, 20)
        Me.txtEleitor.TabIndex = 24
        '
        'txtCategoria
        '
        Me.txtCategoria.AcceptsReturn = True
        Me.txtCategoria.BackColor = System.Drawing.SystemColors.Window
        Me.txtCategoria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoria.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Categoria", True))
        Me.txtCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoria.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCategoria.Location = New System.Drawing.Point(520, 224)
        Me.txtCategoria.MaxLength = 0
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCategoria.Size = New System.Drawing.Size(33, 20)
        Me.txtCategoria.TabIndex = 22
        Me.txtCategoria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHabilitacao
        '
        Me.txtHabilitacao.AcceptsReturn = True
        Me.txtHabilitacao.BackColor = System.Drawing.SystemColors.Window
        Me.txtHabilitacao.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHabilitacao.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Habilitacao", True))
        Me.txtHabilitacao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHabilitacao.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHabilitacao.Location = New System.Drawing.Point(328, 224)
        Me.txtHabilitacao.MaxLength = 0
        Me.txtHabilitacao.Name = "txtHabilitacao"
        Me.txtHabilitacao.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHabilitacao.Size = New System.Drawing.Size(89, 20)
        Me.txtHabilitacao.TabIndex = 21
        '
        'txtCBO
        '
        Me.txtCBO.AcceptsReturn = True
        Me.txtCBO.BackColor = System.Drawing.SystemColors.Window
        Me.txtCBO.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCBO.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "CBO", True))
        Me.txtCBO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCBO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCBO.Location = New System.Drawing.Point(520, 272)
        Me.txtCBO.MaxLength = 0
        Me.txtCBO.Name = "txtCBO"
        Me.txtCBO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCBO.Size = New System.Drawing.Size(49, 20)
        Me.txtCBO.TabIndex = 29
        '
        'txtTrabalho
        '
        Me.txtTrabalho.AcceptsReturn = True
        Me.txtTrabalho.BackColor = System.Drawing.SystemColors.Window
        Me.txtTrabalho.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrabalho.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Trabalho", True))
        Me.txtTrabalho.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrabalho.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrabalho.Location = New System.Drawing.Point(112, 224)
        Me.txtTrabalho.MaxLength = 0
        Me.txtTrabalho.Name = "txtTrabalho"
        Me.txtTrabalho.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrabalho.Size = New System.Drawing.Size(121, 20)
        Me.txtTrabalho.TabIndex = 20
        '
        'txtEmissor
        '
        Me.txtEmissor.AcceptsReturn = True
        Me.txtEmissor.BackColor = System.Drawing.SystemColors.Window
        Me.txtEmissor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmissor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Emissor", True))
        Me.txtEmissor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmissor.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEmissor.Location = New System.Drawing.Point(520, 200)
        Me.txtEmissor.MaxLength = 0
        Me.txtEmissor.Name = "txtEmissor"
        Me.txtEmissor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEmissor.Size = New System.Drawing.Size(65, 20)
        Me.txtEmissor.TabIndex = 18
        '
        'txtIdentidade
        '
        Me.txtIdentidade.AcceptsReturn = True
        Me.txtIdentidade.BackColor = System.Drawing.SystemColors.Window
        Me.txtIdentidade.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIdentidade.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Identidade", True))
        Me.txtIdentidade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdentidade.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIdentidade.Location = New System.Drawing.Point(328, 200)
        Me.txtIdentidade.MaxLength = 0
        Me.txtIdentidade.Name = "txtIdentidade"
        Me.txtIdentidade.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIdentidade.Size = New System.Drawing.Size(89, 20)
        Me.txtIdentidade.TabIndex = 17
        '
        'txtCPF
        '
        Me.txtCPF.AcceptsReturn = True
        Me.txtCPF.BackColor = System.Drawing.SystemColors.Window
        Me.txtCPF.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCPF.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "CPF", True))
        Me.txtCPF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCPF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCPF.Location = New System.Drawing.Point(112, 200)
        Me.txtCPF.MaxLength = 0
        Me.txtCPF.Name = "txtCPF"
        Me.txtCPF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCPF.Size = New System.Drawing.Size(121, 20)
        Me.txtCPF.TabIndex = 16
        '
        'txtExperiencia
        '
        Me.txtExperiencia.AcceptsReturn = True
        Me.txtExperiencia.BackColor = System.Drawing.SystemColors.Window
        Me.txtExperiencia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExperiencia.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Experiencia", True))
        Me.txtExperiencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExperiencia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExperiencia.Location = New System.Drawing.Point(480, 111)
        Me.txtExperiencia.MaxLength = 0
        Me.txtExperiencia.Name = "txtExperiencia"
        Me.txtExperiencia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExperiencia.Size = New System.Drawing.Size(33, 20)
        Me.txtExperiencia.TabIndex = 9
        Me.txtExperiencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSalario
        '
        Me.txtSalario.AcceptsReturn = True
        Me.txtSalario.BackColor = System.Drawing.SystemColors.Window
        Me.txtSalario.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSalario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Salario", True))
        Me.txtSalario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalario.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSalario.Location = New System.Drawing.Point(104, 108)
        Me.txtSalario.MaxLength = 0
        Me.txtSalario.Name = "txtSalario"
        Me.txtSalario.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSalario.Size = New System.Drawing.Size(57, 20)
        Me.txtSalario.TabIndex = 7
        Me.txtSalario.Text = "0,00"
        Me.txtSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFuncao
        '
        Me.txtFuncao.AcceptsReturn = True
        Me.txtFuncao.BackColor = System.Drawing.SystemColors.Window
        Me.txtFuncao.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFuncao.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Funcao", True))
        Me.txtFuncao.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFuncao.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFuncao.Location = New System.Drawing.Point(272, 57)
        Me.txtFuncao.MaxLength = 0
        Me.txtFuncao.Name = "txtFuncao"
        Me.txtFuncao.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFuncao.Size = New System.Drawing.Size(325, 20)
        Me.txtFuncao.TabIndex = 5
        '
        'txtNome
        '
        Me.txtNome.AcceptsReturn = True
        Me.txtNome.BackColor = System.Drawing.SystemColors.Window
        Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNome.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Nome", True))
        Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNome.Location = New System.Drawing.Point(59, 32)
        Me.txtNome.MaxLength = 0
        Me.txtNome.Name = "txtNome"
        Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNome.Size = New System.Drawing.Size(351, 20)
        Me.txtNome.TabIndex = 2
        '
        'imgFoto
        '
        Me.imgFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgFoto.Cursor = System.Windows.Forms.Cursors.Default
        Me.imgFoto.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.bsFuncionarios, "Foto", True))
        Me.imgFoto.Location = New System.Drawing.Point(728, 8)
        Me.imgFoto.Name = "imgFoto"
        Me.imgFoto.Size = New System.Drawing.Size(129, 170)
        Me.imgFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgFoto.TabIndex = 129
        Me.imgFoto.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(520, 304)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Endereço"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(8, 472)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Físicos"
        '
        'Line3
        '
        Me.Line3.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Line3.Location = New System.Drawing.Point(8, 488)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(488, 1)
        Me.Line3.TabIndex = 130
        '
        '_lblLabels_10
        '
        Me._lblLabels_10.AutoSize = True
        Me._lblLabels_10.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_10.Location = New System.Drawing.Point(8, 424)
        Me._lblLabels_10.Name = "_lblLabels_10"
        Me._lblLabels_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_10.Size = New System.Drawing.Size(67, 13)
        Me._lblLabels_10.TabIndex = 124
        Me._lblLabels_10.Text = "Aposentado:"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Location = New System.Drawing.Point(8, 320)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(864, 1)
        Me.Line2.TabIndex = 131
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Familiares"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(8, 192)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(864, 1)
        Me.Line1.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(103, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Documentação"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(520, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "dias"
        '
        '_lblLabels_59
        '
        Me._lblLabels_59.AutoSize = True
        Me._lblLabels_59.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_59.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_59.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_59.Location = New System.Drawing.Point(446, 140)
        Me._lblLabels_59.Name = "_lblLabels_59"
        Me._lblLabels_59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_59.Size = New System.Drawing.Size(35, 13)
        Me._lblLabels_59.TabIndex = 119
        Me._lblLabels_59.Text = "Setor:"
        '
        '_lblLabels_58
        '
        Me._lblLabels_58.AutoSize = True
        Me._lblLabels_58.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_58.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_58.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_58.Location = New System.Drawing.Point(128, 4)
        Me._lblLabels_58.Name = "_lblLabels_58"
        Me._lblLabels_58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_58.Size = New System.Drawing.Size(38, 13)
        Me._lblLabels_58.TabIndex = 118
        Me._lblLabels_58.Text = "Ponto:"
        '
        '_lblLabels_56
        '
        Me._lblLabels_56.AutoSize = True
        Me._lblLabels_56.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_56.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_56.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_56.Location = New System.Drawing.Point(693, 8)
        Me._lblLabels_56.Name = "_lblLabels_56"
        Me._lblLabels_56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_56.Size = New System.Drawing.Size(31, 13)
        Me._lblLabels_56.TabIndex = 117
        Me._lblLabels_56.Text = "Foto:"
        '
        '_lblLabels_55
        '
        Me._lblLabels_55.AutoSize = True
        Me._lblLabels_55.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_55.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_55.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_55.Location = New System.Drawing.Point(512, 472)
        Me._lblLabels_55.Name = "_lblLabels_55"
        Me._lblLabels_55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_55.Size = New System.Drawing.Size(111, 13)
        Me._lblLabels_55.TabIndex = 116
        Me._lblLabels_55.Text = "Telefone Emergência:"
        '
        '_lblLabels_54
        '
        Me._lblLabels_54.AutoSize = True
        Me._lblLabels_54.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_54.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_54.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_54.Location = New System.Drawing.Point(560, 448)
        Me._lblLabels_54.Name = "_lblLabels_54"
        Me._lblLabels_54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_54.Size = New System.Drawing.Size(66, 13)
        Me._lblLabels_54.TabIndex = 115
        Me._lblLabels_54.Text = "Emergência:"
        '
        '_lblLabels_53
        '
        Me._lblLabels_53.AutoSize = True
        Me._lblLabels_53.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_53.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_53.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_53.Location = New System.Drawing.Point(536, 424)
        Me._lblLabels_53.Name = "_lblLabels_53"
        Me._lblLabels_53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_53.Size = New System.Drawing.Size(37, 13)
        Me._lblLabels_53.TabIndex = 114
        Me._lblLabels_53.Text = "e-mail:"
        '
        '_lblLabels_52
        '
        Me._lblLabels_52.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_52.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_52.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_52.Location = New System.Drawing.Point(712, 400)
        Me._lblLabels_52.Name = "_lblLabels_52"
        Me._lblLabels_52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_52.Size = New System.Drawing.Size(41, 17)
        Me._lblLabels_52.TabIndex = 113
        Me._lblLabels_52.Text = "Celular:"
        '
        '_lblLabels_51
        '
        Me._lblLabels_51.AutoSize = True
        Me._lblLabels_51.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_51.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_51.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_51.Location = New System.Drawing.Point(520, 400)
        Me._lblLabels_51.Name = "_lblLabels_51"
        Me._lblLabels_51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_51.Size = New System.Drawing.Size(52, 13)
        Me._lblLabels_51.TabIndex = 112
        Me._lblLabels_51.Text = "Telefone:"
        '
        '_lblLabels_50
        '
        Me._lblLabels_50.AutoSize = True
        Me._lblLabels_50.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_50.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_50.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_50.Location = New System.Drawing.Point(720, 376)
        Me._lblLabels_50.Name = "_lblLabels_50"
        Me._lblLabels_50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_50.Size = New System.Drawing.Size(31, 13)
        Me._lblLabels_50.TabIndex = 111
        Me._lblLabels_50.Text = "CEP:"
        '
        '_lblLabels_49
        '
        Me._lblLabels_49.AutoSize = True
        Me._lblLabels_49.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_49.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_49.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_49.Location = New System.Drawing.Point(528, 376)
        Me._lblLabels_49.Name = "_lblLabels_49"
        Me._lblLabels_49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_49.Size = New System.Drawing.Size(43, 13)
        Me._lblLabels_49.TabIndex = 110
        Me._lblLabels_49.Text = "Cidade:"
        '
        '_lblLabels_48
        '
        Me._lblLabels_48.AutoSize = True
        Me._lblLabels_48.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_48.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_48.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_48.Location = New System.Drawing.Point(280, 544)
        Me._lblLabels_48.Name = "_lblLabels_48"
        Me._lblLabels_48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_48.Size = New System.Drawing.Size(37, 13)
        Me._lblLabels_48.TabIndex = 109
        Me._lblLabels_48.Text = "Calça:"
        '
        '_lblLabels_47
        '
        Me._lblLabels_47.AutoSize = True
        Me._lblLabels_47.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_47.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_47.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_47.Location = New System.Drawing.Point(192, 544)
        Me._lblLabels_47.Name = "_lblLabels_47"
        Me._lblLabels_47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_47.Size = New System.Drawing.Size(39, 13)
        Me._lblLabels_47.TabIndex = 108
        Me._lblLabels_47.Text = "Luvas:"
        '
        '_lblLabels_46
        '
        Me._lblLabels_46.AutoSize = True
        Me._lblLabels_46.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_46.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_46.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_46.Location = New System.Drawing.Point(96, 544)
        Me._lblLabels_46.Name = "_lblLabels_46"
        Me._lblLabels_46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_46.Size = New System.Drawing.Size(49, 13)
        Me._lblLabels_46.TabIndex = 107
        Me._lblLabels_46.Text = "Calçado:"
        '
        '_lblLabels_45
        '
        Me._lblLabels_45.AutoSize = True
        Me._lblLabels_45.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_45.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_45.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_45.Location = New System.Drawing.Point(8, 544)
        Me._lblLabels_45.Name = "_lblLabels_45"
        Me._lblLabels_45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_45.Size = New System.Drawing.Size(44, 13)
        Me._lblLabels_45.TabIndex = 106
        Me._lblLabels_45.Text = "Camisa:"
        '
        '_lblLabels_44
        '
        Me._lblLabels_44.AutoSize = True
        Me._lblLabels_44.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_44.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_44.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_44.Location = New System.Drawing.Point(336, 520)
        Me._lblLabels_44.Name = "_lblLabels_44"
        Me._lblLabels_44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_44.Size = New System.Drawing.Size(37, 13)
        Me._lblLabels_44.TabIndex = 105
        Me._lblLabels_44.Text = "Altura:"
        '
        '_lblLabels_43
        '
        Me._lblLabels_43.AutoSize = True
        Me._lblLabels_43.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_43.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_43.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_43.Location = New System.Drawing.Point(224, 520)
        Me._lblLabels_43.Name = "_lblLabels_43"
        Me._lblLabels_43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_43.Size = New System.Drawing.Size(34, 13)
        Me._lblLabels_43.TabIndex = 104
        Me._lblLabels_43.Text = "Peso:"
        '
        '_lblLabels_42
        '
        Me._lblLabels_42.AutoSize = True
        Me._lblLabels_42.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_42.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_42.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_42.Location = New System.Drawing.Point(224, 496)
        Me._lblLabels_42.Name = "_lblLabels_42"
        Me._lblLabels_42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_42.Size = New System.Drawing.Size(37, 13)
        Me._lblLabels_42.TabIndex = 103
        Me._lblLabels_42.Text = "Olhos:"
        '
        '_lblLabels_41
        '
        Me._lblLabels_41.AutoSize = True
        Me._lblLabels_41.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_41.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_41.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_41.Location = New System.Drawing.Point(8, 520)
        Me._lblLabels_41.Name = "_lblLabels_41"
        Me._lblLabels_41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_41.Size = New System.Drawing.Size(48, 13)
        Me._lblLabels_41.TabIndex = 102
        Me._lblLabels_41.Text = "Cabelos:"
        '
        '_lblLabels_40
        '
        Me._lblLabels_40.AutoSize = True
        Me._lblLabels_40.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_40.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_40.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_40.Location = New System.Drawing.Point(8, 496)
        Me._lblLabels_40.Name = "_lblLabels_40"
        Me._lblLabels_40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_40.Size = New System.Drawing.Size(26, 13)
        Me._lblLabels_40.TabIndex = 101
        Me._lblLabels_40.Text = "Cor:"
        '
        '_lblLabels_39
        '
        Me._lblLabels_39.AutoSize = True
        Me._lblLabels_39.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_39.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_39.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_39.Location = New System.Drawing.Point(256, 448)
        Me._lblLabels_39.Name = "_lblLabels_39"
        Me._lblLabels_39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_39.Size = New System.Drawing.Size(95, 13)
        Me._lblLabels_39.TabIndex = 100
        Me._lblLabels_39.Text = "Nº de V.T. por dia:"
        '
        '_lblLabels_38
        '
        Me._lblLabels_38.AutoSize = True
        Me._lblLabels_38.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_38.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_38.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_38.Location = New System.Drawing.Point(8, 448)
        Me._lblLabels_38.Name = "_lblLabels_38"
        Me._lblLabels_38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_38.Size = New System.Drawing.Size(102, 13)
        Me._lblLabels_38.TabIndex = 99
        Me._lblLabels_38.Text = "Usa vale transporte:"
        '
        '_lblLabels_37
        '
        Me._lblLabels_37.AutoSize = True
        Me._lblLabels_37.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_37.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_37.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_37.Location = New System.Drawing.Point(592, 225)
        Me._lblLabels_37.Name = "_lblLabels_37"
        Me._lblLabels_37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_37.Size = New System.Drawing.Size(53, 13)
        Me._lblLabels_37.TabIndex = 98
        Me._lblLabels_37.Text = "Data PIS:"
        '
        '_lblLabels_36
        '
        Me._lblLabels_36.AutoSize = True
        Me._lblLabels_36.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_36.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_36.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_36.Location = New System.Drawing.Point(616, 200)
        Me._lblLabels_36.Name = "_lblLabels_36"
        Me._lblLabels_36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_36.Size = New System.Drawing.Size(27, 13)
        Me._lblLabels_36.TabIndex = 97
        Me._lblLabels_36.Text = "PIS:"
        '
        '_lblLabels_35
        '
        Me._lblLabels_35.AutoSize = True
        Me._lblLabels_35.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_35.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_35.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_35.Location = New System.Drawing.Point(536, 352)
        Me._lblLabels_35.Name = "_lblLabels_35"
        Me._lblLabels_35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_35.Size = New System.Drawing.Size(37, 13)
        Me._lblLabels_35.TabIndex = 96
        Me._lblLabels_35.Text = "Bairro:"
        '
        '_lblLabels_33
        '
        Me._lblLabels_33.AutoSize = True
        Me._lblLabels_33.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_33.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_33.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_33.Location = New System.Drawing.Point(520, 328)
        Me._lblLabels_33.Name = "_lblLabels_33"
        Me._lblLabels_33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_33.Size = New System.Drawing.Size(56, 13)
        Me._lblLabels_33.TabIndex = 95
        Me._lblLabels_33.Text = "Endereco:"
        '
        '_lblLabels_32
        '
        Me._lblLabels_32.AutoSize = True
        Me._lblLabels_32.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_32.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_32.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_32.Location = New System.Drawing.Point(264, 424)
        Me._lblLabels_32.Name = "_lblLabels_32"
        Me._lblLabels_32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_32.Size = New System.Drawing.Size(84, 13)
        Me._lblLabels_32.TabIndex = 94
        Me._lblLabels_32.Text = "Nº do Beneficio:"
        '
        '_lblLabels_30
        '
        Me._lblLabels_30.AutoSize = True
        Me._lblLabels_30.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_30.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_30.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_30.Location = New System.Drawing.Point(8, 400)
        Me._lblLabels_30.Name = "_lblLabels_30"
        Me._lblLabels_30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_30.Size = New System.Drawing.Size(77, 13)
        Me._lblLabels_30.TabIndex = 93
        Me._lblLabels_30.Text = "Nome da Mãe:"
        '
        '_lblLabels_29
        '
        Me._lblLabels_29.AutoSize = True
        Me._lblLabels_29.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_29.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_29.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_29.Location = New System.Drawing.Point(8, 376)
        Me._lblLabels_29.Name = "_lblLabels_29"
        Me._lblLabels_29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_29.Size = New System.Drawing.Size(71, 13)
        Me._lblLabels_29.TabIndex = 92
        Me._lblLabels_29.Text = "Nome do Pai:"
        '
        '_lblLabels_28
        '
        Me._lblLabels_28.AutoSize = True
        Me._lblLabels_28.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_28.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_28.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_28.Location = New System.Drawing.Point(240, 352)
        Me._lblLabels_28.Name = "_lblLabels_28"
        Me._lblLabels_28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_28.Size = New System.Drawing.Size(95, 13)
        Me._lblLabels_28.TabIndex = 91
        Me._lblLabels_28.Text = "Grau de Instrução:"
        '
        '_lblLabels_27
        '
        Me._lblLabels_27.AutoSize = True
        Me._lblLabels_27.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_27.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_27.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_27.Location = New System.Drawing.Point(8, 352)
        Me._lblLabels_27.Name = "_lblLabels_27"
        Me._lblLabels_27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_27.Size = New System.Drawing.Size(89, 13)
        Me._lblLabels_27.TabIndex = 90
        Me._lblLabels_27.Text = "Nº Dependentes:"
        '
        '_lblLabels_26
        '
        Me._lblLabels_26.AutoSize = True
        Me._lblLabels_26.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_26.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_26.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_26.Location = New System.Drawing.Point(240, 328)
        Me._lblLabels_26.Name = "_lblLabels_26"
        Me._lblLabels_26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_26.Size = New System.Drawing.Size(95, 13)
        Me._lblLabels_26.TabIndex = 89
        Me._lblLabels_26.Text = "Nome do Conjuge:"
        '
        '_lblLabels_25
        '
        Me._lblLabels_25.AutoSize = True
        Me._lblLabels_25.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_25.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_25.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_25.Location = New System.Drawing.Point(8, 328)
        Me._lblLabels_25.Name = "_lblLabels_25"
        Me._lblLabels_25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_25.Size = New System.Drawing.Size(65, 13)
        Me._lblLabels_25.TabIndex = 88
        Me._lblLabels_25.Text = "Estado Civil:"
        '
        '_lblLabels_24
        '
        Me._lblLabels_24.AutoSize = True
        Me._lblLabels_24.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_24.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_24.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_24.Location = New System.Drawing.Point(256, 272)
        Me._lblLabels_24.Name = "_lblLabels_24"
        Me._lblLabels_24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_24.Size = New System.Drawing.Size(67, 13)
        Me._lblLabels_24.TabIndex = 87
        Me._lblLabels_24.Text = "Região (RM)"
        '
        '_lblLabels_23
        '
        Me._lblLabels_23.AutoSize = True
        Me._lblLabels_23.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_23.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_23.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_23.Location = New System.Drawing.Point(8, 272)
        Me._lblLabels_23.Name = "_lblLabels_23"
        Me._lblLabels_23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_23.Size = New System.Drawing.Size(79, 13)
        Me._lblLabels_23.TabIndex = 86
        Me._lblLabels_23.Text = "Registro Militar:"
        '
        '_lblLabels_22
        '
        Me._lblLabels_22.AutoSize = True
        Me._lblLabels_22.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_22.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_22.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_22.Location = New System.Drawing.Point(480, 248)
        Me._lblLabels_22.Name = "_lblLabels_22"
        Me._lblLabels_22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_22.Size = New System.Drawing.Size(41, 13)
        Me._lblLabels_22.TabIndex = 85
        Me._lblLabels_22.Text = "Seção:"
        '
        '_lblLabels_21
        '
        Me._lblLabels_21.AutoSize = True
        Me._lblLabels_21.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_21.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_21.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_21.Location = New System.Drawing.Point(256, 248)
        Me._lblLabels_21.Name = "_lblLabels_21"
        Me._lblLabels_21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_21.Size = New System.Drawing.Size(35, 13)
        Me._lblLabels_21.TabIndex = 84
        Me._lblLabels_21.Text = "Zona:"
        '
        '_lblLabels_20
        '
        Me._lblLabels_20.AutoSize = True
        Me._lblLabels_20.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_20.Location = New System.Drawing.Point(8, 248)
        Me._lblLabels_20.Name = "_lblLabels_20"
        Me._lblLabels_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_20.Size = New System.Drawing.Size(85, 13)
        Me._lblLabels_20.TabIndex = 83
        Me._lblLabels_20.Text = "Título de Eleitor:"
        '
        '_lblLabels_19
        '
        Me._lblLabels_19.AutoSize = True
        Me._lblLabels_19.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_19.Location = New System.Drawing.Point(464, 224)
        Me._lblLabels_19.Name = "_lblLabels_19"
        Me._lblLabels_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_19.Size = New System.Drawing.Size(55, 13)
        Me._lblLabels_19.TabIndex = 82
        Me._lblLabels_19.Text = "Categoria:"
        '
        '_lblLabels_18
        '
        Me._lblLabels_18.AutoSize = True
        Me._lblLabels_18.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_18.Location = New System.Drawing.Point(256, 224)
        Me._lblLabels_18.Name = "_lblLabels_18"
        Me._lblLabels_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_18.Size = New System.Drawing.Size(63, 13)
        Me._lblLabels_18.TabIndex = 81
        Me._lblLabels_18.Text = "Habilitação:"
        '
        '_lblLabels_17
        '
        Me._lblLabels_17.AutoSize = True
        Me._lblLabels_17.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_17.Location = New System.Drawing.Point(488, 272)
        Me._lblLabels_17.Name = "_lblLabels_17"
        Me._lblLabels_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_17.Size = New System.Drawing.Size(32, 13)
        Me._lblLabels_17.TabIndex = 80
        Me._lblLabels_17.Text = "CBO:"
        '
        '_lblLabels_16
        '
        Me._lblLabels_16.AutoSize = True
        Me._lblLabels_16.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_16.Location = New System.Drawing.Point(8, 224)
        Me._lblLabels_16.Name = "_lblLabels_16"
        Me._lblLabels_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_16.Size = New System.Drawing.Size(106, 13)
        Me._lblLabels_16.TabIndex = 79
        Me._lblLabels_16.Text = "Carteira de Trabalho:"
        Me._lblLabels_16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblLabels_15
        '
        Me._lblLabels_15.AutoSize = True
        Me._lblLabels_15.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_15.Location = New System.Drawing.Point(440, 200)
        Me._lblLabels_15.Name = "_lblLabels_15"
        Me._lblLabels_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_15.Size = New System.Drawing.Size(78, 13)
        Me._lblLabels_15.TabIndex = 78
        Me._lblLabels_15.Text = "Órgão Emissor:"
        '
        '_lblLabels_14
        '
        Me._lblLabels_14.AutoSize = True
        Me._lblLabels_14.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_14.Location = New System.Drawing.Point(256, 200)
        Me._lblLabels_14.Name = "_lblLabels_14"
        Me._lblLabels_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_14.Size = New System.Drawing.Size(60, 13)
        Me._lblLabels_14.TabIndex = 77
        Me._lblLabels_14.Text = "Identidade:"
        '
        '_lblLabels_13
        '
        Me._lblLabels_13.AutoSize = True
        Me._lblLabels_13.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_13.Location = New System.Drawing.Point(8, 200)
        Me._lblLabels_13.Name = "_lblLabels_13"
        Me._lblLabels_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_13.Size = New System.Drawing.Size(30, 13)
        Me._lblLabels_13.TabIndex = 76
        Me._lblLabels_13.Text = "CPF:"
        '
        '_lblLabels_12
        '
        Me._lblLabels_12.AutoSize = True
        Me._lblLabels_12.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_12.Location = New System.Drawing.Point(416, 112)
        Me._lblLabels_12.Name = "_lblLabels_12"
        Me._lblLabels_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_12.Size = New System.Drawing.Size(65, 13)
        Me._lblLabels_12.TabIndex = 75
        Me._lblLabels_12.Text = "Experiência:"
        '
        '_lblLabels_11
        '
        Me._lblLabels_11.AutoSize = True
        Me._lblLabels_11.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_11.Location = New System.Drawing.Point(269, 140)
        Me._lblLabels_11.Name = "_lblLabels_11"
        Me._lblLabels_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_11.Size = New System.Drawing.Size(18, 13)
        Me._lblLabels_11.TabIndex = 74
        Me._lblLabels_11.Text = "às"
        '
        '_lblLabels_9
        '
        Me._lblLabels_9.AutoSize = True
        Me._lblLabels_9.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_9.Location = New System.Drawing.Point(148, 140)
        Me._lblLabels_9.Name = "_lblLabels_9"
        Me._lblLabels_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_9.Size = New System.Drawing.Size(18, 13)
        Me._lblLabels_9.TabIndex = 73
        Me._lblLabels_9.Text = "às"
        '
        '_lblLabels_8
        '
        Me._lblLabels_8.AutoSize = True
        Me._lblLabels_8.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_8.Location = New System.Drawing.Point(56, 142)
        Me._lblLabels_8.Name = "_lblLabels_8"
        Me._lblLabels_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_8.Size = New System.Drawing.Size(44, 13)
        Me._lblLabels_8.TabIndex = 72
        Me._lblLabels_8.Text = "Horário:"
        '
        '_lblLabels_7
        '
        Me._lblLabels_7.AutoSize = True
        Me._lblLabels_7.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_7.Location = New System.Drawing.Point(232, 112)
        Me._lblLabels_7.Name = "_lblLabels_7"
        Me._lblLabels_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_7.Size = New System.Drawing.Size(57, 13)
        Me._lblLabels_7.TabIndex = 71
        Me._lblLabels_7.Text = "Hora/mês:"
        '
        '_lblLabels_6
        '
        Me._lblLabels_6.AutoSize = True
        Me._lblLabels_6.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_6.Location = New System.Drawing.Point(8, 111)
        Me._lblLabels_6.Name = "_lblLabels_6"
        Me._lblLabels_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_6.Size = New System.Drawing.Size(93, 13)
        Me._lblLabels_6.TabIndex = 70
        Me._lblLabels_6.Text = "Salário Contratual:"
        '
        '_lblLabels_5
        '
        Me._lblLabels_5.AutoSize = True
        Me._lblLabels_5.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_5.Location = New System.Drawing.Point(224, 59)
        Me._lblLabels_5.Name = "_lblLabels_5"
        Me._lblLabels_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_5.Size = New System.Drawing.Size(46, 13)
        Me._lblLabels_5.TabIndex = 69
        Me._lblLabels_5.Text = "Função:"
        '
        '_lblLabels_4
        '
        Me._lblLabels_4.AutoSize = True
        Me._lblLabels_4.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_4.Location = New System.Drawing.Point(8, 84)
        Me._lblLabels_4.Name = "_lblLabels_4"
        Me._lblLabels_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_4.Size = New System.Drawing.Size(97, 13)
        Me._lblLabels_4.TabIndex = 68
        Me._lblLabels_4.Text = "Data de Demissão:"
        '
        '_lblLabels_3
        '
        Me._lblLabels_3.AutoSize = True
        Me._lblLabels_3.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_3.Location = New System.Drawing.Point(8, 59)
        Me._lblLabels_3.Name = "_lblLabels_3"
        Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_3.Size = New System.Drawing.Size(96, 13)
        Me._lblLabels_3.TabIndex = 67
        Me._lblLabels_3.Text = "Data de Admissão:"
        '
        '_lblLabels_2
        '
        Me._lblLabels_2.AutoSize = True
        Me._lblLabels_2.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_2.Location = New System.Drawing.Point(416, 32)
        Me._lblLabels_2.Name = "_lblLabels_2"
        Me._lblLabels_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_2.Size = New System.Drawing.Size(107, 13)
        Me._lblLabels_2.TabIndex = 66
        Me._lblLabels_2.Text = "Data de Nascimento:"
        '
        '_lblLabels_1
        '
        Me._lblLabels_1.AutoSize = True
        Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_1.Location = New System.Drawing.Point(8, 33)
        Me._lblLabels_1.Name = "_lblLabels_1"
        Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_1.Size = New System.Drawing.Size(38, 13)
        Me._lblLabels_1.TabIndex = 65
        Me._lblLabels_1.Text = "Nome:"
        '
        '_lblLabels_0
        '
        Me._lblLabels_0.AutoSize = True
        Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblLabels_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblLabels_0.Location = New System.Drawing.Point(8, 4)
        Me._lblLabels_0.Name = "_lblLabels_0"
        Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblLabels_0.Size = New System.Drawing.Size(53, 13)
        Me._lblLabels_0.TabIndex = 64
        Me._lblLabels_0.Text = "Matricula:"
        '
        'txtNascimento
        '
        Me.txtNascimento.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Nascimento", True))
        Me.txtNascimento.Location = New System.Drawing.Point(523, 31)
        Me.txtNascimento.Mask = "99/99/9999"
        Me.txtNascimento.Name = "txtNascimento"
        Me.txtNascimento.Size = New System.Drawing.Size(74, 21)
        Me.txtNascimento.TabIndex = 3
        '
        'txtAdmissao
        '
        Me.txtAdmissao.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Admissao", True))
        Me.txtAdmissao.Location = New System.Drawing.Point(104, 56)
        Me.txtAdmissao.Mask = "99/99/9999"
        Me.txtAdmissao.Name = "txtAdmissao"
        Me.txtAdmissao.Size = New System.Drawing.Size(75, 21)
        Me.txtAdmissao.TabIndex = 4
        '
        'txtDemissao
        '
        Me.txtDemissao.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Demissao", True))
        Me.txtDemissao.Location = New System.Drawing.Point(104, 80)
        Me.txtDemissao.Mask = "99/99/9999"
        Me.txtDemissao.Name = "txtDemissao"
        Me.txtDemissao.Size = New System.Drawing.Size(75, 21)
        Me.txtDemissao.TabIndex = 6
        '
        'txtEntM
        '
        Me.txtEntM.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Hora_ent", True))
        Me.txtEntM.Location = New System.Drawing.Point(104, 139)
        Me.txtEntM.Mask = "99:99"
        Me.txtEntM.Name = "txtEntM"
        Me.txtEntM.Size = New System.Drawing.Size(41, 21)
        Me.txtEntM.TabIndex = 10
        '
        'txtSaiM
        '
        Me.txtSaiM.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Hora_sai", True))
        Me.txtSaiM.Location = New System.Drawing.Point(168, 139)
        Me.txtSaiM.Mask = "99:99"
        Me.txtSaiM.Name = "txtSaiM"
        Me.txtSaiM.Size = New System.Drawing.Size(41, 21)
        Me.txtSaiM.TabIndex = 11
        '
        'txtEntT
        '
        Me.txtEntT.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Hora_ent_tarde", True))
        Me.txtEntT.Location = New System.Drawing.Point(224, 138)
        Me.txtEntT.Mask = "99:99"
        Me.txtEntT.Name = "txtEntT"
        Me.txtEntT.Size = New System.Drawing.Size(41, 21)
        Me.txtEntT.TabIndex = 12
        '
        'txtSaiT
        '
        Me.txtSaiT.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "Hora_sai_tarde", True))
        Me.txtSaiT.Location = New System.Drawing.Point(288, 138)
        Me.txtSaiT.Mask = "99:99"
        Me.txtSaiT.Name = "txtSaiT"
        Me.txtSaiT.Size = New System.Drawing.Size(41, 21)
        Me.txtSaiT.TabIndex = 13
        '
        'txtDataPIS
        '
        Me.txtDataPIS.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "DataPis", True))
        Me.txtDataPIS.Location = New System.Drawing.Point(648, 223)
        Me.txtDataPIS.Mask = "99/99/9999"
        Me.txtDataPIS.Name = "txtDataPIS"
        Me.txtDataPIS.Size = New System.Drawing.Size(74, 21)
        Me.txtDataPIS.TabIndex = 23
        '
        'navFuncionarios
        '
        Me.navFuncionarios.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.navFuncionarios.BindingSource = Me.bsFuncionarios
        Me.navFuncionarios.CountItem = Me.BindingNavigatorCountItem
        Me.navFuncionarios.CountItemFormat = "de {0}"
        Me.navFuncionarios.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.navFuncionarios.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.navFuncionarios.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.FuncionariosBindingNavigatorSaveItem})
        Me.navFuncionarios.Location = New System.Drawing.Point(0, 582)
        Me.navFuncionarios.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.navFuncionarios.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.navFuncionarios.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.navFuncionarios.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.navFuncionarios.Name = "navFuncionarios"
        Me.navFuncionarios.PositionItem = Me.BindingNavigatorPositionItem
        Me.navFuncionarios.Size = New System.Drawing.Size(893, 25)
        Me.navFuncionarios.TabIndex = 61
        Me.navFuncionarios.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Adicionar Novo"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.BindingNavigatorCountItem.Text = "de {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Apagar Registro"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Primeiro"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Anterior"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Próximo"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Último"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'FuncionariosBindingNavigatorSaveItem
        '
        Me.FuncionariosBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FuncionariosBindingNavigatorSaveItem.Image = CType(resources.GetObject("FuncionariosBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.FuncionariosBindingNavigatorSaveItem.Name = "FuncionariosBindingNavigatorSaveItem"
        Me.FuncionariosBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.FuncionariosBindingNavigatorSaveItem.Text = "Salvar Registro"
        '
        'IdTextBox
        '
        Me.IdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.bsFuncionarios, "id", True))
        Me.IdTextBox.Location = New System.Drawing.Point(59, 3)
        Me.IdTextBox.Name = "IdTextBox"
        Me.IdTextBox.Size = New System.Drawing.Size(46, 21)
        Me.IdTextBox.TabIndex = 0
        Me.IdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ttInfo
        '
        Me.ttInfo.ToolTipTitle = "Informação:"
        '
        'fdArquivo
        '
        Me.fdArquivo.Filter = "Arquivos JPEG|*.jpg|Arquivos BMP|*.bmp|Arquivos PNG|*.png"
        Me.fdArquivo.Title = "Localizar Foto"
        '
        'taFuncionarios
        '
        Me.taFuncionarios.ClearBeforeFill = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmFuncionario
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(893, 607)
        Me.Controls.Add(Me.IdTextBox)
        Me.Controls.Add(Me.navFuncionarios)
        Me.Controls.Add(Me.txtDataPIS)
        Me.Controls.Add(Me.txtSaiT)
        Me.Controls.Add(Me.txtEntT)
        Me.Controls.Add(Me.txtSaiM)
        Me.Controls.Add(Me.txtEntM)
        Me.Controls.Add(Me.txtDemissao)
        Me.Controls.Add(Me.txtAdmissao)
        Me.Controls.Add(Me.txtNascimento)
        Me.Controls.Add(Me.btImprime)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.chkAtivo)
        Me.Controls.Add(Me.chkVT)
        Me.Controls.Add(Me.chkAposentado)
        Me.Controls.Add(Me.cmbHoraMes)
        Me.Controls.Add(Me.txtSetor)
        Me.Controls.Add(Me.txtPonto)
        Me.Controls.Add(Me.txtEmergencia)
        Me.Controls.Add(Me.txtNomeEmergencia)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtCelular)
        Me.Controls.Add(Me.txtFone)
        Me.Controls.Add(Me.txtCEP)
        Me.Controls.Add(Me.txtCidade)
        Me.Controls.Add(Me.txtCalca)
        Me.Controls.Add(Me.txtLuvas)
        Me.Controls.Add(Me.txtCalcado)
        Me.Controls.Add(Me.txtCamisa)
        Me.Controls.Add(Me.txtAltura)
        Me.Controls.Add(Me.txtPeso)
        Me.Controls.Add(Me.txtOlhos)
        Me.Controls.Add(Me.txtCabelos)
        Me.Controls.Add(Me.txtCor)
        Me.Controls.Add(Me.txtNumVT)
        Me.Controls.Add(Me.txtPIS)
        Me.Controls.Add(Me.txtBairro)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.txtEndereco)
        Me.Controls.Add(Me.txtBeneficio)
        Me.Controls.Add(Me.txtMae)
        Me.Controls.Add(Me.txtPai)
        Me.Controls.Add(Me.txtInstrucao)
        Me.Controls.Add(Me.txtDependentes)
        Me.Controls.Add(Me.txtConjuge)
        Me.Controls.Add(Me.txtEstCivil)
        Me.Controls.Add(Me.txtRegiao)
        Me.Controls.Add(Me.txtRM)
        Me.Controls.Add(Me.txtSecao)
        Me.Controls.Add(Me.txtZona)
        Me.Controls.Add(Me.txtEleitor)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.txtHabilitacao)
        Me.Controls.Add(Me.txtCBO)
        Me.Controls.Add(Me.txtTrabalho)
        Me.Controls.Add(Me.txtEmissor)
        Me.Controls.Add(Me.txtIdentidade)
        Me.Controls.Add(Me.txtCPF)
        Me.Controls.Add(Me.txtExperiencia)
        Me.Controls.Add(Me.txtSalario)
        Me.Controls.Add(Me.txtFuncao)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.imgFoto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Line3)
        Me.Controls.Add(Me._lblLabels_10)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._lblLabels_59)
        Me.Controls.Add(Me._lblLabels_58)
        Me.Controls.Add(Me._lblLabels_56)
        Me.Controls.Add(Me._lblLabels_55)
        Me.Controls.Add(Me._lblLabels_54)
        Me.Controls.Add(Me._lblLabels_53)
        Me.Controls.Add(Me._lblLabels_52)
        Me.Controls.Add(Me._lblLabels_51)
        Me.Controls.Add(Me._lblLabels_50)
        Me.Controls.Add(Me._lblLabels_49)
        Me.Controls.Add(Me._lblLabels_48)
        Me.Controls.Add(Me._lblLabels_47)
        Me.Controls.Add(Me._lblLabels_46)
        Me.Controls.Add(Me._lblLabels_45)
        Me.Controls.Add(Me._lblLabels_44)
        Me.Controls.Add(Me._lblLabels_43)
        Me.Controls.Add(Me._lblLabels_42)
        Me.Controls.Add(Me._lblLabels_41)
        Me.Controls.Add(Me._lblLabels_40)
        Me.Controls.Add(Me._lblLabels_39)
        Me.Controls.Add(Me._lblLabels_38)
        Me.Controls.Add(Me._lblLabels_37)
        Me.Controls.Add(Me._lblLabels_36)
        Me.Controls.Add(Me._lblLabels_35)
        Me.Controls.Add(Me._lblLabels_33)
        Me.Controls.Add(Me._lblLabels_32)
        Me.Controls.Add(Me._lblLabels_30)
        Me.Controls.Add(Me._lblLabels_29)
        Me.Controls.Add(Me._lblLabels_28)
        Me.Controls.Add(Me._lblLabels_27)
        Me.Controls.Add(Me._lblLabels_26)
        Me.Controls.Add(Me._lblLabels_25)
        Me.Controls.Add(Me._lblLabels_24)
        Me.Controls.Add(Me._lblLabels_23)
        Me.Controls.Add(Me._lblLabels_22)
        Me.Controls.Add(Me._lblLabels_21)
        Me.Controls.Add(Me._lblLabels_20)
        Me.Controls.Add(Me._lblLabels_19)
        Me.Controls.Add(Me._lblLabels_18)
        Me.Controls.Add(Me._lblLabels_17)
        Me.Controls.Add(Me._lblLabels_16)
        Me.Controls.Add(Me._lblLabels_15)
        Me.Controls.Add(Me._lblLabels_14)
        Me.Controls.Add(Me._lblLabels_13)
        Me.Controls.Add(Me._lblLabels_12)
        Me.Controls.Add(Me._lblLabels_11)
        Me.Controls.Add(Me._lblLabels_9)
        Me.Controls.Add(Me._lblLabels_8)
        Me.Controls.Add(Me._lblLabels_7)
        Me.Controls.Add(Me._lblLabels_6)
        Me.Controls.Add(Me._lblLabels_5)
        Me.Controls.Add(Me._lblLabels_4)
        Me.Controls.Add(Me._lblLabels_3)
        Me.Controls.Add(Me._lblLabels_2)
        Me.Controls.Add(Me._lblLabels_1)
        Me.Controls.Add(Me._lblLabels_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(201, 90)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFuncionario"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Funcionários"
        CType(Me.bsFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCadastro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.navFuncionarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.navFuncionarios.ResumeLayout(False)
        Me.navFuncionarios.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As frmFuncionario
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As frmFuncionario
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New frmFuncionario()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal value As frmFuncionario)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region

    'Define as variaveis para conexao
    Private MyCON As MySqlConnection
    Private MyCMD As New MySqlCommand
    Private MyCOMM As New MySqlCommandBuilder
    Private myTABLE As System.Data.DataTable
    Private MyADA As MySqlDataAdapter
    Private SQL As String

    Private Sub frmFuncionario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Cria uma conexão usando a ConectionString do Programa
        'MyCON = New MySqlConnection(MY_SQL_CONNECTION)
        'Cria um adaptador para a Tabela baseado na clausula SELECT
        'MyADA = New MySqlDataAdapter("SELECT * FROM Funcionarios", MyCON)
        'Cria todos os outros comandos (Incluir,Alterar, e atualizar baseado nos SELECT)
        'MyCOMM = New MySqlCommandBuilder(MyADA)
        'Preenche o dataSET do programa com os dados do funcionário
        taFuncionarios.Fill(DsCadastro.funcionarios)
        'MyADA.Fill(DsCadastro.funcionarios)

        'Console.WriteLine(MyCOMM.GetUpdateCommand.CommandText)

        'MyCOMM.DataAdapter.UpdateCommand.CommandText = "UPDATE `controle`.`funcionarios` SET `Nome` = @p1, `Nascimento` = @p2, `Admissao` = @p3, `Demissao` = @p4, `Funcao` = @p5, `Salario` = @p6, `Hora_Mes` = @p7, `Hora_ent` = @p8, `Hora_sai` = @p9, `Hora_ent_tarde` = @p10, `Hora_sai_tarde` = @p11, `Experiencia` = @p12, `CPF` = @p13, `Identidade` = @p14, `Emissor` = @p15, `Trabalho` = @p16, `CBO` = @p17, `Habilitacao` = @p18, `Categoria` = @p19, `Eleitor` = @p20, `Zona` = @p21, `Secao` = @p22, `RM` = @p23, `Regiao_RM` = @p24, `EstCivil` = @p25, `NomeConjuge` = @p26, `Dependentes` = @p27, `Instrucao` = @p28, `NomePai` = @p29, `NomeMae` = @p30, `Aposentado` = @p31, `Beneficio` = @p32, `Endereco` = @p33, `Numero` = @p34, `Bairro` = @p35, `PIS` = @p36, `DataPis` = @p37, `ValeTransporte` = @p38, `NumVale` = @p39, `Cor` = @p40, `Cabelos` = @p41, `Olhos` = @p42, `Peso` = @p43, `altura` = @p44, `Camisa` = @p45, `Calcado` = @p46, `Luvas` = @p47, `Calca` = @p48, `Cidade` = @p49, `CEP` = @p50, `Telefone` = @p51, `Celular` = @p52, `email` = @p53, `Emergencia` = @p54, `Tel_Emergencia` = @p55, `Foto` = @p56, `Ativo` = @p57, `Ponto` = @p58, `Setor` = @p59 WHERE (`id` = @p60)"
        'MyADA.UpdateCommand.CommandText = "UPDATE `controle`.`funcionarios` SET `Nome` = @p1, `Nascimento` = @p2, `Admissao` = @p3, `Demissao` = @p4, `Funcao` = @p5, `Salario` = @p6, `Hora_Mes` = @p7, `Hora_ent` = @p8, `Hora_sai` = @p9, `Hora_ent_tarde` = @p10, `Hora_sai_tarde` = @p11, `Experiencia` = @p12, `CPF` = @p13, `Identidade` = @p14, `Emissor` = @p15, `Trabalho` = @p16, `CBO` = @p17, `Habilitacao` = @p18, `Categoria` = @p19, `Eleitor` = @p20, `Zona` = @p21, `Secao` = @p22, `RM` = @p23, `Regiao_RM` = @p24, `EstCivil` = @p25, `NomeConjuge` = @p26, `Dependentes` = @p27, `Instrucao` = @p28, `NomePai` = @p29, `NomeMae` = @p30, `Aposentado` = @p31, `Beneficio` = @p32, `Endereco` = @p33, `Numero` = @p34, `Bairro` = @p35, `PIS` = @p36, `DataPis` = @p37, `ValeTransporte` = @p38, `NumVale` = @p39, `Cor` = @p40, `Cabelos` = @p41, `Olhos` = @p42, `Peso` = @p43, `altura` = @p44, `Camisa` = @p45, `Calcado` = @p46, `Luvas` = @p47, `Calca` = @p48, `Cidade` = @p49, `CEP` = @p50, `Telefone` = @p51, `Celular` = @p52, `email` = @p53, `Emergencia` = @p54, `Tel_Emergencia` = @p55, `Foto` = @p56, `Ativo` = @p57, `Ponto` = @p58, `Setor` = @p59 WHERE (`id` = @p60)"

        'Me.imgFoto.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.FuncionariosBindingSource, "Foto", True))
    End Sub

    Private Sub FuncionariosBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FuncionariosBindingNavigatorSaveItem.Click
        Try
            bsFuncionarios.EndEdit()
            'MyADA.AcceptChangesDuringUpdate = True
            'MyCOMM = New MySqlCommandBuilder(MyADA)
            'Console.WriteLine(Me.Name & ": " & MyCOMM.GetUpdateCommand.CommandText)

            'Faz o ajuste para que o número possa ser gravado no banco de dados
            txtSalario.Text = Numero_to_SQL(txtSalario.Text)
            taFuncionarios.Update(DsCadastro.funcionarios)

            'MyADA.Update(DsCadastro.funcionarios)
            MsgBox("Registro do funcionário salvo com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmação")

        Catch ex As Exception
            MsgBox("Erro ao tentar atualizar o cadastro de funcionários!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    'Carrega a foto
    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click

        Dim FileSize As UInt32
        Dim rawData() As Byte
        Dim fs As FileStream

        Try
            'Localiza o arquivo no HD
            fdArquivo.ShowDialog()

            If fdArquivo.FileName <> "" Then
                'Copia o arquivo jpeg selecionado para a PictureBox com o metodo FromFile do objeto Image
                imgFoto.Image = Image.FromFile(fdArquivo.FileName)

                'Le o arquivo e pega os bytes para colocar na imagem
                fs = New FileStream(fdArquivo.FileName, FileMode.Open, FileAccess.Read)
                FileSize = fs.Length

                'Transforma em dados puros
                rawData = New Byte(FileSize) {}
                fs.Read(rawData, 0, FileSize)
                fs.Close()

                'Tenta incluir no banco de dados
                DsCadastro.funcionarios(Me.BindingContext(DsCadastro, "Funcionarios").Position)("Foto") = rawData

                'Limpa a propriedade FileName depois de copiar a imagem jpeg para o campo Foto
                fdArquivo.FileName = ""
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar carregar a imagem do arquivo!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Erro")
            Exit Sub
        End Try

    End Sub

    Private Sub btImprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImprime.Click
        'Cria o caminho base para os arquivos de relatório
        Dim rptNome As String
        Dim strReportPath As String = My.Application.Info.DirectoryPath & "\Relatorios\"

        'Define o cursor como espera
        Me.Cursor = Cursors.WaitCursor

        rptNome = "crFichaFuncionario.rpt"
        'Monta o caminho do arquivo
        strReportPath = strReportPath & rptNome

        'verifica se o arquivo existe
        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Relatório não localizado :" & vbCrLf & strReportPath))
            Me.Cursor = Cursors.Arrow
        End If

        'instancia o relatorio e carrega
        Dim CR As New ReportDocument
        CR.Load(strReportPath)

        '
        ' atribui os parametros declarados aos objetos relacionados
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldLocation As ParameterFieldDefinition
        Dim crParameterValues As ParameterValues

        '
        ' Pega a coleção de parametros do relatorio
        crParameterFieldDefinitions = CR.DataDefinition.ParameterFields
        '
        ' define o primeiro parametro
        '    - pega o parametro e diz a ela para usar os valores atuais
        '    - define o valor do parametro
        '    - inclui e aplica o valor
        '    - repete para cada parametro se for o caso (não é o caso deste exemplo)
        ' Vamos usar o parametro 'ID'

        'É o nome dado ao ParameterField lá no CrystalReports
        crParameterFieldLocation = crParameterFieldDefinitions.Item("txtID")
        crParameterValues = crParameterFieldLocation.CurrentValues
        crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue

        'obtem o valor da caixa de texto (Matricula)
        crParameterDiscreteValue.Value = IdTextBox.Text
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

        Try
            'Define as variáveis auxiliares de impressão
            Dim PrinterName As String
            Dim ePage As Integer
            Dim sPage As Integer
            Dim nCopy As Integer

            'Pede para selecionar a impressora
            PrintDialog1.Document = PrintDocument1
            Dim DR As DialogResult = PrintDialog1.ShowDialog()
            'Se der tudo certo
            If DR = DialogResult.OK Then
                'Quantas Cópias
                nCopy = PrintDialog1.PrinterSettings.Copies
                'Número da Página inicial (0=todas)
                sPage = 0
                'Numero final igual a Zero imprime todas
                ePage = 0
                'Pega o nome da impressora
                PrinterName = PrintDocument1.PrinterSettings.PrinterName
                'Define o nome da impressora
                CR.PrintOptions.PrinterName = PrinterName
                'Manda o relatório para impressoa selecionada
                CR.PrintToPrinter(nCopy, False, sPage, ePage)
            End If
        Catch ex As Exception
            MsgBox("Erro ao tentar imprimir a ficha do Funcionário" & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro")
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End Try

        




    End Sub

    Private Sub Atualiza_Foto()
        'verifique se o campo Picture do registro atual não é NULL
        'If Not DsCadastro.funcionarios(Me.BindingContext(DsCadastro, "Funcionarios").Position)("Foto") Is DBNull.Value Then
        If Not DsCadastro.funcionarios(Me.BindingContext(DsCadastro, "funcionarios").Position)("Foto") Is DBNull.Value Then
            'Dimensiona uma varivael Byte array (bytePicData) e armazena o valor no campo Foto
            MsgBox(Me.BindingContext(DsCadastro, "funcionarios").Position)
            Dim bytePicData() As Byte = DsCadastro.Tables("funcionarios").Rows(Me.BindingContext(DsCadastro, "funcionarios").Position)("Foto")

            'Um MemoryStream é um obejto System.IO (como um FileStream). Movendo os valores de
            ' do byte array bytePicData para MemoryStream, podemos usar o metodo FromStream do objeto Image Intrinsico
            ' para converter e copiar a figura diretamente para a propriedade Image do controle picFoto

            Dim PicMemStream As New System.IO.MemoryStream(bytePicData)
            imgFoto.Image = Image.FromStream(PicMemStream)
        Else 'Se o campo Foto for Null, define a propriedade Image de picFoto para Nothing
            ' para remover qualquer imagem exibida antes
            imgFoto.Image = Nothing
        End If
    End Sub

    Private Sub txtSalario_Leave(sender As Object, e As EventArgs) Handles txtSalario.Leave
        txtSalario.Text = Format(String_to_Numero(txtSalario.Text), "N2")
    End Sub
End Class