using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicJournalCourse
{
    // Inizizace třídy formuláře (zhruba řečeno hlavní)
    public partial class Form1 : Form
    {
        // Přidání prvků pro tvar
        Form form = new Form();
        Button button ;
        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        TextBox t1 = new TextBox();
        TextBox t2 = new TextBox();
        TextBox t3 = new TextBox();
        ComboBox cB ;

        Form check = new Form();
        Button t ;
        Button f ;
        Label q = new Label();
        string deleteBox = "";

        int clickCount = 0;


        // Inicializace položek, místní databáze
        List<Subject> subjects = new List<Subject>()
        {
             new Subject("Algebra pro pokročilé"),
             new Subject("OOP")
        };
        // Inicializace skupin a studentů v nich spolu s hodnocením a předměty
        List<Group> groups = new List<Group>()
        {
            new Group("211",new List<Student>()
            {
                new Student("Bogdan","Bezhchuk","211",
                    new List<Subject>()
                     {
                        new Subject("Algebra pro pokročilé",
                            new List<Grade>{ 
                                new Grade("1",new DateTime(2022,4,20)),
                                new Grade("2",new DateTime(2022,4,21))
                            }),
                        new Subject("OOP",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,4,19)),
                                new Grade("2",new DateTime(2022,4,21))
                            })
                     }),
                new Student("Vladislav","Gavriluk","211",
                     new List<Subject>()
                     {
                        new Subject("Algebra pro pokročilé",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,4,20)),
                                new Grade("2",new DateTime(2022,4,21))
                            }),
                        new Subject("OOP",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,4,19)),
                                new Grade("2",new DateTime(2022,4,25))
                            })
                     }),
                new Student("Dmitry "," Glasde","211"),
                new Student("Vadim "," Golubenko","211"),
                new Student("Andrew", "Efimenko","211")
            }),
            new Group("212",new List<Student>()
            {
                new Student("Valentine "," Zinkov","212",
                     new List<Subject>()
                     {
                        new Subject("Algebra pro pokročilé",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,4,20)),
                                new Grade("2",new DateTime(2022,4,21))
                            }),
                        new Subject("OOP",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,4,19)),
                                new Grade("2",new DateTime(2022,4,21))
                            })
                     }),
                new Student("Vladislav "," Kostyrko","212",
                     new List<Subject>()
                     {
                        new Subject("Algebra pro pokročilé",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,4,20)),
                                new Grade("2",new DateTime(2022,4,21))
                            }),
                        new Subject("OOP",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,4,15)),
                                new Grade("2",new DateTime(2022,4,16))
                            })
                     }),
                new Student("Sergei "," Astry","212",
                     new List<Subject>()
                     {
                        new Subject("Algebra pro pokročilé",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,3,18)),
                                new Grade("2",new DateTime(2022,4,20))
                            }),
                        new Subject("OOP",
                            new List<Grade>{
                                new Grade("1",new DateTime(2022,4,19)),
                                new Grade("2",new DateTime(2022,4,21))
                            })
                     }),
                new Student("Andrew "," Skred","212"),
                new Student("Denis "," Kiriyenko","212")
            })
        };

        // Metoda in -bializace formy vytváří formu a nahrazuje ikonický druh
        public Form1()
        {
            InitializeComponent();
            RefreshGrid(groups[0]);

            comboBox3.Items.Add("Přidejte kadeta");
            comboBox3.Items.Add("Smazat kadeta");
            comboBox3.Items.Add("Přidat předmět");
            comboBox3.Items.Add("Smazat předmět");



            comboBox4.Visible=false;
            dateTimePicker1.Visible=false;
            textBox1.Visible=false;
            button1.Visible=false;
            label3.Visible=false;
            label4.Visible=false;
            label5.Visible=false;




            
            

        }

        // Metoda formy brnění

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <groups.Count; i++)
            {
                comboBox1.Items.Add(groups[i].Number);
            }
            for (int i = 0; i < subjects.Count; i++)
            {
                comboBox2.Items.Add(subjects[i].Name);
            }

        }

        // Metoda odstraňování tabulek podle skupin
        void RefreshGrid(Group groups)
        {
            groups.Student.Sort();

            dataGridView1.ColumnCount=1;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = groups.Student.Count + 1;
            for (int i = 0; i < groups.Student.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[1].Value = groups.Student[i].ToString();
            }
        }
        // Metoda odstraňování tabulek podle skupin a subjektů

        void RefreshGrid(Group gr,string subjects )
        {
            gr.Student.Sort();
            dataGridView1.ColumnCount=1;
            
            List<Grade> grades = new List<Grade>();
            for (int i = 0; i < gr.Student.Count; i++)
            {

                foreach (var item in gr.Student[i].Subjects)
                {
                    if (item.Name.Equals(subjects))
                    {
                        foreach (var item2 in item.Grade)
                        {
                            int test = 0;
                            foreach (var item3 in grades)
                            {
                                if (item3.Date.Equals(item2.Date))
                                {
                                    test++;
                                }
                            }
                            if (test == 0)
                            {
                                grades.Add(item2);
                            }


                        }

                    }
                }
            }
            grades.Sort();  
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 2+grades.Count;
            dataGridView1.Columns[0].HeaderCell.Value = "id";
            dataGridView1.Columns[1].HeaderCell.Value = "JP";
            for (int i = 0; i < grades.Count; i++)
            {
                dataGridView1.Columns[2+i].HeaderCell.Value = grades[i].Date.Year+" "+grades[i].Date.Month+" "+grades[i].Date.Day;
            }
            dataGridView1.RowCount = gr.Student.Count + 1;
            for (int i = 0; i < gr.Student.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[1].Value = gr.Student[i].ToString();
                foreach (var item in gr.Student[i].Subjects)
                {
                    if (item.Name.Equals(subjects))
                    {
                        for (int l = 0; l < grades.Count; l++)
                        {                            foreach (var item2 in item.Grade)
                            {
                                if (grades[l].Date.Equals(item2.Date))
                                {
                                    dataGridView1.Rows[i].Cells[2+l].Value = item2.Count;
                                }
                            }
                        }   
                    }
                }
            }
            comboBox4.Items.Clear();
            foreach (var item in gr.Student)
            {
                comboBox4.Items.Add(item.ToString());
            }
        }

        // Chotororeye bude při změně urychlen
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            foreach (var item in groups)
            {
                if (box.SelectedItem.Equals(item.Number))
                {
                    if (comboBox2.SelectedItem!=null)
                    {
                        foreach (var item2 in subjects)
                        {
                            if (comboBox2.SelectedItem.Equals(item2.Name))
                            {
                                var i = item2.Name;
                                RefreshGrid(item, item2.Name);
                            }
                        }
                    }
                    else
                    {
                        RefreshGrid(item);
                    }
                }
            }   
        }
        // Chotororeyae je urychlena při změně objektu a spotřebitele.

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            foreach(var item in subjects)
            {
                if (box.SelectedItem.Equals(item.Name))
                {
                    if (comboBox1.SelectedItem!=null)
                    {
                        foreach (var item2 in groups)
                        {
                            if (comboBox1.SelectedItem.Equals(item2.Number))
                            {
                                var i = box.SelectedItem.ToString();
                                RefreshGrid(item2, box.SelectedItem.ToString());
                            }
                        }
                    }
                    else
                    {
                        RefreshGrid(groups[0], box.SelectedItem.ToString());
                    }
                }
            }
            comboBox4.Visible=true;
            dateTimePicker1.Visible=true;
            textBox1.Visible=true;
            button1.Visible=true;
            label3.Visible=true;
            label4.Visible=true;
            label5.Visible=true;

        }

    //  Obsazení, která činidla k poznámkám a přidá cenu ke stolu a okamžitě se z něj dostane na nový
        private void button1_Click(object sender, EventArgs e)
        {
            var cad = (string)comboBox4.SelectedItem;

            DateTime dat = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day) ;
            
            var grade = textBox1.Text;

            var subject =(string) comboBox2.SelectedItem;


            string group = "";
          
            if ((string)comboBox1.SelectedItem!=null)
            {
                group =(string)comboBox1.SelectedItem;
            }
            else
            {
                group=groups[0].Number;
            }

            Group gr = new Group();
            foreach (var item in groups)
            {
                if (item.Number.Equals(group))
                {
                    gr =item;
                    foreach (var item2 in item.Student)
                    {
                        if (item2.ToString().Equals(cad))
                        {
                            int temp0  = 0;
                            foreach (var item3 in item2.Subjects)
                            {
                                int temp = 0;

                                if (item3.Name.Equals(subject))
                                {
                                    temp0++;
                                    foreach (var item4 in item3.Grade)
                                    {
                                        
                                        if (item4.Date.Equals(dat))
                                        {
                                            temp++;
                                            item4.Count=grade;
                                        }
                                    }
                                    if (temp == 0)
                                    {
                                        item3.Grade.Add(new Grade(grade, dat));
                                    }
                                }
                            }
                            if(temp0 == 0)
                            {
                                item2.Subjects.Add(new Subject(subject,new List<Grade> { new Grade(grade, dat) }));
                            }
                            
                        }
                    }
                }
            }
            RefreshGrid(gr, subject);
            
        }

        // dvě zbytečné události, nemůžete smazat
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
           

        }

        // událost, která reaguje, když chceme něco editiro a způsobí odpovídající metodu
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            var box = (string)((ComboBox)sender).SelectedItem;

            
            
            if (box.Equals("Přidejte kadet"))
            {
                form.Controls.Clear();
                button = new Button();
                button.Text = "Přidat";
                button.Location = new Point(100, 220);
                button.Click+=addStudent;

                l1.Text = "Skupina:";
                l1.Location = new Point(50, 60);

                l2.Text="Jmeno:";
                l2.Location= new Point(50, 90);


                l3.Text="Přijmeni:";
                l3.Location= new Point(50, 120);

                t1.Location=new Point(120, 60);

                t2.Location=new Point(120, 90);

                t3.Location=new Point(120, 120);

                form.Controls.Add(t1);
                form.Controls.Add(t2);
                form.Controls.Add(t3);
                form.Controls.Add(l1);
                form.Controls.Add(l2);
                form.Controls.Add(l3);
                form.Controls.Add(button);

                form.ShowDialog();
               
            }
            else if (box.Equals("Odstraňte kadet"))
            {
                form.Controls.Clear();
                cB= new ComboBox();
                cB.Items.Clear();
                l3.Text="Vyberte kadeta:";
                l3.Size = new Size(100, 100);
                l3.Location= new Point(50, 110);
                cB.Location=new Point(110, 120);
                foreach (var item in groups)
                {
                    foreach (var student in item.Student)
                    {
                        cB.Items.Add(student.ToString());
                    }
                }
                cB.SelectedIndexChanged +=checkDeleteStudent;
                cB.DropDownStyle=ComboBoxStyle.DropDownList;

                form.Controls.Add(cB);
                form.Controls.Add(l3);


                form.ShowDialog();
            }
            else if (box.Equals("Přidejte předmět"))
            {
                form.Controls.Clear();
                button= new Button();
                button.Text = "Přidat";
                button.Location = new Point(100, 220);
                button.Click+=addSubject;



                l3.Text="Předmět:";
                l3.Location= new Point(50, 100);

                t3.Location=new Point(120, 100);


                form.Controls.Add(t3);
                form.Controls.Add(l3);
                form.Controls.Add(button);

                form.ShowDialog();
            }
            else if (box.Equals("Odstraňte předmět"))
            {
                form.Controls.Clear();
                cB=new ComboBox();
                cB.Items.Clear();
                l3.Text="Vyberte předmět:";
                l3.Location= new Point(20, 120);
                cB.Location=new Point(130, 120);
                foreach (var item in subjects)
                {
                    cB.Items.Add(item.Name);
                }
                cB.SelectedIndexChanged +=checkDeleteSubject;
                cB.DropDownStyle=ComboBoxStyle.DropDownList;

                form.Controls.Add(l3);
                form.Controls.Add(cB);


                form.ShowDialog();



            }
        }

        // Metoda pro přidání nového studenta po automatickém aktualizaci formuláře
        private void addStudent(object sender, EventArgs e)
        {
            if(!t2.Text.Equals("") || !t1.Text.Equals("")|| !t3.Text.Equals(""))
            {
                int temp = 0;
                int test = 0;

                foreach (var item in groups)
                {
                    var cad = new Student(t2.Text, t3.Text, t1.Text);
                    
                    if (item.Number.Equals(t1.Text))
                    {
                        foreach (var item2 in item.Student)
                        {
                            if (item2.ToString().Equals(cad.ToString()))
                            {
                                test++;
                            }
                        }
                        if (test == 0)
                        {


                            temp++;
                            item.Student.Add(cad);
                            comboBox4.Visible=false;
                            dateTimePicker1.Visible=false;
                            textBox1.Visible=false;
                            button1.Visible=false;
                            label3.Visible=false;
                            label4.Visible=false;
                            label5.Visible=false;
                            RefreshGrid(item);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Takový kadet již existuje");
                            break;
                        }
                    }

                }
                if (temp == 0 && test==0)
                {
                    var gr = new Group(t1.Text, new List<Student> { new Student(t2.Text, t3.Text, t1.Text) });
                    groups.Add(gr);
                    comboBox1.Items.Add(gr.Number);
                    RefreshGrid(gr);
                }
                t1.Clear();
                t2.Clear();
                t3.Clear();
                form.Close();  
            }
            else
            {

                MessageBox.Show("Vyplňte všechna pole");
            }
            
        }
        // Metoda pro přidání nové položky a poté ji automaticky přidá do sekce položky

        private void addSubject(object s,EventArgs e)
        {
            if ( !t3.Text.Equals(""))
            {
                int temp = 0;
                foreach (var item in subjects)
                {
                    if (item.Name.Equals(t3.Text))
                    {
                        temp++;
                        MessageBox.Show("Taková položka již existuje");
                        break;
                    }
                    
                }
                if (temp==0)
                {
                    subjects.Add(new Subject(t3.Text));
                    comboBox2.Items.Add(t3.Text);

                }
                t3.Clear();
                form.Visible=false;
            }
            else
            {

                MessageBox.Show("Vyplňte všechna pole");
            }
            form.Close();
        }

        // Metoda potvrzení odstranění studenta

        private void checkDeleteStudent(object s,EventArgs e)
        {
            deleteBox = (string)((ComboBox)s).SelectedItem;
            t = new Button();
            f= new Button();
            t.Location=new Point(50, 200);
            t.Text="Ano";
            t.Click +=deleteStudent;
            f.Location=new Point(150, 200);
            f.Text ="Ne";
            f.Click += checkNo;
            q.Location=new Point(100, 150);
            q.Text="Jsi si jistá?";
            check.Controls.Add(t);
            check.Controls.Add(f);
            check.Controls.Add(q);
            check.ShowDialog();
        }
        private void checkNo(object s,EventArgs e)
        {
            deleteBox="";
            check.Close();
        }
        //Metoda pro odstranění studenta po automatickém aktualizaci formuláře

        private void deleteStudent(object s,EventArgs e)
        {
            var box = deleteBox;
            

            foreach (var item in groups)
            {
                foreach (var student in item.Student)
                {
                    if (box.Equals(student.ToString()))
                    {
                        item.Student.Remove(student);
                        comboBox4.Visible=false;
                        dateTimePicker1.Visible=false;
                        textBox1.Visible=false;
                        button1.Visible=false;
                        label3.Visible=false;
                        label4.Visible=false;
                        label5.Visible=false;
                        RefreshGrid(item);

                        break;
                    }
                }
            }
            int checkGr = 0;
            foreach (var item in groups)
            {
                if (item.Student.Count==0)
                {
                    checkGr++;
                    comboBox1.Items.Clear();
                    groups.Remove(item);
                    break;
                }
            }
            if (checkGr !=0)
            {
                foreach (var item in groups)
                {
                    comboBox1.Items.Add(item.Number);
                }
            }
            check.Controls.Clear();
            check.Close();
            form.Close();
        }

        // Metoda pro potvrzení odstranění subjektu

        private void checkDeleteSubject(object s,EventArgs e)
        {
            deleteBox = (string)((ComboBox)s).SelectedItem;
            t.Location=new Point(50, 200);
            t.Text="Ano";
            t.Click +=deleteSubject;
            f.Location=new Point(150, 200);
            f.Text ="Ne";
            f.Click += checkNo;
            q.Location=new Point(100, 150);
            q.Text="Jsi si jistá?";
            check.Controls.Add(t);
            check.Controls.Add(f);
            check.Controls.Add(q);
            check.ShowDialog();
        }
        // Metoda pro odstranění subjektu po automatickém aktualizaci formuláře

        private void deleteSubject(object s, EventArgs e)
        {
            clickCount++;
            var box = deleteBox;

            foreach (var item in subjects)
            {
                if (item.Name.Equals(box))
                {
                    subjects.Remove(item);
                    break;
                }

            }
            comboBox2.Items.Clear();
            foreach (var item in subjects)
            {
                comboBox2.Items.Add(item.Name);
            }
            check.Controls.Clear();
            form.Controls.Clear();
            check.Close();
            form.Close();

        }

    }

}
