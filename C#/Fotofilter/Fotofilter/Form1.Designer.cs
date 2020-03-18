namespace Fotofilter
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbBild = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arkivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öppnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sparaBildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ångraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görOmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.angraAlltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storlekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.In = new System.Windows.Forms.ToolStripMenuItem();
            this.Out = new System.Windows.Forms.ToolStripMenuItem();
            this.avslutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shadeSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSortToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorFitlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveRed = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveYellow = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorReplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.GreenToRed = new System.Windows.Forms.ToolStripMenuItem();
            this.GreenToBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueToRed = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueToGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.monochromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grainToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawColorSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImage = new System.Windows.Forms.OpenFileDialog();
            this.saveImage = new System.Windows.Forms.SaveFileDialog();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbBild)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbBild
            // 
            this.pbBild.Location = new System.Drawing.Point(9, 25);
            this.pbBild.Margin = new System.Windows.Forms.Padding(2);
            this.pbBild.Name = "pbBild";
            this.pbBild.Size = new System.Drawing.Size(246, 112);
            this.pbBild.TabIndex = 1;
            this.pbBild.TabStop = false;
            this.pbBild.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawPaint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arkivToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(345, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arkivToolStripMenuItem
            // 
            this.arkivToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öppnaToolStripMenuItem,
            this.sparaBildToolStripMenuItem,
            this.ångraToolStripMenuItem,
            this.görOmToolStripMenuItem,
            this.angraAlltToolStripMenuItem,
            this.storlekToolStripMenuItem,
            this.avslutaToolStripMenuItem});
            this.arkivToolStripMenuItem.Name = "arkivToolStripMenuItem";
            this.arkivToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.arkivToolStripMenuItem.Text = "File";
            // 
            // öppnaToolStripMenuItem
            // 
            this.öppnaToolStripMenuItem.Name = "öppnaToolStripMenuItem";
            this.öppnaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.öppnaToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.öppnaToolStripMenuItem.Text = "Open image...";
            this.öppnaToolStripMenuItem.Click += new System.EventHandler(this.OpenImage);
            // 
            // sparaBildToolStripMenuItem
            // 
            this.sparaBildToolStripMenuItem.Name = "sparaBildToolStripMenuItem";
            this.sparaBildToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.sparaBildToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.sparaBildToolStripMenuItem.Text = "Save image as...";
            this.sparaBildToolStripMenuItem.Click += new System.EventHandler(this.ImageSaveAs);
            // 
            // ångraToolStripMenuItem
            // 
            this.ångraToolStripMenuItem.Name = "ångraToolStripMenuItem";
            this.ångraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.ångraToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.ångraToolStripMenuItem.Text = "Undo";
            this.ångraToolStripMenuItem.Click += new System.EventHandler(this.Undo);
            // 
            // görOmToolStripMenuItem
            // 
            this.görOmToolStripMenuItem.Name = "görOmToolStripMenuItem";
            this.görOmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.görOmToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.görOmToolStripMenuItem.Text = "Redo";
            this.görOmToolStripMenuItem.Click += new System.EventHandler(this.Redo);
            // 
            // angraAlltToolStripMenuItem
            // 
            this.angraAlltToolStripMenuItem.Name = "angraAlltToolStripMenuItem";
            this.angraAlltToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.angraAlltToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.angraAlltToolStripMenuItem.Text = "Undo all";
            this.angraAlltToolStripMenuItem.Click += new System.EventHandler(this.ResetImage);
            // 
            // storlekToolStripMenuItem
            // 
            this.storlekToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.In,
            this.Out});
            this.storlekToolStripMenuItem.Name = "storlekToolStripMenuItem";
            this.storlekToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.storlekToolStripMenuItem.Text = "Size(WIP)";
            // 
            // In
            // 
            this.In.Name = "In";
            this.In.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.In.Size = new System.Drawing.Size(220, 22);
            this.In.Text = "Zoom in";
            this.In.Click += new System.EventHandler(this.Scale);
            // 
            // Out
            // 
            this.Out.Name = "Out";
            this.Out.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.Out.Size = new System.Drawing.Size(220, 22);
            this.Out.Text = "Zoom out";
            this.Out.Click += new System.EventHandler(this.Scale);
            // 
            // avslutaToolStripMenuItem
            // 
            this.avslutaToolStripMenuItem.Name = "avslutaToolStripMenuItem";
            this.avslutaToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.avslutaToolStripMenuItem.Text = "Exit...";
            this.avslutaToolStripMenuItem.Click += new System.EventHandler(this.CloseApp);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorSortToolStripMenuItem,
            this.grainToolStripMenuItem,
            this.colorFitlerToolStripMenuItem,
            this.experimentToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.colorReplaceToolStripMenuItem,
            this.monochromeToolStripMenuItem,
            this.grainToolStripMenuItem1,
            this.brightnessToolStripMenuItem,
            this.blurToolStripMenuItem});
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            // 
            // colorSortToolStripMenuItem
            // 
            this.colorSortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shadeSortToolStripMenuItem,
            this.colorSortToolStripMenuItem1});
            this.colorSortToolStripMenuItem.Name = "colorSortToolStripMenuItem";
            this.colorSortToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.colorSortToolStripMenuItem.Text = "Sort";
            this.colorSortToolStripMenuItem.ToolTipText = "Sorts all colors by their shade from brightest to darkest";
            // 
            // shadeSortToolStripMenuItem
            // 
            this.shadeSortToolStripMenuItem.Name = "shadeSortToolStripMenuItem";
            this.shadeSortToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.shadeSortToolStripMenuItem.Text = "Shade sort";
            this.shadeSortToolStripMenuItem.Click += new System.EventHandler(this.ShadeSortFilter);
            // 
            // colorSortToolStripMenuItem1
            // 
            this.colorSortToolStripMenuItem1.Name = "colorSortToolStripMenuItem1";
            this.colorSortToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.colorSortToolStripMenuItem1.Text = "Color sort";
            this.colorSortToolStripMenuItem1.Click += new System.EventHandler(this.ColorSortFilter);
            // 
            // grainToolStripMenuItem
            // 
            this.grainToolStripMenuItem.Name = "grainToolStripMenuItem";
            this.grainToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.grainToolStripMenuItem.Text = "Demon grain ";
            this.grainToolStripMenuItem.ToolTipText = "Gives the picture a demonic grainy look";
            this.grainToolStripMenuItem.Click += new System.EventHandler(this.DemonGrainImageFilter);
            // 
            // colorFitlerToolStripMenuItem
            // 
            this.colorFitlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveRed,
            this.RemoveGreen,
            this.RemoveBlue,
            this.RemoveYellow});
            this.colorFitlerToolStripMenuItem.Name = "colorFitlerToolStripMenuItem";
            this.colorFitlerToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.colorFitlerToolStripMenuItem.Text = "Color Remove";
            this.colorFitlerToolStripMenuItem.ToolTipText = "Removes one of the color channels";
            // 
            // RemoveRed
            // 
            this.RemoveRed.Name = "RemoveRed";
            this.RemoveRed.Size = new System.Drawing.Size(108, 22);
            this.RemoveRed.Text = "Red";
            this.RemoveRed.Click += new System.EventHandler(this.ColorRemove);
            // 
            // RemoveGreen
            // 
            this.RemoveGreen.Name = "RemoveGreen";
            this.RemoveGreen.Size = new System.Drawing.Size(108, 22);
            this.RemoveGreen.Text = "Green";
            this.RemoveGreen.Click += new System.EventHandler(this.ColorRemove);
            // 
            // RemoveBlue
            // 
            this.RemoveBlue.Name = "RemoveBlue";
            this.RemoveBlue.Size = new System.Drawing.Size(108, 22);
            this.RemoveBlue.Text = "Blue";
            this.RemoveBlue.Click += new System.EventHandler(this.ColorRemove);
            // 
            // RemoveYellow
            // 
            this.RemoveYellow.Name = "RemoveYellow";
            this.RemoveYellow.Size = new System.Drawing.Size(108, 22);
            this.RemoveYellow.Text = "Yellow";
            this.RemoveYellow.Click += new System.EventHandler(this.ColorRemove);
            // 
            // experimentToolStripMenuItem
            // 
            this.experimentToolStripMenuItem.Name = "experimentToolStripMenuItem";
            this.experimentToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.experimentToolStripMenuItem.Text = "Absolute RGB";
            this.experimentToolStripMenuItem.ToolTipText = "Makes the colors their absolute color";
            this.experimentToolStripMenuItem.Click += new System.EventHandler(this.AbsoluteColorFilter);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.ToolTipText = "Inverts colors";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.InvertColorFilter);
            // 
            // colorReplaceToolStripMenuItem
            // 
            this.colorReplaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem1,
            this.greenToolStripMenuItem2,
            this.blueToolStripMenuItem3});
            this.colorReplaceToolStripMenuItem.Name = "colorReplaceToolStripMenuItem";
            this.colorReplaceToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.colorReplaceToolStripMenuItem.Text = "Color Replace";
            this.colorReplaceToolStripMenuItem.ToolTipText = "Replaces every instance of a specific shade with another";
            // 
            // redToolStripMenuItem1
            // 
            this.redToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RedToGreen,
            this.RedToBlue});
            this.redToolStripMenuItem1.Name = "redToolStripMenuItem1";
            this.redToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.redToolStripMenuItem1.Text = "Red -> ";
            // 
            // RedToGreen
            // 
            this.RedToGreen.AccessibleName = "";
            this.RedToGreen.Name = "RedToGreen";
            this.RedToGreen.Size = new System.Drawing.Size(105, 22);
            this.RedToGreen.Text = "Green";
            this.RedToGreen.Click += new System.EventHandler(this.ColorSet);
            // 
            // RedToBlue
            // 
            this.RedToBlue.Name = "RedToBlue";
            this.RedToBlue.Size = new System.Drawing.Size(105, 22);
            this.RedToBlue.Text = "Blue";
            this.RedToBlue.Click += new System.EventHandler(this.ColorSet);
            // 
            // greenToolStripMenuItem2
            // 
            this.greenToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GreenToRed,
            this.GreenToBlue});
            this.greenToolStripMenuItem2.Name = "greenToolStripMenuItem2";
            this.greenToolStripMenuItem2.Size = new System.Drawing.Size(121, 22);
            this.greenToolStripMenuItem2.Text = "Green ->";
            // 
            // GreenToRed
            // 
            this.GreenToRed.Name = "GreenToRed";
            this.GreenToRed.Size = new System.Drawing.Size(97, 22);
            this.GreenToRed.Text = "Red";
            this.GreenToRed.Click += new System.EventHandler(this.ColorSet);
            // 
            // GreenToBlue
            // 
            this.GreenToBlue.Name = "GreenToBlue";
            this.GreenToBlue.Size = new System.Drawing.Size(97, 22);
            this.GreenToBlue.Text = "Blue";
            this.GreenToBlue.Click += new System.EventHandler(this.ColorSet);
            // 
            // blueToolStripMenuItem3
            // 
            this.blueToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BlueToRed,
            this.BlueToGreen});
            this.blueToolStripMenuItem3.Name = "blueToolStripMenuItem3";
            this.blueToolStripMenuItem3.Size = new System.Drawing.Size(121, 22);
            this.blueToolStripMenuItem3.Text = "Blue ->";
            // 
            // BlueToRed
            // 
            this.BlueToRed.Name = "BlueToRed";
            this.BlueToRed.Size = new System.Drawing.Size(105, 22);
            this.BlueToRed.Text = "Red";
            this.BlueToRed.Click += new System.EventHandler(this.ColorSet);
            // 
            // BlueToGreen
            // 
            this.BlueToGreen.Name = "BlueToGreen";
            this.BlueToGreen.Size = new System.Drawing.Size(105, 22);
            this.BlueToGreen.Text = "Green";
            this.BlueToGreen.Click += new System.EventHandler(this.ColorSet);
            // 
            // monochromeToolStripMenuItem
            // 
            this.monochromeToolStripMenuItem.Name = "monochromeToolStripMenuItem";
            this.monochromeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.monochromeToolStripMenuItem.Text = "Monochrome";
            this.monochromeToolStripMenuItem.ToolTipText = "Turns the image black and white";
            this.monochromeToolStripMenuItem.Click += new System.EventHandler(this.MonochromeColorFilter);
            // 
            // grainToolStripMenuItem1
            // 
            this.grainToolStripMenuItem1.Name = "grainToolStripMenuItem1";
            this.grainToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.grainToolStripMenuItem1.Text = "Grain";
            this.grainToolStripMenuItem1.ToolTipText = "Applies a grainy effect to the image";
            this.grainToolStripMenuItem1.Click += new System.EventHandler(this.GrainImageFilter);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.brightnessToolStripMenuItem.Text = "Brightness(WIP)";
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.BlurImageFilter);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawColorSelection});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // drawColorSelection
            // 
            this.drawColorSelection.Name = "drawColorSelection";
            this.drawColorSelection.Size = new System.Drawing.Size(180, 22);
            this.drawColorSelection.Text = "Select color...";
            this.drawColorSelection.Click += new System.EventHandler(this.DrawSelectColor);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OpenAbout);
            // 
            // saveImage
            // 
            this.saveImage.RestoreDirectory = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(345, 148);
            this.Controls.Add(this.pbBild);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainForm";
            this.Text = "ImageBoutique";
            ((System.ComponentModel.ISupportInitialize)(this.pbBild)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbBild;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arkivToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avslutaToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openImage;
        private System.Windows.Forms.ToolStripMenuItem öppnaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorFitlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveRed;
        private System.Windows.Forms.ToolStripMenuItem RemoveGreen;
        private System.Windows.Forms.ToolStripMenuItem RemoveBlue;
        private System.Windows.Forms.ToolStripMenuItem sparaBildToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveImage;
        private System.Windows.Forms.ToolStripMenuItem angraAlltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem experimentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorReplaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem RedToGreen;
        private System.Windows.Forms.ToolStripMenuItem RedToBlue;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem GreenToRed;
        private System.Windows.Forms.ToolStripMenuItem GreenToBlue;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem BlueToRed;
        private System.Windows.Forms.ToolStripMenuItem BlueToGreen;
        private System.Windows.Forms.ToolStripMenuItem RemoveYellow;
        private System.Windows.Forms.ToolStripMenuItem monochromeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grainToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem shadeSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorSortToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ångraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storlekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem In;
        private System.Windows.Forms.ToolStripMenuItem Out;
        private System.Windows.Forms.ToolStripMenuItem görOmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawColorSelection;
    }
}

