''' <summary>
''' Informar apenas quando o item for sujeito ao IPI
''' </summary>
Public Class IPI
    Private _clEnq As String
    Public Property clEnq() As String
        Get
            Return _clEnq
        End Get
        Set(ByVal value As String)
            _clEnq = value
        End Set
    End Property
    Private _CNPJProd As String
    Public Property CNPJProd() As String
        Get
            Return _CNPJProd
        End Get
        Set(ByVal value As String)
            _CNPJProd = value
        End Set
    End Property
    'Private _cSelo As String
    'Public Property cSelo() As String
    '    Get
    '        Return _cSelo
    '    End Get
    '    Set(ByVal value As String)
    '        _cSelo = value
    '    End Set
    'End Property
    'Private _qSelo As Decimal
    'Public Property qSelo() As Decimal
    '    Get
    '        Return _qSelo
    '    End Get
    '    Set(ByVal value As Decimal)
    '        _qSelo = value
    '    End Set
    'End Property
    Private _cEnq As String
    Public Property cEnq() As String
        Get
            Return _cEnq
        End Get
        Set(ByVal value As String)
            _cEnq = value
        End Set
    End Property

    Private _IpiTrib As IPITrib
    Public Property IpiTrib() As IPITrib
        Get
            Return _IpiTrib
        End Get
        Set(ByVal value As IPITrib)
            _IpiTrib = value
        End Set
    End Property
    Private _IpiNT As IPINT
    Public Property IpiNT() As IPINT
        Get
            Return _IpiNT
        End Get
        Set(ByVal value As IPINT)
            _IpiNT = value
        End Set
    End Property
End Class
