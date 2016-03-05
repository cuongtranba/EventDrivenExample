using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDrivenExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var student=new Student()
            {
                GpaScore = 80,
                Name = "Cuong"
            };

            var parent =new Parent()
            {
                Name = "Hung"
            };

            student.NotifyToParent += parent.NotifyMe;
            student.RecordGPAScore();
        }

    }

    public class Parent
    {
        public string Name { get; set; }
        
        public void NotifyMe(object sender, int e)
        {
            Console.WriteLine($"{Name} notified about the gpa {e}");
            Console.WriteLine(sender);
        }
    }

    public class Student
    {
        public event EventHandler<int> NotifyToParent;
        public string Name { get; set; }
        public int GpaScore { get; set; }

        public void RecordGPAScore()
        {
            if (NotifyToParent != null)
            {
                NotifyToParent.Invoke(this,GpaScore);
            }
        }
        
    }
}
