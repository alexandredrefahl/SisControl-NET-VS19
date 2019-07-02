Imports System.Xml
Imports System.IO
Imports System.Globalization
Imports System.Reflection
Imports System.Text

Public Module funcoesNfe
    Public Function removeFormatacao(ByVal texto As String) As String
        Dim txt As String = ""

        txt = texto.Replace(".", "")
        txt = txt.Replace("-", "")
        txt = txt.Replace("/", "")
        txt = txt.Replace("(", "")
        txt = txt.Replace(")", "")
        txt = txt.Replace(" ", "")

        Return txt
    End Function

    Public Sub retornaAtributos(ByVal obj As Object(), ByRef cultura As CultureInfo, ByRef formato As String, ByRef obrigatorio As Boolean)
        cultura = CultureInfo.CreateSpecificCulture("en-US")
        formato = "###0.00"
        obrigatorio = False
        For Each objeto As Object In obj
            If TypeOf objeto Is Formato Then
                Dim culturaStr As String = DirectCast(objeto, Formato).cultura
                formato = DirectCast(objeto, Formato).formato
                cultura = CultureInfo.CreateSpecificCulture(culturaStr)
            ElseIf TypeOf objeto Is Obrigatorio Then
                obrigatorio = DirectCast(objeto, Obrigatorio).propriedadeObrigatoria

            End If

            'cultura.NumberFormat.NumberDecimalSeparator = ",";
            'cultura.NumberFormat.NumberGroupSeparator = ".";
        Next
    End Sub

    Public Function modulo11(ByVal chaveNFE As String) As Integer
        If chaveNFE.Length <> 43 Then
            Throw New Exception("Chave inválida, não é possível calcular o digito verificador")
        End If


        Dim baseCalculo As String = "4329876543298765432987654329876543298765432"
        Dim somaResultados As Integer = 0

        For i As Integer = 0 To chaveNFE.Length - 1
            Dim numNF As Integer = Convert.ToInt32(chaveNFE(i).ToString())
            Dim numBaseCalculo As Integer = Convert.ToInt32(baseCalculo(i).ToString())

            somaResultados += (numBaseCalculo * numNF)
        Next

        Dim restoDivisao As Integer = (somaResultados Mod 11)
        Dim dv As Integer = 11 - restoDivisao
        If (dv = 0) OrElse (dv > 9) Then
            Return 0
        Else
            Return dv
        End If
    End Function

    Public Function TirarAcento(ByVal palavra As String) As String
        Dim palavraSemAcento As String = ""
        Dim caracterComAcento As String = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇº"
        Dim caracterSemAcento As String = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC "

        For i As Integer = 0 To palavra.Length - 1
            If caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1))) >= 0 Then
                Dim car As Integer = caracterComAcento.IndexOf(Convert.ToChar(palavra.Substring(i, 1)))
                palavraSemAcento += caracterSemAcento.Substring(car, 1)
            Else
                palavraSemAcento += palavra.Substring(i, 1)
            End If
        Next

        Return palavraSemAcento
    End Function

    ''' <summary>
    ''' Função que utilizo para saber se é uma propriedade simples (String, Int) ou uma nova classe, que deve gerar
    ''' uma nova tag xml
    ''' </summary>
    ''' <param name="propriedade"></param>
    ''' <returns></returns>
    Public Function novaTag(ByVal propriedade As PropertyInfo) As Boolean
        'TODO: Buscar uma forma melhor de identificar as subclasses.

        Select Case propriedade.PropertyType.ToString()
            'Propriedades que podem ser nulas (com ?)...
            Case "System.DateTime", "System.Int32", "System.String", "System.Double", "System.Nullable", "System.Decimal", _
            "System.Nullable`1[System.Int32]", "System.Nullable`1[System.DateTime]", "System.Nullable`1[System.Decimal]", "System.Nullable`1[System.Double]"
                Return False
            Case Else
                Return True
        End Select
    End Function

    Public Sub gravarElemento(ByVal writer As XmlWriter, ByVal nomeTag As String, ByVal valorTag As Object, ByVal atributos As Object())
        'CultureInfo cultBR = new CultureInfo("pt-BR");
        ' CultureInfo cultUS = new CultureInfo("en-US");

        Dim cult As CultureInfo
        Dim formato As String
        Dim obrigatorio As Boolean
        retornaAtributos(atributos, cult, formato, obrigatorio)

        If valorTag IsNot Nothing Then
            Dim valor As String = ""
            Select Case valorTag.[GetType]().ToString()
                Case "System.DateTime"
                    valor = DirectCast((valorTag), DateTime).ToString("yyyy-MM-dd")
                    If valor = "0001-01-01" Then
                        valor = DirectCast((valorTag), DateTime).ToString("hh:mm:ss")
                    End If
                    'formata no padrão necessário para a NFe
                    Exit Select
                Case "System.Int32"
                    valor = valorTag.ToString()
                    If valor.Trim() = "0" Then
                        'campos do tipo inteiro com valor 0 serão ignorados
                        'valor = ""
                    End If
                    Exit Select
                Case "System.String"
                    valor = TirarAcento(valorTag.ToString().Replace(vbCr & vbLf, " - ")).Trim()
                    'remove linhas... e tira acentos
                    Exit Select
                Case "System.Double"
                    valor = CDbl(valorTag).ToString(formato, cult.NumberFormat)
                    'formata de acordo com o atributo
                    Exit Select
                Case "System.Decimal"
                    valor = CDec(valorTag).ToString(formato, cult.NumberFormat)
                    'formata de acordo com o atributo
                    Exit Select

            End Select
            If (valor.Trim().Length > 0) OrElse (obrigatorio) Then
                writer.WriteElementString(nomeTag, valor)
            End If
        End If
    End Sub

    Public Function tamanhoXML(ByVal documento As XmlDocument) As Long
        Dim nomeArquivo As String = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "")

        Try
            documento.Save(nomeArquivo)
            Dim info As New FileInfo(nomeArquivo)
            Dim tamanhoArquivo As Long = info.Length

            info.Delete()

            Return tamanhoArquivo
        Catch
            Return 0

        End Try
    End Function
    Public Function RandomNumber(ByVal MaxNumber As Integer, _
    Optional ByVal MinNumber As Integer = 0) As Integer

        'initialize random number generator
        Dim r As New Random(System.DateTime.Now.Millisecond)

        'if passed incorrect arguments, swap them
        'can also throw exception or return 0

        If MinNumber > MaxNumber Then
            Dim t As Integer = MinNumber
            MinNumber = MaxNumber
            MaxNumber = t
        End If

        Return r.Next(MinNumber, MaxNumber)

    End Function
    Public Function GerarLoteNfeGeral(ByVal vStringNfe As String) As String
        Dim cVersaoDados As String = "3.10"

        'Pegar o último número de lote de NFe utilizado e acrescentar + 1 para novo envio
        Dim vArqXmlLote As String = "TryNfeLote.xml"
        Dim nNumeroLote As Int32 = 1

        If File.Exists(vArqXmlLote) Then
            Dim oLerXml As New XmlTextReader(vArqXmlLote)

            While oLerXml.Read()
                If oLerXml.NodeType = XmlNodeType.Element Then
                    If oLerXml.Name = "UltimoLoteEnviado" Then
                        oLerXml.Read()
                        nNumeroLote = Convert.ToInt32(oLerXml.Value) + 1
                        Exit While
                    End If
                End If
            End While
            oLerXml.Close()
        End If

        'Salvar o número de lote de NFe utilizado
        Dim oSettings As New XmlWriterSettings()
        oSettings.Indent = True
        oSettings.IndentChars = ""
        oSettings.NewLineOnAttributes = False
        oSettings.OmitXmlDeclaration = False

        Dim oXmlGravar As XmlWriter = XmlWriter.Create("TryNfeLote.xml", oSettings)

        oXmlGravar.WriteStartDocument()
        oXmlGravar.WriteStartElement("DadosLoteNfe")
        oXmlGravar.WriteElementString("UltimoLoteEnviado", nNumeroLote.ToString())
        oXmlGravar.WriteEndElement()
        'DadosLoteNfe
        oXmlGravar.WriteEndDocument()
        oXmlGravar.Flush()
        oXmlGravar.Close()


        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<enviNFe xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""" & cVersaoDados & """>"
        vStringLoteNfe += "<idLote>" & nNumeroLote.ToString("000000000000000") & "</idLote>"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "</enviNFe>"

        Dim PastaNota As String = ""
        PastaNota = My.Application.Info.DirectoryPath & "\NFE\" & Date.Today.ToString("dd-MM-yyyy") & "\"
        If Directory.Exists(PastaNota) = False Then
            Directory.CreateDirectory(PastaNota)
        End If

        Dim NDoc As New XmlDocument
        NDoc.LoadXml(vStringLoteNfe)
        Using xmltw As New XmlTextWriter(PastaNota & nNumeroLote.ToString("000000000000000") & ".xml", New UTF8Encoding(False))
            NDoc.WriteTo(xmltw)
            xmltw.Close()
        End Using
        Return nNumeroLote.ToString("000000000000000")
    End Function

    Public Function SepararNota(ByVal vNfeDadosMsg As String) As String

        'Separar somente o conteúdo a partir da tag <NFe> até </NFe>
        Dim nPosI As Int32 = vNfeDadosMsg.IndexOf("<NFe")
        Dim nPosF As Int32 = vNfeDadosMsg.Length - nPosI
        Dim vStringNfe As String = vNfeDadosMsg.Substring(nPosI, nPosF - 10)
        Return vStringNfe

    End Function

    Public Function GerarNotaProcessada(ByVal vStringNfe As String, ByVal VStringRecibo As String, ByVal NUMERONOTA As String, ByVal EmissaoNota As Date) As String
        Dim cVersaoDados As String = "3.10"

        'Montar a parte do XML referente ao Lote e acrescentar a Nota Fiscal
        Dim vStringLoteNfe As String = String.Empty
        vStringLoteNfe += "<?xml version=""1.0"" encoding=""utf-8""?>"
        vStringLoteNfe += "<nfeProc versao=""" & cVersaoDados & """ xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += vStringNfe
        vStringLoteNfe += "<protNFe versao=""" & cVersaoDados & """ xmlns=""http://www.portalfiscal.inf.br/nfe"">"
        vStringLoteNfe += VStringRecibo
        vStringLoteNfe += "</protNFe>"
        vStringLoteNfe += "</nfeProc>"

        Dim PastaNota As String = ""
        PastaNota = My.Application.Info.DirectoryPath & "\NFE\" & Date.Parse(EmissaoNota).ToString("dd-MM-yyyy") & "\"
        If Directory.Exists(PastaNota) = False Then
            Directory.CreateDirectory(PastaNota)
        End If

        Dim NDoc As New XmlDocument
        MsgBox(vStringNfe)
        NDoc.LoadXml(vStringLoteNfe)
        Using xmltw As New XmlTextWriter(PastaNota & NUMERONOTA & " - NF-e.xml", New UTF8Encoding(False))
            NDoc.WriteTo(xmltw)
            xmltw.Close()
        End Using

        Return PastaNota & NUMERONOTA & " - NF-e.xml"
    End Function
End Module