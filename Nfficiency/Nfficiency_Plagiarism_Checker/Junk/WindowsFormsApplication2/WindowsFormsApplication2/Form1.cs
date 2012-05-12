using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            String S = txtIn.Text;
            String[] x = S.Split(' ');
            Int32 h = 0;
            UInt64 H = 0;
            String[] v = new String[5];
            UInt64 count = 0;
            int mod = UInt16.MaxValue;
            String[] table = new String[mod];
            LinkedList<String> cList = new LinkedList<String>();
            String o="";


            for (int j = 0; j < mod; j++)
            {
                table[j] = " ";
            }

            int collision = 0;
            UInt16 compress = 0;

            lblOut.Text = "";

            int i = 0;
            foreach (String n in x)
            {

                if (n != "")
                {
                    if (i == 5)
                    {
                        h -= v[0].GetHashCode();
                        //H -= UInt64.Parse((UInt32.MaxValue - v[0].GetHashCode()).ToString());
                        for (int z = 0; z < 4; z++)
                        {
                            v[z] = v[z + 1];
                        }
                        i = 4;
                    }
                    string s = n.ToUpper();
                    h += s.GetHashCode();//attempt to use string.gethash as rolling hash
                    //H += UInt64.Parse((UInt32.MaxValue-s.GetHashCode()).ToString());
                    v[i] = s;
                    i++;
                    o = v[0] + v[1] + v[2] + v[3] + v[4];
                    if (table[Math.Abs(h) % mod] == " ")
                    {
                        table[Math.Abs(h) % mod] = o;

                    }
                    else
                    {
                        cList.AddFirst(o);
                        collision++;
                    }

                    lblOut.Text += h.ToString() + " " + o + '\n';

                }


                LinkedListNode<String> testing;
                testing = cList.First;
                while (testing != null)
                {
                    o += testing.Value;
                    testing = testing.Next;
                }
                lblCol.Text = collision.ToString()+o;

            }


        }


    }
}
