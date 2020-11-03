namespace Escape_Room
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.door = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.door)).BeginInit();
            this.SuspendLayout();
            // 
            // door
            // 
            this.door.BackColor = System.Drawing.Color.Transparent;
            this.door.BackgroundImage = global::Escape_Room.Properties.Resources.Door_1;
            this.door.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.door.Location = new System.Drawing.Point(1152, 34);
            this.door.Name = "door";
            this.door.Size = new System.Drawing.Size(214, 259);
            this.door.TabIndex = 0;
            this.door.TabStop = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.door);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1386, 856);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.door)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox door;
    }
}
