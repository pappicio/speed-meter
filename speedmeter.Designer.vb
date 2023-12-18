<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class speedmeter
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SpostamiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelezioneNetworkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SeelzionaFontTestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelezionaCororeTestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelezioneColoreDownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelezionaColoreUploadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelezionaBandWidthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GbToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MbToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KbToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpeedTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CambiaLinkSpeedTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.VisualizzaIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ColoriAutomaticiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Label1.Location = New System.Drawing.Point(32, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpostamiToolStripMenuItem, Me.ToolStripSeparator2, Me.SelezioneNetworkToolStripMenuItem, Me.ToolStripSeparator1, Me.SeelzionaFontTestoToolStripMenuItem, Me.SelezionaCororeTestoToolStripMenuItem, Me.ToolStripSeparator5, Me.SelezioneColoreDownloadToolStripMenuItem, Me.SelezionaColoreUploadToolStripMenuItem1, Me.ToolStripSeparator3, Me.SelezionaBandWidthToolStripMenuItem, Me.ToolStripSeparator9, Me.SpeedTestToolStripMenuItem, Me.ToolStripSeparator4, Me.VisualizzaIToolStripMenuItem, Me.ToolStripSeparator7, Me.ColoriAutomaticiToolStripMenuItem, Me.ToolStripSeparator6, Me.AboutToolStripMenuItem, Me.ToolStripSeparator8})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(264, 322)
        '
        'SpostamiToolStripMenuItem
        '
        Me.SpostamiToolStripMenuItem.Name = "SpostamiToolStripMenuItem"
        Me.SpostamiToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.SpostamiToolStripMenuItem.Text = "Spostami"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(260, 6)
        '
        'SelezioneNetworkToolStripMenuItem
        '
        Me.SelezioneNetworkToolStripMenuItem.Name = "SelezioneNetworkToolStripMenuItem"
        Me.SelezioneNetworkToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.SelezioneNetworkToolStripMenuItem.Text = "Seleziona Network"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(260, 6)
        '
        'SeelzionaFontTestoToolStripMenuItem
        '
        Me.SeelzionaFontTestoToolStripMenuItem.Name = "SeelzionaFontTestoToolStripMenuItem"
        Me.SeelzionaFontTestoToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.SeelzionaFontTestoToolStripMenuItem.Text = "seleziona font testo"
        '
        'SelezionaCororeTestoToolStripMenuItem
        '
        Me.SelezionaCororeTestoToolStripMenuItem.Name = "SelezionaCororeTestoToolStripMenuItem"
        Me.SelezionaCororeTestoToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.SelezionaCororeTestoToolStripMenuItem.Text = "seleziona colore testo"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(260, 6)
        '
        'SelezioneColoreDownloadToolStripMenuItem
        '
        Me.SelezioneColoreDownloadToolStripMenuItem.Name = "SelezioneColoreDownloadToolStripMenuItem"
        Me.SelezioneColoreDownloadToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.SelezioneColoreDownloadToolStripMenuItem.Text = "Selezione Colore Download"
        '
        'SelezionaColoreUploadToolStripMenuItem1
        '
        Me.SelezionaColoreUploadToolStripMenuItem1.Name = "SelezionaColoreUploadToolStripMenuItem1"
        Me.SelezionaColoreUploadToolStripMenuItem1.Size = New System.Drawing.Size(263, 24)
        Me.SelezionaColoreUploadToolStripMenuItem1.Text = "Seleziona Colore Upload"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(260, 6)
        '
        'SelezionaBandWidthToolStripMenuItem
        '
        Me.SelezionaBandWidthToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GBToolStripMenuItem, Me.GbToolStripMenuItem1, Me.MBToolStripMenuItem, Me.MbToolStripMenuItem1, Me.KBToolStripMenuItem, Me.KbToolStripMenuItem1})
        Me.SelezionaBandWidthToolStripMenuItem.Name = "SelezionaBandWidthToolStripMenuItem"
        Me.SelezionaBandWidthToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.SelezionaBandWidthToolStripMenuItem.Text = "Seleziona BandWidth"
        '
        'GBToolStripMenuItem
        '
        Me.GBToolStripMenuItem.Name = "GBToolStripMenuItem"
        Me.GBToolStripMenuItem.Size = New System.Drawing.Size(114, 26)
        Me.GBToolStripMenuItem.Text = "GB"
        '
        'GbToolStripMenuItem1
        '
        Me.GbToolStripMenuItem1.Name = "GbToolStripMenuItem1"
        Me.GbToolStripMenuItem1.Size = New System.Drawing.Size(114, 26)
        Me.GbToolStripMenuItem1.Text = "Gb"
        '
        'MBToolStripMenuItem
        '
        Me.MBToolStripMenuItem.Name = "MBToolStripMenuItem"
        Me.MBToolStripMenuItem.Size = New System.Drawing.Size(114, 26)
        Me.MBToolStripMenuItem.Text = "MB"
        '
        'MbToolStripMenuItem1
        '
        Me.MbToolStripMenuItem1.Checked = True
        Me.MbToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MbToolStripMenuItem1.Name = "MbToolStripMenuItem1"
        Me.MbToolStripMenuItem1.Size = New System.Drawing.Size(114, 26)
        Me.MbToolStripMenuItem1.Text = "Mb"
        '
        'KBToolStripMenuItem
        '
        Me.KBToolStripMenuItem.Name = "KBToolStripMenuItem"
        Me.KBToolStripMenuItem.Size = New System.Drawing.Size(114, 26)
        Me.KBToolStripMenuItem.Text = "KB"
        '
        'KbToolStripMenuItem1
        '
        Me.KbToolStripMenuItem1.Name = "KbToolStripMenuItem1"
        Me.KbToolStripMenuItem1.Size = New System.Drawing.Size(114, 26)
        Me.KbToolStripMenuItem1.Text = "Kb"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(260, 6)
        '
        'SpeedTestToolStripMenuItem
        '
        Me.SpeedTestToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CambiaLinkSpeedTestToolStripMenuItem})
        Me.SpeedTestToolStripMenuItem.Name = "SpeedTestToolStripMenuItem"
        Me.SpeedTestToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.SpeedTestToolStripMenuItem.Text = "SpeedTest"
        '
        'CambiaLinkSpeedTestToolStripMenuItem
        '
        Me.CambiaLinkSpeedTestToolStripMenuItem.Name = "CambiaLinkSpeedTestToolStripMenuItem"
        Me.CambiaLinkSpeedTestToolStripMenuItem.Size = New System.Drawing.Size(246, 26)
        Me.CambiaLinkSpeedTestToolStripMenuItem.Text = "Cambia link Speed Test"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(260, 6)
        '
        'VisualizzaIToolStripMenuItem
        '
        Me.VisualizzaIToolStripMenuItem.Name = "VisualizzaIToolStripMenuItem"
        Me.VisualizzaIToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.VisualizzaIToolStripMenuItem.Text = "Blocca posizione a DX"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(260, 6)
        '
        'ColoriAutomaticiToolStripMenuItem
        '
        Me.ColoriAutomaticiToolStripMenuItem.Name = "ColoriAutomaticiToolStripMenuItem"
        Me.ColoriAutomaticiToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.ColoriAutomaticiToolStripMenuItem.Text = "Colori Automatici"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(260, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.AboutToolStripMenuItem.Text = "About me..."
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(260, 6)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Label2.Location = New System.Drawing.Point(30, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label2"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox3.Image = Global.speed_meter.My.Resources.Resources.su
        Me.PictureBox3.Location = New System.Drawing.Point(0, 28)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(25, 33)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 7
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox2.Image = Global.speed_meter.My.Resources.Resources.giu
        Me.PictureBox2.Location = New System.Drawing.Point(2, -2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(25, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Image = Global.speed_meter.My.Resources.Resources.download
        Me.PictureBox1.Location = New System.Drawing.Point(104, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'speedmeter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(148, 55)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "speedmeter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Speed-meter"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Silver
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SeelzionaFontTestoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelezionaCororeTestoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents SelezioneNetworkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents SpostamiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents SelezioneColoreDownloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelezionaColoreUploadToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents SelezionaBandWidthToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GBToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GbToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MBToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MbToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents KBToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents KbToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents VisualizzaIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ColoriAutomaticiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents SpeedTestToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CambiaLinkSpeedTestToolStripMenuItem As ToolStripMenuItem
End Class
