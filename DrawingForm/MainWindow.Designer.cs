namespace DrawingForm
{
    partial class MainWindow
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._clear = new System.Windows.Forms.Button();
            this._line = new System.Windows.Forms.Button();
            this._rectangle = new System.Windows.Forms.Button();
            this._hexagon = new System.Windows.Forms.Button();
            this._info = new System.Windows.Forms.Label();
            this._menu = new System.Windows.Forms.MenuStrip();
            this._undo = new System.Windows.Forms.ToolStripMenuItem();
            this._redo = new System.Windows.Forms.ToolStripMenuItem();
            this._save = new System.Windows.Forms.ToolStripMenuItem();
            this._load = new System.Windows.Forms.ToolStripMenuItem();
            this._menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _clear
            // 
            this._clear.Location = new System.Drawing.Point(718, 27);
            this._clear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(211, 31);
            this._clear.TabIndex = 0;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _line
            // 
            this._line.Location = new System.Drawing.Point(253, 27);
            this._line.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(190, 31);
            this._line.TabIndex = 1;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _rectangle
            // 
            this._rectangle.Location = new System.Drawing.Point(24, 27);
            this._rectangle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(185, 31);
            this._rectangle.TabIndex = 2;
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            this._rectangle.Click += new System.EventHandler(this.HandleRectangleButtonClick);
            // 
            // _hexagon
            // 
            this._hexagon.Location = new System.Drawing.Point(491, 27);
            this._hexagon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._hexagon.Name = "_hexagon";
            this._hexagon.Size = new System.Drawing.Size(190, 31);
            this._hexagon.TabIndex = 3;
            this._hexagon.Text = "Hexagon";
            this._hexagon.UseVisualStyleBackColor = true;
            this._hexagon.Click += new System.EventHandler(this.HandleHexagonButtonClick);
            // 
            // _info
            // 
            this._info.AccessibleName = "_info";
            this._info.AutoSize = true;
            this._info.Location = new System.Drawing.Point(683, 576);
            this._info.Name = "_info";
            this._info.Size = new System.Drawing.Size(0, 16);
            this._info.TabIndex = 4;
            // 
            // _menu
            // 
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._undo,
            this._redo,
            this._save,
            this._load});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(934, 24);
            this._menu.TabIndex = 5;
            this._menu.Text = "menuStrip1";
            // 
            // _undo
            // 
            this._undo.Enabled = false;
            this._undo.Name = "_undo";
            this._undo.Size = new System.Drawing.Size(49, 20);
            this._undo.Text = "undo";
            this._undo.Click += new System.EventHandler(this.HandleUndo);
            // 
            // _redo
            // 
            this._redo.Enabled = false;
            this._redo.Name = "_redo";
            this._redo.Size = new System.Drawing.Size(46, 20);
            this._redo.Text = "redo";
            this._redo.Click += new System.EventHandler(this.HandleRedo);
            // 
            // _save
            // 
            this._save.Name = "_save";
            this._save.Size = new System.Drawing.Size(44, 20);
            this._save.Text = "save";
            this._save.Click += new System.EventHandler(this.HandleSaveClick);
            // 
            // _load
            // 
            this._load.Name = "_load";
            this._load.Size = new System.Drawing.Size(45, 20);
            this._load.Text = "load";
            this._load.Click += new System.EventHandler(this.HandleLoadClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 601);
            this.Controls.Add(this._info);
            this.Controls.Add(this._hexagon);
            this.Controls.Add(this._rectangle);
            this.Controls.Add(this._line);
            this.Controls.Add(this._clear);
            this.Controls.Add(this._menu);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this._menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(950, 640);
            this.MinimumSize = new System.Drawing.Size(950, 640);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Button _rectangle;
        private System.Windows.Forms.Button _hexagon;
        private System.Windows.Forms.Label _info;
        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem _undo;
        private System.Windows.Forms.ToolStripMenuItem _redo;
        private System.Windows.Forms.ToolStripMenuItem _save;
        private System.Windows.Forms.ToolStripMenuItem _load;
    }
}

