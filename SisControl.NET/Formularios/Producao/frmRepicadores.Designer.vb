<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepicadores
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
        Dim NomeLabel As System.Windows.Forms.Label
        Dim NumeroLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepicadores))
        Dim IdLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Me.DsCadastro = New SisControl.NET.dsCadastro
        Me.RepicadorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RepicadorTableAdapter = New SisControl.NET.dsCadastroTableAdapters.repicadorTableAdapter
        Me.RepicadorBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.RepicadorBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.NomeTextBox = New System.Windows.Forms.TextBox
        Me.NumeroTextBox = New System.Windows.Forms.TextBox
        Me.IdTextBox = New System.Windows.Forms.TextBox
        Me.cmbRepicador = New System.Windows.Forms.ComboBox
        NomeLabel = New System.Windows.Forms.Label
        NumeroLabel = New System.Windows.Forms.Label
        IdLabel = New System.Windows.Forms.Label
        Label1 = New System.Windows.Forms.Label
        CType(Me.DsCadastro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepicadorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepicadorBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RepicadorBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'NomeLabel
        '
        NomeLabel.AutoSize = True
        NomeLabel.Location = New System.Drawing.Point(12, 58)
        NomeLabel.Name = "NomeLabel"
        NomeLabel.Size = New System.Drawing.Size(38, 13)
        NomeLabel.TabIndex = 1
        NomeLabel.Text = "Nome:"
        '
        'NumeroLabel
        '
        NumeroLabel.AutoSize = True
        NumeroLabel.Location = New System.Drawing.Point(12, 84)
        NumeroLabel.Name = "NumeroLabel"
        NumeroLabel.Size = New System.Drawing.Size(47, 13)
        NumeroLabel.TabIndex = 3
        NumeroLabel.Text = "Número:"
        '
        'DsCadastro
        '
        Me.DsCadastro.DataSetName = "dsCadastro"
        Me.DsCadastro.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RepicadorBindingSource
        '
        Me.RepicadorBindingSource.DataMember = "repicador"
        Me.RepicadorBindingSource.DataSource = Me.DsCadastro
        '
        'RepicadorTableAdapter
        '
        Me.RepicadorTableAdapter.ClearBeforeFill = True
        '
        'RepicadorBindingNavigator
        '
        Me.RepicadorBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.RepicadorBindingNavigator.BindingSource = Me.RepicadorBindingSource
        Me.RepicadorBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.RepicadorBindingNavigator.CountItemFormat = "de {0}"
        Me.RepicadorBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.RepicadorBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.RepicadorBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.RepicadorBindingNavigatorSaveItem})
        Me.RepicadorBindingNavigator.Location = New System.Drawing.Point(0, 119)
        Me.RepicadorBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.RepicadorBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.RepicadorBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.RepicadorBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.RepicadorBindingNavigator.Name = "RepicadorBindingNavigator"
        Me.RepicadorBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.RepicadorBindingNavigator.Size = New System.Drawing.Size(400, 25)
        Me.RepicadorBindingNavigator.TabIndex = 0
        Me.RepicadorBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Adiciona novo"
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
        Me.BindingNavigatorDeleteItem.Text = "Exclui registro"
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
        'RepicadorBindingNavigatorSaveItem
        '
        Me.RepicadorBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RepicadorBindingNavigatorSaveItem.Image = CType(resources.GetObject("RepicadorBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.RepicadorBindingNavigatorSaveItem.Name = "RepicadorBindingNavigatorSaveItem"
        Me.RepicadorBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.RepicadorBindingNavigatorSaveItem.Text = "Salvar registro"
        '
        'NomeTextBox
        '
        Me.NomeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RepicadorBindingSource, "Nome", True))
        Me.NomeTextBox.Location = New System.Drawing.Point(63, 55)
        Me.NomeTextBox.Name = "NomeTextBox"
        Me.NomeTextBox.Size = New System.Drawing.Size(317, 20)
        Me.NomeTextBox.TabIndex = 2
        '
        'NumeroTextBox
        '
        Me.NumeroTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RepicadorBindingSource, "Numero", True))
        Me.NumeroTextBox.Location = New System.Drawing.Point(63, 81)
        Me.NumeroTextBox.Name = "NumeroTextBox"
        Me.NumeroTextBox.Size = New System.Drawing.Size(54, 20)
        Me.NumeroTextBox.TabIndex = 4
        '
        'IdLabel
        '
        IdLabel.AutoSize = True
        IdLabel.Enabled = False
        IdLabel.Location = New System.Drawing.Point(316, 15)
        IdLabel.Name = "IdLabel"
        IdLabel.Size = New System.Drawing.Size(18, 13)
        IdLabel.TabIndex = 5
        IdLabel.Text = "id:"
        '
        'IdTextBox
        '
        Me.IdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RepicadorBindingSource, "id", True))
        Me.IdTextBox.Enabled = False
        Me.IdTextBox.Location = New System.Drawing.Point(340, 12)
        Me.IdTextBox.Name = "IdTextBox"
        Me.IdTextBox.Size = New System.Drawing.Size(40, 20)
        Me.IdTextBox.TabIndex = 6
        '
        'cmbRepicador
        '
        Me.cmbRepicador.FormattingEnabled = True
        Me.cmbRepicador.Location = New System.Drawing.Point(128, 12)
        Me.cmbRepicador.Name = "cmbRepicador"
        Me.cmbRepicador.Size = New System.Drawing.Size(182, 21)
        Me.cmbRepicador.TabIndex = 7
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(12, 15)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(110, 13)
        Label1.TabIndex = 8
        Label1.Text = "Localize o Repicador:"
        '
        'frmRepicadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 144)
        Me.Controls.Add(Label1)
        Me.Controls.Add(Me.cmbRepicador)
        Me.Controls.Add(IdLabel)
        Me.Controls.Add(Me.IdTextBox)
        Me.Controls.Add(NumeroLabel)
        Me.Controls.Add(Me.NumeroTextBox)
        Me.Controls.Add(NomeLabel)
        Me.Controls.Add(Me.NomeTextBox)
        Me.Controls.Add(Me.RepicadorBindingNavigator)
        Me.MaximizeBox = False
        Me.Name = "frmRepicadores"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Repicadores"
        CType(Me.DsCadastro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepicadorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepicadorBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RepicadorBindingNavigator.ResumeLayout(False)
        Me.RepicadorBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsCadastro As SisControl.NET.dsCadastro
    Friend WithEvents RepicadorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RepicadorTableAdapter As SisControl.NET.dsCadastroTableAdapters.repicadorTableAdapter
    Friend WithEvents RepicadorBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents RepicadorBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents NomeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NumeroTextBox As System.Windows.Forms.TextBox
    Friend WithEvents IdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents cmbRepicador As System.Windows.Forms.ComboBox
End Class
