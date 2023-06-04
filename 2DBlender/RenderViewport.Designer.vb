<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenderViewport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RenderViewport))
        Me.RenderBox = New System.Windows.Forms.PictureBox()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.File = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.BMPFileButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.PNGFileButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.JPEGFileButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.GIFFileButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.RenderProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Pause = New System.Windows.Forms.ToolStripButton()
        Me.Play = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RenderWorker = New System.ComponentModel.BackgroundWorker()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Log = New System.Windows.Forms.ListBox()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        CType(Me.RenderBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RenderBox
        '
        Me.RenderBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RenderBox.Location = New System.Drawing.Point(0, 0)
        Me.RenderBox.Name = "RenderBox"
        Me.RenderBox.Size = New System.Drawing.Size(619, 425)
        Me.RenderBox.TabIndex = 0
        Me.RenderBox.TabStop = False
        '
        'ToolStrip
        '
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.File, Me.ToolStripLabel1, Me.RenderProgress, Me.ToolStripSeparator1, Me.Pause, Me.Play, Me.ToolStripSeparator2, Me.ToolStripSeparator3})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(800, 25)
        Me.ToolStrip.TabIndex = 1
        Me.ToolStrip.Text = "ToolStrip1"
        '
        'File
        '
        Me.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveAs})
        Me.File.Image = CType(resources.GetObject("File.Image"), System.Drawing.Image)
        Me.File.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.File.Name = "File"
        Me.File.Size = New System.Drawing.Size(38, 22)
        Me.File.Text = "File"
        '
        'SaveAs
        '
        Me.SaveAs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BMPFileButton, Me.PNGFileButton, Me.JPEGFileButton, Me.GIFFileButton})
        Me.SaveAs.Name = "SaveAs"
        Me.SaveAs.Size = New System.Drawing.Size(180, 22)
        Me.SaveAs.Text = "Save As"
        '
        'BMPFileButton
        '
        Me.BMPFileButton.Name = "BMPFileButton"
        Me.BMPFileButton.Size = New System.Drawing.Size(288, 22)
        Me.BMPFileButton.Text = "Bitmap (.bmp)"
        '
        'PNGFileButton
        '
        Me.PNGFileButton.Name = "PNGFileButton"
        Me.PNGFileButton.Size = New System.Drawing.Size(288, 22)
        Me.PNGFileButton.Text = "Portable Network Graphics (.png)"
        '
        'JPEGFileButton
        '
        Me.JPEGFileButton.Name = "JPEGFileButton"
        Me.JPEGFileButton.Size = New System.Drawing.Size(288, 22)
        Me.JPEGFileButton.Text = "Joint Photographic Experts Group (.jpeg)"
        '
        'GIFFileButton
        '
        Me.GIFFileButton.Name = "GIFFileButton"
        Me.GIFFileButton.Size = New System.Drawing.Size(288, 22)
        Me.GIFFileButton.Text = "Graphics Interchange Format (.gif)"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripLabel1.Text = "Render Progress"
        '
        'RenderProgress
        '
        Me.RenderProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.RenderProgress.ForeColor = System.Drawing.Color.Lime
        Me.RenderProgress.Name = "RenderProgress"
        Me.RenderProgress.Size = New System.Drawing.Size(400, 22)
        Me.RenderProgress.Step = 1
        Me.RenderProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'Pause
        '
        Me.Pause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Pause.Image = CType(resources.GetObject("Pause.Image"), System.Drawing.Image)
        Me.Pause.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Pause.Name = "Pause"
        Me.Pause.Size = New System.Drawing.Size(23, 22)
        Me.Pause.Text = "ToolStripButton1"
        '
        'Play
        '
        Me.Play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Play.Image = CType(resources.GetObject("Play.Image"), System.Drawing.Image)
        Me.Play.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Play.Name = "Play"
        Me.Play.Size = New System.Drawing.Size(23, 22)
        Me.Play.Text = "ToolStripButton2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'RenderWorker
        '
        Me.RenderWorker.WorkerReportsProgress = True
        Me.RenderWorker.WorkerSupportsCancellation = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RenderBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Log)
        Me.SplitContainer1.Size = New System.Drawing.Size(800, 425)
        Me.SplitContainer1.SplitterDistance = 619
        Me.SplitContainer1.TabIndex = 3
        '
        'Log
        '
        Me.Log.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Log.FormattingEnabled = True
        Me.Log.Location = New System.Drawing.Point(0, 0)
        Me.Log.Name = "Log"
        Me.Log.Size = New System.Drawing.Size(177, 425)
        Me.Log.TabIndex = 0
        '
        'RenderViewport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RenderViewport"
        Me.Text = "Render Output"
        CType(Me.RenderBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RenderBox As PictureBox
    Private WithEvents ToolStrip As ToolStrip
    Friend WithEvents File As ToolStripDropDownButton
    Private WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents RenderProgress As ToolStripProgressBar
    Friend WithEvents Pause As ToolStripButton
    Friend WithEvents Play As ToolStripButton
    Friend WithEvents RenderWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SaveAs As ToolStripMenuItem
    Friend WithEvents BMPFileButton As ToolStripMenuItem
    Friend WithEvents PNGFileButton As ToolStripMenuItem
    Friend WithEvents JPEGFileButton As ToolStripMenuItem
    Friend WithEvents GIFFileButton As ToolStripMenuItem
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents Log As ListBox
End Class
