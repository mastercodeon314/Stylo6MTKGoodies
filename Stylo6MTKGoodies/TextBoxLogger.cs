using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stylo6MTKGoodies
{
    public class TextBoxLogger
    {
        private TextBox Output;
        private RichTextBox r_Output;

        private bool usingRichOutput = false;

        public TextBoxLogger(TextBox output)
        {
            this.Output = output;
        }

        public TextBoxLogger(RichTextBox output)
        {
            this.r_Output = output;
            usingRichOutput = true;
        }



        private delegate void SafeCallDelegate(string x);
        private delegate void SafeCallDelegateClear();

        public void Log(string x)
        {
            if (usingRichOutput)
            {
                if (r_Output.InvokeRequired)
                {
                    var d = new SafeCallDelegate(Log);
                    r_Output.Invoke(d, new object[] { x });
                }
                else
                {
                    r_Output.AppendText(x.Replace("â–ˆ", "█"));
                    r_Output.Select(r_Output.Text.Length, 0);
                    r_Output.Update();
                    
                }
            }
            else
            {
                if (Output.InvokeRequired)
                {
                    var d = new SafeCallDelegate(Log);
                    Output.Invoke(d, new object[] { x });
                }
                else
                {
                    Output.AppendText(x.Replace("â–ˆ", "█"));
                }
            }

        }

        public void Clear()
        {
            if (usingRichOutput)
            {
                if (r_Output.InvokeRequired)
                {
                    var d = new SafeCallDelegateClear(Clear);
                    r_Output.Invoke(d);
                }
                else
                {
                    r_Output.Clear();
                }
            }
            else
            {
                if (Output.InvokeRequired)
                {
                    var d = new SafeCallDelegateClear(Clear);
                    Output.Invoke(d);
                }
                else
                {
                    Output.Clear();
                }
            }
        }

        public void Log(byte[] x)
        {
            StringBuilder b = new StringBuilder();
            b.Append("{ ");

            for (int i = 0; i < x.Length; i++)
            {
                b.Append(x[i].ToString("X2"));

                if (i < x.Length - 1)
                {
                    b.Append(", ");
                }
            }

            b.Append(" }");

            this.Log(b.ToString());
        }
    }
}
