<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmForPag
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DescricaoLabel As System.Windows.Forms.Label
        Dim VencimentosLabel As System.Windows.Forms.Label
        Dim PorcentagemLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmForPag))
        Dim IdLabel As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Me.DsCadastro = New SisControl.NET.dsCadastro
        Me.ForpagBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ForpagTableAdapter = New SisControl.NET.dsCadastroTableAdapters.forpagTableAdapter
        Me.ForpagBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ForpagBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.DescricaoTextBox = New System.Windows.Forms.TextBox
        Me.VencimentosTextBox = New System.Windows.Forms.TextBox
        Me.PorcentagemTextBox = New System.Windows.Forms.TextBox
        Me.cmbForma = New System.Windows.Forms.ComboBox
        Me.IdTextBox = New System.Windows.Forms.TextBox
        DescricaoLabel = New System.Windows.Forms.Label
        VencimentosLabel = New System.Windows.Forms.Label
        PorcentagemLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        Label2 = New System.Windows.Forms.Label
        IdLabel = New System.Windows.Forms.Label
        Label3 = New System.Windows.Forms.Label
        CType(Me.DsCadastro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ForpagBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ForpagBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ForpagBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'DescricaoLabel
        '
        DescricaoLabel.AutoSize = True
        DescricaoLabel.Location = New System.Drawing.Point(12, 65)
        DescricaoLabel.Name = "DescricaoLabel"
        DescricaoLabel.Size = New System.Drawing.Size(58, 13)
        DescricaoLabel.TabIndex = 1
        DescricaoLabel.Text = "Descrição:"
        '
        'VencimentosLabel
        '
        VencimentosLabel.AutoSize = True
        VencimentosLabel.Location = New System.Drawing.Point(12, 91)
        VencimentosLabel.Name = "VencimentosLabel"
        VencimentosLabel.Size = New System.Drawing.Size(71, 13)
        VencimentosLabel.TabIndex = 3
        VencimentosLabel.Text = "Vencimentos:"
        '
        'PorcentagemLabel
        '
        PorcentagemLabel.AutoSize = True
        PorcentagemLabel.Location = New System.Drawing.Point(12, 132)
        PorcentagemLabel.Name = "PorcentagemLabel"
        PorcentagemLabel.Size = New System.Drawing.Size(73, 13)
        PorcentagemLabel.TabIndex = 5
        PorcentagemLabel.Text = "Porcentagem:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label1.Location = New System.Drawing.Point(86, 111)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(201, 13)
        Label1.TabIndex = 7
        Label1.Text = "Dias separados por virgula - Ex: 30,60,90"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.Location = New System.Drawing.Point(86, 152)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(246, 13)
        Label2.TabIndex = 8
        Label2.Text = "Porcentagens separadas por virgula - Ex: 33,33,34"
        '
        'DsCadastro
        '
        Me.DsCadastro.DataSetName = "dsCadastro"
        Me.DsCadastro.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ForpagBindingSource
        '
        Me.ForpagBindingSource.DataMember = "forpag"
        Me.ForpagBindingSource.DataSource = Me.DsCadastro
        '
        'ForpagTableAdapter
        '
        Me.ForpagTableAdapter.ClearBeforeFill = True
        '
        'ForpagBindingNavigator
        '
        Me.ForpagBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ForpagBindingNavigator.BindingSource = Me.ForpagBindingSource
        Me.ForpagBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ForpagBindingNavigator.CountItemFormat = "de {0}"
        Me.ForpagBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ForpagBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ForpagBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ForpagBindingNavigatorSaveItem})
        Me.ForpagBindingNavigator.Location = New System.Drawing.Point(0, 186)
        Me.ForpagBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ForpagBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ForpagBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ForpagBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ForpagBindingNavigator.Name = "ForpagBindingNavigator"
        Me.ForpagBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ForpagBindingNavigator.Size = New System.Drawing.Size(415, 25)
        Me.ForpagBindingNavigator.TabIndex = 0
        Me.ForpagBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
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
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
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
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ForpagBindingNavigatorSaveItem
        '
        Me.ForpagBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ForpagBindingNavigatorSaveItem.Image = CType(resources.GetObject("ForpagBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ForpagBindingNavigatorSaveItem.Name = "ForpagBindingNavigatorSaveItem"
        Me.ForpagBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ForpagBindingNavigatorSaveItem.Text = "Save Data"
        '
        'DescricaoTextBox
        '
        Me.DescricaoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ForpagBindingSource, "Descricao", True))
        Me.DescricaoTextBox.Location = New System.Drawing.Point(89, 62)
        Me.DescricaoTextBox.Name = "DescricaoTextBox"
        Me.DescricaoTextBox.Size = New System.Drawing.Size(306, 20)
        Me.DescricaoTextBox.TabIndex = 2
        '
        'VencimentosTextBox
        '
        Me.VencimentosTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ForpagBindingSource, "Vencimentos", True))
        Me.VencimentosTextBox.Location = New System.Drawing.Point(89, 88)
        Me.VencimentosTextBox.Name = "VencimentosTextBox"
        Me.VencimentosTextBox.Size = New System.Drawing.Size(306, 20)
        Me.VencimentosTextBox.TabIndex = 4
        '
        'PorcentagemTextBox
        '
        Me.PorcentagemTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ForpagBindingSource, "Porcentagem", True))
        Me.PorcentagemTextBox.Location = New System.Drawing.Point(89, 129)
        Me.PorcentagemTextBox.Name = "PorcentagemTextBox"
        Me.PorcentagemTextBox.Size = New System.Drawing.Size(306, 20)
        Me.PorcentagemTextBox.TabIndex = 6
        '
        'cmbForma
        '
        Me.cmbForma.FormattingEnabled = True
        Me.cmbForma.Location = New System.Drawing.Point(108, 12)
        Me.cmbForma.Name = "cmbForma"
        Me.cmbForma.Size = New System.Drawing.Size(208, 21)
        Me.cmbForma.TabIndex = 9
        '
        'IdLabel
        '
        IdLabel.AutoSize = True
        IdLabel.Location = New System.Drawing.Point(322, 15)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New System.Drawing.Size(18, 13)
        IdLabel.TabIndex = 10
        IdLabel.Text = "id:"
        '
        'IdTextBox
        '
        Me.IdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ForpagBindingSource, "id", True))
        Me.IdTextBox.Enabled = False
        Me.IdTextBox.Location = New System.Drawing.Point(346, 12)
        Me.IdTextBox.Name = "IdTextBox"
        Me.IdTextBox.Size = New System.Drawing.Size(49, 20)
        Me.IdTextBox.TabIndex = 11
        Me.IdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(12, 15)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(90, 13)
        Label3.TabIndex = 12
        Label3.Text = "Localize a Forma:"
        '
        'frmForPag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 211)
        Me.Controls.Add(Label3)
        Me.Controls.Add(IdLabel)
        Me.Controls.Add(Me.IdTextBox)
        Me.Controls.Add(Me.cmbForma)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Controls.Add(PorcentagemLabel)
        Me.Controls.Add(Me.PorcentagemTextBox)
        Me.Controls.Add(VencimentosLabel)
        Me.Controls.Add(Me.VencimentosTextBox)
        Me.Controls.Add(DescricaoLabel)
        Me.Controls.Add(Me.DescricaoTextBox)
        Me.Controls.Add(Me.ForpagBindingNavigator)
        Me.Name = "frmForPag"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Formas de Pagamento"
        CType(Me.DsCadastro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ForpagBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ForpagBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ForpagBindingNavigator.ResumeLayout(False)
        Me.ForpagBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsCadastro As SisControl.NET.dsCadastro
    Friend WithEvents ForpagBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ForpagTableAdapter As SisControl.NET.dsCadastroTableAdapters.forpagTableAdapter
    Friend WithEvents ForpagBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents ForpagBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents DescricaoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VencimentosTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PorcentagemTextBox As System.Windows.Forms.TextBox
    Friend WithEvents cmbForma As System.Windows.Forms.ComboBox
    Friend WithEvents IdTextBox As System.Windows.Forms.TextBox
End Class
