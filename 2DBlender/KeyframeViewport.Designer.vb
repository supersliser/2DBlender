<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeyframeViewport
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TrackBar = New System.Windows.Forms.TrackBar()
        Me.OutputBox = New System.Windows.Forms.PictureBox()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OutputBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrackBar
        '
        Me.TrackBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TrackBar.Location = New System.Drawing.Point(0, 121)
        Me.TrackBar.Minimum = 1
        Me.TrackBar.Name = "TrackBar"
        Me.TrackBar.Size = New System.Drawing.Size(575, 45)
        Me.TrackBar.TabIndex = 0
        Me.TrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.TrackBar.Value = 1
        '
        'OutputBox
        '
        Me.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputBox.Location = New System.Drawing.Point(0, 0)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.Padding = New System.Windows.Forms.Padding(13, 0, 13, 0)
        Me.OutputBox.Size = New System.Drawing.Size(575, 121)
        Me.OutputBox.TabIndex = 1
        Me.OutputBox.TabStop = False
        '
        'KeyframeViewport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OutputBox)
        Me.Controls.Add(Me.TrackBar)
        Me.Name = "KeyframeViewport"
        Me.Size = New System.Drawing.Size(575, 166)
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OutputBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TrackBar As TrackBar
    Friend WithEvents OutputBox As PictureBox
End Class
