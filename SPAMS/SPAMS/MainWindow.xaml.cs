using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.IO;

namespace SPAMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        public void insert()
        {
            using (SQLiteConnection cn=conn()) 
            {
                cn.Open();
                string Q = string.Format("INSERT INTO `member`(`name`,`number`,`id`,`points`,`field`)VALUES('{0}','{1}','{2}',0,'{3}')",textname.Text,textphone.Text,textid.Text,fieldtext_.Text) ;
                SQLiteCommand cmd = new SQLiteCommand(Q, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("new member inserted");




            }
        }
        public SQLiteConnection conn() {
            
            return new SQLiteConnection(@"data source=spa.db");
        }

        public void find()
        {
            listviewshow.Items.Clear();
            using (SQLiteConnection cn = conn())
            {
                cn.Open();
                string Q = string.Format("SELECT name,id,number,points,field FROM member WHERE name='{0}' OR id='{0}'", find_text.Text);
                SQLiteCommand cmd = new SQLiteCommand(Q, cn);

                SQLiteDataReader result = cmd.ExecuteReader();
                while (result.Read())  
                {
                    listviewshow.Items.Clear();
                    listviewshow.Items.Add(string.Format("name : {0}",result[0].ToString()));
                    listviewshow.Items.Add(string.Format("id : {0}", result[1].ToString()));
                    listviewshow.Items.Add(string.Format("phone : {0}", result[2].ToString()));
                    listviewshow.Items.Add(string.Format("points : {0}", result[3].ToString()));
                    listviewshow.Items.Add(string.Format("field : {0}", result[4].ToString()));
                    //contenue from here
                }




            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            insert();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            find();
        }
        public void modify()
        {
            using ( SQLiteConnection modify_conn=conn()) 
            {
                if (ckname.IsChecked == true && ckid.IsChecked == true && cknumber.IsChecked == true && ckpoints.IsChecked==true || ckid.IsChecked == true && ckname.IsChecked == true || ckid.IsChecked == true && cknumber.IsChecked == true || ckid.IsChecked == true && ckpoints.IsChecked == true || ckname.IsChecked == true && cknumber.IsChecked == true || ckname.IsChecked == true && ckpoints.IsChecked == true ||cknumber.IsChecked == true && ckpoints.IsChecked == true || cknumber.IsChecked == true && ckfield.IsChecked==true || ckname.IsChecked == true && ckfield.IsChecked == true || ckid.IsChecked == true && ckfield.IsChecked == true || ckpoints.IsChecked == true && ckfield.IsChecked == true) 
                {
                    MessageBox.Show("dont choose multi options ");
                    return;

                }
                if (ckid.IsChecked == false && ckname.IsChecked == false && cknumber.IsChecked == false && ckpoints.IsChecked==false && ckfield.IsChecked == false) 
                {
                    MessageBox.Show("you must choose option");
                    return;
                }
                if (ckname.IsChecked==true ) 
                {
                    string value_ = "name";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }
                if (ckid.IsChecked == true)
                {
                    string value_ = "id";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }
                if (ckpoints.IsChecked == true)
                {
                    string value_ = "points";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }
                if (cknumber.IsChecked == true)
                {
                    string value_ = "number";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }
                if (ckfield.IsChecked == true)
                {
                    string value_ = "field";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }









            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            modify();
        }

        private void find_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void deleteuser()
        {
            using (SQLiteConnection deleteconn=conn()) 
            {
                deleteconn.Open();
                string query = string.Format("DELETE FROM member WHERE name={0} OR id={0}", find_text.Text);
                SQLiteCommand cmd = new SQLiteCommand(query, deleteconn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("this user is outside of family now");
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            deleteuser();
        }
        public void insert_waiting()
        {
            using (SQLiteConnection cn = conn())
            {
                cn.Open();
                string Q = string.Format("INSERT INTO `member_waiting`(`name`,`number`,`id`,`points`,`field`)VALUES('{0}','{1}','{2}',0,'{3}')", textname_Copy.Text, textphone_Copy.Text, textid_Copy.Text, fieldtext__Copy.Text);
                SQLiteCommand cmd = new SQLiteCommand(Q, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("new member inserted");




            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            insert_waiting();

        }
        public void find_waiting()
        {
            listviewshow.Items.Clear();
            using (SQLiteConnection cn = conn())
            {
                cn.Open();
                string Q = string.Format("SELECT name,id,number,points,field FROM member_waiting WHERE name='{0}' OR id='{0}'", find_text.Text);
                SQLiteCommand cmd = new SQLiteCommand(Q, cn);

                SQLiteDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    listviewshow.Items.Clear();
                    listviewshow.Items.Add(string.Format("name : {0}", result[0].ToString()));
                    listviewshow.Items.Add(string.Format("id : {0}", result[1].ToString()));
                    listviewshow.Items.Add(string.Format("phone : {0}", result[2].ToString()));
                    listviewshow.Items.Add(string.Format("points : {0}", result[3].ToString()));
                    listviewshow.Items.Add(string.Format("field : {0}", result[4].ToString()));
                    //contenue from here
                }




            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            find_waiting();


        }
        public void modify_waiting()
        {
            using (SQLiteConnection modify_conn = conn())
            {
                if (ckname.IsChecked == true && ckid.IsChecked == true && cknumber.IsChecked == true && ckpoints.IsChecked == true || ckid.IsChecked == true && ckname.IsChecked == true || ckid.IsChecked == true && cknumber.IsChecked == true || ckid.IsChecked == true && ckpoints.IsChecked == true || ckname.IsChecked == true && cknumber.IsChecked == true || ckname.IsChecked == true && ckpoints.IsChecked == true || cknumber.IsChecked == true && ckpoints.IsChecked == true || cknumber.IsChecked == true && ckfield.IsChecked == true || ckname.IsChecked == true && ckfield.IsChecked == true || ckid.IsChecked == true && ckfield.IsChecked == true || ckpoints.IsChecked == true && ckfield.IsChecked == true)
                {
                    MessageBox.Show("dont choose multi options ");
                    return;

                }
                if (ckid.IsChecked == false && ckname.IsChecked == false && cknumber.IsChecked == false && ckpoints.IsChecked == false && ckfield.IsChecked == false)
                {
                    MessageBox.Show("you must choose option");
                    return;
                }
                if (ckname.IsChecked == true)
                {
                    string value_ = "name";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member_waiting` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }
                if (ckid.IsChecked == true)
                {
                    string value_ = "id";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member_waiting` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }
                if (ckpoints.IsChecked == true)
                {
                    string value_ = "points";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member_waiting` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }
                if (cknumber.IsChecked == true)
                {
                    string value_ = "number";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member_waiting` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }
                if (ckfield.IsChecked == true)
                {
                    string value_ = "field";
                    modify_conn.Open();
                    string mod_quary = string.Format("UPDATE `member_waiting` SET `{0}`='{1}' WHERE `name`='{2}' OR `id`='{2}' ", value_, value_of_change.Text, identity.Text);
                    SQLiteCommand command = new SQLiteCommand(mod_quary, modify_conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("this modify done");

                }









            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            modify_waiting();

        }
        public void deleteuser_waiting()
        {
            using (SQLiteConnection deleteconn = conn())
            {
                deleteconn.Open();
                string query = string.Format("DELETE FROM member_waiting WHERE name={0} OR id={0}", find_text.Text);
                SQLiteCommand cmd = new SQLiteCommand(query, deleteconn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("this user is outside of family waiting list  now");
            }

        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            deleteuser_waiting();
        }
    }
}
