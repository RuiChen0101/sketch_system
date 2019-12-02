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
            this.SuspendLayout();
            // 
            // _clear
            // 
            this._clear.Location = new System.Drawing.Point(676, 3);
            this._clear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._clear.Name = "_clear";
            this._clear.Size = new System.Drawing.Size(253, 31);
            this._clear.TabIndex = 0;
            this._clear.Text = "Clear";
            this._clear.UseVisualStyleBackColor = true;
            this._clear.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _line
            // 
            this._line.Location = new System.Drawing.Point(356, 3);
            this._line.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._line.Name = "_line";
            this._line.Size = new System.Drawing.Size(253, 31);
            this._line.TabIndex = 1;
            this._line.Text = "Line";
            this._line.UseVisualStyleBackColor = true;
            this._line.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _rectangle
            // 
            this._rectangle.Location = new System.Drawing.Point(22, 3);
            this._rectangle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this._rectangle.Name = "_rectangle";
            this._rectangle.Size = new System.Drawing.Size(253, 31);
            this._rectangle.TabIndex = 2;
            this._rectangle.Text = "Rectangle";
            this._rectangle.UseVisualStyleBackColor = true;
            this._rectangle.Click += new System.EventHandler(this.HandleRectangleButtonClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 601);
            this.Controls.Add(this._rectangle);
            this.Controls.Add(this._line);
            this.Controls.Add(this._clear);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(950, 640);
            this.MinimumSize = new System.Drawing.Size(950, 640);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _clear;
        private System.Windows.Forms.Button _line;
        private System.Windows.Forms.Button _rectangle;
    }
}

