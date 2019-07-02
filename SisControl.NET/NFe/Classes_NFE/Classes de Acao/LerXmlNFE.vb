Imports System.Xml


Public Class LerXmlNFE
    Public Structure NotaEletronica
        Dim NotaEletronica As NFe
        Dim ProtocoloAutorizacao As String
    End Structure
    Public Function LerNFE(ByVal CaminhoNFE As String) As NotaEletronica


        'CRIA UM NOVO DOCUMENTO XML
        Dim dados As XmlDocument = New XmlDocument

        dados.Load(CaminhoNFE)

        'DESMEMBRA RETORNO XML
        '-----------------------------------------------------------------------------------
        Dim NotaComProtocolo As New NotaEletronica

        For Each outerNode As XmlNode In dados
            If outerNode.Name = "enviNFe" Then
                For Each InnerNode As XmlNode In outerNode
                    If InnerNode.Name = "NFe" Then
                        NotaComProtocolo = PegaDadosNodeNFe(InnerNode)
                    End If

                Next
            ElseIf outerNode.Name = "nfeProc" Then
                For Each InnerNode As XmlNode In outerNode
                    If InnerNode.Name = "NFe" Then
                        NotaComProtocolo = PegaDadosNodeNFe(InnerNode)
                    End If
                    If InnerNode.Name = "protNFe" Then
                        NotaComProtocolo.ProtocoloAutorizacao = InnerNode.ChildNodes(0).ChildNodes(4).InnerText
                    End If
                Next
            ElseIf outerNode.Name = "NFe" Then
                NotaComProtocolo = PegaDadosNodeNFe(outerNode)
            End If
        Next

        Return NotaComProtocolo

        'Dim xmlGerado As XmlDocument = NotaComProtocolo.NotaEletronica.GerarXML()
        'Salva uma cópia do XML não assinado - ATENÇÃO - se você está utilizando Windows Vista/7/Server, salvar na Unidade C pode não ser possível caso o VS2008 não esteja rodando como administrador
        'xmlGerado.Save("c:\TESTELEITURA.xml")

    End Function

    Private Function PegaDadosNodeNFe(ByRef NodeNota As XmlNode) As NotaEletronica

        Dim NotaLida As New NFe()
        Dim ContarDet As Integer = 0

        For Each InnerNode As XmlNode In NodeNota.ChildNodes
            If InnerNode.Name = "infNFe" Then
                NotaLida.Id = InnerNode.Attributes.ItemOf("Id").InnerText.Replace("NFe", "")
                NotaLida.versao = InnerNode.Attributes.ItemOf("versao").InnerText

                For Each InnerNode2 As XmlNode In InnerNode.ChildNodes

                    If (InnerNode2.Name = "ide") Then
                        Dim ContarEntradas As Integer = 0

                        NotaLida.infNFE.Ide.cUF = InnerNode2.ChildNodes(0).InnerText
                        NotaLida.infNFE.Ide.cNF = InnerNode2.ChildNodes(1).InnerText
                        NotaLida.infNFE.Ide.natOp = InnerNode2.ChildNodes(2).InnerText
                        NotaLida.infNFE.Ide.indPag = InnerNode2.ChildNodes(3).InnerText
                        NotaLida.infNFE.Ide.[mod] = InnerNode2.ChildNodes(4).InnerText
                        NotaLida.infNFE.Ide.serie = InnerNode2.ChildNodes(5).InnerText
                        NotaLida.infNFE.Ide.nNF = InnerNode2.ChildNodes(6).InnerText
                        NotaLida.infNFE.Ide.dEmi = InnerNode2.ChildNodes(7).InnerText
                        'MsgBox(InnerNode2.ChildNodes(8).Name())

                        If InnerNode2.ChildNodes(8).Name = "dEmi" Then
                            NotaLida.infNFE.Ide.dEmi = InnerNode2.ChildNodes(8).InnerText
                            NotaLida.infNFE.Ide.dSaiEnt = InnerNode2.ChildNodes(9).InnerText
                            NotaLida.infNFE.Ide.hSaiEnt = InnerNode2.ChildNodes(10).InnerText
                            NotaLida.infNFE.Ide.tpNF = InnerNode2.ChildNodes(11).InnerText
                            NotaLida.infNFE.Ide.cMunFG = InnerNode2.ChildNodes(12).InnerText
                        Else
                            NotaLida.infNFE.Ide.dSaiEnt = InnerNode2.ChildNodes(8).InnerText
                            NotaLida.infNFE.Ide.hSaiEnt = InnerNode2.ChildNodes(9).InnerText
                            NotaLida.infNFE.Ide.tpNF = InnerNode2.ChildNodes(10).InnerText
                            NotaLida.infNFE.Ide.cMunFG = InnerNode2.ChildNodes(11).InnerText
                            'ContarEntradas -= 1
                        End If

                        For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                            If InnerNode3.Name = "NFref" Then
                                Dim NFrefS As NFref
                                If InnerNode3.ChildNodes(0).Name = "refNFe" Then
                                    NFrefS = New NFref
                                    NFrefS.refNFe = InnerNode3.ChildNodes(0).ChildNodes(0).InnerText
                                    NotaLida.infNFE.Ide.NFRef.Add(NFrefS)
                                Else
                                    NFrefS = New NFref
                                    NFrefS.RefNF.cUF = InnerNode3.ChildNodes(0).ChildNodes(0).InnerText
                                    NFrefS.RefNF.AAMM = InnerNode3.ChildNodes(0).ChildNodes(1).InnerText
                                    NFrefS.RefNF.CNPJ = InnerNode3.ChildNodes(0).ChildNodes(2).InnerText
                                    NFrefS.RefNF.mod = InnerNode3.ChildNodes(0).ChildNodes(3).InnerText
                                    NFrefS.RefNF.serie = InnerNode3.ChildNodes(0).ChildNodes(4).InnerText
                                    NFrefS.RefNF.nNF = InnerNode3.ChildNodes(0).ChildNodes(5).InnerText
                                    NotaLida.infNFE.Ide.NFRef.Add(NFrefS)
                                End If
                                ContarEntradas += 1
                            End If
                        Next

                        NotaLida.infNFE.Ide.tpImp = InnerNode2.ChildNodes(12 + ContarEntradas).InnerText
                        NotaLida.infNFE.Ide.tpEmis = InnerNode2.ChildNodes(13 + ContarEntradas).InnerText
                        NotaLida.infNFE.Ide.cDV = InnerNode2.ChildNodes(14 + ContarEntradas).InnerText
                        NotaLida.infNFE.Ide.tpAmb = InnerNode2.ChildNodes(15 + ContarEntradas).InnerText
                        NotaLida.infNFE.Ide.finNFe = InnerNode2.ChildNodes(16 + ContarEntradas).InnerText
                        NotaLida.infNFE.Ide.procEmi = InnerNode2.ChildNodes(17 + ContarEntradas).InnerText
                        NotaLida.infNFE.Ide.verProc = InnerNode2.ChildNodes(18 + ContarEntradas).InnerText

                    ElseIf (InnerNode2.Name = "emit") Then

                        NotaLida.infNFE.Emit.CNPJ = InnerNode2.ChildNodes(0).InnerText
                        NotaLida.infNFE.Emit.xNome = InnerNode2.ChildNodes(1).InnerText
                        NotaLida.infNFE.Emit.xFant = InnerNode2.ChildNodes(2).InnerText

                        NotaLida.infNFE.Emit.EnderEmit.xLgr = InnerNode2.ChildNodes(3).ChildNodes(0).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.nro = InnerNode2.ChildNodes(3).ChildNodes(1).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.xBairro = InnerNode2.ChildNodes(3).ChildNodes(2).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.cMun = InnerNode2.ChildNodes(3).ChildNodes(3).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.xMun = InnerNode2.ChildNodes(3).ChildNodes(4).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.UF = InnerNode2.ChildNodes(3).ChildNodes(5).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.CEP = InnerNode2.ChildNodes(3).ChildNodes(6).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.cPais = InnerNode2.ChildNodes(3).ChildNodes(7).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.xPais = InnerNode2.ChildNodes(3).ChildNodes(8).InnerText
                        NotaLida.infNFE.Emit.EnderEmit.fone = InnerNode2.ChildNodes(3).ChildNodes(9).InnerText

                        NotaLida.infNFE.Emit.IE = InnerNode2.ChildNodes(4).InnerText

                    ElseIf (InnerNode2.Name = "dest") Then

                        NotaLida.infNFE.Dest.CNPJ = InnerNode2.ChildNodes(0).InnerText
                        NotaLida.infNFE.Dest.xNome = InnerNode2.ChildNodes(1).InnerText
                        NotaLida.infNFE.Dest.EnderDest.xLgr = InnerNode2.ChildNodes(2).ChildNodes(0).InnerText
                        NotaLida.infNFE.Dest.EnderDest.nro = InnerNode2.ChildNodes(2).ChildNodes(1).InnerText
                        NotaLida.infNFE.Dest.EnderDest.xBairro = InnerNode2.ChildNodes(2).ChildNodes(2).InnerText
                        NotaLida.infNFE.Dest.EnderDest.cMun = InnerNode2.ChildNodes(2).ChildNodes(3).InnerText
                        NotaLida.infNFE.Dest.EnderDest.xMun = InnerNode2.ChildNodes(2).ChildNodes(4).InnerText
                        NotaLida.infNFE.Dest.EnderDest.UF = InnerNode2.ChildNodes(2).ChildNodes(5).InnerText
                        If InnerNode2.ChildNodes(2).ChildNodes(6).Name = "CEP" Then
                            NotaLida.infNFE.Dest.EnderDest.CEP = InnerNode2.ChildNodes(2).ChildNodes(6).InnerText
                            NotaLida.infNFE.Dest.EnderDest.cPais = InnerNode2.ChildNodes(2).ChildNodes(7).InnerText
                            NotaLida.infNFE.Dest.EnderDest.xPais = InnerNode2.ChildNodes(2).ChildNodes(8).InnerText
                            Try
                                If InnerNode2.ChildNodes(2).ChildNodes(9).Name = "fone" Then
                                    NotaLida.infNFE.Dest.EnderDest.fone = InnerNode2.ChildNodes(2).ChildNodes(9).InnerText
                                End If
                            Catch
                                NotaLida.infNFE.Dest.EnderDest.fone = ""
                            Finally

                            End Try
                        Else
                            NotaLida.infNFE.Dest.EnderDest.cPais = InnerNode2.ChildNodes(2).ChildNodes(6).InnerText
                            NotaLida.infNFE.Dest.EnderDest.xPais = InnerNode2.ChildNodes(2).ChildNodes(7).InnerText
                            Try
                                If InnerNode2.ChildNodes(2).ChildNodes(8).Name = "fone" Then
                                    NotaLida.infNFE.Dest.EnderDest.fone = InnerNode2.ChildNodes(2).ChildNodes(8).InnerText
                                End If
                            Catch
                                NotaLida.infNFE.Dest.EnderDest.fone = ""
                            Finally

                            End Try
                        End If
                        NotaLida.infNFE.Dest.IE = InnerNode2.ChildNodes(3).InnerText


                    ElseIf (InnerNode2.Name = "det") Then


                        ContarDet += 1

                        Dim Detalhamento As New det
                        Detalhamento.nItem = ContarDet
                        Detalhamento.Prod.cProd = InnerNode2.ChildNodes(0).ChildNodes(0).InnerText
                        Detalhamento.Prod.cEAN = InnerNode2.ChildNodes(0).ChildNodes(1).InnerText
                        Detalhamento.Prod.xProd = InnerNode2.ChildNodes(0).ChildNodes(2).InnerText

                        If InnerNode2.ChildNodes(0).ChildNodes(3).Name <> "NCM" Then
                            Detalhamento.Prod.CFOP = InnerNode2.ChildNodes(0).ChildNodes(3).InnerText
                            Detalhamento.Prod.uCom = InnerNode2.ChildNodes(0).ChildNodes(4).InnerText
                            Detalhamento.Prod.qCom = InnerNode2.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                            Detalhamento.Prod.vUnCom = InnerNode2.ChildNodes(0).ChildNodes(6).InnerText.Replace(".", ",")
                            Detalhamento.Prod.vProd = InnerNode2.ChildNodes(0).ChildNodes(7).InnerText.Replace(".", ",")
                            Detalhamento.Prod.cEANTrib = InnerNode2.ChildNodes(0).ChildNodes(8).InnerText
                            Detalhamento.Prod.uTrib = InnerNode2.ChildNodes(0).ChildNodes(9).InnerText.Replace(".", ",")
                            Detalhamento.Prod.qTrib = InnerNode2.ChildNodes(0).ChildNodes(10).InnerText.Replace(".", ",")
                            Detalhamento.Prod.vUnTrib = InnerNode2.ChildNodes(0).ChildNodes(11).InnerText.Replace(".", ",")
                        Else

                            Detalhamento.Prod.NCM = InnerNode2.ChildNodes(0).ChildNodes(3).InnerText
                            Detalhamento.Prod.CFOP = InnerNode2.ChildNodes(0).ChildNodes(4).InnerText
                            Detalhamento.Prod.uCom = InnerNode2.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                            Detalhamento.Prod.qCom = InnerNode2.ChildNodes(0).ChildNodes(6).InnerText.Replace(".", ",")
                            Detalhamento.Prod.vUnCom = InnerNode2.ChildNodes(0).ChildNodes(7).InnerText.Replace(".", ",")
                            Detalhamento.Prod.vProd = InnerNode2.ChildNodes(0).ChildNodes(8).InnerText.Replace(".", ",")
                            Detalhamento.Prod.cEANTrib = InnerNode2.ChildNodes(0).ChildNodes(9).InnerText
                            Detalhamento.Prod.uTrib = InnerNode2.ChildNodes(0).ChildNodes(10).InnerText.Replace(".", ",")
                            Detalhamento.Prod.qTrib = InnerNode2.ChildNodes(0).ChildNodes(11).InnerText.Replace(".", ",")
                            Detalhamento.Prod.vUnTrib = InnerNode2.ChildNodes(0).ChildNodes(12).InnerText.Replace(".", ",")
                        End If

                        For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                            If (InnerNode3.Name = "prod") Then
                                For Each InnerNode4 As XmlNode In InnerNode3.ChildNodes
                                    If (InnerNode4.Name = "rastro") Then
                                        Dim Crastro As New rastro
                                        Crastro.nLote = InnerNode4.ChildNodes(0).InnerText
                                        Crastro.qLote = InnerNode4.ChildNodes(1).InnerText.Replace(".", ",")
                                        Crastro.dFab = InnerNode4.ChildNodes(2).InnerText
                                        Crastro.dVal = InnerNode4.ChildNodes(3).InnerText
                                        'Crastro.vPMC = InnerNode4.ChildNodes(4).InnerText.Replace(".", ",")
                                        Detalhamento.Prod.Rastro.Add(Crastro)
                                    End If
                                Next
                            End If
                            If (InnerNode3.Name = "infAdProd") Then
                                Detalhamento.infAdProd = InnerNode3.ChildNodes(0).InnerText
                            End If
                            If (InnerNode3.Name = "imposto") Then
                                For Each InnerNode4 As XmlNode In InnerNode3.ChildNodes
                                    If InnerNode4.Name = "ICMS" Then
                                        Select Case InnerNode4.ChildNodes(0).Name
                                            Case Is = "ICMS40"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.Icms40 = New ICMS40()
                                                Detalhamento.Imposto.Icms.Icms40.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                                Detalhamento.Imposto.Icms.Icms40.CST = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText
                                            Case Is = "ICMS00"
                                                Detalhamento.Imposto.Icms = New ICMS()
                                                Detalhamento.Imposto.Icms.Icms00 = New ICMS00()
                                                Detalhamento.Imposto.Icms.Icms00.orig = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms00.CST = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms00.modBC = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms00.vBC = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms00.pICMS = InnerNode4.ChildNodes(0).ChildNodes(4).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Icms.Icms00.vICMS = InnerNode4.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                                        End Select
                                    End If
                                    If InnerNode4.Name = "PIS" Then
                                        Select Case InnerNode4.ChildNodes(0).Name
                                            Case Is = "PISAliq"
                                                Detalhamento.Imposto.Pis = New PIS()
                                                Detalhamento.Imposto.Pis.PisAliq = New PISAliq()
                                                Detalhamento.Imposto.Pis.PisAliq.CST = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Pis.PisAliq.vBC = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Pis.PisAliq.pPIS = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Pis.PisAliq.vPIS = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                            Case Is = "PISNT"
                                                Detalhamento.Imposto.Pis = New PIS()
                                                Detalhamento.Imposto.Pis.PisNT = New PISNT()
                                                Detalhamento.Imposto.Pis.PisNT.CST = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                        End Select
                                    End If
                                    If InnerNode4.Name = "COFINS" Then
                                        Select Case InnerNode4.ChildNodes(0).Name
                                            Case Is = "COFINSAliq"
                                                Detalhamento.Imposto.Cofins = New COFINS()
                                                Detalhamento.Imposto.Cofins.CofinsAliq = New COFINSAliq()
                                                Detalhamento.Imposto.Cofins.CofinsAliq.CST = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Cofins.CofinsAliq.vBC = InnerNode4.ChildNodes(0).ChildNodes(1).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Cofins.CofinsAliq.pCOFINS = InnerNode4.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                                                Detalhamento.Imposto.Cofins.CofinsAliq.vCOFINS = InnerNode4.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                                            Case Is = "COFINSNT"
                                                Detalhamento.Imposto.Cofins = New COFINS()
                                                Detalhamento.Imposto.Cofins.CofinsNT = New COFINSNT()
                                                Detalhamento.Imposto.Cofins.CofinsNT.CST = InnerNode4.ChildNodes(0).ChildNodes(0).InnerText
                                        End Select
                                    End If
                                Next
                            End If
                        Next

                        NotaLida.infNFE.Det.Add(Detalhamento)

                    ElseIf (InnerNode2.Name = "total") Then


                        NotaLida.infNFE.Total = New total()
                        NotaLida.infNFE.Total.IcmsTot = New ICMSTot()
                        NotaLida.infNFE.Total.IcmsTot.vBC = InnerNode2.ChildNodes(0).ChildNodes(0).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vICMS = InnerNode2.ChildNodes(0).ChildNodes(1).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vBCST = InnerNode2.ChildNodes(0).ChildNodes(2).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vST = InnerNode2.ChildNodes(0).ChildNodes(3).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vProd = InnerNode2.ChildNodes(0).ChildNodes(4).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vFrete = InnerNode2.ChildNodes(0).ChildNodes(5).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vSeg = InnerNode2.ChildNodes(0).ChildNodes(6).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vDesc = InnerNode2.ChildNodes(0).ChildNodes(7).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vII = InnerNode2.ChildNodes(0).ChildNodes(8).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vIPI = InnerNode2.ChildNodes(0).ChildNodes(9).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vPIS = InnerNode2.ChildNodes(0).ChildNodes(10).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vCOFINS = InnerNode2.ChildNodes(0).ChildNodes(11).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vOutro = InnerNode2.ChildNodes(0).ChildNodes(12).InnerText.Replace(".", ",")
                        NotaLida.infNFE.Total.IcmsTot.vNF = InnerNode2.ChildNodes(0).ChildNodes(13).InnerText.Replace(".", ",")

                    ElseIf (InnerNode2.Name = "transp") Then

                        NotaLida.infNFE.Transp = New transp()
                        NotaLida.infNFE.Transp.modFrete = InnerNode2.ChildNodes(0).InnerText

                        If Not InnerNode2.ChildNodes(1) Is Nothing Then
                            NotaLida.infNFE.Transp.Transporta = New transporta
                            NotaLida.infNFE.Transp.Vol = New vol
                            For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                                If (InnerNode3.Name = "transporta") Then
                                    NotaLida.infNFE.Transp.Transporta.CNPJ = InnerNode3.ChildNodes(0).InnerText
                                    NotaLida.infNFE.Transp.Transporta.xNome = InnerNode3.ChildNodes(1).InnerText
                                    NotaLida.infNFE.Transp.Transporta.UF = InnerNode3.ChildNodes(4).InnerText
                                    NotaLida.infNFE.Transp.Transporta.xEnder = InnerNode3.ChildNodes(2).InnerText
                                    Try
                                        NotaLida.infNFE.Transp.Transporta.xMun = InnerNode3.ChildNodes(3).InnerText
                                        NotaLida.infNFE.Transp.Transporta.IE = InnerNode3.ChildNodes(5).InnerText
                                    Catch
                                    End Try
                                End If
                                If (InnerNode3.Name = "vol") Then
                                    NotaLida.infNFE.Transp.Vol.qVol = InnerNode3.ChildNodes(0).InnerText
                                    NotaLida.infNFE.Transp.Vol.esp = InnerNode3.ChildNodes(1).InnerText
                                    NotaLida.infNFE.Transp.Vol.pesoL = InnerNode3.ChildNodes(2).InnerText
                                    NotaLida.infNFE.Transp.Vol.pesoB = InnerNode3.ChildNodes(3).InnerText
                                End If
                            Next
                        End If

                    ElseIf (InnerNode2.Name = "cobr") Then

                        Dim cobranca As New cobr()
                        For Each InnerNode3 As XmlNode In InnerNode2.ChildNodes
                            If (InnerNode3.Name = "dup") Then
                                Dim DUPLICATA As New dup

                                DUPLICATA.nDup = InnerNode3.ChildNodes(0).InnerText
                                DUPLICATA.dVenc = InnerNode3.ChildNodes(1).InnerText
                                DUPLICATA.vDup = InnerNode3.ChildNodes(2).InnerText.Replace(".", ",")

                                cobranca.Dup.Add(DUPLICATA)
                            End If
                        Next
                        NotaLida.infNFE.Cobr = cobranca
                    ElseIf (InnerNode2.Name = "infAdic") Then
                        Dim InfAd As New infAdic
                        If Not InnerNode2.ChildNodes(0) Is Nothing Then
                            InfAd.infCpl = InnerNode2.ChildNodes(0).InnerText
                            NotaLida.infNFE.InfAdic = InfAd
                        Else
                            InfAd.infCpl = ""
                            NotaLida.infNFE.InfAdic = InfAd
                        End If
                    End If
                Next
            End If
        Next

        Dim VNotaE As New NotaEletronica

        VNotaE.NotaEletronica = NotaLida
        VNotaE.ProtocoloAutorizacao = ""

        Return VNotaE

    End Function
End Class
