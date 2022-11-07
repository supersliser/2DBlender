<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.File = New System.Windows.Forms.ToolStripDropDownButton()
        Me.NewProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenProject = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Import = New System.Windows.Forms.ToolStripMenuItem()
        Me.Export = New System.Windows.Forms.ToolStripMenuItem()
        Me.Edit = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Undo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Redo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.Paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.View = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Zoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom25 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom150 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom200 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom300 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom400 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarkMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.Reset = New System.Windows.Forms.ToolStripMenuItem()
        Me.Render = New System.Windows.Forms.ToolStripDropDownButton()
        Me.RenderImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenderAnimation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.SelectTool = New System.Windows.Forms.ToolStripButton()
        Me.MoveTool = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.CreatePrimitveTriangle = New System.Windows.Forms.ToolStripButton()
        Me.CreatePrimitiveSquare = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.CreateVertex = New System.Windows.Forms.ToolStripButton()
        Me.ConnectNodes = New System.Windows.Forms.ToolStripButton()
        Me.ConnectArcs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.CreateCamera = New System.Windows.Forms.ToolStripButton()
        Me.KeyframeSplitter = New System.Windows.Forms.SplitContainer()
        Me.PropertiesSplitter = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PropertiesControl = New System.Windows.Forms.TabControl()
        Me.Outliner = New System.Windows.Forms.TreeView()
        Me.OutputBox = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.StatusStrip.SuspendLayout()
        Me.ToolStrip.SuspendLayout()
        CType(Me.KeyframeSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KeyframeSplitter.Panel1.SuspendLayout()
        Me.KeyframeSplitter.SuspendLayout()
        CType(Me.PropertiesSplitter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PropertiesSplitter.Panel1.SuspendLayout()
        Me.PropertiesSplitter.Panel2.SuspendLayout()
        Me.PropertiesSplitter.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.OutputBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.File, Me.Edit, Me.View, Me.Render})
        Me.StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.StatusStrip.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip.TabIndex = 0
        '
        'File
        '
        Me.File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProject, Me.OpenProject, Me.ToolStripSeparator1, Me.Save, Me.SaveAs, Me.ToolStripSeparator2, Me.Import, Me.Export})
        Me.File.Image = CType(resources.GetObject("File.Image"), System.Drawing.Image)
        Me.File.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.File.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.File.Name = "File"
        Me.File.Size = New System.Drawing.Size(38, 20)
        Me.File.Text = "File"
        Me.File.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'NewProject
        '
        Me.NewProject.Name = "NewProject"
        Me.NewProject.Size = New System.Drawing.Size(186, 22)
        Me.NewProject.Text = "New Project"
        '
        'OpenProject
        '
        Me.OpenProject.Name = "OpenProject"
        Me.OpenProject.Size = New System.Drawing.Size(186, 22)
        Me.OpenProject.Text = "Open Project"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(183, 6)
        '
        'Save
        '
        Me.Save.Name = "Save"
        Me.Save.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.Save.Size = New System.Drawing.Size(186, 22)
        Me.Save.Text = "Save"
        '
        'SaveAs
        '
        Me.SaveAs.Name = "SaveAs"
        Me.SaveAs.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAs.Size = New System.Drawing.Size(186, 22)
        Me.SaveAs.Text = "Save As"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(183, 6)
        '
        'Import
        '
        Me.Import.Name = "Import"
        Me.Import.Size = New System.Drawing.Size(186, 22)
        Me.Import.Text = "Import"
        '
        'Export
        '
        Me.Export.Name = "Export"
        Me.Export.Size = New System.Drawing.Size(186, 22)
        Me.Export.Text = "Export"
        '
        'Edit
        '
        Me.Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Undo, Me.Redo, Me.ToolStripSeparator3, Me.Cut, Me.Copy, Me.Paste, Me.ToolStripSeparator4, Me.Delete})
        Me.Edit.Image = CType(resources.GetObject("Edit.Image"), System.Drawing.Image)
        Me.Edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Edit.Name = "Edit"
        Me.Edit.Size = New System.Drawing.Size(40, 20)
        Me.Edit.Text = "Edit"
        '
        'Undo
        '
        Me.Undo.Name = "Undo"
        Me.Undo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.Undo.Size = New System.Drawing.Size(144, 22)
        Me.Undo.Text = "Undo"
        '
        'Redo
        '
        Me.Redo.Name = "Redo"
        Me.Redo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.Redo.Size = New System.Drawing.Size(144, 22)
        Me.Redo.Text = "Redo"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(141, 6)
        '
        'Cut
        '
        Me.Cut.Name = "Cut"
        Me.Cut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.Cut.Size = New System.Drawing.Size(144, 22)
        Me.Cut.Text = "Cut"
        '
        'Copy
        '
        Me.Copy.Name = "Copy"
        Me.Copy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.Copy.Size = New System.Drawing.Size(144, 22)
        Me.Copy.Text = "Copy"
        '
        'Paste
        '
        Me.Paste.Name = "Paste"
        Me.Paste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.Paste.Size = New System.Drawing.Size(144, 22)
        Me.Paste.Text = "Paste"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(141, 6)
        '
        'Delete
        '
        Me.Delete.Name = "Delete"
        Me.Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.Delete.Size = New System.Drawing.Size(144, 22)
        Me.Delete.Text = "Delete"
        '
        'View
        '
        Me.View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.View.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Zoom, Me.DarkMode, Me.Reset})
        Me.View.Image = CType(resources.GetObject("View.Image"), System.Drawing.Image)
        Me.View.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.View.Name = "View"
        Me.View.Size = New System.Drawing.Size(45, 20)
        Me.View.Text = "View"
        '
        'Zoom
        '
        Me.Zoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Zoom10, Me.Zoom25, Me.Zoom50, Me.Zoom100, Me.Zoom150, Me.Zoom200, Me.Zoom300, Me.Zoom400})
        Me.Zoom.Name = "Zoom"
        Me.Zoom.Size = New System.Drawing.Size(148, 22)
        Me.Zoom.Text = "Zoom"
        '
        'Zoom10
        '
        Me.Zoom10.Name = "Zoom10"
        Me.Zoom10.Size = New System.Drawing.Size(102, 22)
        Me.Zoom10.Text = "10%"
        '
        'Zoom25
        '
        Me.Zoom25.Name = "Zoom25"
        Me.Zoom25.Size = New System.Drawing.Size(102, 22)
        Me.Zoom25.Text = "25%"
        '
        'Zoom50
        '
        Me.Zoom50.Name = "Zoom50"
        Me.Zoom50.Size = New System.Drawing.Size(102, 22)
        Me.Zoom50.Text = "50%"
        '
        'Zoom100
        '
        Me.Zoom100.Name = "Zoom100"
        Me.Zoom100.Size = New System.Drawing.Size(102, 22)
        Me.Zoom100.Text = "100%"
        '
        'Zoom150
        '
        Me.Zoom150.Name = "Zoom150"
        Me.Zoom150.Size = New System.Drawing.Size(102, 22)
        Me.Zoom150.Text = "150%"
        '
        'Zoom200
        '
        Me.Zoom200.Name = "Zoom200"
        Me.Zoom200.Size = New System.Drawing.Size(102, 22)
        Me.Zoom200.Text = "200%"
        '
        'Zoom300
        '
        Me.Zoom300.Name = "Zoom300"
        Me.Zoom300.Size = New System.Drawing.Size(102, 22)
        Me.Zoom300.Text = "300%"
        '
        'Zoom400
        '
        Me.Zoom400.Name = "Zoom400"
        Me.Zoom400.Size = New System.Drawing.Size(102, 22)
        Me.Zoom400.Text = "400%"
        '
        'DarkMode
        '
        Me.DarkMode.Name = "DarkMode"
        Me.DarkMode.Size = New System.Drawing.Size(148, 22)
        Me.DarkMode.Text = "Dark Mode"
        '
        'Reset
        '
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(148, 22)
        Me.Reset.Text = "Reset Position"
        '
        'Render
        '
        Me.Render.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Render.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenderImage, Me.RenderAnimation})
        Me.Render.Image = CType(resources.GetObject("Render.Image"), System.Drawing.Image)
        Me.Render.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Render.Name = "Render"
        Me.Render.Size = New System.Drawing.Size(57, 20)
        Me.Render.Text = "Render"
        '
        'RenderImage
        '
        Me.RenderImage.Name = "RenderImage"
        Me.RenderImage.Size = New System.Drawing.Size(170, 22)
        Me.RenderImage.Text = "Render Image"
        '
        'RenderAnimation
        '
        Me.RenderAnimation.Name = "RenderAnimation"
        Me.RenderAnimation.Size = New System.Drawing.Size(170, 22)
        Me.RenderAnimation.Text = "Render Animation"
        '
        'ToolStrip
        '
        Me.ToolStrip.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.SelectTool, Me.MoveTool, Me.ToolStripSeparator5, Me.ToolStripLabel2, Me.CreatePrimitveTriangle, Me.CreatePrimitiveSquare, Me.ToolStripSeparator6, Me.ToolStripLabel3, Me.CreateVertex, Me.ConnectNodes, Me.ConnectArcs, Me.ToolStripSeparator7, Me.CreateCamera})
        Me.ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStrip.Location = New System.Drawing.Point(731, 22)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(69, 428)
        Me.ToolStrip.TabIndex = 1
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(66, 15)
        Me.ToolStripLabel1.Text = "Tools"
        '
        'SelectTool
        '
        Me.SelectTool.Image = CType(resources.GetObject("SelectTool.Image"), System.Drawing.Image)
        Me.SelectTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SelectTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SelectTool.Name = "SelectTool"
        Me.SelectTool.Size = New System.Drawing.Size(66, 20)
        Me.SelectTool.Text = "Select"
        Me.SelectTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MoveTool
        '
        Me.MoveTool.Image = CType(resources.GetObject("MoveTool.Image"), System.Drawing.Image)
        Me.MoveTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MoveTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MoveTool.Name = "MoveTool"
        Me.MoveTool.Size = New System.Drawing.Size(66, 20)
        Me.MoveTool.Text = "Move"
        Me.MoveTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(66, 6)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(66, 15)
        Me.ToolStripLabel2.Text = "Primitives"
        '
        'CreatePrimitveTriangle
        '
        Me.CreatePrimitveTriangle.Image = CType(resources.GetObject("CreatePrimitveTriangle.Image"), System.Drawing.Image)
        Me.CreatePrimitveTriangle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CreatePrimitveTriangle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CreatePrimitveTriangle.Name = "CreatePrimitveTriangle"
        Me.CreatePrimitveTriangle.Size = New System.Drawing.Size(66, 20)
        Me.CreatePrimitveTriangle.Text = "Triangle"
        Me.CreatePrimitveTriangle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CreatePrimitiveSquare
        '
        Me.CreatePrimitiveSquare.Image = CType(resources.GetObject("CreatePrimitiveSquare.Image"), System.Drawing.Image)
        Me.CreatePrimitiveSquare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CreatePrimitiveSquare.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CreatePrimitiveSquare.Name = "CreatePrimitiveSquare"
        Me.CreatePrimitiveSquare.Size = New System.Drawing.Size(66, 20)
        Me.CreatePrimitiveSquare.Text = "Square"
        Me.CreatePrimitiveSquare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(66, 6)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(66, 15)
        Me.ToolStripLabel3.Text = "Custom"
        '
        'CreateVertex
        '
        Me.CreateVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CreateVertex.Image = CType(resources.GetObject("CreateVertex.Image"), System.Drawing.Image)
        Me.CreateVertex.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CreateVertex.Name = "CreateVertex"
        Me.CreateVertex.Size = New System.Drawing.Size(66, 19)
        Me.CreateVertex.Text = "Vertex"
        '
        'ConnectNodes
        '
        Me.ConnectNodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ConnectNodes.Image = CType(resources.GetObject("ConnectNodes.Image"), System.Drawing.Image)
        Me.ConnectNodes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConnectNodes.Name = "ConnectNodes"
        Me.ConnectNodes.Size = New System.Drawing.Size(66, 19)
        Me.ConnectNodes.Text = "Edge"
        '
        'ConnectArcs
        '
        Me.ConnectArcs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ConnectArcs.Image = CType(resources.GetObject("ConnectArcs.Image"), System.Drawing.Image)
        Me.ConnectArcs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConnectArcs.Name = "ConnectArcs"
        Me.ConnectArcs.Size = New System.Drawing.Size(66, 19)
        Me.ConnectArcs.Text = "Face"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(66, 6)
        '
        'CreateCamera
        '
        Me.CreateCamera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.CreateCamera.Image = CType(resources.GetObject("CreateCamera.Image"), System.Drawing.Image)
        Me.CreateCamera.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CreateCamera.Name = "CreateCamera"
        Me.CreateCamera.Size = New System.Drawing.Size(66, 19)
        Me.CreateCamera.Text = "Camera"
        '
        'KeyframeSplitter
        '
        Me.KeyframeSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KeyframeSplitter.Location = New System.Drawing.Point(0, 22)
        Me.KeyframeSplitter.Name = "KeyframeSplitter"
        Me.KeyframeSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'KeyframeSplitter.Panel1
        '
        Me.KeyframeSplitter.Panel1.Controls.Add(Me.PropertiesSplitter)
        Me.KeyframeSplitter.Size = New System.Drawing.Size(731, 428)
        Me.KeyframeSplitter.SplitterDistance = 289
        Me.KeyframeSplitter.SplitterWidth = 10
        Me.KeyframeSplitter.TabIndex = 2
        '
        'PropertiesSplitter
        '
        Me.PropertiesSplitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertiesSplitter.Location = New System.Drawing.Point(0, 0)
        Me.PropertiesSplitter.Name = "PropertiesSplitter"
        '
        'PropertiesSplitter.Panel1
        '
        Me.PropertiesSplitter.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'PropertiesSplitter.Panel2
        '
        Me.PropertiesSplitter.Panel2.Controls.Add(Me.OutputBox)
        Me.PropertiesSplitter.Size = New System.Drawing.Size(731, 289)
        Me.PropertiesSplitter.SplitterDistance = 193
        Me.PropertiesSplitter.SplitterWidth = 10
        Me.PropertiesSplitter.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PropertiesControl)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Outliner)
        Me.SplitContainer1.Size = New System.Drawing.Size(193, 289)
        Me.SplitContainer1.SplitterDistance = 252
        Me.SplitContainer1.SplitterWidth = 10
        Me.SplitContainer1.TabIndex = 0
        '
        'PropertiesControl
        '
        Me.PropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertiesControl.Location = New System.Drawing.Point(0, 0)
        Me.PropertiesControl.Name = "PropertiesControl"
        Me.PropertiesControl.SelectedIndex = 0
        Me.PropertiesControl.Size = New System.Drawing.Size(193, 252)
        Me.PropertiesControl.TabIndex = 0
        '
        'Outliner
        '
        Me.Outliner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Outliner.Location = New System.Drawing.Point(0, 0)
        Me.Outliner.Name = "Outliner"
        Me.Outliner.Size = New System.Drawing.Size(193, 27)
        Me.Outliner.TabIndex = 0
        '
        'OutputBox
        '
        Me.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputBox.Location = New System.Drawing.Point(0, 0)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.Size = New System.Drawing.Size(528, 289)
        Me.OutputBox.TabIndex = 0
        Me.OutputBox.TabStop = False
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = """2D Blender Files|*.tbl|All files|*.*"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = """2D Blender Files|*.tbl|All files|*.*"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.KeyframeSplitter)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "2D Blender"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.KeyframeSplitter.Panel1.ResumeLayout(False)
        CType(Me.KeyframeSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KeyframeSplitter.ResumeLayout(False)
        Me.PropertiesSplitter.Panel1.ResumeLayout(False)
        Me.PropertiesSplitter.Panel2.ResumeLayout(False)
        CType(Me.PropertiesSplitter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PropertiesSplitter.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.OutputBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents ToolStrip As ToolStrip
    Friend WithEvents KeyframeSplitter As SplitContainer
    Friend WithEvents PropertiesSplitter As SplitContainer
    Friend WithEvents OutputBox As PictureBox
    Friend WithEvents File As ToolStripDropDownButton
    Friend WithEvents NewProject As ToolStripMenuItem
    Friend WithEvents OpenProject As ToolStripMenuItem
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Save As ToolStripMenuItem
    Friend WithEvents SaveAs As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Import As ToolStripMenuItem
    Friend WithEvents Export As ToolStripMenuItem
    Private WithEvents Edit As ToolStripDropDownButton
    Friend WithEvents Undo As ToolStripMenuItem
    Friend WithEvents Redo As ToolStripMenuItem
    Private WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Cut As ToolStripMenuItem
    Friend WithEvents Copy As ToolStripMenuItem
    Friend WithEvents Paste As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents Delete As ToolStripMenuItem
    Friend WithEvents View As ToolStripDropDownButton
    Friend WithEvents Zoom As ToolStripMenuItem
    Friend WithEvents Zoom10 As ToolStripMenuItem
    Friend WithEvents Zoom25 As ToolStripMenuItem
    Friend WithEvents Zoom50 As ToolStripMenuItem
    Friend WithEvents Zoom100 As ToolStripMenuItem
    Friend WithEvents Zoom150 As ToolStripMenuItem
    Friend WithEvents Zoom200 As ToolStripMenuItem
    Friend WithEvents Zoom300 As ToolStripMenuItem
    Friend WithEvents Zoom400 As ToolStripMenuItem
    Friend WithEvents DarkMode As ToolStripMenuItem
    Friend WithEvents Reset As ToolStripMenuItem
    Private WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PropertiesControl As TabControl
    Friend WithEvents Outliner As TreeView
    Friend WithEvents SelectTool As ToolStripButton
    Private WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents MoveTool As ToolStripButton
    Private WithEvents ToolStripSeparator5 As ToolStripSeparator
    Private WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents CreatePrimitiveSquare As ToolStripButton
    Friend WithEvents CreatePrimitveTriangle As ToolStripButton
    Private WithEvents ToolStripSeparator6 As ToolStripSeparator
    Private WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents CreateVertex As ToolStripButton
    Friend WithEvents ConnectNodes As ToolStripButton
    Friend WithEvents ConnectArcs As ToolStripButton
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents Render As ToolStripDropDownButton
    Friend WithEvents RenderImage As ToolStripMenuItem
    Friend WithEvents RenderAnimation As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents CreateCamera As ToolStripButton
End Class
