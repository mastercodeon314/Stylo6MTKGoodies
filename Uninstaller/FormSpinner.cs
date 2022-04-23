using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stylo6MTKGoodiesInstaller
{
	public class FormSpinner
	{
		/*
		 * https://github.com/sindresorhus/cli-spinners/blob/main/spinners.json
		 *
		 * https://jsbin.com/tofehujixe/1/edit?js,output
		 * https://www.npmjs.com/package/cli-spinners
		 * https://www.fileformat.info/info/unicode/block/braille_patterns/images.htm
		 */

		#region Spinners

		public static string[] Dots =
		{
			"⠋",
			"⠙",
			"⠹",
			"⠸",
			"⠼",
			"⠴",
			"⠦",
			"⠧",
			"⠇",
			"⠏"
		};

		public static string[] Dots2 =
		{
			"⣾",
			"⣽",
			"⣻",
			"⢿",
			"⡿",
			"⣟",
			"⣯",
			"⣷"
		};

		public static string[] Dots3 =
		{
			"⠋",
			"⠙",
			"⠚",
			"⠞",
			"⠖",
			"⠦",
			"⠴",
			"⠲",
			"⠳",
			"⠓"
		};

		public static string[] Dots4 =
		{
			"⠄",
			"⠆",
			"⠇",
			"⠋",
			"⠙",
			"⠸",
			"⠰",
			"⠠",
			"⠰",
			"⠸",
			"⠙",
			"⠋",
			"⠇",
			"⠆"
		};

		public static string[] Dots5 =
		{
			"⠋",
			"⠙",
			"⠚",
			"⠒",
			"⠂",
			"⠂",
			"⠒",
			"⠲",
			"⠴",
			"⠦",
			"⠖",
			"⠒",
			"⠐",
			"⠐",
			"⠒",
			"⠓",
			"⠋"
		};

		public static string[] Dots8Bit =
		{
			"⠀",
			"⠁",
			"⠂",
			"⠃",
			"⠄",
			"⠅",
			"⠆",
			"⠇",
			"⡀",
			"⡁",
			"⡂",
			"⡃",
			"⡄",
			"⡅",
			"⡆",
			"⡇",
			"⠈",
			"⠉",
			"⠊",
			"⠋",
			"⠌",
			"⠍",
			"⠎",
			"⠏",
			"⡈",
			"⡉",
			"⡊",
			"⡋",
			"⡌",
			"⡍",
			"⡎",
			"⡏",
			"⠐",
			"⠑",
			"⠒",
			"⠓",
			"⠔",
			"⠕",
			"⠖",
			"⠗",
			"⡐",
			"⡑",
			"⡒",
			"⡓",
			"⡔",
			"⡕",
			"⡖",
			"⡗",
			"⠘",
			"⠙",
			"⠚",
			"⠛",
			"⠜",
			"⠝",
			"⠞",
			"⠟",
			"⡘",
			"⡙",
			"⡚",
			"⡛",
			"⡜",
			"⡝",
			"⡞",
			"⡟",
			"⠠",
			"⠡",
			"⠢",
			"⠣",
			"⠤",
			"⠥",
			"⠦",
			"⠧",
			"⡠",
			"⡡",
			"⡢",
			"⡣",
			"⡤",
			"⡥",
			"⡦",
			"⡧",
			"⠨",
			"⠩",
			"⠪",
			"⠫",
			"⠬",
			"⠭",
			"⠮",
			"⠯",
			"⡨",
			"⡩",
			"⡪",
			"⡫",
			"⡬",
			"⡭",
			"⡮",
			"⡯",
			"⠰",
			"⠱",
			"⠲",
			"⠳",
			"⠴",
			"⠵",
			"⠶",
			"⠷",
			"⡰",
			"⡱",
			"⡲",
			"⡳",
			"⡴",
			"⡵",
			"⡶",
			"⡷",
			"⠸",
			"⠹",
			"⠺",
			"⠻",
			"⠼",
			"⠽",
			"⠾",
			"⠿",
			"⡸",
			"⡹",
			"⡺",
			"⡻",
			"⡼",
			"⡽",
			"⡾",
			"⡿",
			"⢀",
			"⢁",
			"⢂",
			"⢃",
			"⢄",
			"⢅",
			"⢆",
			"⢇",
			"⣀",
			"⣁",
			"⣂",
			"⣃",
			"⣄",
			"⣅",
			"⣆",
			"⣇",
			"⢈",
			"⢉",
			"⢊",
			"⢋",
			"⢌",
			"⢍",
			"⢎",
			"⢏",
			"⣈",
			"⣉",
			"⣊",
			"⣋",
			"⣌",
			"⣍",
			"⣎",
			"⣏",
			"⢐",
			"⢑",
			"⢒",
			"⢓",
			"⢔",
			"⢕",
			"⢖",
			"⢗",
			"⣐",
			"⣑",
			"⣒",
			"⣓",
			"⣔",
			"⣕",
			"⣖",
			"⣗",
			"⢘",
			"⢙",
			"⢚",
			"⢛",
			"⢜",
			"⢝",
			"⢞",
			"⢟",
			"⣘",
			"⣙",
			"⣚",
			"⣛",
			"⣜",
			"⣝",
			"⣞",
			"⣟",
			"⢠",
			"⢡",
			"⢢",
			"⢣",
			"⢤",
			"⢥",
			"⢦",
			"⢧",
			"⣠",
			"⣡",
			"⣢",
			"⣣",
			"⣤",
			"⣥",
			"⣦",
			"⣧",
			"⢨",
			"⢩",
			"⢪",
			"⢫",
			"⢬",
			"⢭",
			"⢮",
			"⢯",
			"⣨",
			"⣩",
			"⣪",
			"⣫",
			"⣬",
			"⣭",
			"⣮",
			"⣯",
			"⢰",
			"⢱",
			"⢲",
			"⢳",
			"⢴",
			"⢵",
			"⢶",
			"⢷",
			"⣰",
			"⣱",
			"⣲",
			"⣳",
			"⣴",
			"⣵",
			"⣶",
			"⣷",
			"⢸",
			"⢹",
			"⢺",
			"⢻",
			"⢼",
			"⢽",
			"⢾",
			"⢿",
			"⣸",
			"⣹",
			"⣺",
			"⣻",
			"⣼",
			"⣽",
			"⣾",
			"⣿"
		};

		public static string[] Dots9 =
		{
			"⢹",
			"⢺",
			"⢼",
			"⣸",
			"⣇",
			"⡧",
			"⡗",
			"⡏"
		};

		public static string[] Dots10 =
		{
			"⢄",
			"⢂",
			"⢁",
			"⡁",
			"⡈",
			"⡐",
			"⡠"
		};

		public static string[] Dots11 =
		{
			"⠁",
			"⠂",
			"⠄",
			"⡀",
			"⢀",
			"⠠",
			"⠐",
			"⠈"
		};

		public static string[] Dots12 =
		{
			"⢀⠀",
			"⡀⠀",
			"⠄⠀",
			"⢂⠀",
			"⡂⠀",
			"⠅⠀",
			"⢃⠀",
			"⡃⠀",
			"⠍⠀",
			"⢋⠀",
			"⡋⠀",
			"⠍⠁",
			"⢋⠁",
			"⡋⠁",
			"⠍⠉",
			"⠋⠉",
			"⠋⠉",
			"⠉⠙",
			"⠉⠙",
			"⠉⠩",
			"⠈⢙",
			"⠈⡙",
			"⢈⠩",
			"⡀⢙",
			"⠄⡙",
			"⢂⠩",
			"⡂⢘",
			"⠅⡘",
			"⢃⠨",
			"⡃⢐",
			"⠍⡐",
			"⢋⠠",
			"⡋⢀",
			"⠍⡁",
			"⢋⠁",
			"⡋⠁",
			"⠍⠉",
			"⠋⠉",
			"⠋⠉",
			"⠉⠙",
			"⠉⠙",
			"⠉⠩",
			"⠈⢙",
			"⠈⡙",
			"⠈⠩",
			"⠀⢙",
			"⠀⡙",
			"⠀⠩",
			"⠀⢘",
			"⠀⡘",
			"⠀⠨",
			"⠀⢐",
			"⠀⡐",
			"⠀⠠",
			"⠀⢀",
			"⠀⡀"
		};

		public static string[] Progress7 =
		{
			"▰▱▱▱▱▱▱",
			"▰▰▱▱▱▱▱",
			"▰▰▰▱▱▱▱",
			"▰▰▰▰▱▱▱",
			"▰▰▰▰▰▱▱",
			"▰▰▰▰▰▰▱",
			"▰▰▰▰▰▰▰",
			"▰▱▱▱▱▱▱"
		};

		public static string[] Progress10 =
		{
			"▰▱▱▱▱▱▱▱▱▱",
			"▰▰▱▱▱▱▱▱▱▱",
			"▰▰▰▱▱▱▱▱▱▱",
			"▰▰▰▰▱▱▱▱▱▱",
			"▰▰▰▰▰▱▱▱▱▱",
			"▰▰▰▰▰▰▱▱▱▱",
			"▰▰▰▰▰▰▰▱▱▱",
			"▰▰▰▰▰▰▰▰▱▱",
			"▰▰▰▰▰▰▰▰▰▱",
			"▰▰▰▰▰▰▰▰▰▰",
			"▰▱▱▱▱▱▱▱▱▱"
		};

		public static string[] Line =
		{
			"-",
			"\\",
			"|",
			"/"
		};

		#endregion

		public Form frmWindow { get; set; }

		public bool InvokeRequired
		{
			get
			{
				if (frmWindow != null) return frmWindow.InvokeRequired;
				else return false;
			}
		}

        public FormSpinner(Form frm)
	    {
		    this.frmWindow = frm;
		    this.formOldText = this.frmWindow.Text;
	    }

	    private delegate void setFormTextDelegate(string text);
	    private void setFormText(string text)
	    {
		    if (this.frmWindow.InvokeRequired)
		    {
			    var d = new setFormTextDelegate(setFormText);
			    this.frmWindow.Invoke(d, new object[] { text });
		    }
		    else
		    {
			    this.frmWindow.Text = text;
		    }
	    }

	    private CancellationTokenSource _cancelToken;
		public bool IsRunning = false;

		private string formOldText = String.Empty;

		public void Start()
		{
			formOldText = this.frmWindow.Text;
			_cancelToken = new CancellationTokenSource();
			this.IsRunning = true;
			Queue(_cancelToken);
		}

		public void Stop()
		{
			if (_cancelToken != null && this.IsRunning == true)
			{
				this.IsRunning = false;
				_cancelToken.Cancel();
				
				setFormText(formOldText);
			}
		}

		public void Reset()
		{
			if (_cancelToken != null && this.IsRunning == true)
			{
				this.Stop();
				
				this.Start();
			}
		}


		public string[] Current { get; set; } = Dots2;

		public TimeSpan Duration { get; set; } = TimeSpan.FromMilliseconds(80);

		public void ForTask(Task t)
		{
			var cts = new CancellationTokenSource();
			Queue(cts);
			// ReSharper disable once MethodSupportsCancellation
			t.Wait();
			cts.Cancel();
			cts.Dispose();
		}

		public void Queue(CancellationTokenSource cts)
		{
			// Pass the token to the cancelable operation.
			ThreadPool.QueueUserWorkItem(Show, cts.Token);
		}

		public void Show(object obj)
		{
			var token = (CancellationToken) obj;

			while (!token.IsCancellationRequested)
			{
				foreach (string t in Current) 
				{
					if (token.IsCancellationRequested)
					{
						break;
					}
					
					this.setFormText($"{this.formOldText} \r{t}");

					Thread.Sleep(Duration);
				}
			}
			
			setFormText(this.formOldText);
		}
	}
}