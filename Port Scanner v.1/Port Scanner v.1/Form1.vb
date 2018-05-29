Public Class Form1
    'First declare or variables
    Dim host As String
    Dim port As Integer
    Dim counter As Integer

    'Create timer
    Private Sub Timer1_Tick(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles Timer1.Tick
        'Set the host and port and counter
        counter = counter + 1 'counter is for the timer
        TextBox2.Text = counter
        host = TextBox1.Text
        port = TextBox2.Text
        ' Next part creates a socket to try and connect 
        ' on with the given user information.

        Dim hostadd As System.Net.IPAddress =
      System.Net.Dns.GetHostEntry(host).AddressList(0)
        Dim EPhost As New System.Net.IPEndPoint(hostadd, port)
        Dim s As New System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp)
        Try
            s.Connect(EPhost)
        Catch
        End Try
        If Not s.Connected Then
            ListBox1.Items.Add("Port " + port.ToString + " is not open")
        Else
            ListBox1.Items.Add("Port " + port.ToString + " is open")
            ListBox2.Items.Add(port.ToString)
        End If
        Label3.Text = "Open Ports: " + ListBox2.Items.Count.ToString
    End Sub

    'Start Button
    'The block of code below just starts the timer and the disabling/enabling buttons. Listbox1 adds text stating the host we are scanning
    Private Sub Button1_Click(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles Button1.Click
        ListBox1.Items.Add("Scanning: " + TextBox1.Text)
        ListBox1.Items.Add("-------------------")
        Button2.Enabled = True
        Button1.Enabled = False
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    'Form Load and Stop Button
    'code for enabling/disabling controls
    Private Sub Form1_Load(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        TextBox2.Text = "0"
        'set counter explained before to 0
        counter = 0
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object,
  ByVal e As System.EventArgs) Handles Button2.Click
        'stop button
        Timer1.Stop()
        Timer1.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = False
    End Sub

End Class
