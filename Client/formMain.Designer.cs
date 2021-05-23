﻿namespace Client
{
    partial class formMain
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
            this.history = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.privateChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.indicator = new System.Windows.Forms.Panel();
            this.btnClr = new System.Windows.Forms.Button();
            this.pleaseTryAgainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl = new System.Windows.Forms.Label();
            this.btntry = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // history
            // 
            this.history.Location = new System.Drawing.Point(12, 60);
            this.history.Multiline = true;
            this.history.Name = "history";
            this.history.ReadOnly = true;
            this.history.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.history.Size = new System.Drawing.Size(219, 150);
            this.history.TabIndex = 0;
            this.history.TextChanged += new System.EventHandler(this.history_TextChanged);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(27, 216);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(161, 20);
            this.input.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(197, 216);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(298, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(72, 134);
            this.listBox1.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.privateChatToolStripMenuItem,
            this.pleaseTryAgainToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 48);
            // 
            // privateChatToolStripMenuItem
            // 
            this.privateChatToolStripMenuItem.Name = "privateChatToolStripMenuItem";
            this.privateChatToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.privateChatToolStripMenuItem.Text = "Private Chat";
            this.privateChatToolStripMenuItem.Click += new System.EventHandler(this.privateChatToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Friends";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(298, 226);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // indicator
            // 
            this.indicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.indicator.Location = new System.Drawing.Point(12, 12);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(10, 11);
            this.indicator.TabIndex = 6;
            this.indicator.BackColorChanged += new System.EventHandler(this.indicator_BackColorChanged);
            // 
            // btnClr
            // 
            this.btnClr.Location = new System.Drawing.Point(237, 189);
            this.btnClr.Name = "btnClr";
            this.btnClr.Size = new System.Drawing.Size(20, 21);
            this.btnClr.TabIndex = 7;
            this.btnClr.Text = "-";
            this.btnClr.UseVisualStyleBackColor = true;
            this.btnClr.Click += new System.EventHandler(this.btnClr_Click);
            // 
            // pleaseTryAgainToolStripMenuItem
            // 
            this.pleaseTryAgainToolStripMenuItem.Name = "pleaseTryAgainToolStripMenuItem";
            this.pleaseTryAgainToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.pleaseTryAgainToolStripMenuItem.Text = "Please try again";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(102, 25);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 20);
            this.lbl.TabIndex = 8;
            // 
            // btntry
            // 
            this.btntry.Location = new System.Drawing.Point(281, 188);
            this.btntry.Name = "btntry";
            this.btntry.Size = new System.Drawing.Size(102, 23);
            this.btntry.TabIndex = 9;
            this.btntry.Text = "Please Try Again";
            this.btntry.UseVisualStyleBackColor = true;
            this.btntry.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(276, 265);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(75, 23);
            this.btnnew.TabIndex = 10;
            this.btnnew.Text = "TRY";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(439, 321);
            this.Controls.Add(this.btnnew);
            this.Controls.Add(this.btntry);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnClr);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.input);
            this.Controls.Add(this.history);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.indicator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "formMain";
            this.Text = "Client ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox history;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem privateChatToolStripMenuItem;
        private System.Windows.Forms.Panel indicator;
        private System.Windows.Forms.Button btnClr;
        private System.Windows.Forms.ToolStripMenuItem pleaseTryAgainToolStripMenuItem;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btntry;
        private System.Windows.Forms.Button btnnew;
    }
}

