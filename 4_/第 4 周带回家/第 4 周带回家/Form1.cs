using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace 第4周带回家
{
    public partial class 表格1 : Form
    {
        List<Team> 队伍名单 = new List<Team>();

        public 表格1()
        {
            InitializeComponent();

            string[] 一系列国家 = { "中国", "中国", "日本" };
            string[] 一系列城市 = { "北京", "沧州", "東京" };
            string[] 团队名称数组 = { "北京国安", "沧州威狮", "サムライ・ブルー" };
            string[] 衬衫后面的号码 = { "01", "02", "03", "05", "09", "10", "13", "15", "18", "21", "24", "27" };
            string[] 球员的位置 = { "GK", "DF", "DF", "DF", "MF", "MF", "MF", "MF", "FF", "FW", "FW", "FW" };

            for (int 我 = 0; 我 < 3; 我++)
            {
                Team team = new Team();
                team.teamCountry = 一系列国家[我];
                team.teamCity = 一系列城市[我];
                team.teamName = 团队名称数组[我];
                List<Player> 球员名单 = new List<Player>();
                for (int 杰 = 0; 杰 < 12; 杰++)
                {
                    string[] 北京国安玩家 = { "张玉宁", "池忠国", "玉稀国", "张稀哲", "李磊", "于大宝", "王刚", "金敏载", "周彭", "侯永永", "王子铭", "严鼎皓" };
                    string[] 沧州威狮玩家 = { "刘军帅", "杨博文", "杨超", "杨超良", "陈柏良", "高梦", "王伟", "杨王磊", "张瑞", "刘永昌", "刘军宁", "刘旭" };
                    string[] サムライブルー玩家 = { "田中太郎", "山田花子", "鈴木健太", "高橋美希", "佐藤大介", " 藤大伊", "伊藤真理", "渡辺雅人", "中村亮介", "小林愛子", "斎藤大輔", "岡田みどり" };
                    Player 玩家 = new Player();
                    if (我 == 0)
                    {
                        玩家.playerName = 北京国安玩家[杰];
                    }
                    else if (我 == 1)
                    {
                        玩家.playerName = 沧州威狮玩家[杰];
                    }
                    else
                    {
                        玩家.playerName = サムライブルー玩家[杰];
                    }
                    玩家.playerNum = 衬衫后面的号码[杰];
                    玩家.playerPos = 球员的位置[杰];
                    球员名单.Add(玩家);
                }
                team.Players = 球员名单;
                队伍名单.Add(team);
            }

            for (int k = 0; k < 队伍名单.Count; k++)
            {
                if (!国家地区的组合框.Items.Contains(队伍名单[k].teamCountry))
                {
                    国家地区的组合框.Items.Add(队伍名单[k].teamCountry);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            重置团队();
        }

        private void 重置团队()
        {
            城市组合框.Items.Clear();
            城市组合框.Text = "";
            for (int i = 0; i < 队伍名单.Count; i++)
            {
                string country = 国家地区的组合框.SelectedItem.ToString();
                if (队伍名单[i].teamCountry == country)
                {
                    城市组合框.Items.Add(队伍名单[i].teamName);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            重置列表框();
        }

        private void 重置列表框()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < 队伍名单.Count; i++)
            {
                string team = 城市组合框.SelectedItem.ToString();
                if (队伍名单[i].teamName == team)
                {
                    for (int j = 0; j < 队伍名单[i].Players.Count; j++)
                    {
                        string nama = 队伍名单[i].Players[j].playerName;
                        string nom = 队伍名单[i].Players[j].playerNum;
                        string pos = 队伍名单[i].Players[j].playerPos;
                        listBox1.Items.Add("(" + nom + ") " + nama + "," + pos);
                    }
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool allow = true;
            if (国家地区文本框.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                for(int i = 0; i < 队伍名单.Count; i++)
                {
                    if (队伍名单[i].teamName == textBox2.Text)
                    {
                        MessageBox.Show("Team already has been added");
                        break;
                        allow = true;
                    }
                }
                if (allow)
                {
                    Team team = new Team();
                    team.teamCountry = 国家地区文本框.Text;
                    team.teamName = textBox2.Text;
                    team.teamCity = textBox3.Text;
                    List<Player> playerlist = new List<Player>();
                    team.Players = playerlist;
                    队伍名单.Add(team);

                    国家地区文本框.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show("please fill the textbox");
            }

            for (int o = 0; o < 队伍名单.Count; o++)
            {
                if (国家地区的组合框.Items.Contains(队伍名单[o].teamCountry))
                {

                }
                else
                {
                    国家地区的组合框.Items.Add(队伍名单[o].teamCountry);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 队伍名单.Count; i++)
            {
                string team = 城市组合框.SelectedItem.ToString();
                if (队伍名单[i].teamName == team && 队伍名单[i].Players.Count > 11)
                {
                    队伍名单[i].Players.Remove(队伍名单[i].Players[listBox1.SelectedIndex]);
                    break;
                }
                else if (队伍名单[i].Players.Count <= 11)
                {
                    MessageBox.Show("Too low members");
                    break;
                }
                
            }
            重置列表框();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] Posisi = { "GK", "DF", "MF", "FW" };
            string nama = textBox4.Text;
            string nom = textBox5.Text;
            string pos = Posisi[comboBox3.SelectedIndex];

            if (nama != "" && nom != "" && comboBox3.SelectedIndex != -1)
            {
                if (国家地区的组合框.SelectedIndex != -1 && 城市组合框.SelectedIndex != -1)
                {
                    for (int i = 0; i < 队伍名单.Count; i++)
                    {
                        string team = 城市组合框.SelectedItem.ToString();
                        if (队伍名单[i].teamName == team)
                        {
                            bool cek2 = true;
                            for(int k = 0; k < 队伍名单[i].Players.Count; k++)
                            {
                                if (队伍名单[i].Players[k].playerName == nama)
                                {
                                    cek2 = false;
                                } 
                            }
                            if (cek2)
                            {
                                Player player = new Player();
                                player.playerName = nama;
                                player.playerNum = nom;
                                player.playerPos = pos;
                                队伍名单[i].Players.Add(player);
                                listBox1.Items.Add("(" + nom + ") " + nama + "," + pos);
                            }
                            else
                            {
                                MessageBox.Show("player already exist");
                            }
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the team");
                }
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox3.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("please fill the textbox");
            }
        }
    }
}
