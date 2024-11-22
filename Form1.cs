using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;


namespace blockChain
{
    public partial class Form1 : Form
    {
        const string ip = "127.0.0.1";
        List<NetworkStream> peers = new List<NetworkStream>();
        TcpListener server;
        EndPoint address;
        BlockChain chain;
        int diff = 5;
        string node;

        public void setEnable()
        {
            ConnectButton.Enabled = false;
            NodeBox.Enabled = false;
            MineButton.Enabled = true;
            PortButton.Enabled = true;
            PortBox.Enabled = true;
        }
        public Form1()
        {
            InitializeComponent();
            FormClosing += Form1_FormClosing;
        }

        static byte[] recieveMsg(NetworkStream ns)
        {
            try
            {
                byte[] buffer = new byte[1024];
                MemoryStream data = new MemoryStream();
                int bytesRead = ns.Read(buffer, 0, 1024);

                while (bytesRead > 0)
                {
                    data.Write(buffer, 0, bytesRead);
                    if (ns.DataAvailable)
                    {
                        bytesRead = ns.Read(buffer, 0, 1024);
                    }
                    else break;
                }
                return data.ToArray();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Napaka pri prejemanju");
                return null;
            }
        }

        static bool sendMsg(NetworkStream ns, byte[] msg)
        {
            try
            {
                ns.Write(msg, 0, msg.Length);
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Napaka pri pošiljanju");
                return false;
            }
        }

        public void acceptClientFunc(object o)
        {
            try
            {
                NetworkStream ns = (NetworkStream)o;
                byte[] bts;
                string data;
                BlockChain other;
                bts = recieveMsg(ns);
                while (bts != null)
                {
                    data = Encoding.UTF8.GetString(bts);
                    //preverimo če je chain dober;
                    other = JsonConvert.DeserializeObject<BlockChain>(data);
                    if (other == null) break;
                    if (other.Validate()) {
                        if (other.comulative() > chain.comulative()) {
                            chain = other;
                        }
                    }
                    bts = recieveMsg(ns);
                }
                ns.Close();
            }
            catch (Exception e) { }

        }

        public void ListenThreadFunction()
        {
            try
            {
                server = new TcpListener(IPAddress.Parse(ip), 0);
                server.Start();
                address = server.LocalEndpoint;
                Invoke(new Action(() =>
                {
                    PortLabel.Text = address.ToString();
                }));

                while (true)
                {
                    //System.Diagnostics.Debug.WriteLine("Čakam na client");
                    TcpClient client = server.AcceptTcpClient();
                    NetworkStream ns = client.GetStream();
                    //System.Diagnostics.Debug.WriteLine("dobil clienta");
                    Thread t = new Thread(acceptClientFunc);
                    t.IsBackground = true;
                    t.Start(ns);

                }
            }
            catch (Exception e) { }
        }

        public void MineThreadFunction()
        {
            try
            {
                while (true)
                {
                    chain.MineBlock();
                    Invoke(new Action(() =>
                    {
                        HashListBox.Items.Add(chain.Chain.Last().Hash);
                    }));
                }
            }
            catch (Exception e) { }

        }

        public void sync()
        {
            while (true)
            {
                Thread.Sleep(7000);
                for (int i = 0; i < peers.Count; i++)
                {
                    string json = JsonConvert.SerializeObject(chain);
                    if(!sendMsg(peers[i], Encoding.UTF8.GetBytes(json))) { peers[i].Close();  peers.RemoveAt(i); }

                }
                Invoke(new Action(() =>
                {
                    ChainListBox.Items.Clear();

                    for (int i = 0; i < chain.Chain.Count; i++)
                    {
                        Block temp = chain.Chain[i];
                        ChainListBox.Items.Add("Hash: " + temp.Hash);
                        ChainListBox.Items.Add("Index: " + temp.Index);
                        ChainListBox.Items.Add("Timestamp: " + temp.Timestamp);
                        ChainListBox.Items.Add("Difficulty: " + temp.Diff);
                        ChainListBox.Items.Add("Prev hash: " + temp.PrevHash);
                        ChainListBox.Items.Add("");
                        ChainListBox.TopIndex = ChainListBox.Items.Count - 1;
                    }
                }));
            }
        }

