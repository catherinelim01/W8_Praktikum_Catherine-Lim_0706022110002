using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace W8_Praktikum_Catherine_Lim_0706022110002
{
    public partial class HasilPertandingan : Form
    {
        public static string sqlConnection = "server=localhost;uid=root; pwd=;database=premier_league";
        public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection);
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        public string sqlQuery;

        public HasilPertandingan()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnect.Open();
            DataTable dtTeamHome = new DataTable();
            DataTable dtTeamAway = new DataTable();
          
            sqlQuery = "SELECT team_name as `NamaTim`, team_id as `ID Team` FROM team";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTeamHome);

            sqlQuery = "SELECT team_name as `NamaTim`, team_id as `ID Team` FROM team";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTeamAway);

            comboBox_Tim1.DataSource = dtTeamHome;
            comboBox_Tim2.DataSource = dtTeamAway;

            comboBox_Tim1.DisplayMember = "NamaTim";
            comboBox_Tim1.ValueMember = "NamaTim";

            comboBox_Tim2.DisplayMember = "NamaTim";
            comboBox_Tim2.ValueMember = "NamaTim";
        }

        private void comboBox_Tim1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            DataTable dtPlayer = new DataTable();
            sqlQuery = "select m.manager_id, m.manager_name, t.team_id, t.captain_id, p.player_name, team_name, t.home_stadium, t.capacity from manager m, team t, player p where m.manager_id = t.manager_id and t.captain_id = p.player_id and t.team_name = '" + comboBox_Tim1.SelectedValue +"'; ";

            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPlayer);

            label_Captain1.Text = dtPlayer.Rows[0]["player_name"].ToString();
            label_Manager1.Text = dtPlayer.Rows[0]["manager_name"].ToString();

            label_Stadium.Text = dtPlayer.Rows[0]["home_stadium"].ToString();
            label_Capacity.Text = dtPlayer.Rows[0]["capacity"].ToString();

            }
            catch (Exception)
            {

               
            }
            
        }

        private void comboBox_Tim2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            DataTable dtPlayer = new DataTable();
            sqlQuery = "select m.manager_id, m.manager_name, t.team_id, t.captain_id, p.player_name, team_name from manager m, team t, player p where m.manager_id = t.manager_id and t.captain_id = p.player_id and t.team_name = '" + comboBox_Tim2.SelectedValue.ToString() + "'; ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtPlayer);

            label_Captain2.Text = dtPlayer.Rows[0]["player_name"].ToString();
            label_Manager2.Text = dtPlayer.Rows[0]["manager_name"].ToString();
            }
            catch (Exception)
            {


            }

        }

    }
}
