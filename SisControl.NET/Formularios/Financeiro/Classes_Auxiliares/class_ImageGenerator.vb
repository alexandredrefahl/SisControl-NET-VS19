Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO
Imports System.Reflection

Namespace BoletoNET.Arquivo

    Public Class WebsiteThumbnailImageGenerator

        Public Shared Function GerarImagem(ByRef WebBrowser As Object, Arquivo As String) As String

            Dim address As String = WebBrowser.Url.ToString()
            Dim width As Integer = 670
            Dim height As Integer = 1020

            Dim webBrowserWidth As Integer = 670
            Dim webBrowserHeight As Integer = 1020

            Dim bmp As Bitmap = WebsiteThumbnailImageGenerator.GetWebSiteThumbnail(address, webBrowserWidth, webBrowserHeight, width, height)
            Dim file As String = Path.Combine(Environment.CurrentDirectory, Arquivo)
            bmp.Save(file)
            Return file
        End Function

        Public Shared Function GetWebSiteThumbnail(Url As String, BrowserWidth As Integer, BrowserHeight As Integer, ThumbnailWidth As Integer, ThumbnailHeight As Integer) As Bitmap
            Dim thumbnailGenerator As WebsiteThumbnailImage = New WebsiteThumbnailImage(Url, BrowserWidth, BrowserHeight, ThumbnailWidth, ThumbnailHeight)
            Return thumbnailGenerator.GenerateWebSiteThumbnailImage()
        End Function

        Public Class WebsiteThumbnailImage
            Public Sub New(Url As String, BrowserWidth As Integer, BrowserHeight As Integer, ThumbnailWidth As Integer, ThumbnailHeight As Integer)
                m_Url = Url
                m_BrowserWidth = BrowserWidth
                m_BrowserHeight = BrowserHeight
                m_ThumbnailHeight = ThumbnailHeight
                m_ThumbnailWidth = ThumbnailWidth
            End Sub

            Private m_Url As String = ""
            Public Property Url As String
                Get
                    Return m_Url
                End Get
                Set(value As String)
                    m_Url = value
                End Set
            End Property

            Private m_Bitmap As Bitmap
            Public ReadOnly Property ThumbnailImage As Bitmap
                Get
                    Return m_Bitmap
                End Get
            End Property

            Private m_ThumbnailWidth As Integer
            Public Property ThumbnailWidth As Integer
                Get
                    Return m_ThumbnailWidth
                End Get
                Set(value As Integer)
                    m_ThumbnailWidth = value
                End Set
            End Property

            Private m_ThumbnailHeight As Integer
            Public Property ThumbnailHeight As Integer
                Get
                    Return m_ThumbnailHeight
                End Get
                Set(value As Integer)
                    m_ThumbnailHeight = value
                End Set
            End Property

            Private m_BrowserWidth As Integer
            Public Property BrowserWidth As Integer
                Get
                    Return m_BrowserWidth
                End Get
                Set(value As Integer)
                    m_BrowserWidth = value
                End Set
            End Property

            Private m_BrowserHeight As Integer
            Public Property BrowserHeight As Integer
                Get
                    Return m_BrowserHeight
                End Get
                Set(value As Integer)
                    m_BrowserHeight = value
                End Set
            End Property

            Public Function GenerateWebSiteThumbnailImage() As Bitmap
                Dim m_thread As Thread = New Thread(New ThreadStart(AddressOf _GenerateWebSiteThumbnailImage))
                m_thread.SetApartmentState(ApartmentState.STA)
                m_thread.Start()
                m_thread.Join()
                Return m_Bitmap
            End Function

            Private Sub _GenerateWebSiteThumbnailImage()
                Dim m_WebBrowser As WebBrowser = New WebBrowser()
                m_WebBrowser.ScrollBarsEnabled = False
                m_WebBrowser.Navigate(m_Url)
                AddHandler m_WebBrowser.DocumentCompleted, New WebBrowserDocumentCompletedEventHandler(AddressOf WebBrowser_DocumentCompleted)
                While (m_WebBrowser.ReadyState <> WebBrowserReadyState.Complete)
                    Application.DoEvents()
                End While
                m_WebBrowser.Dispose()
            End Sub

            Private Sub WebBrowser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
                Dim m_WebBrowser As WebBrowser = sender
                Dim myCallback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
                m_WebBrowser.ClientSize = New Size(m_BrowserWidth, m_BrowserHeight)
                m_WebBrowser.ScrollBarsEnabled = False
                m_Bitmap = New Bitmap(m_WebBrowser.Bounds.Width, m_WebBrowser.Bounds.Height)
                m_WebBrowser.BringToFront()
                m_WebBrowser.DrawToBitmap(m_Bitmap, m_WebBrowser.Bounds)
                m_Bitmap = m_Bitmap.GetThumbnailImage(m_ThumbnailWidth, m_ThumbnailHeight, myCallback, IntPtr.Zero)
            End Sub

            Private Function ThumbnailCallback() As Boolean
                Return False
            End Function

        End Class
    End Class
End Namespace