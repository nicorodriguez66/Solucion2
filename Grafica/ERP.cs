using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Persistencia;
using System.Drawing.Imaging;
using System.IO;

namespace Solucion2
{
    public partial class ERP : Form
    {
        private ERPsystem mysystem;
        private Student searchedStudent;
        private Subject searchedSubject;
        private Teacher searchedTeacher;
        private Van searchedVan;
        private Activity searchedActivity;
        private Exam searchedExam;
        private Point DefaultPanelLocation;
        private Persistence dbmanager;
        public ERP()
        {
            InitializeComponent();
            DefaultPanelLocation.X = ModulesGroupBox.Width + 15;
            DefaultPanelLocation.Y = ModulesGroupBox.Location.Y;
            this.Size = new Size(600, 400);
            mysystem = new ERPsystem();
            dbmanager = new Persistence();
            empty();
            hideallgrouboxes();
        }

        private void ToDb()
        {
            foreach (Activity element in mysystem.allactivities)
            {
                dbmanager.dbActivities.Add(element);
            }

            foreach (Exam element in mysystem.allexams)
            {
                dbmanager.dbExams.Add(element);
            }
            foreach(Student element in mysystem.allstudents)
            {
                dbmanager.dbStudents.Add(element);
            }
            foreach(Teacher element in mysystem.allteachers)
            {
                dbmanager.dbTeachers.Add(element);
            }
            foreach(Subject element in mysystem.allsubjects)
            {
                dbmanager.dbSubjects.Add(element);
            }
            foreach(Van element in mysystem.allvans)
            {
                dbmanager.dbVans.Add(element);
            }
            dbmanager.SaveChanges();
            dbmanager.LoadAllDbs();
            mysystem.allexams = dbmanager.dbExams.ToList();
            mysystem.allstudents = dbmanager.dbStudents.ToList();
            mysystem.allsubjects = dbmanager.dbSubjects.ToList();
            mysystem.allteachers = dbmanager.dbTeachers.ToList();
            mysystem.allvans = dbmanager.dbVans.ToList();
            mysystem.allactivities= dbmanager.dbActivities.ToList();
        }


        private void hideallgrouboxes()
        {
            StudentPaymentListGroupBox.Visible = false;
            StudentGroupBox.Visible = false;
            TeacherGroupBox.Visible = false;
            VanGroupBox.Visible = false;
            SubjectGroupBox.Visible = false;
            ActivityGroupBox.Visible = false;
            PaymentGroupBox.Visible = false;
            StudentCreatGroupBox.Visible = false;
            StudentModifyGroupBox.Visible = false;
            StudentListGroupBox.Visible = false;
            TeacherCreateGroupBox.Visible = false;
            SubjectCreateGroupBox.Visible = false;
            VanCreateGroupBox.Visible = false;
            ActivityCreateGroupBox.Visible = false;
            SubjectListGroupBox.Visible = false;
            TeacherListGroupBox.Visible = false;
            ExamsGroupBox.Visible = false;
            ExamDeleteGroupBox.Visible = false;
            ExamCreateGroupBox.Visible = false;
            ExamEnrollGroupBox.Visible = false;
            ExamUnenrollGroupBox.Visible = false;
            ExamFilterGroupBox.Visible = false;
            ExamScoreGroupBox.Visible = false;
            ActivityStudentsEnrollGroupBox.Visible = false;
            ActivityStudentsUnEnrollGroupBox.Visible = false;
            SubjectReportGroupBox.Visible = false;
            btnSubjectSearch.Hide();
            btnSubjectSearchModify.Hide();
            btnSubjectSearchModify1.Hide();
            btnDeleteSubject.Hide();
            button29.Hide();
            btnCreateNewTeacher.Hide();
            btnTeacherDelete1.Hide();
            btnTeacherModify1.Hide();
            textBox8.Hide();
            TeacherSubjectsListBox.Hide();
            btnVanCreate.Hide();
            btnVanModify1.Hide();
            btnVanDelete1.Hide();
            btnVanSearchDelete.Hide();
            btnVanSearchModify.Hide();
            VanList.Hide();
            VanAvailableCheckBox.Hide();
            btnActivitySearchDelete.Hide();
            btnActivityDelete1.Hide();
            btnActivitySearchModify.Hide();
            btnActivityModify1.Hide();
            ActivityStudentsGroupBox.Hide();
            PaymentCreateGroupBox.Hide();
            btnPaymentSearchDelete.Hide();
            btnPaymentSearchModify.Hide();
            btnDeletePayment1.Hide();
            btnModifyPayment1.Hide();
            btnCreateNewPayment.Hide();
            btnTeacherSearchModify.Hide();
            btnTeacherSearchDelete.Hide();
            btnCreateNewTeacher.Hide();
            btnCreateNewActivity.Hide();

        }

