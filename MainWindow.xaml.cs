using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students;
        public MainWindow()
        {
            students = new List<Student>();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void ShowDataGrid()
        {
            MyDataGrid.ItemsSource = null;
            MyDataGrid.ItemsSource = students;
        }
        private Student FindStudent(string id)
        {
            foreach (Student s in students)
            {
                if (id.Equals(s.StudentId))
                {
                    return s;
                }
            }
            return null;
        }

        private void btCreate_Click(object sender, RoutedEventArgs e)
        {
            var StudentId = txtStudentID.Text;
            var Fullname = txtFullname.Text;
            var Email = txtEmail.Text;
            var PhoneNumber = txtPhoneNumber.Text;
            DateTime Date = (DateTime)dtBday.SelectedDate;

            if (StudentId.Length != 0 && Fullname.Length != 0 && Email.Length != 0 && PhoneNumber.Length != 0)
            {
                bool isExist = false;
                foreach (Student s in students)
                {
                    if (StudentId.Equals(s.StudentId))
                    {
                        isExist = true;
                    }
                }
                if (!isExist)
                {
                    if (Regex.Match(Email, "^[a-zA-Z0-9._%+-]+@gmail\\.com$").Success)
                    {
                        if (Regex.Match(PhoneNumber, @"^0[0-9]{9}$").Success)
                        {
                            Student student = new Student(StudentId, Fullname, Email, PhoneNumber, Date);
                            students.Add(student);
                            ShowDataGrid();
                            MessageBox.Show("Added Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Wrong type of phone number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email must end with @gmail.com!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Student ID already exist!!!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!!!");
            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var StudentId = txtStudentID.Text;
            if (StudentId.Length != 0)
            {
                var student = FindStudent(StudentId);
                if (student != null)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        students.Remove(student);
                        ShowDataGrid();
                        MessageBox.Show("Delete successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Student not found!!!");
                }
            }
            else
            {
                MessageBox.Show("You need to enter the ID of student you want to delete!!!");
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}