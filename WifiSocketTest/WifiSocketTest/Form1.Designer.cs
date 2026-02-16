namespace WifiSocketTEst
{
   partial class Form1
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
         this.components = new System.ComponentModel.Container();
         this.SendaBtn = new System.Windows.Forms.Button();
         this.LogLB = new System.Windows.Forms.ListBox();
         this.SendbBtn = new System.Windows.Forms.Button();
         this.SendcBtn = new System.Windows.Forms.Button();
         this.SenddBtn = new System.Windows.Forms.Button();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.SuspendLayout();
         // 
         // SendaBtn
         // 
         this.SendaBtn.Location = new System.Drawing.Point(12, 12);
         this.SendaBtn.Name = "SendaBtn";
         this.SendaBtn.Size = new System.Drawing.Size(184, 44);
         this.SendaBtn.TabIndex = 0;
         this.SendaBtn.Text = "Send a";
         this.SendaBtn.UseVisualStyleBackColor = true;
         this.SendaBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SendaBtn_MouseUp);
         // 
         // LogLB
         // 
         this.LogLB.FormattingEnabled = true;
         this.LogLB.Location = new System.Drawing.Point(12, 212);
         this.LogLB.Name = "LogLB";
         this.LogLB.Size = new System.Drawing.Size(184, 95);
         this.LogLB.TabIndex = 1;
         // 
         // SendbBtn
         // 
         this.SendbBtn.Location = new System.Drawing.Point(12, 62);
         this.SendbBtn.Name = "SendbBtn";
         this.SendbBtn.Size = new System.Drawing.Size(184, 44);
         this.SendbBtn.TabIndex = 0;
         this.SendbBtn.Text = "Send b";
         this.SendbBtn.UseVisualStyleBackColor = true;
         this.SendbBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SendbBtn_MouseUp);
         // 
         // SendcBtn
         // 
         this.SendcBtn.Location = new System.Drawing.Point(12, 112);
         this.SendcBtn.Name = "SendcBtn";
         this.SendcBtn.Size = new System.Drawing.Size(184, 44);
         this.SendcBtn.TabIndex = 0;
         this.SendcBtn.Text = "Send c";
         this.SendcBtn.UseVisualStyleBackColor = true;
         this.SendcBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SendcBtn_MouseUp);
         // 
         // SenddBtn
         // 
         this.SenddBtn.Location = new System.Drawing.Point(12, 162);
         this.SenddBtn.Name = "SenddBtn";
         this.SenddBtn.Size = new System.Drawing.Size(184, 44);
         this.SenddBtn.TabIndex = 0;
         this.SenddBtn.Text = "Send d";
         this.SenddBtn.UseVisualStyleBackColor = true;
         this.SenddBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SenddBtn_MouseUp);
         // 
         // timer1
         // 
         this.timer1.Enabled = true;
         this.timer1.Interval = 1000;
         this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(237, 324);
         this.Controls.Add(this.LogLB);
         this.Controls.Add(this.SenddBtn);
         this.Controls.Add(this.SendcBtn);
         this.Controls.Add(this.SendbBtn);
         this.Controls.Add(this.SendaBtn);
         this.Name = "Form1";
         this.Text = "Antenna Switch";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button SendaBtn;
      private System.Windows.Forms.ListBox LogLB;
      private System.Windows.Forms.Button SendbBtn;
      private System.Windows.Forms.Button SendcBtn;
      private System.Windows.Forms.Button SenddBtn;
      private System.Windows.Forms.Timer timer1;
   }
}