        public void refreshdata()
        {
            StudentListBox.Items.Clear();
            foreach (Student element in mysystem.showallstudents())
            {
                StudentListBox.Items.Add(element.ToString());
            }
            SubjectStudentListBox.Items.Clear();
            foreach (Student element in mysystem.showallstudents())
            {
                SubjectStudentListBox.Items.Add(element.ToString());
            }
            StudentListBoxPayments.Items.Clear();
            foreach (Student element in mysystem.showallstudents())
            {
                StudentListBoxPayments.Items.Add(element.ToString());
            }

            ExamsToDeleteListBox.Items.Clear();
            foreach (Exam element in mysystem.showallexams())
            {
                ExamsToDeleteListBox.Items.Add(element.ToString());
            }

            ExamSubjectEnrollListBox.Items.Clear();
            foreach(Student element in mysystem.showallstudents())
            {
                ExamSubjectEnrollListBox.Items.Add(element.ToString());
            }

            ExamStudentUnEnrollListBox.Items.Clear();
            foreach(Subject element in mysystem.showallsubjects())
            {
                ExamStudentUnEnrollListBox.Items.Add(element.ToString());
            }
            
            SubjectTeachersListBox.Items.Clear();
            foreach (Teacher element in mysystem.showallteachers())
            {
                SubjectTeachersListBox.Items.Add(element.ToString());
            }
            SubjectListBox.Items.Clear();
            foreach(Subject element in mysystem.showallsubjects())
            {
                SubjectListBox.Items.Add(element.ToString());
            }
            TeacherListBox.Items.Clear();
            foreach(Teacher element in mysystem.showallteachers())
            {
                TeacherListBox.Items.Add(element.ToString());
            }
            SubjectEnrolledStudentsListBox.Items.Clear();
            SubjectEnrolledTeachersListBox.Items.Clear();

            VanAvailableListBox1.Items.Clear();
            foreach (Van element in mysystem.showAvailableVans())
            {
                VanAvailableListBox1.Items.Add(element.ToString());
            }
            ExamSubjectListBox.Items.Clear();
            foreach (Subject element in mysystem.showallsubjects())
            {
                ExamSubjectListBox.Items.Add(element.ToString());
            }

            ActivityListBox.Items.Clear();
            foreach(Activity element in mysystem.showallactivities())
            {
                ActivityListBox.Items.Add(element.ToString());
            }

            ScoreExams.Items.Clear();
            foreach (Exam element in mysystem.allexams)
            {
                ScoreExams.Items.Add(element.ToString());
            }
            ActivitiesUnEnrollListBox.Items.Clear();
            ActivitiesEnrollListBox.Items.Clear();
            foreach(Activity element in mysystem.allactivities)
            {
                ActivitiesUnEnrollListBox.Items.Add(element.ToString());
                ActivitiesEnrollListBox.Items.Add(element.ToString());
            }
            
            ActivitiesStudentsEnrollListBox.Items.Clear();
            foreach(Student element in mysystem.allstudents)
            {
                ActivitiesStudentsEnrollListBox.Items.Add(element.ToString());
            }

            FeeStudentListBox.Items.Clear();
            foreach (Student element in mysystem.allstudents)
            {
                FeeStudentListBox.Items.Add(element);
            }


            FeeYearComboBox.Items.Clear();
            for (int i = 1900; i <= DateTime.Now.Year; i++)
            {
                FeeYearComboBox.Items.Add(i.ToString());
            }

            FeeMonthComboBox.Items.Clear();
            ExamApprovalComboBox.Items.Clear();
            ScoreComboBox.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                FeeMonthComboBox.Items.Add(i.ToString());
                ExamApprovalComboBox.Items.Add(i.ToString());
                ScoreComboBox.Items.Add(i.ToString());
            }
        }

