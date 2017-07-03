using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Todo> todos = new List<Todo>()
            {
                new Todo { Description = "First todo", Status = Status.Waiting},

                new Todo { Description = "Second todo", Status = Status.Started},

                new Todo { Description = "Third todo", Status = Status.Completed},

                new Todo { Description = "Fourth todo", Status = Status.Deleted},
            };

            printStatus(todos);
            Console.ReadLine();
        }

        private static void printStatus (List<Todo> todos)
        {
            foreach (Todo todo in todos)
            {
                string todoInfo = todo.Description;

                switch (todo.Status)
                {
                    case Status.Waiting:
                        todoInfo += " - IN STATUS: WAITING " + Status.Waiting;
                        break;

                    case Status.Started:
                        todoInfo += " - IN STATUS: STARTED " + Status.Started;
                        break;

                    case Status.Completed:
                        todoInfo += " - IN STATUS: COMPLETED " + Status.Completed;
                        break;

                    case Status.Deleted:
                        todoInfo += " - IN STATUS: DELETED " + Status.Deleted;
                        break;

                    default:
                        todoInfo += " - IN STATUS: ERROR! DEFAULT CASE";
                        break;
                }

                Console.WriteLine(todoInfo);
            }
        }
    }

    class Todo
    {
        public string Description { get; set; }
        public Status Status { get; set; }
    }

    enum Status
    {
        Waiting,
        Started,
        Completed,
        Deleted
    }
}
