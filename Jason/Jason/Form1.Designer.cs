namespace Jason
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000020DE File Offset: 0x000002DE
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003760 File Offset: 0x00001960
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Jason.Form1));
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtExchangeAddress = new global::System.Windows.Forms.TextBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cmbExchangeVersion = new global::System.Windows.Forms.ComboBox();
			this.txtUserPassFile = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.btnOpen = new global::System.Windows.Forms.Button();
			this.btnStart = new global::System.Windows.Forms.Button();
			this.grdResult = new global::System.Windows.Forms.DataGridView();
			this.clnNumber = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCurrentUsername = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCurrentPassword = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnStatus = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnTotalCheck = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnTotalSuccess = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TimerMain = new global::System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.btnPassGenPerUser = new global::System.Windows.Forms.Button();
			this.label13 = new global::System.Windows.Forms.Label();
			this.btnGeneratePass = new global::System.Windows.Forms.Button();
			this.btnPasswordOpen = new global::System.Windows.Forms.Button();
			this.label15 = new global::System.Windows.Forms.Label();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.cmbMethod = new global::System.Windows.Forms.ComboBox();
			this.txtUsernameEnd = new global::System.Windows.Forms.TextBox();
			this.txtUsernameStart = new global::System.Windows.Forms.TextBox();
			this.txtThreadCount = new global::System.Windows.Forms.TextBox();
			this.txtPassword = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.lblTimer = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.lblSuccess = new global::System.Windows.Forms.Label();
			this.label8 = new global::System.Windows.Forms.Label();
			this.lblChecked = new global::System.Windows.Forms.Label();
			this.label9 = new global::System.Windows.Forms.Label();
			this.lblEmailTime = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.lblEmailTimeThread = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.lblTotalUsers = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.lblStatus = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.grdResult).BeginInit();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(25, 30);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(102, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Exchange Address :";
			this.txtExchangeAddress.Location = new global::System.Drawing.Point(133, 27);
			this.txtExchangeAddress.Name = "txtExchangeAddress";
			this.txtExchangeAddress.Size = new global::System.Drawing.Size(944, 20);
			this.txtExchangeAddress.TabIndex = 0;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(28, 56);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(99, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Exchange Version :";
			this.cmbExchangeVersion.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbExchangeVersion.FormattingEnabled = true;
			this.cmbExchangeVersion.Location = new global::System.Drawing.Point(133, 53);
			this.cmbExchangeVersion.Name = "cmbExchangeVersion";
			this.cmbExchangeVersion.Size = new global::System.Drawing.Size(944, 21);
			this.cmbExchangeVersion.TabIndex = 1;
			this.txtUserPassFile.Location = new global::System.Drawing.Point(133, 107);
			this.txtUserPassFile.Name = "txtUserPassFile";
			this.txtUserPassFile.Size = new global::System.Drawing.Size(863, 20);
			this.txtUserPassFile.TabIndex = 2;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(47, 110);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(80, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Username File :";
			this.btnOpen.Location = new global::System.Drawing.Point(1002, 105);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new global::System.Drawing.Size(75, 23);
			this.btnOpen.TabIndex = 3;
			this.btnOpen.Text = "Open";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new global::System.EventHandler(this.btnOpen_Click);
			this.btnStart.Location = new global::System.Drawing.Point(1002, 183);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new global::System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 7;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new global::System.EventHandler(this.btnStart_Click);
			this.grdResult.AllowUserToAddRows = false;
			this.grdResult.AllowUserToDeleteRows = false;
			this.grdResult.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdResult.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.clnNumber,
				this.clnCurrentUsername,
				this.clnCurrentPassword,
				this.clnStatus,
				this.clnTotalCheck,
				this.clnTotalSuccess
			});
			this.grdResult.Location = new global::System.Drawing.Point(12, 266);
			this.grdResult.Name = "grdResult";
			this.grdResult.ReadOnly = true;
			this.grdResult.Size = new global::System.Drawing.Size(1106, 413);
			this.grdResult.TabIndex = 4;
			this.clnNumber.DataPropertyName = "pNumber";
			this.clnNumber.HeaderText = "Thread Number";
			this.clnNumber.Name = "clnNumber";
			this.clnNumber.ReadOnly = true;
			this.clnNumber.Width = 50;
			this.clnCurrentUsername.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clnCurrentUsername.DataPropertyName = "pCurrentUsername";
			this.clnCurrentUsername.HeaderText = "Current Username";
			this.clnCurrentUsername.Name = "clnCurrentUsername";
			this.clnCurrentUsername.ReadOnly = true;
			this.clnCurrentPassword.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clnCurrentPassword.DataPropertyName = "pCurrentPassword";
			this.clnCurrentPassword.HeaderText = "Current Password";
			this.clnCurrentPassword.Name = "clnCurrentPassword";
			this.clnCurrentPassword.ReadOnly = true;
			this.clnStatus.AutoSizeMode = global::System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clnStatus.DataPropertyName = "pStatus";
			this.clnStatus.HeaderText = "Status";
			this.clnStatus.Name = "clnStatus";
			this.clnStatus.ReadOnly = true;
			this.clnTotalCheck.DataPropertyName = "pTotalCheck";
			this.clnTotalCheck.HeaderText = "Email Checked";
			this.clnTotalCheck.Name = "clnTotalCheck";
			this.clnTotalCheck.ReadOnly = true;
			this.clnTotalSuccess.DataPropertyName = "pTotalSuccess";
			this.clnTotalSuccess.HeaderText = "Login Successful";
			this.clnTotalSuccess.Name = "clnTotalSuccess";
			this.clnTotalSuccess.ReadOnly = true;
			this.TimerMain.Tick += new global::System.EventHandler(this.TimerMain_Tick);
			this.groupBox1.Controls.Add(this.btnPassGenPerUser);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.btnGeneratePass);
			this.groupBox1.Controls.Add(this.btnPasswordOpen);
			this.groupBox1.Controls.Add(this.btnOpen);
			this.groupBox1.Controls.Add(this.btnStart);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cmbMethod);
			this.groupBox1.Controls.Add(this.cmbExchangeVersion);
			this.groupBox1.Controls.Add(this.txtUsernameEnd);
			this.groupBox1.Controls.Add(this.txtUsernameStart);
			this.groupBox1.Controls.Add(this.txtThreadCount);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Controls.Add(this.txtUserPassFile);
			this.groupBox1.Controls.Add(this.txtExchangeAddress);
			this.groupBox1.Location = new global::System.Drawing.Point(15, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(1103, 220);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input";
			this.btnPassGenPerUser.Location = new global::System.Drawing.Point(947, 157);
			this.btnPassGenPerUser.Name = "btnPassGenPerUser";
			this.btnPassGenPerUser.Size = new global::System.Drawing.Size(130, 23);
			this.btnPassGenPerUser.TabIndex = 8;
			this.btnPassGenPerUser.Text = "Generate Pass Per User";
			this.btnPassGenPerUser.UseVisualStyleBackColor = true;
			this.btnPassGenPerUser.Click += new global::System.EventHandler(this.btnPassGenPerUser_Click);
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(63, 83);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(65, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "BF Method :";
			this.btnGeneratePass.Location = new global::System.Drawing.Point(833, 157);
			this.btnGeneratePass.Name = "btnGeneratePass";
			this.btnGeneratePass.Size = new global::System.Drawing.Size(108, 23);
			this.btnGeneratePass.TabIndex = 5;
			this.btnGeneratePass.Text = "Generate Pass";
			this.btnGeneratePass.UseVisualStyleBackColor = true;
			this.btnGeneratePass.Click += new global::System.EventHandler(this.btnGeneratePass_Click);
			this.btnPasswordOpen.Location = new global::System.Drawing.Point(1002, 131);
			this.btnPasswordOpen.Name = "btnPasswordOpen";
			this.btnPasswordOpen.Size = new global::System.Drawing.Size(75, 23);
			this.btnPasswordOpen.TabIndex = 5;
			this.btnPasswordOpen.Text = "Open";
			this.btnPasswordOpen.UseVisualStyleBackColor = true;
			this.btnPasswordOpen.Click += new global::System.EventHandler(this.btnPasswordOpen_Click);
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(513, 188);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(117, 13);
			this.label15.TabIndex = 0;
			this.label15.Text = "Add to Username End :";
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(7, 188);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(120, 13);
			this.label14.TabIndex = 0;
			this.label14.Text = "Add to Username Start :";
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(23, 162);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(104, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Number of Threads :";
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(50, 136);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(78, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Password File :";
			this.cmbMethod.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMethod.FormattingEnabled = true;
			this.cmbMethod.Items.AddRange(new object[]
			{
				"EWS",
				"OAB",
				"Full"
			});
			this.cmbMethod.Location = new global::System.Drawing.Point(133, 80);
			this.cmbMethod.Name = "cmbMethod";
			this.cmbMethod.Size = new global::System.Drawing.Size(944, 21);
			this.cmbMethod.TabIndex = 1;
			this.txtUsernameEnd.Location = new global::System.Drawing.Point(636, 185);
			this.txtUsernameEnd.Name = "txtUsernameEnd";
			this.txtUsernameEnd.Size = new global::System.Drawing.Size(360, 20);
			this.txtUsernameEnd.TabIndex = 6;
			this.txtUsernameStart.Location = new global::System.Drawing.Point(133, 185);
			this.txtUsernameStart.Name = "txtUsernameStart";
			this.txtUsernameStart.Size = new global::System.Drawing.Size(370, 20);
			this.txtUsernameStart.TabIndex = 6;
			this.txtThreadCount.Location = new global::System.Drawing.Point(133, 159);
			this.txtThreadCount.Name = "txtThreadCount";
			this.txtThreadCount.Size = new global::System.Drawing.Size(694, 20);
			this.txtThreadCount.TabIndex = 6;
			this.txtPassword.Location = new global::System.Drawing.Point(133, 133);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new global::System.Drawing.Size(863, 20);
			this.txtPassword.TabIndex = 4;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(376, 242);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(36, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Time :";
			this.lblTimer.AutoSize = true;
			this.lblTimer.Location = new global::System.Drawing.Point(413, 242);
			this.lblTimer.Name = "lblTimer";
			this.lblTimer.Size = new global::System.Drawing.Size(49, 13);
			this.lblTimer.TabIndex = 7;
			this.lblTimer.Text = "00:00:00";
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(206, 242);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(121, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Total Login Successful :";
			this.lblSuccess.AutoSize = true;
			this.lblSuccess.Location = new global::System.Drawing.Point(328, 242);
			this.lblSuccess.Name = "lblSuccess";
			this.lblSuccess.Size = new global::System.Drawing.Size(13, 13);
			this.lblSuccess.TabIndex = 7;
			this.lblSuccess.Text = "0";
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(12, 242);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(111, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Total Email Checked :";
			this.lblChecked.AutoSize = true;
			this.lblChecked.Location = new global::System.Drawing.Point(124, 242);
			this.lblChecked.Name = "lblChecked";
			this.lblChecked.Size = new global::System.Drawing.Size(13, 13);
			this.lblChecked.TabIndex = 7;
			this.lblChecked.Text = "0";
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(520, 242);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(93, 13);
			this.label9.TabIndex = 6;
			this.label9.Text = "Email check time :";
			this.lblEmailTime.AutoSize = true;
			this.lblEmailTime.Location = new global::System.Drawing.Point(614, 242);
			this.lblEmailTime.Name = "lblEmailTime";
			this.lblEmailTime.Size = new global::System.Drawing.Size(10, 13);
			this.lblEmailTime.TabIndex = 6;
			this.lblEmailTime.Text = "-";
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(657, 242);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(148, 13);
			this.label11.TabIndex = 6;
			this.label11.Text = "Email check time per Thread :";
			this.lblEmailTimeThread.AutoSize = true;
			this.lblEmailTimeThread.Location = new global::System.Drawing.Point(806, 242);
			this.lblEmailTimeThread.Name = "lblEmailTimeThread";
			this.lblEmailTimeThread.Size = new global::System.Drawing.Size(10, 13);
			this.lblEmailTimeThread.TabIndex = 6;
			this.lblEmailTimeThread.Text = "-";
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(843, 242);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(79, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "Remain Users :";
			this.lblTotalUsers.AutoSize = true;
			this.lblTotalUsers.Location = new global::System.Drawing.Point(923, 242);
			this.lblTotalUsers.Name = "lblTotalUsers";
			this.lblTotalUsers.Size = new global::System.Drawing.Size(10, 13);
			this.lblTotalUsers.TabIndex = 6;
			this.lblTotalUsers.Text = "-";
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(959, 242);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(43, 13);
			this.label12.TabIndex = 6;
			this.label12.Text = "Status :";
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new global::System.Drawing.Point(1003, 242);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new global::System.Drawing.Size(10, 13);
			this.lblStatus.TabIndex = 6;
			this.lblStatus.Text = "-";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1129, 691);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.lblEmailTime);
			base.Controls.Add(this.lblEmailTimeThread);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.lblTotalUsers);
			base.Controls.Add(this.lblStatus);
			base.Controls.Add(this.label12);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.lblChecked);
			base.Controls.Add(this.lblSuccess);
			base.Controls.Add(this.lblTimer);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.grdResult);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "Form1";
			this.Text = "Jason - Exchange Mail BF - v 7.0";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			((global::System.ComponentModel.ISupportInitialize)this.grdResult).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000009 RID: 9
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000A RID: 10
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400000B RID: 11
		private global::System.Windows.Forms.TextBox txtExchangeAddress;

		// Token: 0x0400000C RID: 12
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400000D RID: 13
		private global::System.Windows.Forms.ComboBox cmbExchangeVersion;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.TextBox txtUserPassFile;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.Button btnOpen;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Button btnStart;

		// Token: 0x04000012 RID: 18
		private global::System.Windows.Forms.DataGridView grdResult;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Timer TimerMain;

		// Token: 0x04000014 RID: 20
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000015 RID: 21
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.Label lblTimer;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button btnPasswordOpen;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.TextBox txtPassword;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.Label lblSuccess;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.TextBox txtThreadCount;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label lblChecked;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.DataGridViewTextBoxColumn clnNumber;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.DataGridViewTextBoxColumn clnCurrentUsername;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.DataGridViewTextBoxColumn clnCurrentPassword;

		// Token: 0x04000023 RID: 35
		private global::System.Windows.Forms.DataGridViewTextBoxColumn clnStatus;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.DataGridViewTextBoxColumn clnTotalCheck;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.DataGridViewTextBoxColumn clnTotalSuccess;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.Label lblEmailTime;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.Label lblEmailTimeThread;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Label lblTotalUsers;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400002D RID: 45
		private global::System.Windows.Forms.Label lblStatus;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.ComboBox cmbMethod;

		// Token: 0x04000030 RID: 48
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04000031 RID: 49
		private global::System.Windows.Forms.Label label14;

		// Token: 0x04000032 RID: 50
		private global::System.Windows.Forms.TextBox txtUsernameEnd;

		// Token: 0x04000033 RID: 51
		private global::System.Windows.Forms.TextBox txtUsernameStart;

		// Token: 0x04000034 RID: 52
		private global::System.Windows.Forms.Button btnGeneratePass;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Button btnPassGenPerUser;
	}
}