        private void BtnStudents_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            StudentGroupBox.Visible = true;
            StudentGroupBox.Location = DefaultPanelLocation;
        }

        private void btnCreateStudent_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            StudentCreatGroupBox.Visible = true;
            StudentCreatGroupBox.Location = DefaultPanelLocation;
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            StudentModifyGroupBox.Visible = true;
            StudentModifyGroupBox.Location = DefaultPanelLocation;
            StudentModifyGroupBox.Text = "Baja Alumno";
            textBox1.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button26.Hide();
            btnStudentSearchModify.Hide();
            btnStudentSearch.Show();
        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            StudentListGroupBox.Visible = true;
            StudentListGroupBox.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            StudentModifyGroupBox.Visible = true;
            StudentModifyGroupBox.Location = DefaultPanelLocation;
            textBox1.Hide();
            textBox3.Hide();
            textBox4.Hide();
            button26.Hide();
            btnStudentSearch.Hide();
            btnStudentSearchModify.Show();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            SubjectGroupBox.Visible = true;
            SubjectGroupBox.Location = DefaultPanelLocation;

        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            TeacherGroupBox.Visible = true;
            TeacherGroupBox.Location = DefaultPanelLocation;
        }

        private void btnVans_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            VanGroupBox.Visible = true;
            VanGroupBox.Location = DefaultPanelLocation;
        }

        private void btnActivity_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ActivityGroupBox.Visible = true;
            ActivityGroupBox.Location = DefaultPanelLocation;
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            PaymentGroupBox.Visible = true;
            PaymentGroupBox.Location = DefaultPanelLocation;

            btnModifyPayment.Visible = false;
            btnDeletePayment.Visible = false;
            btnListPayment.Visible = false;
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            VanCreateGroupBox.Visible = true;
            VanCreateGroupBox.Location = DefaultPanelLocation;
            VanCreateGroupBox.Text = "Alta Camioneta";
            textBox14.Show(); textBox14.Text = "";
            textBox16.Show(); textBox16.Text = "";
            VanAvailableCheckBox.Show();
            btnVanCreate.Show();
        }

        

        private void CreateStudent_Click(object sender, EventArgs e)
        {
            Student createdStudent = new Student();
            createdStudent.EditStudentName (studentNameTxtBox.Text); studentNameTxtBox.Text = "";
            createdStudent.EditStudentSurname(studentSurnameTxtBox.Text); studentSurnameTxtBox.Text = "";
            createdStudent.EditStudentNumber(Int32.Parse(studentNumberTxtBox.Text)); studentNumberTxtBox.Text = "";
            createdStudent.EditStudentidCard(Int32.Parse(studentIdCardTxtBox.Text)); studentIdCardTxtBox.Text = "";
            mysystem.showallstudents().Add(createdStudent); dbmanager.dbStudents.Add(createdStudent); dbmanager.SaveChanges();
            hideallgrouboxes();
          }

        private void btnStudentSearchModify_Click(object sender, EventArgs e)
        {
            if(textBox2.Text!="")
            {
                //searchedStudent = mysystem.searchStudent(Int32.Parse(textBox2.Text));
                int a = Int32.Parse(textBox2.Text);
                
                searchedStudent = dbmanager.dbStudents.FirstOrDefault(t=>t.number.Equals(a));
                if (searchedStudent == null)
                {
                    MessageBox.Show("No existe estudiante");
                }
                else
                {
                    textBox1.Show(); textBox1.Text = searchedStudent.GetidCard().ToString();
                    textBox3.Show(); textBox3.Text = searchedStudent.GetSurname();
                    textBox4.Show(); textBox4.Text = searchedStudent.GetName();
                    button26.Show();
                    btnStudentSearchModify.Hide();
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if(searchedStudent != null)
            {                
                searchedStudent.EditStudentName(textBox4.Text);
                searchedStudent.EditStudentSurname(textBox3.Text);
                searchedStudent.EditStudentNumber(Int32.Parse(textBox2.Text));
                searchedStudent.EditStudentidCard(Int32.Parse(textBox1.Text));                            
                dbmanager.ModifyStudent(searchedStudent);
                updatedb();
            }
            else
            {
                
            }
            hideallgrouboxes();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStudentSearch_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                searchedStudent = mysystem.searchStudent(Int32.Parse(textBox2.Text));
                if (searchedStudent == null)
                {
                    MessageBox.Show("No existe estudiante");
                }
                else
                {
                    button29.Show();
                    btnStudentSearch.Hide();
                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (searchedStudent!= null)
            {
                mysystem.DeleteStudent(searchedStudent);dbmanager.dbStudents.Remove(searchedStudent); dbmanager.SaveChanges();
                searchedStudent = null;                
            }
            else
            {

            }
            hideallgrouboxes();
        }

        private void btnSubjectList_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            SubjectListGroupBox.Visible = true;
            SubjectListGroupBox.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void btnSubjectSearch_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "")
            {
                searchedSubject= mysystem.searchSubject(Int32.Parse(textBox11.Text));
                if (searchedSubject == null)
                {
                    MessageBox.Show("No existe Materia");
                }
                else
                {
                    textBox12.Show(); textBox12.Text = searchedSubject.GetName();
                    SubjectStudentListBox.Items.Clear();
                    foreach (Student element in searchedSubject.GetStudents())
                    {
                        SubjectStudentListBox.Items.Add(element.ToString());
                    }
                    SubjectTeachersListBox.Items.Clear();
                    foreach (Teacher element in searchedSubject.GetTeachers())
                    {
                        SubjectTeachersListBox.Items.Add(element.ToString());
                    }
                    btnSubjectSearch.Hide();
                    btnDeleteSubject.Show();
                }
            }
        }

        private void btnCreateSubject_Click_1(object sender, EventArgs e)
        {
            hideallgrouboxes();
            SubjectCreateGroupBox.Visible = true;
            SubjectCreateGroupBox.Location = DefaultPanelLocation;
            SubjectStudentListBox.Show();
            SubjectTeachersListBox.Show();
            textBox12.Show();
            btnCreateNewSubject.Show();
            refreshdata();
        }

        private void btnCreateNewSubject_Click_1(object sender, EventArgs e)
        {
            Subject createdSubject = new Subject();
            createdSubject.EditSubjectCode(Int32.Parse(textBox11.Text)); textBox11.Text = "";
            createdSubject.EditSubjectName(textBox12.Text); textBox12.Text = "";
            foreach (string s1 in SubjectStudentListBox.SelectedItems)
            {
                string[] subStrings = s1.Split(' ');
                searchedStudent = mysystem.searchStudent(Int32.Parse(subStrings[2]));
                searchedStudent.subjects.Add(createdSubject);
                createdSubject.students.Add(searchedStudent);

            }
            foreach (string s2 in SubjectTeachersListBox.SelectedItems)
            {
                string[] subStrings = s2.Split(' ');
                searchedTeacher = mysystem.searchTeacher((subStrings[1]));
                searchedTeacher.subjects.Add(createdSubject);
                createdSubject.teachers.Add(searchedTeacher); 
            }

            mysystem.showallsubjects().Add(createdSubject); dbmanager.dbSubjects.Add(createdSubject); dbmanager.SaveChanges();
            hideallgrouboxes();
        }

        private void btnSubjectDelete_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            SubjectCreateGroupBox.Visible = true;
            SubjectCreateGroupBox.Location = DefaultPanelLocation;
            textBox12.Hide();
            SubjectStudentListBox.Hide();
            SubjectTeachersListBox.Hide();
            btnCreateNewSubject.Hide();
            btnSubjectSearch.Show();
            btnSubjectSearchModify.Hide();//
            btnDeleteSubject.Hide();
            SubjectCreateGroupBox.Text = "Baja Materia";
        }

        private void btnDeleteSubject_Click(object sender, EventArgs e)
        {
            if (searchedSubject != null)
            {
                mysystem.DeleteSubject(searchedSubject);dbmanager.dbSubjects.Remove(searchedSubject);dbmanager.SaveChanges();
                searchedSubject = null;
            }
            else
            {

            }
            hideallgrouboxes();
        }

        private void btnSubjectModify_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            SubjectCreateGroupBox.Visible = true;
            SubjectCreateGroupBox.Location = DefaultPanelLocation;
            textBox12.Hide();
            SubjectStudentListBox.Hide();
            SubjectTeachersListBox.Hide();
            btnCreateNewSubject.Hide();
            btnSubjectSearchModify1.Show();//
            btnSubjectSearch.Hide();
            btnDeleteSubject.Hide();
            SubjectCreateGroupBox.Text = "Modificar Materia";
        }

        private void btnSubjectSearchModify_Click(object sender, EventArgs e)
        {
            if (searchedSubject!=null)
            {
                searchedSubject.EditSubjectName(textBox12.Text);
                searchedSubject.EditSubjectCode(Int32.Parse(textBox11.Text));
                dbmanager.ModifySubject(searchedSubject);
                updatedb();
            }
            else
            {

            }
            hideallgrouboxes();
        }
        
        private void btnTeacherList_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            TeacherListGroupBox.Visible = true;
            TeacherListGroupBox.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            preload();
            hideallgrouboxes();
            refreshdata();
        }

        private void empty()
        {
            dbmanager.emptybase("Starter");
            Student dummy = new Student();
            dbmanager.SaveStudent(dummy);
            dbmanager.DeleteStudent(dummy);
        }
        private void preload()
        {
            dbmanager.preloaded();
            updatedb();
        }
        private void updatedb()
        {
            dbmanager.LoadAllDbs();
            mysystem.allactivities = dbmanager.dbActivities.ToList();
            mysystem.allexams = dbmanager.dbExams.ToList();
            mysystem.allstudents=dbmanager.dbStudents.ToList();
            mysystem.allsubjects=dbmanager.dbSubjects.ToList();
            mysystem.allteachers = dbmanager.dbTeachers.ToList();
            mysystem.allvans = dbmanager.dbVans.ToList();
        }

        private void btnSubjectSearchModify1_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "")
            {
                searchedSubject = mysystem.searchSubject(Int32.Parse(textBox11.Text));
                
                if (searchedSubject == null)
                {
                    MessageBox.Show("No existe Materia");
                }
                else
                {
                    int a = Int32.Parse(textBox11.Text);
                    searchedSubject = dbmanager.dbSubjects.First(t => t.codeId.Equals(a));
                    textBox12.Show(); textBox12.Text = searchedSubject.GetName();
                    SubjectStudentListBox.Items.Clear();
                    foreach (Student element in searchedSubject.GetStudents())
                    {
                        SubjectStudentListBox.Items.Add(element.ToString());
                    }
                    SubjectTeachersListBox.Items.Clear();
                    foreach (Teacher element in searchedSubject.GetTeachers())
                    {
                        SubjectTeachersListBox.Items.Add(element.ToString());
                    }
                    btnSubjectSearchModify1.Hide();
                    btnSubjectSearchModify.Show();
                }
            }
        }

        private void btnTeacherModify_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            TeacherCreateGroupBox.Visible = true;
            TeacherCreateGroupBox.Location = DefaultPanelLocation;
            btnTeacherSearchModify.Show();
            btnTeacherSearchDelete.Hide();
            TeacherCreateGroupBox.Text = "Modificar Docente";
            
        }

        private void btnTeacherDelete_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            TeacherCreateGroupBox.Visible = true;
            TeacherCreateGroupBox.Location = DefaultPanelLocation;
            btnTeacherSearchModify.Hide();
            btnTeacherSearchDelete.Show();
            TeacherCreateGroupBox.Text = "Baja Docente";

        }

        private void btnTeacherDelete1_Click(object sender, EventArgs e)
        {
            if (searchedTeacher != null)
            {
                mysystem.DeleteTeacher(searchedTeacher); dbmanager.dbTeachers.Remove(searchedTeacher); dbmanager.SaveChanges();
                searchedStudent = null;

            }
            else
            {

            }
            hideallgrouboxes();
        }

        private void btnTeacherSearchModify_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                searchedTeacher = mysystem.searchTeacher(textBox7.Text);
                
                if (searchedTeacher == null)
                {
                    MessageBox.Show("No existe Docente");
                }
                else
                {
                    string a = textBox7.Text;
                    searchedTeacher = dbmanager.dbTeachers.First(t => t.surname.Equals(a));
                    textBox8.Show(); textBox8.Text = searchedTeacher.GetName();
                    TeacherSubjectsListBox.Items.Clear();
                    foreach (Subject element in searchedTeacher.GetSubjects())
                    {
                        TeacherSubjectsListBox.Items.Add(element.ToString());
                    }
                    btnTeacherSearchModify.Hide();
                    btnTeacherModify1.Show();
                }
            }
        }

        private void btnTeacherSearchDelete_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                searchedTeacher = mysystem.searchTeacher(textBox7.Text);
                if (searchedTeacher == null)
                {
                    MessageBox.Show("No existe Docente");
                }
                else
                {
                    textBox8.Show(); textBox8.Text = searchedTeacher.GetName();

                    TeacherSubjectsListBox.Items.Clear();
                    foreach (Subject element in searchedTeacher.GetSubjects())
                    {
                        TeacherSubjectsListBox.Items.Add(element.ToString());
                    }
                    btnTeacherSearchDelete.Hide();
                    btnTeacherDelete1.Show();
                }
            }
        }

        private void btnTeacherModify1_Click(object sender, EventArgs e)
        {
            if (searchedTeacher != null)

            {
                searchedTeacher.EditTeacherName(textBox8.Text);
                searchedTeacher.EditTeacherSurname(textBox7.Text);
                dbmanager.ModifyTeacher(searchedTeacher);
                updatedb();
            }
            else
            {

            }
            hideallgrouboxes();
        }

        private void StudentListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StudentListBox.SelectedItem != null)
            {
                string myString = StudentListBox.SelectedItem.ToString();
                string[] subStrings = myString.Split(' ');
                searchedStudent = mysystem.searchStudent(Int32.Parse(subStrings[2]));
                StudentSubjectsList.Items.Clear();
                foreach (Subject element in searchedStudent.GetSubjects())
                {
                    StudentSubjectsList.Items.Add(element.ToString());
                }
            }            
        }

        private void SubjectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SubjectListBox.SelectedItem!=null)
            {
                string myString = SubjectListBox.SelectedItem.ToString();
                string[] subStrings = myString.Split(' ');
                searchedSubject = mysystem.searchSubject(Int32.Parse(subStrings[0]));
                SubjectEnrolledStudentsListBox.Items.Clear();
                foreach (Student element in searchedSubject.GetStudents())
                {
                    SubjectEnrolledStudentsListBox.Items.Add(element.ToString());
                }

                SubjectEnrolledTeachersListBox.Items.Clear();
                foreach (Teacher element in searchedSubject.GetTeachers())
                {
                    SubjectEnrolledTeachersListBox.Items.Add(element.ToString());
                }
            }
        }

        private void TeacherListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TeacherListBox.SelectedItem != null)
            {
                string myString = TeacherListBox.SelectedItem.ToString();
                string[] subStrings = myString.Split(' ');
                searchedTeacher = mysystem.searchTeacher(subStrings[1]);
                TeacherSubjectslistBox1.Items.Clear();
                foreach (Subject element in searchedTeacher.GetSubjects())
                {
                    TeacherSubjectslistBox1.Items.Add(element.ToString());
                }
            }
        }

        private void btnVanCreate_Click(object sender, EventArgs e)
        {
            Van createdVan = new Van();
            createdVan.EditVanCapacity(Int32.Parse(textBox14.Text)); textBox14.Text = "";
            createdVan.EditVanId(Int32.Parse(textBox13.Text)); textBox13.Text = "";
            createdVan.EditVanName(textBox16.Text); textBox16.Text = "";
            createdVan.EditVanAvailability(VanAvailableCheckBox.Checked);
            mysystem.showallvans().Add(createdVan);dbmanager.dbVans.Add(createdVan); dbmanager.SaveChanges();
            hideallgrouboxes();
        }

        private void btnVanUpdate_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            VanCreateGroupBox.Visible = true;
            VanCreateGroupBox.Location = DefaultPanelLocation;

            textBox16.Hide();
            textBox14.Hide();
            btnVanSearchModify.Show();
            
            VanCreateGroupBox.Text = "Modificar Camioneta";
        }

        private void btnVanSearchModify_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "")
            {
                searchedVan = mysystem.searchVan(Int32.Parse(textBox13.Text));
                if (searchedVan == null)
                {
                    MessageBox.Show("No existe camioneta");
                }
                else
                {
                    textBox14.Show(); textBox14.Text = searchedVan.GetCapacity().ToString();
                    textBox16.Show(); textBox16.Text = searchedVan.GetName();
                    btnVanModify1.Show();
                    btnVanSearchModify.Hide();
                }
            }
        }

        private void btnVanSearchDelete_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != "")
            {
                searchedVan = mysystem.searchVan(Int32.Parse(textBox13.Text));
                if (searchedVan == null)
                {
                    MessageBox.Show("No existe camioneta");
                }
                else
                {
                    textBox14.Show(); textBox14.Text = searchedVan.GetCapacity().ToString();
                    textBox16.Show(); textBox16.Text = searchedVan.GetName();
                    btnVanDelete1.Show();
                    btnVanSearchDelete.Hide();
                }
            }
        }

        private void btnVanModify1_Click(object sender, EventArgs e)
        {
            if (searchedVan != null)
            {
                searchedVan.EditVanCapacity(Int32.Parse(textBox14.Text)); textBox14.Text = "";
                searchedVan.EditVanId(Int32.Parse(textBox13.Text)); textBox13.Text = "";
                searchedVan.EditVanName(textBox16.Text); textBox16.Text = "";
                dbmanager.ModifyVan(searchedVan);
                updatedb();
            }
            else
            {

            }
            hideallgrouboxes();
        }

        private void btnVanDelete1_Click(object sender, EventArgs e)
        {
            if (searchedVan != null)
            {
                mysystem.DeleteVan(searchedVan); dbmanager.dbVans.Remove(searchedVan); dbmanager.SaveChanges();
                searchedVan = null;
            }
            else
            {

            }
            hideallgrouboxes();
        }

        private void btnVanDelete_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            VanCreateGroupBox.Visible = true;
            VanCreateGroupBox.Location = DefaultPanelLocation;

            textBox16.Hide();
            textBox14.Hide();
            btnVanSearchDelete.Show();

            VanCreateGroupBox.Text = "Baja Camioneta";
        }

        private void btnAvailableVans_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            VanList.Visible = true;
            VanList.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void btnCreateActivity_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ActivityCreateGroupBox.Visible = true;
            ActivityCreateGroupBox.Location = DefaultPanelLocation;
            ActivityCreateGroupBox.Text = "Alta Actividad";
            textBox20.Show();
            textBox19.Show();
            dateTimePicker1.Show();
            textBox17.Show();
            btnCreateNewActivity.Show();
        }

        private void btnCreateNewActivity_Click(object sender, EventArgs e)
        {
            Activity createdActivity = new Activity();
            createdActivity.EditActivityName(textBox20.Text);
            createdActivity.EditActivityId(Int32.Parse(textBox19.Text));
            createdActivity.EditActivityDate(dateTimePicker1.Value);
            createdActivity.EditActivityCost(Int32.Parse(textBox17.Text));
            mysystem.showallactivities().Add(createdActivity);dbmanager.dbActivities.Add(createdActivity); dbmanager.SaveChanges();
            hideallgrouboxes();
        }

        private void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ActivityCreateGroupBox.Visible = true;
            ActivityCreateGroupBox.Location = DefaultPanelLocation;

            textBox20.Hide();
            dateTimePicker1.Hide();
            textBox17.Hide();
            btnActivitySearchDelete.Show();

            ActivityCreateGroupBox.Text = "Baja Actividad";
        }

        private void btnActivityModify1_Click(object sender, EventArgs e)
        {
            if (searchedActivity != null)
            {

                searchedActivity.EditActivityName(textBox20.Text);
                searchedActivity.EditActivityId(Int32.Parse(textBox19.Text));
                searchedActivity.EditActivityDate(dateTimePicker1.Value);
                searchedActivity.EditActivityCost(Int32.Parse(textBox17.Text));
                dbmanager.ModifyActivity(searchedActivity); dbmanager.SaveChanges();
                updatedb();
            }
            else
            {

            }
            hideallgrouboxes();
        }

        private void btnModifyActivity_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ActivityCreateGroupBox.Visible = true;
            ActivityCreateGroupBox.Location = DefaultPanelLocation;

            textBox20.Hide();
            dateTimePicker1.Hide();
            textBox17.Hide();
            btnActivitySearchModify.Show();
            btnCreateNewActivity.Hide();
            
            ActivityCreateGroupBox.Text = "Modificar Actividad";
        }

        private void btnActivitySearchDelete_Click(object sender, EventArgs e)
        {
            if (textBox19.Text != "")
            {
                searchedActivity = mysystem.searchActivity(Int32.Parse(textBox19.Text));
                
                if (searchedActivity == null)
                {
                    MessageBox.Show("No existe actividad");
                }
                else
                {
                    btnActivityDelete1.Show();
                    btnActivitySearchDelete.Hide();
                }
            }
        }

        private void btnActivityDelete1_Click(object sender, EventArgs e)
        {
            if (searchedActivity != null)
            {
                mysystem.DeleteActivity(searchedActivity); dbmanager.dbActivities.Remove(searchedActivity); dbmanager.SaveChanges();
                searchedActivity = null;
            }
            else
            {

            }
            hideallgrouboxes();
        }

        private void btnActivitySearchModify_Click(object sender, EventArgs e)
        {
            if (textBox19.Text != "")
            {
                searchedActivity = mysystem.searchActivity(Int32.Parse(textBox19.Text));

                if (searchedActivity == null)
                {
                    MessageBox.Show("No existe actividad");
                }
                else
                {
                    textBox20.Show();
                    dateTimePicker1.Show();
                    textBox17.Show();
                    btnActivityModify1.Show();
                    btnActivitySearchModify.Hide();
                }
            }
        }

        private void btnActivityStudents_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ActivityStudentsGroupBox.Visible = true;
            ActivityStudentsGroupBox.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void ActivityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myString = ActivityListBox.SelectedItem.ToString();
            string[] subStrings = myString.Split(' ');
            searchedActivity = mysystem.searchActivity(Int32.Parse(subStrings[1]));
            ActivityStudentsListBox.Items.Clear();
            foreach (Student element in searchedActivity.GetStudents())
            {
                ActivityStudentsListBox.Items.Add(element.ToString());
            }
        }

        private void btnCreatePayment_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            PaymentCreateGroupBox.Visible = true;
            PaymentCreateGroupBox.Location = DefaultPanelLocation;
            PaymentCreateGroupBox.Text = "Alta Pago";
            FeeYearComboBox.Show();
            FeeMonthComboBox.Show();
            FeeCostTextBox.Show();
            refreshdata();
            btnCreateNewPayment.Show();
        }

        private void btnDeletePayment_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            PaymentCreateGroupBox.Visible = true;
            PaymentCreateGroupBox.Location = DefaultPanelLocation;
            PaymentCreateGroupBox.Text = "Baja Pago";

            FeeYearComboBox.Hide();
            FeeMonthComboBox.Hide();
            FeeCostTextBox.Hide();

            btnPaymentSearchDelete.Show();
        }

        private void btnModifyPayment_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            PaymentCreateGroupBox.Visible = true;
            PaymentCreateGroupBox.Location = DefaultPanelLocation;
            PaymentCreateGroupBox.Text = "Modificar Pago";

            FeeYearComboBox.Hide();
            FeeMonthComboBox.Hide();
            FeeCostTextBox.Hide();

            btnPaymentSearchModify.Show();
        }

        private void btnListPayment_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            PaymentCreateGroupBox.Visible = true;
            PaymentCreateGroupBox.Location = DefaultPanelLocation;
            PaymentCreateGroupBox.Text = "Listar Pago";
            refreshdata();
            
        }

        private void btnModifyPayment1_Click(object sender, EventArgs e)
        {
            btnModifyPayment1.Show();
            btnModifyPayment.Hide();
        }

        private void btnDeletePayment1_Click(object sender, EventArgs e)
        {
            btnDeletePayment1.Show();
            btnDeletePayment.Hide();
        }

        private void VanAvailableListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myString = VanAvailableListBox1.SelectedItem.ToString();
            string[] subStrings = myString.Split(' ');
            searchedVan = mysystem.searchVan(Int32.Parse(subStrings[1]));
            roadmapListBox.Items.Clear();
            foreach (Student element in mysystem.routeVan(searchedVan))
            {
                roadmapListBox.Items.Add(element.ToString());
            }
        }

        private void btnTeacherCreate_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            TeacherCreateGroupBox.Visible = true;
            TeacherCreateGroupBox.Location = DefaultPanelLocation;
            TeacherCreateGroupBox.Text = "Alta Docente";
            textBox8.Show();
            textBox7.Show();
            TeacherSubjectsListBox.Show();
            btnCreateNewTeacher.Show();
        }

        private void btnCreateNewTeacher_Click(object sender, EventArgs e)
        {
            Teacher createdTeacher = new Teacher();
            createdTeacher.EditTeacherName(textBox8.Text); textBox8.Text = "";
            createdTeacher.EditTeacherSurname(textBox7.Text); textBox7.Text = "";
            mysystem.showallteachers().Add(createdTeacher);dbmanager.dbTeachers.Add(createdTeacher); dbmanager.SaveChanges();
            hideallgrouboxes();
        }


        private void DBSave_Click(object sender, EventArgs e)
        {
            List<Van> aux = dbmanager.GetVans1(1);
            
            Student s1 = new Student();
            if (!dbmanager.SaveStudent(s1)) MessageBox.Show("La base no esta disponible");
            Teacher t1 = new Teacher { name ="Teacher2Name", surname= "Teacher2Surname" };
            if (!dbmanager.SaveTeacher(t1)) MessageBox.Show("La base no esta disponible");
            Subject sub1=new Subject { name="Subject 3"};
            dbmanager.SaveSubject(sub1);

            Exam e1 = new Exam {approval = 1, subject = sub1, date = DateTime.Now };
            dbmanager.SaveExam(e1);


            Van element = new Van();
            dbmanager.SaveVan(element);

            mysystem.allstudents = dbmanager.dbStudents.ToList();
            mysystem.allvans = dbmanager.dbVans.ToList();

            mysystem.allvans = dbmanager.GetVans();

            List<Van> loaded=mysystem.showallvans();

            MessageBox.Show("OK");                
        }

        private void btnModifyDB_Click(object sender, EventArgs e)
        {

            Fee feeToSave = new Fee() { month=1,year=2017,paid=true};
            dbmanager.SaveFee(feeToSave);
            feeToSave.month = 1;
            feeToSave.year = 3;
            feeToSave.paid = false;
            dbmanager.ModifyFee(feeToSave);
            dbmanager.dbFees.Remove(feeToSave);dbmanager.SaveChanges();
            Activity activityToSave = new Activity() { cost = 1, date = DateTime.Now, id = 1, name = "A1", paid = true };
            dbmanager.SaveActivity(activityToSave);
            activityToSave.cost = 2;
            activityToSave.date = DateTime.MaxValue;
            activityToSave.id = 2;
            activityToSave.name = "A2";
            activityToSave.paid = false;
            dbmanager.ModifyActivity(activityToSave);
            dbmanager.dbActivities.Remove(activityToSave);dbmanager.SaveChanges();



            Van VanToSave = new Van { name = "nameA", capacity = 11, available = true,eficiency=0 };

            dbmanager.SaveVan(VanToSave);
            VanToSave.available = false;
            VanToSave.capacity = 10;
            VanToSave.name = "nameB";
            dbmanager.ModifyVan(VanToSave);
            Student StudentTosave = new Student { cardId = 1, name = "A", number = 1, surname = "A1", x = 0, y = 0 };
            dbmanager.SaveStudent(StudentTosave);
            //StudentTosave.cardId = 4;
            StudentTosave.name = "B";
            StudentTosave.surname = "B2";
            StudentTosave.x = 11;
            StudentTosave.y = 11;
            StudentTosave.number = 2;
            dbmanager.ModifyStudent(StudentTosave);
            Teacher TeacherToSave = new Teacher { cardId = 1, name = "T1", surname = "T2" };
            dbmanager.SaveTeacher(TeacherToSave);
            TeacherToSave.name = "TT22";
            TeacherToSave.surname = "TT44";
            dbmanager.ModifyTeacher(TeacherToSave);
            Subject subjectToSave = new Subject { codeId = 1, name = "S1" };
            dbmanager.SaveSubject(subjectToSave);
            subjectToSave.name = "S2";
            dbmanager.ModifySubject(subjectToSave);
            


            MessageBox.Show("MODIFICADO OK");

        }

        private void btnStudentPayments_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            StudentPaymentListGroupBox.Visible = true;
            StudentPaymentListGroupBox.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void StudentListBoxPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myString = StudentListBoxPayments.SelectedItem.ToString();
            string[] subStrings = myString.Split(' ');
            searchedStudent = mysystem.searchStudent(Int32.Parse(subStrings[2]));
            PaymentsListBox.Items.Clear();
            foreach (Payment element in searchedStudent.GetPayments())
            {
                if(element.paid)
                    PaymentsListBox.Items.Add(element.ToString());
            }
        }

        private void btnExams_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ExamsGroupBox.Visible = true;
            ExamsGroupBox.Location = DefaultPanelLocation;
        }

        private void btnCreateExam1_Click(object sender, EventArgs e)
        {
            if((ExamSubjectListBox.SelectedItem!=null) &&(ExamApprovalComboBox.SelectedItem!=null))
            {
                string myStringSubject = ExamSubjectListBox.SelectedItem.ToString();
                string[] subStrings1 = myStringSubject.Split(' ');
                //searchedExam = mysystem.searchExam(Int32.Parse(subStrings1[0]));
                searchedSubject = mysystem.searchSubject(Int32.Parse(subStrings1[0]));//substring1[0] 0 = subjectid

                Exam examcreated = new Exam() { approval = Int32.Parse(ExamApprovalComboBox.SelectedItem.ToString()), date = ExamDatePicker.Value, subject = searchedSubject };
                mysystem.allexams.Add(examcreated); dbmanager.dbExams.Add(examcreated); dbmanager.SaveChanges();
            }
            
            hideallgrouboxes();
        }

        private void btnExamCreate_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ExamCreateGroupBox.Visible = true;
            ExamCreateGroupBox.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void btnExamDelete_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ExamDeleteGroupBox.Visible = true;
            ExamDeleteGroupBox.Location = DefaultPanelLocation;
            ExamDeleteGroupBox.Text = "Baja Examen";
            refreshdata();
            btnDeleteSelectedExam.Visible = true;
        }

        private void btnExamEnroll_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ExamEnrollGroupBox.Visible = true;
            ExamEnrollGroupBox.Location = DefaultPanelLocation;

            ExamStudentEnrollListBox.Items.Clear();
            foreach (Student element in mysystem.showallstudents())
            {
                ExamStudentEnrollListBox.Items.Add(element.ToString());
            }
            ExamSubjectEnrollListBox.Items.Clear();
            foreach (Exam element in mysystem.showallexams())
            {
                ExamSubjectEnrollListBox.Items.Add(element.ToString());
            }
        }

        private void btnExamUnEnroll_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ExamUnenrollGroupBox.Visible = true;
            ExamUnenrollGroupBox.Location = DefaultPanelLocation;
            ExamStudentUnEnrollListBox.Items.Clear();
            ExamSubjectUnEnrollListBox.Items.Clear();
            foreach (Exam element in mysystem.showallexams())
            {
                ExamSubjectUnEnrollListBox.Items.Add(element.ToString());
            }
        }
        
        private void btnExamStudentUnenroll_Click(object sender, EventArgs e)
        {
            if((ExamStudentUnEnrollListBox.SelectedItem!=null) &&(ExamSubjectUnEnrollListBox.SelectedItem != null))
            {
                string myStringStudent = ExamStudentUnEnrollListBox.SelectedItem.ToString();
                string[] subStrings2 = myStringStudent.Split(' ');
                searchedStudent = mysystem.searchStudent(Int32.Parse(subStrings2[2]));//substring2[2]= student number

                string myStringSubject = ExamSubjectUnEnrollListBox.SelectedItem.ToString();
                string[] subStrings1 = myStringSubject.Split(' ');
                searchedExam = mysystem.searchExam(Int32.Parse(subStrings1[0]));//substring1[0] 0 = examid
    
                searchedExam.ExamUnEnrollStudent(searchedStudent);
            }
            hideallgrouboxes();
            ExamStudentUnEnrollListBox.Items.Clear();
            ExamSubjectUnEnrollListBox.Items.Clear();
        }

        private void btnExamStudentEnroll_Click(object sender, EventArgs e)
        {
            if ((ExamSubjectEnrollListBox.SelectedItem != null) && (ExamStudentEnrollListBox.SelectedItem != null))
            {
                string myStringSubject = ExamSubjectEnrollListBox.SelectedItem.ToString();
                string[] subStrings1 = myStringSubject.Split(' ');
                searchedExam = mysystem.searchExam(Int32.Parse(subStrings1[0]));//substring1[0] 0 = examid

                string myStringStudent = ExamStudentEnrollListBox.SelectedItem.ToString();
                string[] subStrings2 = myStringStudent.Split(' ');
                searchedStudent = mysystem.searchStudent(Int32.Parse(subStrings2[2]));//substring2[2]= student number

                searchedExam.ExamEnrollStudent(searchedStudent, 0);dbmanager.SaveChanges();//ToDb();
            }
            hideallgrouboxes();
            ExamSubjectEnrollListBox.Items.Clear();
            ExamStudentEnrollListBox.Items.Clear();
        }

        private void btnDeleteSelectedExam_Click(object sender, EventArgs e)
        {
            if (ExamsToDeleteListBox.SelectedItem != null)
            {
                string myStringSubject = ExamsToDeleteListBox.SelectedItem.ToString();
                string[] subStrings1 = myStringSubject.Split(' ');
                searchedExam = mysystem.searchExam(Int32.Parse(subStrings1[0]));//substring1[0] 0 = examid
                mysystem.allexams.Remove(searchedExam);dbmanager.dbExams.Remove(searchedExam);
            }
            hideallgrouboxes();
        }

        private void btnExamList_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ExamDeleteGroupBox.Visible = true;
            ExamDeleteGroupBox.Location = DefaultPanelLocation;
            ExamDeleteGroupBox.Text = "Lista de Examenes";
            refreshdata();
            btnDeleteSelectedExam.Visible = false;
        }

        private void ExamSubjectUnEnrollListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string myStringSubject = ExamSubjectUnEnrollListBox.SelectedItem.ToString();
            string[] subStrings1 = myStringSubject.Split(' ');
            searchedExam = mysystem.searchExam(Int32.Parse(subStrings1[0]));//substring1[0] 0 = examid

            ExamStudentUnEnrollListBox.Items.Clear();
            foreach(Tuple<Student,int> element in searchedExam.enrolled)
            {
                ExamStudentUnEnrollListBox.Items.Add(element.Item1.ToString());
            }
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ExamFilterGroupBox.Visible = true;
            ExamFilterGroupBox.Location = DefaultPanelLocation;
            ExamFilterListBox.Items.Clear();
            ExamFilterStudentListBox.Items.Clear();
            ExamFilterListBox.HorizontalScrollbar = true;
        }

        private void btnExamFilter_Click(object sender, EventArgs e)
        {
            List<Exam> origin = mysystem.allexams;
            List<Exam> L1,L2,L3; L1 = origin; L2 = origin; L3 = origin;
            ExamFilterListBox.Items.Clear();
            ExamFilterStudentListBox.Items.Clear();
            sortme(origin.OrderBy(p => p.ExamId).ToList());

            if (FilterApprovalCheckBox.Checked)
            {
                L1 = origin.OrderByDescending(p => p.ExamApproved().Count).ToList();
                sortme(L1);
            }
                
            if(FilterDateCheckBox.Checked)
            {
                DateTime d1 = FilterDatePickerFrom.Value;
                DateTime d2 = FilterDatePickerTo.Value;
                L2 = L1.Where(p => p.date.CompareTo(d1) >= 0 && p.date.CompareTo(d2) <= 0).ToList();
                sortme(L2);
            }

            if (FilterSubjectCheckBox.Checked)
            {
                L3 = L2.OrderByDescending(p => p.subject.codeId).ToList();
                L3.Sort();
                sortme(L3);
            }
        }

        public void sortme(List<Exam> origin)
        {
            ExamFilterListBox.Items.Clear();
            foreach (Exam element in origin)
            {
                ExamFilterListBox.Items.Add(element.ToString());
            }
        }

        private void btnUpdateScore_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ExamScoreGroupBox.Show();
            ExamScoreGroupBox.Location = DefaultPanelLocation;
            refreshdata();

        }

        private void ScoreExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScoreExams.SelectedItem != null)
            {
                string[] subStrings1 = ScoreExams.SelectedItem.ToString().Split(' ');
                searchedExam = mysystem.searchExam(Int32.Parse(subStrings1[0]));//substring1[0] 0 = examid
                ScoreStudentsEnrolled.Items.Clear();
                foreach (Tuple<Student, int> element in searchedExam.enrolled)
                {
                    ScoreStudentsEnrolled.Items.Add(element.Item1.ToString());
                }
            }
            
        }

        private void btnScoreExam_Click(object sender, EventArgs e)
        {
            if ((ScoreExams.SelectedItem!=null)&&(ScoreStudentsEnrolled.SelectedItem!= null))
            {
                string[] subStrings = ScoreStudentsEnrolled.SelectedItem.ToString().Split(' ');
                searchedStudent = mysystem.searchStudent(Int32.Parse(subStrings[2]));
                searchedExam.qualify(searchedStudent, Int32.Parse(ScoreComboBox.SelectedItem.ToString()));
                dbmanager.SaveChanges();
                hideallgrouboxes();
            }
        }

        private void btnActivityEnroll_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ActivityStudentsEnrollGroupBox.Visible = true;
            ActivityStudentsEnrollGroupBox.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void btnActivityUnEnroll_Click(object sender, EventArgs e)
        {
            hideallgrouboxes();
            ActivityStudentsUnEnrollGroupBox.Visible = true;
            ActivityStudentsUnEnrollGroupBox.Location = DefaultPanelLocation;
            refreshdata();
        }

        private void btnActivityEnrollStudent_Click(object sender, EventArgs e)
        {
            if ((ActivitiesEnrollListBox.SelectedItem != null) && (ActivitiesStudentsEnrollListBox.SelectedItem != null))
            {

                string[] s1 = ActivitiesEnrollListBox.SelectedItem.ToString().Split(' ');
                searchedActivity = mysystem.searchActivity(Int32.Parse(s1[1]));

                string[] s2 = ActivitiesStudentsEnrollListBox.SelectedItem.ToString().Split(' ');
                searchedStudent = mysystem.searchStudent(Int32.Parse(s2[2]));

                searchedActivity.paid = true;

                searchedActivity.ActivityEnrollStudent(searchedStudent);
                
                searchedStudent.payments.Add(searchedActivity);
                dbmanager.ModifyStudent(searchedStudent);
                //dbmanager.ModifyActivity(searchedActivity);
                dbmanager.SaveChanges();
                hideallgrouboxes();
            }
        }

        private void ActivitiesUnEnrollListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActivitiesUnEnrollListBox.SelectedItem != null)
            {
                string[] subStrings = ActivitiesUnEnrollListBox.SelectedItem.ToString().Split(' ');
                searchedActivity = mysystem.searchActivity(Int32.Parse(subStrings[1]));
                ActivitiesStudentsUnEnrollListBox.Items.Clear();
                foreach (Student element in searchedActivity.students)
                {
                    ActivitiesStudentsUnEnrollListBox.Items.Add(element.ToString());
                }
            }
        }

        private void btnActivityUnEnrollStudent_Click(object sender, EventArgs e)
        {
            if ((ActivitiesUnEnrollListBox.SelectedItem != null) && (ActivitiesStudentsUnEnrollListBox.SelectedItem != null))
            {

                string[] s1 = ActivitiesUnEnrollListBox.SelectedItem.ToString().Split(' ');
                searchedActivity = mysystem.searchActivity(Int32.Parse(s1[1]));

                string[] s2 = ActivitiesStudentsUnEnrollListBox.SelectedItem.ToString().Split(' ');
                searchedStudent = mysystem.searchStudent(Int32.Parse(s2[2]));

                searchedActivity.paid = false;
                searchedActivity.ActivityUnEnrollStudent(searchedStudent);


                searchedStudent.payments.Remove(searchedActivity);
                dbmanager.ModifyStudent(searchedStudent);
                dbmanager.ModifyActivity(searchedActivity);
                dbmanager.SaveChanges();
                hideallgrouboxes();
            }
        }

        private void ExamFilterListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string myStringSubject = ExamFilterListBox.SelectedItem.ToString();
            string[] subStrings1 = myStringSubject.Split(' ');
            searchedExam = mysystem.searchExam(Int32.Parse(subStrings1[0]));//substring1[0] 0 = examid

            ExamFilterStudentListBox.Items.Clear();
            foreach (Tuple<Student, int> element in searchedExam.enrolled)
            {
                ExamFilterStudentListBox.Items.Add(element.Item1.ToString()+" Pts."+ element.Item2.ToString());
            }
        }

        

        private void btnSubjectReport_Click(object sender, EventArgs e)
        {
            

            hideallgrouboxes();
            SubjectReportGroupBox.Visible = true;
            SubjectReportGroupBox.Location = DefaultPanelLocation;


        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {


            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    //Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    Rectangle bounds = this.Bounds;
                    Bitmap printscreen = new Bitmap(bounds.Width, bounds.Height);

                    Graphics graphics = Graphics.FromImage(printscreen as Image);
                    graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    printscreen.Save(fbd.SelectedPath + @"\Reporte.jpg", ImageFormat.Jpeg);
                }
            }
        }

        private void btnCreateNewPayment_Click(object sender, EventArgs e)
        {
            if ((FeeMonthComboBox.SelectedItem != null) && (FeeYearComboBox.SelectedItem != null)&& (FeeStudentListBox.SelectedItem!=null))
            {
                int onemonth = Int32.Parse(FeeMonthComboBox.SelectedItem.ToString());
                int oneyear = Int32.Parse(FeeYearComboBox.SelectedItem.ToString());
                int onecost = Int32.Parse(FeeCostTextBox.Text);

                Fee createdFee = new Fee() { month = onemonth, year = oneyear };

                string[] subStrings = FeeStudentListBox.Text.Split(' ');
                searchedStudent = mysystem.searchStudent(Int32.Parse(subStrings[2]));

                bool pago = false;
                foreach (Payment p in searchedStudent.payments)
                {
                    string a = p.GetType().ToString();
                    if (p.GetType().ToString().Equals("Dominio.Fee"))
                    {
                        Fee f = (Fee)p;
                        if ((f.Equals(createdFee))&&(f.paid=true))
                        {
                            pago = true;
                        }
                    }        
                }
                if (!pago)
                {
                    createdFee.paid = true;
                    searchedStudent.payments.Add(createdFee);
                    dbmanager.SaveFee(createdFee); dbmanager.SaveChanges(); updatedb();
                    MessageBox.Show("Cuota pagada satisfactoriamente");
                    hideallgrouboxes();
                }
                else
                {
                    MessageBox.Show("Esta cuota ya fue pagada. Seleccione otra para pagar");
                }
            }
        }
    }
}
