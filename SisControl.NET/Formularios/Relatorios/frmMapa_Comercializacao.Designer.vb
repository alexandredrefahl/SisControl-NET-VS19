<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMapa_Comercializacao
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAno = New System.Windows.Forms.TextBox()
        Me.dgMapa = New System.Windows.Forms.DataGridView()
        Me.btExcel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DsMapa_Com = New SisControl.NET.dsMapa_Com()
        Me.DsMapaComBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RNCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EspecieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CultivarDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClasseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrevistaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AprovadaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComUFDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComForaResumoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComExpoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TerceirosDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescarteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SaldoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComForaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgMapa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsMapa_Com, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsMapaComBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ano Base"
        '
        'txtAno
        '
        Me.txtAno.Location = New System.Drawing.Point(71, 6)
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(43, 20)
        Me.txtAno.TabIndex = 1
        Me.txtAno.Text = "2015"
        Me.txtAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgMapa
        '
        Me.dgMapa.AllowUserToAddRows = False
        Me.dgMapa.AllowUserToDeleteRows = False
        Me.dgMapa.AllowUserToOrderColumns = True
        Me.dgMapa.AutoGenerateColumns = False
        Me.dgMapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMapa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RNCDataGridViewTextBoxColumn, Me.EspecieDataGridViewTextBoxColumn, Me.CultivarDataGridViewTextBoxColumn, Me.TipoDataGridViewTextBoxColumn, Me.ClasseDataGridViewTextBoxColumn, Me.PrevistaDataGridViewTextBoxColumn, Me.AprovadaDataGridViewTextBoxColumn, Me.ComUFDataGridViewTextBoxColumn, Me.ComForaResumoDataGridViewTextBoxColumn, Me.ComExpoDataGridViewTextBoxColumn, Me.UsoDataGridViewTextBoxColumn, Me.TerceirosDataGridViewTextBoxColumn, Me.DescarteDataGridViewTextBoxColumn, Me.SaldoDataGridViewTextBoxColumn, Me.ComForaDataGridViewTextBoxColumn})
        Me.dgMapa.DataMember = "dtComercializacao"
        Me.dgMapa.DataSource = Me.DsMapaComBindingSource
        Me.dgMapa.Location = New System.Drawing.Point(12, 32)
        Me.dgMapa.Name = "dgMapa"
        Me.dgMapa.RowHeadersWidth = 21
        Me.dgMapa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMapa.Size = New System.Drawing.Size(1032, 355)
        Me.dgMapa.TabIndex = 2
        '
        'btExcel
        '
        Me.btExcel.Location = New System.Drawing.Point(969, 393)
        Me.btExcel.Name = "btExcel"
        Me.btExcel.Size = New System.Drawing.Size(75, 23)
        Me.btExcel.TabIndex = 3
        Me.btExcel.Text = "Copiar"
        Me.btExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.SisControl.NET.My.Resources.Resources.zoom
        Me.Button1.Location = New System.Drawing.Point(120, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 24)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DsMapa_Com
        '
        Me.DsMapa_Com.DataSetName = "dsMapa_Com"
        Me.DsMapa_Com.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsMapaComBindingSource
        '
        Me.DsMapaComBindingSource.DataSource = Me.DsMapa_Com
        Me.DsMapaComBindingSource.Position = 0
        '
        'RNCDataGridViewTextBoxColumn
        '
        Me.RNCDataGridViewTextBoxColumn.DataPropertyName = "RNC"
        Me.RNCDataGridViewTextBoxColumn.HeaderText = "RNC"
        Me.RNCDataGridViewTextBoxColumn.Name = "RNCDataGridViewTextBoxColumn"
        Me.RNCDataGridViewTextBoxColumn.Visible = False
        '
        'EspecieDataGridViewTextBoxColumn
        '
        Me.EspecieDataGridViewTextBoxColumn.DataPropertyName = "Especie"
        Me.EspecieDataGridViewTextBoxColumn.HeaderText = "Especie"
        Me.EspecieDataGridViewTextBoxColumn.Name = "EspecieDataGridViewTextBoxColumn"
        '
        'CultivarDataGridViewTextBoxColumn
        '
        Me.CultivarDataGridViewTextBoxColumn.DataPropertyName = "Cultivar"
        Me.CultivarDataGridViewTextBoxColumn.HeaderText = "Cultivar"
        Me.CultivarDataGridViewTextBoxColumn.Name = "CultivarDataGridViewTextBoxColumn"
        '
        'TipoDataGridViewTextBoxColumn
        '
        Me.TipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo"
        Me.TipoDataGridViewTextBoxColumn.HeaderText = "Tipo"
        Me.TipoDataGridViewTextBoxColumn.Name = "TipoDataGridViewTextBoxColumn"
        '
        'ClasseDataGridViewTextBoxColumn
        '
        Me.ClasseDataGridViewTextBoxColumn.DataPropertyName = "Classe"
        Me.ClasseDataGridViewTextBoxColumn.HeaderText = "Classe"
        Me.ClasseDataGridViewTextBoxColumn.Name = "ClasseDataGridViewTextBoxColumn"
        Me.ClasseDataGridViewTextBoxColumn.Width = 45
        '
        'PrevistaDataGridViewTextBoxColumn
        '
        Me.PrevistaDataGridViewTextBoxColumn.DataPropertyName = "Prevista"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.PrevistaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.PrevistaDataGridViewTextBoxColumn.HeaderText = "Prevista"
        Me.PrevistaDataGridViewTextBoxColumn.Name = "PrevistaDataGridViewTextBoxColumn"
        Me.PrevistaDataGridViewTextBoxColumn.Width = 60
        '
        'AprovadaDataGridViewTextBoxColumn
        '
        Me.AprovadaDataGridViewTextBoxColumn.DataPropertyName = "Aprovada"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.AprovadaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.AprovadaDataGridViewTextBoxColumn.HeaderText = "Aprovada"
        Me.AprovadaDataGridViewTextBoxColumn.Name = "AprovadaDataGridViewTextBoxColumn"
        Me.AprovadaDataGridViewTextBoxColumn.Width = 60
        '
        'ComUFDataGridViewTextBoxColumn
        '
        Me.ComUFDataGridViewTextBoxColumn.DataPropertyName = "ComUF"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ComUFDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ComUFDataGridViewTextBoxColumn.HeaderText = "ComUF"
        Me.ComUFDataGridViewTextBoxColumn.Name = "ComUFDataGridViewTextBoxColumn"
        Me.ComUFDataGridViewTextBoxColumn.Width = 60
        '
        'ComForaResumoDataGridViewTextBoxColumn
        '
        Me.ComForaResumoDataGridViewTextBoxColumn.DataPropertyName = "ComForaResumo"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ComForaResumoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.ComForaResumoDataGridViewTextBoxColumn.HeaderText = "ComForaResumo"
        Me.ComForaResumoDataGridViewTextBoxColumn.Name = "ComForaResumoDataGridViewTextBoxColumn"
        '
        'ComExpoDataGridViewTextBoxColumn
        '
        Me.ComExpoDataGridViewTextBoxColumn.DataPropertyName = "ComExpo"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ComExpoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.ComExpoDataGridViewTextBoxColumn.HeaderText = "ComExpo"
        Me.ComExpoDataGridViewTextBoxColumn.Name = "ComExpoDataGridViewTextBoxColumn"
        Me.ComExpoDataGridViewTextBoxColumn.Width = 60
        '
        'UsoDataGridViewTextBoxColumn
        '
        Me.UsoDataGridViewTextBoxColumn.DataPropertyName = "Uso"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.UsoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.UsoDataGridViewTextBoxColumn.HeaderText = "Uso"
        Me.UsoDataGridViewTextBoxColumn.Name = "UsoDataGridViewTextBoxColumn"
        Me.UsoDataGridViewTextBoxColumn.Width = 60
        '
        'TerceirosDataGridViewTextBoxColumn
        '
        Me.TerceirosDataGridViewTextBoxColumn.DataPropertyName = "Terceiros"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.TerceirosDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.TerceirosDataGridViewTextBoxColumn.HeaderText = "Terceiros"
        Me.TerceirosDataGridViewTextBoxColumn.Name = "TerceirosDataGridViewTextBoxColumn"
        Me.TerceirosDataGridViewTextBoxColumn.Width = 60
        '
        'DescarteDataGridViewTextBoxColumn
        '
        Me.DescarteDataGridViewTextBoxColumn.DataPropertyName = "Descarte"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.DescarteDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.DescarteDataGridViewTextBoxColumn.HeaderText = "Descarte"
        Me.DescarteDataGridViewTextBoxColumn.Name = "DescarteDataGridViewTextBoxColumn"
        Me.DescarteDataGridViewTextBoxColumn.Width = 60
        '
        'SaldoDataGridViewTextBoxColumn
        '
        Me.SaldoDataGridViewTextBoxColumn.DataPropertyName = "Saldo"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = "0"
        Me.SaldoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.SaldoDataGridViewTextBoxColumn.HeaderText = "Saldo"
        Me.SaldoDataGridViewTextBoxColumn.Name = "SaldoDataGridViewTextBoxColumn"
        Me.SaldoDataGridViewTextBoxColumn.Width = 60
        '
        'ComForaDataGridViewTextBoxColumn
        '
        Me.ComForaDataGridViewTextBoxColumn.DataPropertyName = "ComFora"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.ComForaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.ComForaDataGridViewTextBoxColumn.HeaderText = "ComFora"
        Me.ComForaDataGridViewTextBoxColumn.Name = "ComForaDataGridViewTextBoxColumn"
        Me.ComForaDataGridViewTextBoxColumn.Width = 60
        '
        'frmMapa_Comercializacao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1056, 425)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btExcel)
        Me.Controls.Add(Me.dgMapa)
        Me.Controls.Add(Me.txtAno)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMapa_Comercializacao"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapa de Produção e Comercialização"
        CType(Me.dgMapa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsMapa_Com, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsMapaComBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents dgMapa As System.Windows.Forms.DataGridView
    Friend WithEvents btExcel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DsMapaComBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsMapa_Com As SisControl.NET.dsMapa_Com
    Friend WithEvents RNCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EspecieDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CultivarDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClasseDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrevistaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AprovadaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComUFDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComForaResumoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComExpoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TerceirosDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescarteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaldoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComForaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
