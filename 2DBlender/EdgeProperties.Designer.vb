<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EdgeProperties
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Colour = New System.Windows.Forms.Panel()
        Me.Keyframe = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NameValue = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AddInterpolation = New System.Windows.Forms.Button()
        Me.InterpolationType = New System.Windows.Forms.ComboBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.8!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.4!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.8!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Colour, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Keyframe, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NameValue, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.AddInterpolation, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.InterpolationType, 2, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(250, 250)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 83)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Colour"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Colour
        '
        Me.Colour.BackColor = System.Drawing.Color.Black
        Me.Colour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Colour.Location = New System.Drawing.Point(155, 86)
        Me.Colour.Name = "Colour"
        Me.Colour.Size = New System.Drawing.Size(92, 77)
        Me.Colour.TabIndex = 1
        '
        'Keyframe
        '
        Me.Keyframe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Keyframe.Location = New System.Drawing.Point(74, 86)
        Me.Keyframe.Name = "Keyframe"
        Me.Keyframe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Keyframe.Size = New System.Drawing.Size(75, 77)
        Me.Keyframe.TabIndex = 2
        Me.Keyframe.Text = "Key"
        Me.Keyframe.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 83)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameValue
        '
        Me.NameValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NameValue.Location = New System.Drawing.Point(155, 31)
        Me.NameValue.Name = "NameValue"
        Me.NameValue.Size = New System.Drawing.Size(92, 20)
        Me.NameValue.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 84)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Interpolation"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AddInterpolation
        '
        Me.AddInterpolation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddInterpolation.Location = New System.Drawing.Point(74, 169)
        Me.AddInterpolation.Name = "AddInterpolation"
        Me.AddInterpolation.Size = New System.Drawing.Size(75, 78)
        Me.AddInterpolation.TabIndex = 6
        Me.AddInterpolation.Text = "Add Interpolation"
        Me.AddInterpolation.UseVisualStyleBackColor = True
        '
        'InterpolationType
        '
        Me.InterpolationType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InterpolationType.FormattingEnabled = True
        Me.InterpolationType.Items.AddRange(New Object() {"Static", "Constant"})
        Me.InterpolationType.Location = New System.Drawing.Point(155, 169)
        Me.InterpolationType.Name = "InterpolationType"
        Me.InterpolationType.Size = New System.Drawing.Size(92, 21)
        Me.InterpolationType.TabIndex = 7
        Me.InterpolationType.Text = "Static"
        '
        'EdgeProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "EdgeProperties"
        Me.Size = New System.Drawing.Size(250, 250)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents TableLayoutPanel1 As TableLayoutPanel
    Private WithEvents Label1 As Label
    Friend WithEvents Colour As Panel
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents Keyframe As Button
    Private WithEvents Label2 As Label
    Friend WithEvents NameValue As TextBox
    Private WithEvents Label3 As Label
    Friend WithEvents AddInterpolation As Button
    Friend WithEvents InterpolationType As ComboBox
End Class
