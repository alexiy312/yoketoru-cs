namespace yoketoru_cs
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timeLabel = new System.Windows.Forms.Label();
            this.leftLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timeLabel.Location = new System.Drawing.Point(12, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(114, 33);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time: 0";
            // 
            // leftLabel
            // 
            this.leftLabel.AutoSize = true;
            this.leftLabel.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.leftLabel.Location = new System.Drawing.Point(702, 9);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(132, 33);
            this.leftLabel.TabIndex = 1;
            this.leftLabel.Text = "残り: 0個";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("MS UI Gothic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.titleLabel.Location = new System.Drawing.Point(298, 161);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(280, 54);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "よけとるVC#";
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("MS UI Gothic", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.startButton.Location = new System.Drawing.Point(307, 335);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(271, 71);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "ゲームスタート！";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 40F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(298, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 54);
            this.label1.TabIndex = 4;
            this.label1.Text = "クリア！！！";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 26F);
            this.button1.Location = new System.Drawing.Point(307, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 66);
            this.button1.TabIndex = 5;
            this.button1.Text = "タイトルへ戻る";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 40F);
            this.label2.Location = new System.Drawing.Point(298, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 54);
            this.label2.TabIndex = 6;
            this.label2.Text = "GAMEOVER";
            this.label2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.leftLabel);
            this.Controls.Add(this.timeLabel);
            this.Name = "Form1";
            this.Text = "よけとるVC#";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}

