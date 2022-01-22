﻿
namespace SugiTool.DistinctData.WinForm.Views
{
    partial class DistinctDataView
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
			this.srcDirTextBox = new System.Windows.Forms.TextBox();
			this.dstDirTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// srcDirTextBox
			// 
			this.srcDirTextBox.Location = new System.Drawing.Point(12, 37);
			this.srcDirTextBox.Name = "srcDirTextBox";
			this.srcDirTextBox.Size = new System.Drawing.Size(238, 19);
			this.srcDirTextBox.TabIndex = 0;
			this.srcDirTextBox.Text = "D:\\Sugi\\資料\\00.介護報酬改定\\リランデータ\\出力データ\\";
			// 
			// dstDirTextBox
			// 
			this.dstDirTextBox.Location = new System.Drawing.Point(12, 84);
			this.dstDirTextBox.Name = "dstDirTextBox";
			this.dstDirTextBox.Size = new System.Drawing.Size(238, 19);
			this.dstDirTextBox.TabIndex = 1;
			this.dstDirTextBox.Text = "D:\\Sugi\\資料\\00.介護報酬改定\\リランデータ\\";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 143);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "実行";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "元ディレクトリ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "出力先ディレクトリ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 116);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(166, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "ファイル内のキー重複データを削除";
			// 
			// DistinctDataView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(262, 178);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dstDirTextBox);
			this.Controls.Add(this.srcDirTextBox);
			this.Name = "DistinctDataView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "重複削除";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox srcDirTextBox;
        private System.Windows.Forms.TextBox dstDirTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

