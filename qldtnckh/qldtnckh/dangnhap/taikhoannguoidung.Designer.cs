namespace qldtnckh.dangnhap
{
    partial class taikhoannguoidung
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_pass_old = new DevExpress.XtraEditors.TextEdit();
            this.txt_pass_new = new DevExpress.XtraEditors.TextEdit();
            this.txt_check_pass_new = new DevExpress.XtraEditors.TextEdit();
            this.lb_quyen = new DevExpress.XtraEditors.LabelControl();
            this.lb_username = new DevExpress.XtraEditors.LabelControl();
            this.btn_dmk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass_old.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass_new.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_check_pass_new.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Quyền";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "username";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 141);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(58, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Mật khẩu cũ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 185);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(63, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Mật khẩu mới";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 232);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(104, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Nhập lại mật khẩu mới";
            // 
            // txt_pass_old
            // 
            this.txt_pass_old.Location = new System.Drawing.Point(120, 136);
            this.txt_pass_old.Name = "txt_pass_old";
            this.txt_pass_old.Size = new System.Drawing.Size(113, 20);
            this.txt_pass_old.TabIndex = 5;
            // 
            // txt_pass_new
            // 
            this.txt_pass_new.Location = new System.Drawing.Point(120, 181);
            this.txt_pass_new.Name = "txt_pass_new";
            this.txt_pass_new.Size = new System.Drawing.Size(112, 20);
            this.txt_pass_new.TabIndex = 6;
            // 
            // txt_check_pass_new
            // 
            this.txt_check_pass_new.Location = new System.Drawing.Point(120, 229);
            this.txt_check_pass_new.Name = "txt_check_pass_new";
            this.txt_check_pass_new.Size = new System.Drawing.Size(111, 20);
            this.txt_check_pass_new.TabIndex = 7;
            // 
            // lb_quyen
            // 
            this.lb_quyen.Location = new System.Drawing.Point(133, 48);
            this.lb_quyen.Name = "lb_quyen";
            this.lb_quyen.Size = new System.Drawing.Size(63, 13);
            this.lb_quyen.TabIndex = 8;
            this.lb_quyen.Text = "labelControl6";
            // 
            // lb_username
            // 
            this.lb_username.Location = new System.Drawing.Point(133, 92);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(63, 13);
            this.lb_username.TabIndex = 9;
            this.lb_username.Text = "labelControl7";
            // 
            // btn_dmk
            // 
            this.btn_dmk.Location = new System.Drawing.Point(80, 293);
            this.btn_dmk.Name = "btn_dmk";
            this.btn_dmk.Size = new System.Drawing.Size(91, 17);
            this.btn_dmk.TabIndex = 10;
            this.btn_dmk.Text = "Đổi mật khẩu";
            this.btn_dmk.Click += new System.EventHandler(this.btn_dmk_Click);
            // 
            // taikhoannguoidung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 363);
            this.Controls.Add(this.btn_dmk);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.lb_quyen);
            this.Controls.Add(this.txt_check_pass_new);
            this.Controls.Add(this.txt_pass_new);
            this.Controls.Add(this.txt_pass_old);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "taikhoannguoidung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài khoản người dùng";
            this.Load += new System.EventHandler(this.taikhoannguoidung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass_old.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_pass_new.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_check_pass_new.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txt_pass_old;
        private DevExpress.XtraEditors.TextEdit txt_pass_new;
        private DevExpress.XtraEditors.TextEdit txt_check_pass_new;
        private DevExpress.XtraEditors.LabelControl lb_quyen;
        private DevExpress.XtraEditors.LabelControl lb_username;
        private DevExpress.XtraEditors.SimpleButton btn_dmk;
    }
}