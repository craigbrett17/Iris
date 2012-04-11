namespace Iris.Views
{
    partial class MainWindow
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
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.friendsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.allFriendsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newStatusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.friendsMenu});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(440, 24);
            this.menuBar.TabIndex = 0;
            this.menuBar.Text = "MenuBar";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStatusMenuItem,
            this.toolStripSeparator1,
            this.exitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(35, 20);
            this.fileMenu.Text = "&File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitMenuItem.Text = "E&xit";
            // 
            // friendsMenu
            // 
            this.friendsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allFriendsMenuItem});
            this.friendsMenu.Name = "friendsMenu";
            this.friendsMenu.Size = new System.Drawing.Size(54, 20);
            this.friendsMenu.Text = "F&riends";
            // 
            // allFriendsMenuItem
            // 
            this.allFriendsMenuItem.Name = "allFriendsMenuItem";
            this.allFriendsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allFriendsMenuItem.Text = "&All friends";
            this.allFriendsMenuItem.Click += new System.EventHandler(this.allFriendsMenuItem_Click);
            // 
            // newStatusMenuItem
            // 
            this.newStatusMenuItem.Name = "newStatusMenuItem";
            this.newStatusMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newStatusMenuItem.Text = "Post new &status...";
            this.newStatusMenuItem.Click += new System.EventHandler(this.newStatusMenuItem_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 24);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(440, 354);
            this.contentPanel.TabIndex = 1;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 378);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuBar;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MainWindow";
            this.Text = "Iris";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem friendsMenu;
        private System.Windows.Forms.ToolStripMenuItem allFriendsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newStatusMenuItem;
        private System.Windows.Forms.Panel contentPanel;
    }
}