        public void sendThreadFunc() {
            try
            {
                TcpClient temp;
                string text = PortBox.Text;
                temp = new TcpClient(ip, Int32.Parse(text));
                NetworkStream ns = temp.GetStream();
                peers.Add(ns);
                
            }
            catch (Exception)
            {
                Invoke(new Action(() =>
                {
                    HashListBox.Items.Add("Povezava ni mogoča");
                }));
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try {
                if (NodeBox.Text != "") {
                    node = NodeBox.Text;
                    setEnable();
                    chain = new BlockChain(diff);
                    Thread listen = new Thread(ListenThreadFunction);
                    listen.Name = "listen";
                    listen.IsBackground = true;
                    listen.Start();
       
                    Thread syncThread = new Thread(sync);
                    syncThread.Name = "sync";
                    syncThread.IsBackground = true;
                    syncThread.Start();
                }
            }
            catch (Exception) { }
        }

        private void PortButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = PortBox.Text;
                if (text != "")
                {
                    Thread tmp = new Thread(sendThreadFunc);
                    tmp.IsBackground = true;
                    tmp.Start();
                }
            }
            catch (Exception) {
                HashListBox.Items.Add("Povezava ni mogoča");
            }
        }

        private void MineButton_Click(object sender, EventArgs e)
        {
            try
            {       
                MineButton.Enabled = false;
                Thread t = new Thread(MineThreadFunction);
                t.Name = "mine";
                t.IsBackground = true;
                t.Start();
            }
            catch (Exception)
            {
                
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (NetworkStream peer in peers) {
                peer.Close();
            }
            server.Stop();
        }

    }

    public class Block { 
        public int Index { get; set; }
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }
        public string Hash { get; set; }
        public string PrevHash { get; set; }
        public long Nonce { get; set; }
        public int Diff { get; set; }

        public Block(int i, string data, DateTime time, int diff, string prev = "") {
            Index = i;
            Data = data;
            Timestamp = time;
            PrevHash = prev;
            Hash = "";
            Nonce = 0;
            Diff = diff;
        }

        public bool TestHash() {
            int i = 0;
            while (Hash[i] == '0') {
                i++;
            }
            if (i >= Diff) return true;
            return false;
        }

        public void Mine() {
            while (true) {
                Hash = CalculateHash();
                if (TestHash()) {
                    return; 
                }
                else Nonce++;
            }
        }
        public string CalculateHash()
        {
            using (SHA256 sha = SHA256.Create())
            {
                StringBuilder Sb = new StringBuilder();
                Byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(Index.ToString() + Timestamp + Data + PrevHash + Diff.ToString() + Nonce.ToString()));
                foreach (Byte b in bytes) Sb.Append(b.ToString("x2"));
                return Sb.ToString();
            }
        }
    }
    public class BlockChain {
        public int Diff { get; set; }
        public List<Block> Chain = new List<Block>();
        public BlockChain(int d) {
            Diff = d;
            Block first = new Block(0, "to je blok 0", DateTime.Now, d, "0");
            first.Hash = "1234";
            Chain.Add(first);
        }
        public void MineBlock()
        {
            Block last = Chain.Last();
            int index = last.Index + 1;
            Block temp = new Block(index, "to je blok " + index.ToString(), DateTime.Now, Diff, Chain.Last().Hash);
            temp.Mine();
            Chain.Add(temp);
        }

        public bool Validate() {
            for (int i = 1; i < Chain.Count; i++) {
                Block current = Chain[i];
                Block prev = Chain[i - 1];
                if (current.Index - 1 != prev.Index || current.PrevHash != prev.Hash ||
                    current.CalculateHash() != current.Hash) return false;
            }
            return true;
        }

        public double comulative() {
            double res = 0;
            for (int i = 0; i < Chain.Count; i++) {
                res += Math.Pow(2, Chain[i].Diff);
            }
            return res;
        }
    }
}
