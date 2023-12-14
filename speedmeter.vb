Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Runtime
Imports System.Security.Principal
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class speedmeter


    Public Function FindDockedTaskBars(Optional DockedRectCounter As Integer = 0) As Rectangle()
        '  Dim TmpScrn As Screen = Nothing
        Dim LeftDockedWidth As Integer = 0
        Dim TopDockedHeight As Integer = 0
        Dim RightDockedWidth As Integer = 0
        Dim BottomDockedHeight As Integer = 0
        Dim DockedRects(Screen.AllScreens.Count * 4) As Rectangle

        DockedRectCounter = 0

        Dim TmpScrn As Screen = Screen.FromControl(Me)
        If Not TmpScrn.Bounds.Equals(TmpScrn.WorkingArea) Then
            LeftDockedWidth = Math.Abs(Math.Abs(TmpScrn.Bounds.Left) - Math.Abs(TmpScrn.WorkingArea.Left))
            TopDockedHeight = Math.Abs(Math.Abs(TmpScrn.Bounds.Top) - Math.Abs(TmpScrn.WorkingArea.Top))
            RightDockedWidth = (TmpScrn.Bounds.Width - LeftDockedWidth) - TmpScrn.WorkingArea.Width
            BottomDockedHeight = (TmpScrn.Bounds.Height - TopDockedHeight) - TmpScrn.WorkingArea.Height

            If LeftDockedWidth > 0 Then
                DockedRects(DockedRectCounter).X = TmpScrn.Bounds.Left
                DockedRects(DockedRectCounter).Y = TmpScrn.Bounds.Top
                DockedRects(DockedRectCounter).Width = LeftDockedWidth
                DockedRects(DockedRectCounter).Height = TmpScrn.Bounds.Height
                DockedRectCounter += 1
            End If
            If RightDockedWidth > 0 Then
                DockedRects(DockedRectCounter).X = TmpScrn.WorkingArea.Right
                DockedRects(DockedRectCounter).Y = TmpScrn.Bounds.Top
                DockedRects(DockedRectCounter).Width = RightDockedWidth
                DockedRects(DockedRectCounter).Height = TmpScrn.Bounds.Height
                DockedRectCounter += 1
            End If
            If TopDockedHeight > 0 Then
                DockedRects(DockedRectCounter).X = TmpScrn.WorkingArea.Left
                DockedRects(DockedRectCounter).Y = TmpScrn.Bounds.Top
                DockedRects(DockedRectCounter).Width = TmpScrn.WorkingArea.Width
                DockedRects(DockedRectCounter).Height = TopDockedHeight
                DockedRectCounter += 1
            End If
            If BottomDockedHeight > 0 Then
                DockedRects(DockedRectCounter).X = TmpScrn.WorkingArea.Left
                DockedRects(DockedRectCounter).Y = TmpScrn.WorkingArea.Bottom
                DockedRects(DockedRectCounter).Width = TmpScrn.WorkingArea.Width
                DockedRects(DockedRectCounter).Height = BottomDockedHeight
                DockedRectCounter += 1
            End If
        End If

        Return DockedRects
    End Function
    Dim TaskBarRect As Rectangle()



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load






        IsAdministrator = New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
        If IsAdministrator Then
            CreateShortCut()
        End If
        TaskBarRect = FindDockedTaskBars()

        Me.Top = TaskBarRect(0).Top + 1
        Me.Left = TaskBarRect(0).Width / 2 - Me.Width / 2

        If My.Settings.posizione <> 0 Then
            Me.Left = My.Settings.posizione
        End If

        If My.Settings.font Is Nothing Then
        Else
            Label1.Font = My.Settings.font
            Label2.Font = My.Settings.font
            Label3.Font = My.Settings.font
            Label4.Font = My.Settings.font
        End If

        If My.Settings.colore = Nothing Then
        Else
            Label1.ForeColor = My.Settings.colore
            Label2.ForeColor = My.Settings.colore
        End If

        If My.Settings.coloredown = Nothing Then
        Else
            Label3.ForeColor = My.Settings.coloredown
        End If

        If My.Settings.coloreup = Nothing Then
        Else
            Label4.ForeColor = My.Settings.coloreup
        End If

        AddHandler NetworkChange.NetworkAvailabilityChanged, AddressOf OnNetWorkChanged_Event
        AddHandler NetworkChange.NetworkAddressChanged, AddressOf OnNetworkAddrChanged_Event
        Invoke(New MethodInvoker(Sub()

                                     loadnic()

                                 End Sub))
        posiziona()
        Timer2_Tick(Nothing, Nothing)
    End Sub

    Private Sub OnNetworkAddrChanged_Event(ByVal sender As Object, ByVal e As EventArgs)

        Invoke(New MethodInvoker(Sub()

                                     loadnic()

                                 End Sub))
    End Sub

    Private Sub OnNetWorkChanged_Event(ByVal sender As Object, ByVal e As NetworkInformation.NetworkAvailabilityEventArgs) ' Handles Me.NetChangedHandler
        Invoke(New MethodInvoker(Sub()

                                     loadnic()

                                 End Sub))
    End Sub

    Sub posiziona()

        Me.Height = TaskBarRect(0).Height - 1
        Dim mezzo As Integer = Me.Height / 2
        Label1.Left = Label3.Width + 5
        Label2.Left = Label4.Width + 5
        Me.Label1.Top = mezzo - Label1.Height - 1 '+1
        Me.Label2.Top = mezzo + 1 '- 1
        Label3.Top = Label1.Top
        Label4.Top = Label2.Top


    End Sub

    Dim IsAdministrator As Boolean = False
    Function CreateShortCut() As Boolean

        Dim TargetName As String = Application.ProductName
        Dim ShortCutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup)
        Dim myshortcutpath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim oShell As Object
        Dim oLink As Object

        If IsAdministrator Then
            Try
                oShell = CreateObject("WScript.Shell")
                oLink = oShell.CreateShortcut(ShortCutPath & "\" & TargetName & ".lnk")

                oLink.TargetPath = Application.ExecutablePath
                ''' oLink.WindowStyle = 1
                oLink.Save()

                MsgBox("Eseguito con diritti AMMINISTRATORE, Link ad esecuzione autmatica allusers creata!" & vbCr & " ora mi chiudo, rieseguimi con diritti utente!")

                End
            Catch ex As Exception
                MsgBox("ERRORE nell' esecuzione con diritti AMMINISTRATORE, ora mi chiudo, Riprovare!!!")
                End
                Return False
            End Try
        End If
        Return True


    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ritorna Then
            Return
        End If

        TaskBarRect = FindDockedTaskBars()

        Me.Top = TaskBarRect(0).Top + 1
        If Me.Left < TaskBarRect(0).Left Then
            Me.Left = TaskBarRect(0).Left
        End If

        If Me.Left > TaskBarRect(0).Width Then
            Me.Left = TaskBarRect(0).Width - Me.Width
        End If
        Me.TopMost = True
        Me.Visible = True
        Application.DoEvents()
    End Sub
    Dim ritorna As Boolean = False
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If ritorna Then
            Return
        End If


        '''autonic()

        BandSec()
    End Sub

    Private isMouseDown As Boolean = False
    Private mouseOffset As Point

    ' Left mouse button pressed
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            ' Get the new position
            mouseOffset = New Point(-e.X, -e.Y)
            ' Set that left button is pressed
            isMouseDown = True
        End If
    End Sub

    ' MouseMove used to check if mouse cursor is moving
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            ' Get the new form position
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Me.Left = mousePos.X
        End If
    End Sub

    ' Left mouse button released, form should stop moving
    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then
            isMouseDown = False
            My.Settings.posizione = Me.Left
            My.Settings.Save()
        End If
    End Sub


    Public net As NetworkInterface

    Public Function BytesConverter(ByVal bytes As Long) As String
        Dim KB As Long = 1024
        Dim MB As Long = KB * KB
        Dim GB As Long = KB * KB * KB
        Dim TB As Long = KB * KB * KB * KB
        Dim ret As String = "0 Mb"
        ret = (bytes / 1024 / 1024 * 8).ToString("000.00") & " Mb"


        Return ret.ToString
    End Function

    Dim LastUpload As Long
    Dim LastDownload As Long

    Public Function CheckNet() As Boolean
        Dim num As Integer
        Return InternetGetConnectedState(num, 0)
    End Function
    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Int32,
ByVal dwReserved As Int32) As Boolean



    Public Function GetLocalIPAddress() As String
        Dim addressList As IPAddress() = Dns.GetHostEntry(Dns.GetHostName()).AddressList
        Dim num As Integer = 0
        Do
            Dim pAddress As IPAddress = addressList(num)
            If (pAddress.AddressFamily = AddressFamily.InterNetwork) Then

                Return pAddress.ToString()

            End If
            num = num + 1
        Loop While num < CInt(addressList.Length)
        Return ""
        Throw New Exception("no ip4 found")

    End Function

    Dim LocalIPAddress As String

    Private Sub mnuItem_Clicked(sender As Object, e As EventArgs)

        ContextMenuStrip1.Hide() 'Sometimes the menu items can remain open.  May not be necessary for you.
        Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        If item IsNot Nothing Then
            net = item.Tag


            Try
                For Each i As ToolStripMenuItem In SelezioneNetworkToolStripMenuItem.DropDownItems
                    If My.Settings.nic <> "" And My.Settings.nic.ToString.ToLower.Trim = i.Text.ToString.ToLower.Trim Then
                        i.Checked = False
                    End If
                Next
            Catch ex As Exception

            End Try

            item.Checked = True
            My.Settings.nic = net.Description
            My.Settings.Save()
        End If
    End Sub

    Dim menu2 As New ToolStripMenuItem


    Private Sub loadnic()
        Try
            SelezioneNetworkToolStripMenuItem.DropDownItems.Clear()
            RemoveHandler menu2.Click, AddressOf mnuItem_Clicked

        Catch ex As Exception

        End Try
        Try
            Dim Adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim ce As Boolean = False
            Dim conta As Integer = 0
            For Each network As NetworkInterface In Adapters
                If network.OperationalStatus = 1 Then

                    If GetLocalIPAddress() <> "" And (network.NetworkInterfaceType = 6 Or network.NetworkInterfaceType = 71) Then
                        Dim ip = network.GetIPProperties().UnicastAddresses(1).Address.ToString

                        conta = conta + 1
                        menu2 = New ToolStripMenuItem With {.Text = network.Description, .Name = CStr(conta), .Tag = network}
                        'We have a reference to menu1 already, but here's how you can find the menu item by name...
                        Try
                            For Each item As ToolStripMenuItem In ContextMenuStrip1.Items
                                If item.Name = "SelezioneNetworkToolStripMenuItem" Then
                                    If item.DropDownItems.Contains(menu2) = False Then
                                        item.DropDownItems.Add(menu2)
                                        AddHandler menu2.Click, AddressOf mnuItem_Clicked
                                    End If

                                    If ce = False Then
                                        net = network
                                        ce = True
                                        menu2.Checked = True
                                    End If
                                End If
                            Next
                        Catch ex As Exception

                        End Try

                    End If

                End If
            Next

            Dim esiste As Boolean = False

            Try
                For Each item As ToolStripMenuItem In SelezioneNetworkToolStripMenuItem.DropDownItems
                    If My.Settings.nic <> "" And My.Settings.nic.ToString.ToLower.Trim = item.Text.ToString.ToLower.Trim Then
                        esiste = True
                        Exit For
                    Else
                        My.Settings.nic = ""
                    End If
                Next
            Catch ex As Exception

            End Try
            If esiste Then
                Try
                    For Each item As ToolStripMenuItem In SelezioneNetworkToolStripMenuItem.DropDownItems
                        item.Checked = False
                        If My.Settings.nic <> "" And My.Settings.nic.ToString.ToLower.Trim = item.Text.ToString.ToLower.Trim Then
                            item.Checked = True
                        End If
                    Next
                Catch ex As Exception

                End Try
            End If




        Catch exception As System.Exception
            Throw
        End Try
    End Sub
    Private Sub BandSec()
        If net Is Nothing Then
            Exit Sub
        End If
        Try

            Dim NicStats As IPv4InterfaceStatistics = net.GetIPv4Statistics

            Dim Up = NicStats.BytesSent - LastUpload
            Dim Down = NicStats.BytesReceived - LastDownload

            LastUpload = NicStats.BytesSent
            LastDownload = NicStats.BytesReceived
            Try
                Label1.Text = ":" & BytesConverter(If(Down < 0, 0, Down)) & "/s"
                Label2.Text = ":" & BytesConverter(If(Up < 0, 0, Up)) & "/s"
                Label1.Text = Label1.Text.Replace(",", ".")
                Label2.Text = Label2.Text.Replace(",", ".")

                If Label1.Width > Label2.Width Then
                    Me.Width = Label1.Width + Label3.Width + 5
                Else
                    Me.Width = Label2.Width + Label4.Width + 5
                End If


            Catch ex As Exception

            End Try



        Catch ex As Exception

        End Try

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            ' Get the new position
            mouseOffset = New Point(-e.X, -e.Y)
            ' Set that left button is pressed
            isMouseDown = True
        Else
            ContextMenuStrip1.Show()
        End If
    End Sub

    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown
        If e.Button = MouseButtons.Left Then
            ' Get the new position
            mouseOffset = New Point(-e.X, -e.Y)
            ' Set that left button is pressed
            isMouseDown = True
        Else
            ContextMenuStrip1.Show()
        End If
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        If e.Button = MouseButtons.Left Then
            isMouseDown = False
            My.Settings.posizione = Me.Left
            My.Settings.Save()
        End If
    End Sub
    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        If e.Button = MouseButtons.Left Then
            isMouseDown = False
            My.Settings.posizione = Me.Left
            My.Settings.Save()
        End If
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            ' Get the new form position
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Me.Left = mousePos.X
        End If
    End Sub
    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            ' Get the new form position
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Me.Left = mousePos.X
        End If
    End Sub

    Private Sub SelezionaCororeTestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelezionaCororeTestoToolStripMenuItem.Click
        Me.ColorDialog1.Color = Label1.ForeColor
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            Label1.ForeColor = ColorDialog1.Color
            Label2.ForeColor = ColorDialog1.Color
            My.Settings.colore = ColorDialog1.Color
            My.Settings.Save()

        End If
        ritorna = False
    End Sub

    Private Sub SeelzionaFontTestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeelzionaFontTestoToolStripMenuItem.Click
        Me.FontDialog1.Font = Label1.Font
        ritorna = True
        If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label1.Font = FontDialog1.Font
            Label2.Font = FontDialog1.Font
            Label3.Font = FontDialog1.Font
            Label4.Font = FontDialog1.Font
            My.Settings.font = FontDialog1.Font
            My.Settings.Save()
            posiziona()
        End If
        ritorna = False
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SelezionaColoreUploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelezionaColoreUploadToolStripMenuItem.Click
        Me.ColorDialog1.Color = Label4.ForeColor
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label4.ForeColor = ColorDialog1.Color
            My.Settings.coloreup = ColorDialog1.Color
            My.Settings.Save()
        End If
        ritorna = False
    End Sub

    Private Sub SelezionaColoreDownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelezionaColoreDownloadToolStripMenuItem.Click
        Me.ColorDialog1.Color = Label3.ForeColor
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label3.ForeColor = ColorDialog1.Color
            My.Settings.coloredown = ColorDialog1.Color
            My.Settings.Save()
        End If
        ritorna = False
    End Sub


End Class


