using System;

namespace EntityFramework
{
    class CallAStoredProcedure
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            var projects = context.FindAllProjectsForGivenEmployee("Ruth", "Ellerbrock");

            foreach (var project in projects)
            {
                Console.WriteLine("{0} - {1} - {2}", project.Name, project.Description, project.StartDate);
            }
        }
    }
}
