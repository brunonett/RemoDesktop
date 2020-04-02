Imports System.Net.Sockets
Imports System.Threading
Imports System.Drawing
Imports System.Runtime.Serialization.Formatters.Binary

Public Class Form2

    Dim client As New TcpClient
    Dim port As Integer
    Dim server As TcpListener
    Dim ns As NetworkStream
    Dim listening As New Thread(AddressOf Listen)
    Dim GetImage As New Thread(AddressOf ReceiveImagem)

    Private Sub ReceiveImagem()

        Dim bf As New BinaryFormatter

        While client.Connected = True
            ns = client.GetStream
            PictureBox1.Image = bf.Deserialize(ns)
        End While

    End Sub

    Private Sub Listen()

        While client.Connected = False
            server.Start()
            client = server.AcceptTcpClient
        End While
        GetImage.Start()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        port = Integer.Parse(Form1.TextBox1.Text)
        server = New TcpListener(port)
        listening.Start()

    End Sub
End Class